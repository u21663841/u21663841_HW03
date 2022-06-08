using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21663841_HW03.Models;

namespace u21663841_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, string UploadType) //INSIDE HOME
        {
            // Verify that the user selected a file
            // Not null and has a length
            if (files != null && files.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(files.FileName);
                if(UploadType == "document")
                {
                    //store file in the /Media/Documents
                  var path = Path.Combine(Server.MapPath("~/Media/Documents"), fileName);
                    //the chosen file path for saving
                  files.SaveAs(path);
                }
                else if(UploadType == "image")
                {
                    //store file in the /Media/Images
                    var path = Path.Combine(Server.MapPath("~/Media/Images"), fileName);
                    //the chosen file path for saving
                    files.SaveAs(path);
                }
                else if(UploadType == "videos")
                {
                    //store file in the /Media/Videos
                    var path = Path.Combine(Server.MapPath("~/Media/Videos"), fileName);
                    //the chosen file path for saving
                    files.SaveAs(path);
                }
               }
             return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            return View();
        }
    }
}