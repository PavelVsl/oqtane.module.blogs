using Oqtane.Modules;

namespace Oqtane.Module.Blogs.Client
{
    public class Module : IModule
    {
        public string Name { get { return "Blog"; } }
        public string Description { get { return "Blog"; } }
        public string Version { get { return "0.0.1"; } }
        public string Owner { get { return ""; } }
        public string Url { get { return ""; } }
        public string Contact { get { return ""; } }
        public string License { get { return ""; } }
        public string Dependencies { get { return ""; } }
    }
}
