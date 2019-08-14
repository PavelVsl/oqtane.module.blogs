using System;
using Oqtane.Models;

namespace Oqtane.Module.Blogs.Models
{
    public class Blog : IAuditable
    {
        public int BlogId { get; set; }
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
