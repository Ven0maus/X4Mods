namespace MdScriptsIndexer.Models
{
    public class MdCue : ICallsProvider
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public string FilePath { get; set; }
        public string RawXml { get; set; }
        public string FullName => string.IsNullOrEmpty(Namespace)
            ? Name
            : $"{Namespace}.{Name}";

        public List<MdCall> Calls { get; set; } = [];

        public override string ToString()
        {
            return $"[CUE] " + FullName;
        }
    }
}
