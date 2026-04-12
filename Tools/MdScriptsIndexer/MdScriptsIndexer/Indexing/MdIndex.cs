using MdScriptsIndexer.Models;

namespace MdScriptsIndexer.Indexing
{
    public class MdIndex
    {
        public Dictionary<string, MdCue> Cues { get; set; } = [];
        public Dictionary<string, MdLibrary> Libraries { get; set; } = [];
        public HashSet<MdEdge> Edges { get; set; } = [];
    }
}
