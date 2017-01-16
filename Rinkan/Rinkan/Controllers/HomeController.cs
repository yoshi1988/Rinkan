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

        public ActionResult Index()
        {
            DbSet<Posts> list = this.masterEntity.Posts.OrderByDescending<>
               return View(list.ToList());
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

        //public ActionResult Update(int? id, string title, string body, DateTime datetime, string tags)
        // {

        //}
    }
}