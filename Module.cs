using Oqtane.Modules;

namespace Oqtane.Module.Sample
{
    public class Module : IModule
    {
        public string Name { get { return "Sample Module"; } }
        public string Description { get { return "Sample Module"; } }
        public string Version { get { return "0.0.1"; } }
        public string Owner { get { return ""; } }
        public string Url { get { return ""; } }
        public string Contact { get { return ""; } }
        public string License { get { return ""; } }
        public string Dependencies { get { return ""; } }
    }
}
