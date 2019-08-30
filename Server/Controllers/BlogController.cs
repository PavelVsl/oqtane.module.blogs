using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oqtane.Module.Blogs.Models;
using Oqtane.Module.Blogs.Repository;

namespace Oqtane.Module.Blogs.Controllers
{
    [Route("{site}/api/[controller]")]
    public class BlogController : Controller
    {
        private IBlogRepository Blogs;
        private int EntityId = -1; // passed as a querystring parameter for authorization and used for validation

        public BlogController(IBlogRepository Blogs, IHttpContextAccessor HttpContextAccessor)
        {
            this.Blogs = Blogs;
            if (HttpContextAccessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                EntityId = int.Parse(HttpContextAccessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = "ViewModule")]
        public IEnumerable<Blog> Get(int moduleid)
        {
            IEnumerable<Blog> blogs = null;
            if (moduleid == EntityId)
            {
                blogs = Blogs.GetBlogs(moduleid);
            }
            return blogs;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = "ViewModule")]
        public Blog Get(int id, int moduleid)
        {
            Blog blog = null;
            if (moduleid == EntityId)
            {
                blog = Blogs.GetBlog(id, moduleid);
            }
            return blog;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = "EditModule")]
        public Blog Post([FromBody] Blog Blog)
        {
            if (ModelState.IsValid && Blog.ModuleId == EntityId)
            {
                Blog = Blogs.AddBlog(Blog);
            }
            return Blog;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "EditModule")]
        public Blog Put(int id, [FromBody] Blog Blog)
        {
            if (ModelState.IsValid && Blog.ModuleId == EntityId)
            {
                Blog = Blogs.UpdateBlog(Blog);
            }
            return Blog; 
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "EditModule")]
        public void Delete(int id, int moduleid)
        {
            if (moduleid == EntityId)
            {
                Blogs.DeleteBlog(id, moduleid);
            }
        }
    }
}
