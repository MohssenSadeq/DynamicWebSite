using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magfinalproject.Models
{
    public class social
    {
        public int id { get; set; }
        [Display(Name = "موقع التواصل الأجتماعي")]
        public socials social_name { get; set; }
        [Required]
        [Display(Name = "رابط الموقع")]
        public string link { get; set; }
     
        [Display(Name = "الأيقونة")]
        public string icon { get; set; }
        [Display(Name = "تاريخ التعديل")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM d, yyyy, hh:mm tt}")]
        public DateTime date { get; set; }
        [Display(Name = "إسم المستخدم")]
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }

    }
}
public enum socials
{
    فيسبوك, تويتر, إنستجرام, لينكن, جوجل_بلس, بينترست, جيت_هب, تمبلر, فليكر
}