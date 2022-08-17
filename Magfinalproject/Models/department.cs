using Magfinalproject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magfinalproject.Models
{
    public class department
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "اسم الفرع")]
        public string name { get; set; }

        [Display(Name = "الصورة ")]
        public string photo { get; set; }
        [Required]
        [Display(Name = "نبذة عن الفرع")]
        [AllowHtml]
        public string about { get; set; }
       
        public int collegeid { get; set; }
      
        [Display(Name = "إسم المستخدم")]
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }


        public Mohsen dgreeid { get; set; }
        public virtual college college { get; set; }
        public virtual ICollection<Thesis> thesis { get; set; }


    }

}
