using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magfinalproject.Models
{
    public class contacts
    {
        public int id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "إيميل التحكم في الموقع")]
        public string control_email { get; set; }
     
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة السر")]
        public string Password_control { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "إيميل التواصل مع الوكيل")]
        public string contact_email  { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة السر")]
        public string Password_contact { get; set; }
       
      
        [Phone]
        [Display(Name = "التلفون الأرضي")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="إدخل رقم التلفون بالصيغة الصحيحة")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(###)-###-####}")]      
        public string telephone { get; set; }

        [Phone]
        [Display(Name = "المحمول")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "إدخل رقم التلفون بالصيغة الصحيحة")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(###)-###-####}")]
        public string phone_num { get; set; }
        
        [Display(Name = "تاريخ التعديل")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM d, yyyy, hh:mm tt}")]
        public DateTime date { get; set; }
        [Display(Name = "إسم المستخدم")]
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }
    }

}