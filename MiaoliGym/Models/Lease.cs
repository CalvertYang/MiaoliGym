using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiaoliGym.Models
{
    [DisplayName("定期租借場地紀錄")]
    public class Lease
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Gym Gym{get;set;}

        [DisplayName("借用單位")]
        [Required(ErrorMessage="請輸入借用單位")]
        [MaxLength(50,ErrorMessage="借用單位名稱不得超過50個字元")]
        public string Unit { get; set; }

        [DisplayName("借用區域")]
        public string Area { get; set; }

        [DisplayName("借用日期-起")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [DisplayName("借用日期-迄")]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }

        [DisplayName("應繳租金")]
        [DataType(DataType.Currency)]
        public int PayableRent { get; set; }

        [DisplayName("繳交日期")]
        [Description("並非實際繳交日期，而是區分為【上半年】【下半年】")]
        [MaxLength(10,ErrorMessage="繳交日期文字不得超過10個字元")]
        public string PayMode { get; set; }

        [DisplayName("水電費金額")]
        [DataType(DataType.Currency)]
        public int HydropowerPrice { get; set; }

        [DisplayName("水電費繳交日")]
        [DataType(DataType.Date)]
        public DateTime? HydropowerPaidOn { get; set; }

        [DisplayName("保證金金額")]
        [DataType(DataType.Currency)]
        public int Bail { get; set; }

        [DisplayName("保證金繳交日期")]
        [DataType(DataType.Date)]
        public DateTime? BailPaidOn { get; set; }

        [DisplayName("收據編號")]
        public string ReceiptNo { get; set; }

        [DisplayName("收據開立日期")]
        [DataType(DataType.Date)]
        public DateTime? ReceiptCreateOn { get; set; }

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