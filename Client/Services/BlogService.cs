using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using Oqtane.Services;
using Oqtane.Module.Blogs.Models;
using Oqtane.Shared;

namespace Oqtane.Module.Blogs.Services
{
    public class BlogService : ServiceBase, IBlogService
    {
        private readonly HttpClient http;
        private readonly SiteState sitestate;
        private readonly IUriHelper urihelper;

        public BlogService(HttpClient http, SiteState sitestate, IUriHelper urihelper)
        {
            this.http = http;
            this.sitestate = sitestate;
            this.urihelper = urihelper;
        }

        private string apiurl
        {
            get { return CreateApiUrl(sitestate.Alias, urihelper.GetAbsoluteUri(), "Blog"); }
        }

        public async Task<List<Blog>> GetBlogsAsync(int ModuleId)
        {
            List<Blog> blogs = await http.GetJsonAsync<List<Blog>>(apiurl);
            blogs = blogs
                .Where(item => item.ModuleId == ModuleId)
                .ToList();
            return blogs;
        }

        public async Task<Blog> GetBlogAsync(int BlogId)
        {
            return await http.GetJsonAsync<Blog>(apiurl + "/" + BlogId.ToString());
        }

        public async Task AddBlogAsync(Blog Blog)
        {
            await http.PostJsonAsync(apiurl, Blog);
        }

        public async Task UpdateBlogAsync(Blog Blog)
        {
            await http.PutJsonAsync(apiurl + "/" + Blog.BlogId.ToString(), Blog);
        }

        public async Task DeleteBlogAsync(int BlogId)
        {
            await http.DeleteAsync(apiurl + "/" + BlogId.ToString());
        }
    }
}
