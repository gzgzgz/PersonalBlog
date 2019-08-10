using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projects.Models;
using Microsoft.EntityFrameworkCore;

namespace Projects.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var blogList = new AllBlogList();
            var db = new BlogDBContext(new DbContextOptions<BlogDBContext>());
            blogList.allRecords = db.Blogs.Select(x => new BlogAbstractView { 
                                                    Id = x.BlogID, 
                                                    PostDate = x.PostDate, 
                                                    Title = x.Title
                                                }).ToList();
            return View(blogList);
        }


        [HttpGet]
        public IActionResult GetArticle(int id)
        {
            var db = new BlogDBContext(new DbContextOptions<BlogDBContext>());
            var (articleTitle, article) = db.Blogs.Where(x => x.BlogID==id).Select(x => Tuple.Create(x.Title, x.BlogHtml)).FirstOrDefault();
            ViewData["article"] = article;
            ViewData["articleID"] = id;
            ViewData["articleTitle"] = articleTitle;
            return View();
        }

        public IActionResult Edit(int id)
        {
            var db = new BlogDBContext(new DbContextOptions<BlogDBContext>());
            var blogPost = db.Blogs.Where(x => x.BlogID==id).Select(x => new BlogViewModel{
                ID = x.BlogID,
                Title = x.Title,
                PostDate = x.PostDate,
                Blog = x.Blog,
                BlogHtml = x.BlogHtml,
                Permission = x.Permission
            }).FirstOrDefault();
            return View(blogPost);
        }

        public IActionResult Delete(int id)
        {
            var db = new BlogDBContext(new DbContextOptions<BlogDBContext>());
            var selectedPost = db.Blogs.Where(x => x.BlogID == id).FirstOrDefault();
            db.Blogs.Remove(selectedPost);
            db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(BlogViewModel editPost)
        {
            var db = new BlogDBContext(new DbContextOptions<BlogDBContext>());
            var articleInEdit = db.Blogs.SingleOrDefault(x => x.BlogID==editPost.ID);
            if (articleInEdit != null) {
                articleInEdit.Blog = editPost.Blog;
                articleInEdit.BlogHtml = editPost.BlogHtml;
                articleInEdit.Permission = editPost.Permission;
                articleInEdit.Title = editPost.Title;
            }
            db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogViewModel newPost)
        {
            newPost.PostDate = DateTime.Now;
            var db = new BlogDBContext(new DbContextOptions<BlogDBContext>());
            db.Blogs.Add(new BlogsEntityModel{
                Title=newPost.Title,
                PostDate = newPost.PostDate,
                Blog = newPost.Blog,
                BlogHtml = newPost.BlogHtml,
                Permission = newPost.Permission
            });
            db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SendContent([FromBody] string inContent)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
