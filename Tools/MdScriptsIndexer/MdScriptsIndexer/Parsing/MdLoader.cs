namespace MdScriptsIndexer.Parsing
{
    public static class MdLoader
    {
        public static List<string> GetAllFiles(string root)
        {
            var files = Directory.GetFiles(root, "*.xml", SearchOption.AllDirectories);
            return [.. files];
        }
    }
}
