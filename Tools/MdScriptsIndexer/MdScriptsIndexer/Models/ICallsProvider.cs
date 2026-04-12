namespace MdScriptsIndexer.Models
{
    public interface ICallsProvider
    {
        string Name { get; }
        List<MdCall> Calls { get; }
    }
}
