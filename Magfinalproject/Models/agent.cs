using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Magfinalproject.Models
{
    public class agent
    {
        public int id { get; set; }
        [Display(Name = "اسم نقطة الخدمة")]
        public string PointName { get; set; }
       
        [Display(Name = "المنطقة/العنوان")]
        public string regon { get; set; }

        [Display(Name = "تاريخ التعديل")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM d, yyyy, hh:mm tt}")]
        public DateTime date { get; set; }
        [Display(Name = "إسم المستخدم")]
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}