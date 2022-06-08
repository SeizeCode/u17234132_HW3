using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u17234132_HW3.Models;
using System.IO;

namespace u17234132_HW3.Controllers
{
    public class FileController : Controller
    {
        //create an empty list of visual objects
       //public List<FileModel> FileList = new List<FileModel>();
        // GET: File
       
        public ActionResult Index()
        {
            
            //FETCH EACH FILE IN EACH FOLDER AS A COLLECTION/ARRAY
            string[] documents = Directory.GetFiles(Server.MapPath("~/App_Data/Media/Documents/"));
            //string[] Videos = Directory.GetFiles(Server.MapPath("~/App_Data/Media/Videos/"));
            //string[] imges = Directory.GetFiles(Server.MapPath("~/App_Data/Media/Images/"));
            //Copy File names to Model collection.
            //The return below returns to the list here.

            List<FileModel> FILES = new List<FileModel>();//empty list of files

            //save videos into list of files
            //foreach (string VID in Videos)
            //{
            //    FILES.Add(new FileModel { FileName = Path.GetFileName(VID) });//add videos into global list
            //}
            ////save images into list of files
            //foreach (string IMG in imges)
            //{
            //    FILES.Add(new FileModel { FileName = Path.GetFileName(IMG) });//add images into global list
            //}
            //save documents into list of files

            foreach (string DOCS in documents)//add each file from the list into the folder path
            {
                FILES.Add(new FileModel { FileName = Path.GetFileName(DOCS) });
            }
            return View(FILES);//return the view with the list of files
        }

        public ActionResult DownloadFile(string fileName)//PASS RARAMETER REPRESENT A FILE
        {
            
            //access the file in its own folder
            string path = Server.MapPath("~/App_Data/Media/Documents/") + fileName;


            byte[] bytes = System.IO.File.ReadAllBytes(path);//read the file


            return File(bytes, "application/octet-stream", fileName);//return and download the file into the computer
            
        }
     
        // GET: File/Delete/5
        public ActionResult DeleteFile(string fileName)//PASS RARAMETER REPRESENT A FILE
        {
            
            try
            {
                //access the file in its own folder
                string path = Server.MapPath("~/App_Data/Media/Documents/") + fileName;
            
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                //s  System.IO.File.Delete(path);
                if (path.Length > 0)//test if there is a  file
                {
                    System.IO.File.Delete(path);//read the file and DELETE it
                }
                else
                {
                    return null;//return null if there is no file
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
