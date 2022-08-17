using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magfinalproject.Models
{
    public class Carsual
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "العنوان")]
        public string describtion { get; set; }

        [Display(Name = "المحتوى")]
        [Required]
        [AllowHtml]
        public string contenet { get; set; }

        [Display(Name = "وصف ال (Alt)")]
        public string alt { get; set; }

        [Required]
        [Display(Name = "تاريخ الإنشاء")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM d, yyyy, hh:mm tt}")]

        public DateTime date { get; set; }
        [Display(Name = "إسم المستخدم")]
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }

        [Display(Name = "الصورة")]
        public string pic { get; set; }
    }
}