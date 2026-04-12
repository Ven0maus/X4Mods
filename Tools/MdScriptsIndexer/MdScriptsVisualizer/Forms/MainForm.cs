using MdScriptsIndexer.Indexing;
using MdScriptsIndexer.Models;
using MdScriptsIndexer.Parsing;
using System.ComponentModel;

namespace MdScriptsVisualizer
{
    public partial class MainForm : Form
    {
        public static MainForm Instance { get; private set; }

        private string _gameDirectoryPath;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string GameDirectoryPath
        {
            get => _gameDirectoryPath;
            set
            {
                _gameDirectoryPath = value;
                if (string.IsNullOrEmpty(_gameDirectoryPath))
                    ClearAllData();
                else
                    LoadAllData();
            }
        }

        private readonly List<MdFile> _mdFiles = [];
        private readonly List<object> _allScripts = [];
        private MdIndex _index;

        public MainForm()
        {
            InitializeComponent();
            Instance = this;
        }

        #region Setup
        private void ClearAllData()
        {
            MdFiles.Items.Clear();
            _mdFiles.Clear();
            _allScripts.Clear();
        }

        private void LoadAllData()
        {
            _mdFiles.Clear();
            _mdFiles.AddRange(MdLoader.GetAllFiles(GameDirectoryPath)
                .Select(MdParser.Parse)
                .OrderBy(a => a.FileName));

            _allScripts.Clear();
            _allScripts.AddRange(_mdFiles.SelectMany(a => a.Cues));
            _allScripts.AddRange(_mdFiles.SelectMany(a => a.Libraries));
            _allScripts.AddRange(_mdFiles.SelectMany(a => a.Macros));

            foreach (var file in _mdFiles)
                MdFiles.Items.Add(file);

            // Build new index
            _index = MdIndexer.Build(_mdFiles);
        }

        private void BtnSetupDirectory_Click(object sender, EventArgs e)
        {
            var sf = new SetupForm();
            sf.Show();
        }
        #endregion

        #region Displaying md content
        private void MdFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MdFiles.DataSource != null) return;
            if (MdFiles.SelectedIndex == -1)
            {
                MdScripts.DataSource = null;
                MdScripts.Items.Clear();
                return;
            }

            var mdFile = (MdFile)MdFiles.SelectedItem;
            MdScripts.Items.Clear();

            // Add all md file content
            foreach (var item in mdFile.Cues)
                MdScripts.Items.Add(item);
            foreach (var item in mdFile.Libraries)
                MdScripts.Items.Add(item);
            foreach (var item in mdFile.Macros)
                MdScripts.Items.Add(item);
        }

        private void MdScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            MdCalls.Items.Clear();
            MdUsedBy.Items.Clear();

            if (MdScripts.SelectedItem != null &&
                MdScripts.SelectedItem is ICallsProvider provider)
            {
                var calls = _index.Edges
                    .Where(e => e.Source == provider.Name);

                foreach (var call in calls)
                {
                    MdCalls.Items.Add($"{call.Target} ({call.Type})");
                }

                var usedBy = _index.Edges
                    .Where(e => e.Target == provider.Name);

                foreach (var use in usedBy)
                {
                    MdUsedBy.Items.Add($"{use.Source} ({use.Type})");
                }
            }
        }
        #endregion

        #region Search functionality
        private void UndoSearch()
        {
            MdFiles.DataSource = null;
            MdScripts.DataSource = null;
            MdFiles.Items.Clear();
            foreach (var file in _mdFiles)
                MdFiles.Items.Add(file);
        }

        private void Search()
        {
            var query = TxtSearch.Text.Trim();
            if (CmbFilterMode.SelectedIndex == -1 ||
                CmbMdValuesFilter.SelectedIndex == -1 ||
                string.IsNullOrEmpty(query))
            {
                UndoSearch();
                return;
            }

            query = query.ToLowerInvariant();

            var filterMode = (string)CmbFilterMode.SelectedItem;

            switch (filterMode)
            {
                case "Filename search":
                    SearchFileNames(query);
                    break;
                case "File content search":
                    SearchFileContent(query);
                    break;
                case "MD function search":
                    SearchScripts(query);
                    break;
            }
        }

        private void SearchFileNames(string query)
        {
            var results = _mdFiles
                .Where(f => f.FileName.Contains(query, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            MdFiles.DataSource = results;
            MdScripts.DataSource = null;
            MdScripts.Items.Clear();
        }

        private void SearchFileContent(string query)
        {
            var typeFilter = (string)CmbMdValuesFilter.SelectedItem;

            IEnumerable<object> scripts = typeFilter switch
            {
                "Cues" => _allScripts.OfType<MdCue>(),
                "Libraries" => _allScripts.OfType<MdLibrary>(),
                "Macros" => _allScripts.OfType<MdMacro>(),
                _ => _allScripts
            };

            var matchingScripts = scripts
                .Where(s =>
                {
                    var content = GetScriptContent(s);
                    return content != null &&
                           content.Contains(query, StringComparison.InvariantCultureIgnoreCase);
                })
                .ToList();

            // Get files from matching scripts
            var filePaths = matchingScripts
                .Select(GetFilePath)
                .Where(p => p != null)
                .Distinct()
                .ToHashSet();

            var matchingFiles = _mdFiles
                .Where(f => filePaths.Contains(f.Path))
                .ToList();

            MdScripts.DataSource = matchingScripts;
            MdFiles.DataSource = matchingFiles;
        }

        private static string GetFilePath(object script)
        {
            return script switch
            {
                MdCue c => c.FilePath,
                MdLibrary l => l.FilePath,
                MdMacro m => m.FilePath,
                _ => null
            };
        }

        private static string GetScriptContent(object script)
        {
            return script switch
            {
                MdCue c => c.RawXml,
                MdLibrary l => l.RawXml,
                MdMacro m => m.RawXml,
                _ => null
            };
        }

        private void SearchScripts(string query)
        {
            var typeFilter = (string)CmbMdValuesFilter.SelectedItem;

            IEnumerable<object> scripts = typeFilter switch
            {
                "Cues" => _allScripts.OfType<MdCue>(),
                "Libraries" => _allScripts.OfType<MdLibrary>(),
                "Macros" => _allScripts.OfType<MdMacro>(),
                _ => _allScripts
            };

            var results = scripts
                .Where(s =>
                {
                    return s switch
                    {
                        MdCue c => c.FullName.Contains(query, StringComparison.InvariantCultureIgnoreCase),
                        MdLibrary l => l.Name.Contains(query, StringComparison.InvariantCultureIgnoreCase),
                        MdMacro m => m.Name.Contains(query, StringComparison.InvariantCultureIgnoreCase),
                        _ => false
                    };
                })
                .ToList();

            // Extract matching file paths
            var filePaths = results
                .Select(GetFilePath)
                .Where(p => p != null)
                .Distinct()
                .ToHashSet();

            // Find corresponding MdFiles
            var matchingFiles = _mdFiles
                .Where(f => filePaths.Contains(f.Path))
                .ToList();

            // Bind both
            MdScripts.DataSource = results;
            MdFiles.DataSource = matchingFiles;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchTimer.Stop();
            SearchTimer.Start();
        }

        private void CmbFilterMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            SearchTimer.Stop();
            Search();
        }

        private void CmbMdValuesFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }
        #endregion
    }
}
