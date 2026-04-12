using MdScriptsIndexer.Models;

namespace MdScriptsIndexer.Indexing
{
    public static class MdIndexer
    {
        public static MdIndex Build(List<MdFile> files)
        {
            var index = new MdIndex();

            foreach (var file in files)
            {
                foreach (var cue in file.Cues)
                {
                    index.Cues[cue.FullName] = cue;
                    RegisterCalls(index, cue.FullName, cue.Calls);
                }

                foreach (var lib in file.Libraries)
                {
                    index.Libraries[lib.Name] = lib;
                    RegisterCalls(index, lib.Name, lib.Calls);
                }
            }

            return index;
        }

        private static void RegisterCalls(MdIndex index, string source, List<MdCall> calls)
        {
            foreach (var call in calls)
            {
                index.Edges.Add(new MdEdge
                {
                    Source = source,
                    Target = call.Target,
                    Type = call.Type
                });
            }
        }
    }
}
