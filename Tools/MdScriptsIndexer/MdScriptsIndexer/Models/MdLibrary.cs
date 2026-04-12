namespace MdScriptsIndexer.Models
{
    public class MdLibrary : ICallsProvider
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string RawXml { get; set; }
        public List<MdCall> Calls { get; set; } = [];

        public override string ToString()
        {
            return $"[LIBRARY] " + Name;
        }
    }
}
