namespace MdScriptsIndexer.Models
{
    public class MdFile
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public List<MdCue> Cues { get; set; } = [];
        public List<MdLibrary> Libraries { get; set; } = [];
        public List<MdMacro> Macros { get; set; } = [];

        public override string ToString()
        {
            return FileName;
        }
    }
}
