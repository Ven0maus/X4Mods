namespace MdScriptsIndexer.Models
{
    public class MdEdge
    {
        public string Source { get; set; }
        public string Target { get; set; }
        public MdCallType Type { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is not MdEdge other) return false;

            return Source == other.Source
                && Target == other.Target
                && Type == other.Type;
        }

        public override int GetHashCode()
            => HashCode.Combine(Source, Target, Type);
    }
}
