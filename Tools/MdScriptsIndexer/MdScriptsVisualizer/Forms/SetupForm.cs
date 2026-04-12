namespace MdScriptsVisualizer
{
    public partial class SetupForm : Form
    {
        public SetupForm()
        {
            InitializeComponent();
        }

        private void BtnSelectDirectory_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog
            {
                Description = "Select your X4 unpacked game folder",
                UseDescriptionForTitle = true,
                ShowNewFolderButton = false
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    TxtDirectoryPath.Text = dialog.SelectedPath;
                    BtnConfirm.Enabled = true;
                }
                else
                {
                    TxtDirectoryPath.Text = string.Empty;
                    BtnConfirm.Enabled = false;
                }
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (Path.GetFileName(TxtDirectoryPath.Text) != "md")
            {
                MessageBox.Show("The selected path is not a valid md file location.");
                return;
            }

            MainForm.Instance.GameDirectoryPath = TxtDirectoryPath.Text;
            Close();
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MainForm.Instance.GameDirectoryPath))
                TxtDirectoryPath.Text = MainForm.Instance.GameDirectoryPath;
        }
    }
}
