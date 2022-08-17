using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Magfinalproject.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        [Required]
        [Remote("Check_clsname", "Categories",AdditionalFields ="ID",ErrorMessage =".هذا التصنيف موجود مسبقا")]
        [Display(Name = "تصنيف أساسي")]    
        public string classname { get; set; }
       
        [Required]
        [Display(Name = "تاريخ الإنشاء")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM d, yyyy, hh:mm tt}")]       
        public DateTime date { get; set; }

        [Display(Name = "إسم المستخدم")]
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }
        public virtual ICollection<cardinfo> cardinfo { get; set; }
    }
}
//public enum cat
//{
//    الأحداث,الأخبار,الطلاب,مجتمع_محلي,الخريجين,عن_الشركة,القبول_والتسجيل,الشئون_الأكاديمية,الدراسات_العلياء_والبحث_العلمي
//}