using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21663841_HW03.Models; // use of FileModel
using System.IO;

namespace u21663841_HW03.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Image()
        {
            //fetches all the files in the Media/Images folder
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Images/"));
            //list to the index view of the image controller for display in the view
            List<FileModel> file = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                file.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(file);
        }
        //Action to recieve file name of image user wishes to download
        public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.

            string path = Server.MapPath("~/Media/Images/") + fileName;

            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.

            return File(bytes, "application/octet-stream", fileName);
        }
         //Action to delete image
        public ActionResult DeleteFile(string fileName)
        {
            //Delete requires reading the files and then the allocation of a file path.
            //The file is then deleted based on the identified file path.

            string path = Server.MapPath("~/Media/Images/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Files");
        }
    }
}