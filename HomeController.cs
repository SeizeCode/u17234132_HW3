using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u17234132_HW3.Models;//using Model created in \u17234132_HW3\Models\FileModel.cs
using System.IO;/// <summary>
//allow access,creation and control of files on the computer
/// </summary>


namespace u17234132_HW3.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        [HttpGet]
        public ActionResult Index()//this index controller randers the Main HomePage of the system
        {
            return View();
        }

        [HttpPost]//This handles the Posted data from the view
        public ActionResult Index(HttpPostedFileBase files)//pass paramater ==pass file from View to THIS controler
        {
            //RADIO buttons
           var videos = Request["Video_rad"];//video radio button
            var docs = Request["document_rad"];//documents radio button
            var imgs = Request["Image_rad"];//images radio button
          
            if (files != null) //test if there is a file posted
            {
                //if there is a file...do the below...
                //first,get the name of the file
                var fileName = Path.GetFileName(files.FileName);

                //create local path for each type of file:images,documents and videos
                var documentspath = Path.Combine(Server.MapPath("~/App_Data/Media/Documents/"), fileName);
                var imagespath = Path.Combine(Server.MapPath("~/App_Data/Media/Images/"), fileName);
                var Videospath = Path.Combine(Server.MapPath("~/App_Data/Media/Videos/"), fileName);
                var mediapath = Path.Combine(Server.MapPath("~/App_Data/Media/"), fileName);//default folder

                // The chosen path for saving
                //SAVE EACH FILE IN THE CORRECT FOLDER :Eg,all images saved in image folder on the computer
                if (videos != null)
                {
                    files.SaveAs(Videospath);
                    ViewBag.Message = "File successfully uploaded!";
                }
                else if (docs != null)
                {
                    files.SaveAs(documentspath);
                }
                else if (imgs != null)
                {
                    files.SaveAs(imagespath);
                    ViewBag.img = imgs;
                }
                else 
                {
                    files.SaveAs(mediapath);
                }
               
                ViewBag.Message = "File successfully uploaded!";
            }
            
            // redirect back to the index action to show the form once again

            return RedirectToAction("Index");
            
        }
        public ActionResult About()
        {
            return View();//return the About Page
        }
    }
}