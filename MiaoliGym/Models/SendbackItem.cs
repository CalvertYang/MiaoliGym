using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiaoliGym.Models
{
    [DisplayName("應歸還項目")]
    public class SendbackItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual GymRecord GymRecord { get; set; }

        [DisplayName("應歸還項目名稱")]
        [Required(ErrorMessage="請輸入應歸還項目名稱")]
        public string Name { get; set; }

        [DisplayName("應退還金額")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "請輸入應退還金額")]
        public int Price { get; set; }

        [DisplayName("退還日期")]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        [DisplayName("支票號碼")]
        public string CheckNo { get; set; }

        [DisplayName("備註")]
        [DataType(DataType.Text)]
        public string Comment { get; set; }

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
    }
}