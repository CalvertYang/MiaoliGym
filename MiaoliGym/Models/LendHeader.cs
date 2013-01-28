using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiaoliGym.Models
{
    [DisplayName("器材借用紀錄")]
    public class LendHeader
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Gym Gym { get; set; }

        [DisplayName("借用單位")]
        [Required(ErrorMessage="請輸入借用單位")]
        [MaxLength(50,ErrorMessage="借用單位名稱不得超過50字元")]
        public string Unit { get; set; }

        [DisplayName("聯絡電話")]
        [Required(ErrorMessage="請輸入聯絡電話")]
        [DataType(DataType.PhoneNumber)]
        public string ContactPhone { get; set; }

        [DisplayName("負責人")]
        [Required(ErrorMessage="請輸入負責人")]
        public string Responsible { get; set; }

        [DisplayName("經手人")]
        [Required(ErrorMessage="請輸入經手人")]
        public string Clerk { get; set; }

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

        //--------------------------------------------------------------------

        public virtual ICollection<LendItem> LendItems { get; set; }
    }
}