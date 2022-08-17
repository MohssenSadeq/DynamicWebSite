using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magfinalproject.Models
{
    public class cardinfo
    {
        public int ID { get; set; }

        [Display(Name = "تصنيف أساسي")]
        public int CategoryID { get; set; }
        public virtual Categorie Category { get; set; }      
        [Required]
        [StringLength(59,ErrorMessage ="يجب أن يكون العنوان أقل من 60 حرف")]
        [Display(Name = "العنوان")]
        public string title { get; set; }
        [Required]
        [Display(Name = "المحتوى")]
        [AllowHtml]
        public string describtion { get; set; }
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