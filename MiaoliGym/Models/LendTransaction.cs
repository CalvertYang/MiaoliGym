using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiaoliGym.Models
{
    [DisplayName("歸還紀錄")]
    public class LendTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual LendItem LendItem { get; set; }

        [DisplayName("歸還數量")]
        [Required(ErrorMessage="請輸入歸還數量")]
        [RegularExpression(@"[\d]+")]
        public int ReturnAmount { get; set; }


        [DisplayName("經手人")]
        [Required(ErrorMessage = "請輸入經手人")]
        public string Clerk { get; set; }

        [DisplayName("建立時間")]
        [DataType(DataType.DateTime)]
        public DateTime CreateOn { get; set; }

        [DisplayName("最後編輯者")]
        [Required]
        public string LastEditor { get; set; }

        [DisplayName("更新時間")]
        [DataType(DataType.DateTime)]
        public DateTime? LastUpdateOn { get; set; }

    }
}