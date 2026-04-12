using MdScriptsIndexer.Models;
using System.Xml.Linq;

namespace MdScriptsIndexer.Parsing
{
    public static class MdParser
    {
        public static MdFile Parse(string path)
        {
            var doc = XDocument.Load(path);

            var dirName = Path.GetFileName(Path.GetDirectoryName(path));
            var fileName = Path.GetFileName(path);
            var filePath = Path.Combine(dirName, fileName);

            var file = new MdFile { FileName = fileName, Path = filePath };

            ParseCues(doc, file);
            ParseLibraries(doc, file);
            ParseMacros(doc, file);

            return file;
        }

        private static void ParseCues(XDocument doc, MdFile file)
        {
            var cues = doc.Descendants("cue");

            foreach (var cue in cues)
            {
                var model = new MdCue
                {
                    Name = cue.Attribute("name")?.Value,
                    Namespace = cue.Attribute("namespace")?.Value,
                    FilePath = file.Path,
                    RawXml = cue.ToString()
                };

                model.Calls.AddRange(ExtractCalls(cue));

                file.Cues.Add(model);
            }
        }

        private static void ParseLibraries(XDocument doc, MdFile file)
        {
            var libs = doc.Descendants("library");

            foreach (var lib in libs)
            {
                var model = new MdLibrary
                {
                    Name = lib.Attribute("name")?.Value,
                    FilePath = file.Path,
                    RawXml = lib.ToString()
                };

                model.Calls.AddRange(ExtractCalls(lib));

                file.Libraries.Add(model);
            }
        }

        private static void ParseMacros(XDocument doc, MdFile file)
        {
            var macros = doc.Descendants("macro");

            foreach (var macro in macros)
            {
                file.Macros.Add(new MdMacro
                {
                    Name = macro.Attribute("name")?.Value ?? "Unknown",
                    FilePath = file.Path,
                    RawXml = macro.ToString()
                });
            }
        }

        private static List<MdCall> ExtractCalls(XElement element)
        {
            var calls = new List<MdCall>();

            // 1. Cue triggers (most important)
            calls.AddRange(
                element.Descendants()
                    .Where(x => x.Attribute("cue") != null)
                    .Select(x => new MdCall
                    {
                        Target = x.Attribute("cue")?.Value,
                        Type = MdCallType.Cue
                    })
                    .Where(x => x.Target != null)
            );

            // 2. Macro calls
            calls.AddRange(
                element.Descendants("call")
                    .Select(x => new MdCall
                    {
                        Target = x.Attribute("macro")?.Value,
                        Type = MdCallType.Macro
                    })
                    .Where(x => x.Target != null)
            );

            // 3. run_actions references (IMPORTANT in your sample)
            calls.AddRange(
                element.Descendants("run_actions")
                    .Select(x => new MdCall
                    {
                        Target = x.Attribute("ref")?.Value,
                        Type = MdCallType.Macro
                    })
                    .Where(x => x.Target != null)
            );

            // 4. includes / includes-like refs
            calls.AddRange(
                element.Descendants()
                    .Where(x => x.Name.LocalName == "include")
                    .Select(x => new MdCall
                    {
                        Target = x.Attribute("ref")?.Value,
                        Type = MdCallType.Include
                    })
                    .Where(x => x.Target != null)
            );

            return calls;
        }
    }
}
