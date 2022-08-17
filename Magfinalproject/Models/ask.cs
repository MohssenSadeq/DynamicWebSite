using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magfinalproject.Models
{
    public class ask
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "الإسم الثلاثي*")]
        public string fname { get; set; }
        [Required]
        [Display(Name = " إسم الوكيل / العميل*")]
        public string lname { get; set; }
        [Display(Name = "تاريخ التعديل")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM d, yyyy, hh:mm tt}")]
        public DateTime date { get; set; }     
        [Required]
        [Display(Name = "البريد الألكتروني*")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "الرسالة*")]
        [StringLength(59, ErrorMessage = "يجب أن يكون العنوان أقل من 60 حرف")]

        public string subject { get; set; }
        [Required]
        [Display(Name = "السؤال*")]
        [StringLength(59, ErrorMessage = "يجب أن يكون العنوان أقل من 60 حرف")]

        public string question { get; set; }
        [Phone]
        [Display(Name = "المحمول")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "إدخل رقم التلفون بالصيغة الصحيحة")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(###)-###-####}")]
        public string phone_num { get; set; }
        [Display(Name = "الإجابة")]
        public string answer { get; set; }
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }
        [Required]
        [Display(Name = "الأولوية")]
        public float priority { get; set; }
    }
}