using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u17234132_HW3.Models;
using System.IO;

namespace u17234132_HW3.Controllers
{
    public class ImageController : Controller
    {
        // public  List<FileModel> Images = new List<FileModel>();
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        // GET: Image
        public ActionResult Index()
        {
            try
            {
                //get all images from the server
                string path = Server.MapPath("~/App_Data/Media/Images/");
                string[] imges = Directory.GetFiles(path);
                if (imges.Length < 0)
                {
                    ViewBag.Message = "No images";
                }
                else
                {
                    List<FileModel> ImageList = new List<FileModel>();
                    //save images into list of imagelst
                    foreach (string IMG in imges)
                    {

                        ImageList.Add(new FileModel { FileName = Path.GetFileName(IMG) });//add images into global list
                    }
                    return View(ImageList);
                }
                return RedirectToAction("Index");//edirect to index view


            }
            catch (InvalidCastException)
            {

                throw;
            }

        }
        
        public ActionResult DownloadFile(string fileName)
        {
            
            //Build the File Path.

            string path = Server.MapPath("~/App_Data/Media/Images/") + fileName;

            

            byte[] bytes = System.IO.File.ReadAllBytes(path);

          

            return File(bytes, "application/octet-stream", fileName);

        }
        
        public ActionResult DeleteFile(string fileName)
        {
            
            try
            {
                string path = Server.MapPath("~/App_Data/Media/Images/") + fileName;
                
                
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                
                if(path.Length > 0)
                {
                    System.IO.File.Delete(path);
                }
                else
                {
                    return null;
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}