using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiaoliGym.Models
{
    [DisplayName("工程採購紀錄")]
    public class PurchaseRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Gym Gym { get; set; }

        [DisplayName("案號")]
        [Required(ErrorMessage="請輸入案號")]
        public string No { get; set; }

        [DisplayName("採購名稱")]
        [Required(ErrorMessage="請輸入採購名稱")]
        public string Name { get; set; }

        [DisplayName("經費來源")]
        public string Source { get; set; }

        [DisplayName("預算金額")]
        [DataType(DataType.Currency)]
        public int Budget { get; set; }

        [DisplayName("決標金額")]
        [DataType(DataType.Currency)]
        public int? SellingPrice { get; set; }

        [DisplayName("承包商")]
        public string Vendor { get; set; }

        [DisplayName("負責人")]
        public string Responsible { get; set; }

        [DisplayName("聯絡電話")]
        [DataType(DataType.PhoneNumber)]
        public string ContactPhone { get; set; }

        [DisplayName("履約期限")]
        [DataType(DataType.Date)]
        public DateTime? ContractExpire { get; set; }

        [DisplayName("保證金金額")]
        [DataType(DataType.Currency)]
        public int? Bail { get; set; }

        [DisplayName("保證金實際繳交日期")]
        [DataType(DataType.Date)]
        public DateTime? BailPaidOn { get; set; }

        [DisplayName("保證金退還日期")]
        [DataType(DataType.Date)]
        public DateTime? BailSendbackDate { get; set; }

        [DisplayName("保證金支票號碼")]
        public string BailCheckNo { get; set; }

        [DisplayName("驗收日期")]
        [DataType(DataType.Date)]
        public DateTime? AcceptingDate{get;set;}

        [DisplayName("保固金金額")]
        [DataType(DataType.Currency)]
        public int? Retentions { get; set; }

        [DisplayName("保固金實際繳交日期")]
        [DataType(DataType.Date)]
        public DateTime? RetentionsPaidOn { get; set; }

        [DisplayName("保固期限")]
        [DataType(DataType.Date)]
        public DateTime? RetentionsExpire { get; set; }

        [DisplayName("保固金退還日期")]
        [DataType(DataType.Date)]
        public DateTime? RetentionsSendbackDate { get; set; }

        [DisplayName("保固金支票號碼")]
        public string RetentionsCheckNo { get; set; }

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