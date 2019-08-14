using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Oqtane.Module.Blogs.Models;
using Oqtane.Modules;

namespace Oqtane.Module.Blogs.Repository
{
    public class BlogRepository : IBlogRepository, IService
    {
        private readonly BlogContext db;

        public BlogRepository(BlogContext context)
        {
            db = context;
        }

        public IEnumerable<Blog> GetBlogs()
        {
            try
            {
                return db.Blog.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Blog AddBlog(Blog Blog)
        {
            try
            {
                db.Blog.Add(Blog);
                db.SaveChanges();
                return Blog;
            }
            catch
            {
                throw;
            }
        }

        public Blog UpdateBlog(Blog Blog)
        {
            try
            {
                db.Entry(Blog).State = EntityState.Modified;
                db.SaveChanges();
                return Blog;
            }
            catch
            {
                throw;
            }
        }

        public Blog GetBlog(int BlogId)
        {
            try
            {
                Blog Blog = db.Blog.Find(BlogId);
                return Blog;
            }
            catch
            {
                throw;
            }
        }

        public void DeleteBlog(int BlogId)
        {
            try
            {
                Blog Blog = db.Blog.Find(BlogId);
                db.Blog.Remove(Blog);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
