using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magfinalproject.Models
{
    public class staff
    {
        public int id { get; set; }

        

        [Display(Name = "الأسم")]
        public string name { get; set; }
        [Display(Name = "الأسم الأول بالأنجليزي")]
        public string name_en  { get; set; }
        [Display(Name = "تاريخ التعديل")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM d, yyyy, hh:mm tt}")]

        public DateTime date  { get; set; }
        [Phone]
        [Display(Name = "المحمول")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "إدخل رقم التلفون بالصيغة الصحيحة")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(###)-###-####}")]
        public string phone_num { get; set; }

        [Display(Name = "الصورة الشخصية")]
        public string photo { get; set; }
        [Display(Name = "المسيرة العلمية")]
        [AllowHtml]
        public string about { get; set; }


 

        [Display(Name = "إسم المستخدم")]
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }

        [Display(Name = "إسم المستخدم")]
        public string user_name { get; set; }
        [Display(Name = "كلمة السر")]
        public string password  { get; set; }
  
        public virtual ICollection<Request_to_edit> request_to_edit { get; set; }
        [Display(Name = "إسم الوظيفة")]

        public Mohsen dgreesid { get; set; }
     
    }

}
public enum Mohsen
{
    قسم_التغطيات,قسم_الحوالات, مصمم, IT, قسم_الحسابات , قسم_الحراسة, قسم_الإدارة, بيع_وشراء_العملات
}