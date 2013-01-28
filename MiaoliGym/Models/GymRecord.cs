using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MiaoliGym.Models
{
    [DisplayName("館場借用紀錄")]
    public class GymRecord
    {
        [Key]
        public int Id { get; set; }
   
        [Required]
        public virtual Gym Gym { get; set; }

        [DisplayName("借用單位")]
        [Required(ErrorMessage="請輸入借用單位")]
        [MaxLength(30,ErrorMessage="借用單位名稱不得超過30字")]
        public string LendUnit { get; set; }

        [DisplayName("借用時間-起")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage="請輸入借用時間-起")]
        public DateTime LendDateStart { get; set; }

        // UNDONE: DateCompareValidation
        [DisplayName("借用時間-迄")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage="請輸入借用時間-迄")]
        [DateCompareValidation(DateCompareValidationAttribute.CompareType.GreatherThenOrEqualTo, "結束日期必須要大於起始日期", compareWith: "LendDateStart")]
        public DateTime LendDateEnd { get; set; }

        [DisplayName("活動名稱")]
        [Required(ErrorMessage="請輸入活動名稱或借用事由")]
        [Description("借用場地的相關活動或事由")]
        public string Event { get; set; }

        [DisplayName("聯絡人")]
        [MaxLength(50,ErrorMessage="姓名不得大於50個字元")]
        public string Contacter { get; set; }

        [Required(ErrorMessage="請輸入聯絡電話")]
        [DisplayName("聯絡電話")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(25, ErrorMessage="電話長度不可超過25字元")]
        public string ContactPhone { get; set; }

        [DisplayName("核准文號")]
        [Required(ErrorMessage="請輸入核准文號")]
        public string ApprovalNo { get; set; }

        [DisplayName("建立時間")]
        [Required]
        public DateTime CreateOn { get; set; }

        [DisplayName("更新時間")]
        public DateTime? LastUpdateOn { get; set; }

        [Required]
        public string LastEditor { get; set; }

        [Required]
        public bool Deleted { get; set; }


        //----------------------------------------------------------------------------------------

        public virtual ICollection<PayItem> PayItems { get; set; }
        public virtual ICollection<FreeItem> FreeItems { get; set; }
        public virtual ICollection<SendbackItem> SendbackItems { get; set; }

    }
}