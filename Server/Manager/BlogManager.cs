using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using Oqtane.Module.Blogs.Models;
using Oqtane.Module.Blogs.Repository;

namespace Oqtane.Module.Blogs.Manager
{
    public class BlogManager : IInstallable, IPortable
    {
        private IBlogRepository _blogs;
        private ISqlRepository _sql;

        public BlogManager(IBlogRepository blogs, ISqlRepository sql)
        {
            _blogs = blogs;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Blog." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Blog.Uninstall.sql");
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            List<Blog> blogs = _blogs.GetBlogs(module.ModuleId).ToList();
            if (blogs != null)
            {
                content = JsonSerializer.Serialize(blogs);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
            List<Blog> blogs = null;
            if (!string.IsNullOrEmpty(content))
            {
                blogs = JsonSerializer.Deserialize<List<Blog>>(content);
            }
            if (blogs != null)
            {
                foreach (Blog blog in blogs)
                {
                    Blog _blog = new Blog();
                    _blog.ModuleId = module.ModuleId;
                    _blog.Title = blog.Title;
                    _blog.Content = blog.Content;
                    _blogs.AddBlog(_blog);
                }
            }
        }
    }
}