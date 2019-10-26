using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oqtane.Infrastructure;
using Oqtane.Module.Blogs.Models;
using Oqtane.Module.Blogs.Repository;
using Oqtane.Shared;

namespace Oqtane.Module.Blogs.Controllers
{
    [Route("{site}/api/[controller]")]
    public class BlogController : Controller
    {
        private IBlogRepository Blogs;
        private readonly ILogManager logger;
        private int EntityId = -1; // passed as a querystring parameter for authorization and used for validation

        public BlogController(IBlogRepository Blogs, IHttpContextAccessor HttpContextAccessor, ILogManager logger)
        {
            this.Blogs = Blogs;
            this.logger = logger;
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
            try
            {
                IEnumerable<Blog> blogs = null;
                if (moduleid == EntityId)
                {
                    blogs = Blogs.GetBlogs(moduleid);
                }
                return blogs;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, this.GetType().AssemblyQualifiedName, LogFunction.Read, ex, "Get Error {Error}", ex.Message);
                throw;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = "ViewModule")]
        public Blog Get(int id, int moduleid)
        {
            try
            {
                Blog blog = null;
                if (moduleid == EntityId)
                {
                    blog = Blogs.GetBlog(id, moduleid);
                }
                return blog;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, this.GetType().AssemblyQualifiedName, LogFunction.Read, ex, "Get Error {Error}", ex.Message);
                throw;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = "EditModule")]
        public Blog Post([FromBody] Blog Blog)
        {
            try
            {
                if (ModelState.IsValid && Blog.ModuleId == EntityId)
                {
                    Blog = Blogs.AddBlog(Blog);
                    logger.Log(LogLevel.Information, this.GetType().AssemblyQualifiedName, LogFunction.Create, "Blog Added {Blog}", Blog);
                }
                return Blog;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, this.GetType().AssemblyQualifiedName, LogFunction.Create, ex, "Post Error {Error}", ex.Message);
                throw;
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "EditModule")]
        public Blog Put(int id, [FromBody] Blog Blog)
        {
            try
            {
                if (ModelState.IsValid && Blog.ModuleId == EntityId)
                {
                    Blog = Blogs.UpdateBlog(Blog);
                    logger.Log(LogLevel.Information, this.GetType().AssemblyQualifiedName, LogFunction.Update, "Blog Updated {Blog}", Blog);
                }
                return Blog;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, this.GetType().AssemblyQualifiedName, LogFunction.Update, ex, "Put Error {Error}", ex.Message);
                throw;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "EditModule")]
        public void Delete(int id, int moduleid)
        {
            try
            {
                if (moduleid == EntityId)
                {
                    Blogs.DeleteBlog(id, moduleid);
                    logger.Log(LogLevel.Information, this.GetType().AssemblyQualifiedName, LogFunction.Delete, "Blog Deleted {BlogId}", id);
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, this.GetType().AssemblyQualifiedName, LogFunction.Delete, ex, "Delete Error {Error}", ex.Message);
                throw;
            }
        }
    }
}
