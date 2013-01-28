using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiaoliGym.Models
{
    [DisplayName("體育器材")]
    public class SportsStuff
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("器材名稱")]
        [Required(ErrorMessage="請輸入器材名稱")]
        public string Name { get; set; }

        [DisplayName("器材總數量")]
        [Required(ErrorMessage="請輸入器材數量")]
        public int Total { get; set; }

    }
}