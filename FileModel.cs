using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace u17234132_HW3.Models
{
    //filemodel
    public class FileModel
    {
        //deco
        [Display(Name ="FileName")]
        public string FileName { get; set; }
       // redio options
        public string Document { get; set; }
        [Display(Name = "Image")]
        public string Image { get; set; }
        [Display(Name = "Video")]
        public string Video { get; set; }

    }
}