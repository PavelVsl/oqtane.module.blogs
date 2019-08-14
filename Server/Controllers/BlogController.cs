using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Oqtane.Module.Blogs.Models;
using Oqtane.Module.Blogs.Repository;

namespace Oqtane.Module.Blogs.Controllers
{
    [Route("{site}/api/[controller]")]
    public class BlogController : Controller
    {
        private IBlogRepository blog;

        public BlogController(IBlogRepository Blog)
        {
            blog = Blog;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return blog.GetBlogs();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Blog Get(int id)
        {
            return blog.GetBlog(id);
        }

        // POST api/<controller>
        [HttpPost]
        public Blog Post([FromBody] Blog Blog)
        {
            if (ModelState.IsValid)
            {
                Blog = blog.AddBlog(Blog);
            }
            return Blog;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public Blog Put(int id, [FromBody] Blog Blog)
        {
            if (ModelState.IsValid)
            {
                Blog = blog.UpdateBlog(Blog);
            }
            return Blog; 
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            blog.DeleteBlog(id);
        }
    }
}
