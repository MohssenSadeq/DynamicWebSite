using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Magfinalproject.Models
{
    public class Thesis
    {
        public int id { get; set; }
        [Display(Name = "النخصص")]
        public int departmentID { get; set; }
        public virtual department department { get; set; }
        [Required]
        [Display(Name = "اسم الباحث")]
        public string name { get; set; }
        [Required]
        [Display(Name = " عنوان الرسالة")]
        public string title { get; set; }
        [Required]
        [Display(Name = "المشرف")]
        public string supervisor { get; set; }
        [Required]
        [Display(Name = " العام")]
        public DateTime date { get; set; }
        public Mohsen thesistype { get; set; }
        [Display(Name = "إسم المستخدم")]
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}
