using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiaoliGym.Models
{
    [DisplayName("免繳項目")]
    public class FreeItem
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("項目名稱")]
        [Required(ErrorMessage="請輸入免繳項目名稱")]
        public string Name { get; set; }

        [Required]
        public virtual GymRecord GymRecord { get; set; }

        [DisplayName("免繳文號")]
        [Required(ErrorMessage="請輸入免繳文號")]
        public string ApprovalNo { get; set; }

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