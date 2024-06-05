using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TN_DNET.Areas.Admin.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập.")]
        public string UserAdmin { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [DataType(DataType.Password)]
        public string PassAdmin { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ và tên.")]
        public string FullName { get; set; }
    }
}