using System.Collections.Generic;
using Oqtane.Module.Blogs.Models;

namespace Oqtane.Module.Blogs.Repository
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetBlogs();
        Blog AddBlog(Blog Blog);
        Blog UpdateBlog(Blog Blog);
        Blog GetBlog(int BlogId);
        void DeleteBlog(int BlogId);
    }
}
