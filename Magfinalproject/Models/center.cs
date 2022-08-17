using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magfinalproject.Models
{
    public class center
    {
        public int ID { get; set; }
        [Required]
        [Remote("Check_clsname", "centers", AdditionalFields = "ID", ErrorMessage = ".هذا التصنيف موجود مسبقا")]
        [Display(Name = "نوع الخدمة")]   
        public string classname { get; set; }
        
        [Required]
        [Display(Name = "تاريخ الإنشاء")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM d, yyyy, hh:mm tt}")]

        public DateTime date { get; set; }
        [Display(Name = "إسم المستخدم")]
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }
        public virtual ICollection<college> college { get; set; }
    }
}
