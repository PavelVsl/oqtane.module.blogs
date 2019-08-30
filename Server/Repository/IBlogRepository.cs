using System.Collections.Generic;
using Oqtane.Module.Blogs.Models;

namespace Oqtane.Module.Blogs.Repository
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetBlogs(int ModuleId);
        Blog AddBlog(Blog Blog);
        Blog UpdateBlog(Blog Blog);
        Blog GetBlog(int BlogId, int ModuleId);
        void DeleteBlog(int BlogId, int ModuleId);
    }
}
