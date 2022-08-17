using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magfinalproject.Models
{
    public class footer
    {

        public int ID { get; set; }
        [Required]
        [StringLength(59, ErrorMessage = "يجب أن يكون أقل من 60 حرفاً")]
        [Display(Name = "تصنيف أساسي")]
        public string mainfoot { get; set; }       
        [Required]
        [Display(Name = "العنوان")]
        public string title { get; set; }
        [Required]
        [Display(Name = "المحتوى")]
        [AllowHtml]
        public string describtion { get; set; }
        [Required]
        [Display(Name = "تاريخ التعديل")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM d, yyyy, hh:mm tt}")]
        public DateTime date { get; set; }
        [Display(Name = "الصورة")]
        public string pic { get; set; }
        [Display(Name = "إسم المستخدم")]
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}
public enum mainfooter
{
    معلومات_حول,معلومات_لأجل,روابط_سريعة,برمجة_وتصميم_الموقع,سياسة_الخصوصية
}