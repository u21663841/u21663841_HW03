using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using u21663841_HW03.Models;
using System.IO;
using System.Web.Mvc;



namespace u21663841_HW03.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Files()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Documents/"));

            List<FileModel> file = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                file.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(file);


        }
        public FileResult DownloadFile(string fileName) 
        {
            //Build the File Path.

            string path = Server.MapPath("~/Media/Documents/") + fileName;

            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.

            return File(bytes, "application/octet-stream", fileName);
        }
        public ActionResult DeleteFile(string fileName)
        {
            //Delete requires reading the files and then the allocation of a file path.
            //The file is then deleted based on the identified file path.

            string path = Server.MapPath("~/Media/Documents/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Files");
        }
    }
}