using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiaoliGym.Models
{
    [DisplayName("體育場館場")]
    [DisplayColumn("Name")]
    public class Gym
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("館場名稱")]
        [Required(ErrorMessage="請輸入館場名稱")]
        [MaxLength(25,ErrorMessage="場館名稱不得大於25個字元")]
        public string Name { get; set; }

        [DisplayName("館場描述")]
        public string Description { get; set; }

        [DisplayName("建立日期")]
        public DateTime CreateOn { get; set; }

        // 關聯集合
        //---------------------------------------------------------------//
        
    }
}