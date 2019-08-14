using System.Collections.Generic;
using System.Threading.Tasks;
using Oqtane.Module.Blogs.Models;

namespace Oqtane.Module.Blogs.Services
{
    public interface IBlogService 
    {
        Task<List<Blog>> GetBlogsAsync(int ModuleId);

        Task<Blog> GetBlogAsync(int BlogId);

        Task AddBlogAsync(Blog Blog);

        Task UpdateBlogAsync(Blog Blog);

        Task DeleteBlogAsync(int BlogId);
    }
}
