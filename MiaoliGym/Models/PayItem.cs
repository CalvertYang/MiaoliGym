using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiaoliGym.Models
{
    [DisplayName("繳費項目")]
    public class PayItem
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("項目名稱")]
        [Required(ErrorMessage="請輸入項目名稱")]
        public string Name { get; set; }

        [Required] // 隸屬於哪筆紀錄
        public virtual GymRecord GymRecord { get; set; }

        [DisplayName("應繳費日期")]
        [DataType(DataType.Date)]
        public DateTime PayableDate { get; set; }

        [DisplayName("繳費金額")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage="請輸入繳費金額")]
        public int Price { get; set; }

        [DisplayName("實際繳費日期")]
        [DataType(DataType.Date)]
        public DateTime? PaidOn { get; set; }

        [DisplayName("是否已繳費")]
        public bool IsPaid { get; set; }

        [DisplayName("收據開立日期")]
        [DataType(DataType.Date)]
        public DateTime? ReceiptCreateOn { get; set; }

        [DisplayName("收據號碼")]
        public string ReceiptNo { get; set; }

        [DisplayName("繳庫日期")]
        [DataType(DataType.Date)]
        public DateTime? ReturnGovOn { get; set; }

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