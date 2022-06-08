using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u17234132_HW3.Models;
using System.IO;

namespace u17234132_HW3.Controllers
{
    public class VideoController : Controller
    {
        //list of videos
        public  List<FileModel> Videos=new List<FileModel>();
        // GET: Video
        public ActionResult Index()
        {
            string path = Server.MapPath("~/App_Data/Media/Videos/");
            string [] vids=Directory.GetFiles(path);
            //add each object to the list
            foreach(string vid in vids)
            {
                Videos.Add(new FileModel { FileName = Path.GetFileName(vid) });
            }
            return View(Videos);//pass the list of videos to the view
                                // return RedirectToAction("Index",Videos);
        }
        public ActionResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/App_Data/Media/Videos/") + fileName;



            byte[] bytes = System.IO.File.ReadAllBytes(path);



            return File(bytes, "application/octet-stream", fileName);
            //return View();  
        }
        public ActionResult DeleteFile(string fileName)
        {
            string path = Server.MapPath("~/App_Data/Media/Videos/") + fileName;


            byte[] bytes = System.IO.File.ReadAllBytes(path);

            if (path.Length > 0)
            {
                System.IO.File.Delete(path);
            }
            else
            {
                return null;
            }
            return RedirectToAction("Index");
        }
    }
}