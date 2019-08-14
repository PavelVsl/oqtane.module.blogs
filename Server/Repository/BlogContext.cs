using Microsoft.EntityFrameworkCore;
using Oqtane.Module.Blogs.Models;
using Oqtane.Repository;
using Oqtane.Modules;
using Microsoft.AspNetCore.Http;

namespace Oqtane.Module.Blogs.Repository
{
    public class BlogContext : DBContextBase, IService
    {
        public virtual DbSet<Blog> Blog { get; set; }

        public BlogContext(ITenantResolver TenantResolver, IHttpContextAccessor accessor) : base(TenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
