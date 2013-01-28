using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiaoliGym.Models
{
    [DisplayName("系統成員")]
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("帳號(Email)")]
        [Required(ErrorMessage="請輸入帳號(電子郵件)")]
        [Description("系統直接以Email作為登入帳號")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(250,ErrorMessage="Email長度無法超過250個字元")]
        public string Email { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage="請輸入密碼")]
        [MaxLength(50,ErrorMessage="密碼不得超過50個字元")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage="請輸入姓名")]
        public string Name { get; set; }

        [DisplayName("權限")]
        [Required]
        [Description("1: 超級管理員, 2: 一般管理員, 3: 財務人員, 4: 一般查閱人員 ")]
        public int Rank { get; set; }

        [Required]
        public bool Deleted { get; set; }
    }
}