using MikeCressey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MikeCressey.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Music()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Videos()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Photos()
        {
            return View();
        }

        public ActionResult FreeStuff()
        {
            ViewBag.Title = "Free Music";
            /*if (!User.Identity.IsAuthenticated)
                return new HttpUnauthorizedResult();*/

            return View();
        }

        [AllowAnonymous]
        public ActionResult Studio()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Title = "Bio";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            ViewBag.Message = "Please email or call me (leave a message) if you want to book me for a music performance or schedule studio services";

            return View();
        }
    }
}