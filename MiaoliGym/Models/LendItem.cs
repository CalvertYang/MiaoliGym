using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiaoliGym.Models
{
    [DisplayName("借用項目")]
    public class LendItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual SportsStuff SportsStuff { get; set; }

        [DisplayName("借用數量")]
        [Required(ErrorMessage="請輸入借用數量")]
        public int Amount { get; set; }

        [DisplayName("借用日期")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage="請輸入借用日期")]
        public DateTime LendOn { get; set; }

        [DisplayName("借用期限")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "請輸入借用期限")]
        public DateTime Expire { get; set; }

        [DisplayName("經手人")]
        [Required(ErrorMessage = "請輸入經手人")]
        public string Clerk { get; set; }

        [Required]
        public LendHeader LendHeader { get; set; }

        [DisplayName("建立時間")]
        [DataType(DataType.DateTime)]
        public DateTime CreateOn { get; set; }

        [DisplayName("最後編輯者")]
        [Required]
        public string LastEditor { get; set; }

        [DisplayName("更新時間")]
        [DataType(DataType.DateTime)]
        public DateTime? LastUpdateOn { get; set; }

        [Required]
        public bool Deleted { get; set; }

        //-------------------------------------------------------------------------------

        public virtual ICollection<LendTransaction> Transactions { get; set; }
    }
}