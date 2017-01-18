using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rinkan.Models;
using System.Data.Entity;


namespace Rinkan.Controllers
{
    public class HomeController : Controller
    {
        private Rinkan.Models.Posts postBlob = new Posts();
        private masterEntities2 masterEntity = new masterEntities2();

        private const int PostsPerpage = 5;

        public ActionResult Index(int? id)
        {
            int pageNumber = id ?? 0;
            //IEnumerable<Posts> posts = this.masterEntity.Posts.Where(x => x.Datetime < DateTime.Now).Skip(pageNumber * PostsPerpage).Take(PostsPerpage + 1);
            IEnumerable<Posts> posts = this.masterEntity.Posts.Where(x => x.Datetime < DateTime.Now).OrderBy(x => x.Datetime).Skip(pageNumber * PostsPerpage).Take(PostsPerpage + 1);

            ViewBag.IsPreviousLinkVisible = pageNumber > 0;
            ViewBag.IsNextLinkVisible = posts.Count() > PostsPerpage;
            ViewBag.PageNumber = pageNumber;

            return View(posts.Take(PostsPerpage));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search()
        {
            ViewBag.Message = "Research Page";

            return View();
        }

        public ActionResult Update(int? id, string title, string body, DateTime datetime, string tags)
        {
            if (!isAdmin)
            {
                return RedirectToAction("Index");
            }

            Posts post = GetPost(id);
            post.Title = title;
            post.Body = body;
            post.Datetime = datetime;


            //            tags = tags ?? string.Empty;
            //            string[] tagNames = tags.Split(new char[] { '' }, StringSplitOptions.RemoveEmptyEntries);
            // foreach (string tagName in tagNames)
            // {
            //TODO Tagシステムの追加
            // post.PostsTags.Tags.PostsTags(GET)

            //post.po
            //   this.masterEntity.Tags(GetTag(tagName));
            //}

            if (!id.HasValue)
            {
                this.masterEntity.Posts.Add(post);
            }
            this.masterEntity.SaveChanges();

            return View("Details", new { id = post.ID});
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Posts post = GetPost(id);
            //foreach(PostsTags postTag in post.PostsTags)
            //{

            //        }
            ViewBag.Tags = "TODO";
            return View(post);
        }

        //[HttpPost]
        //[ActionName("Index")]
        //public ActionResult EditPost(Posts post)
        //{
        //   // int id = post.ID;
        //    int title = post.Title;

        //    //Posts post = GetPost(id);
        //    //foreach(PostsTags postTag in post.PostsTags)
        //    //{

        //    //        }
        //    ViewBag.Tags = "TODO";
        //    return View(post);
        //}

        private Tags GetTag(string tagName)
        {
            return this.masterEntity.Tags.Where(x => x.Name == tagName).FirstOrDefault() ?? new Tags() { Name = tagName }; 
        }

        private Posts GetPost(int? id)
        {
            return id.HasValue ?  this.masterEntity.Posts.Where(x => x.ID == id).First() : new Rinkan.Models.Posts () { ID = -1 };
        }

        public bool isAdmin { get { return true; } }
    }
}