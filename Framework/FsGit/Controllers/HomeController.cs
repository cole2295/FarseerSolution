using System;
using System.Web.Mvc;
using FS.Utils.Common;
using FS.Utils.Page;

namespace FsGit.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            ViewBag.Title = "首页";
            
            return View(); 
        }
    }
}