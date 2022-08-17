using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magfinalproject.Models
{
    public class Request_to_edit
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "الدرجة العلمية")]
        public Mohsen dgreeid { get; set; }

        public int staffid { get; set; }
        public virtual staff staff { get; set; }    
        [Required]
        [StringLength(59, ErrorMessage = "يجب أن يكون الأسم أقل من 50 حرف")]
        [Display(Name = "الأسم الثلاثي")]
        public string fullName { get; set; }
        [Required]
        [Display(Name = "البريد الألكتروني")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "رقم التلفون")]
        [Phone]
        public string phoneNum { get; set; }

        [Required]
        [Display(Name = "تاريخ الطلب")]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString = "{0:MMMM d, yyyy, hh:mm tt}")]
        public DateTime date { get; set; }
    
        [Display(Name = "صورة البطاقة الشخصية")]
        public string pic { get; set; }
       
        [Display(Name = "صورة الشهادة الجامعية")]
        public string picuni { get; set; }
        [Display(Name = "الحالة")]
        public bool states { get; set; }
        [Display(Name = "إسم المستخدم")]
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }

    }
}