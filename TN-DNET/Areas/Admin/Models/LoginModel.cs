using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TN_DNET.Areas.Admin.Models
{
    public class LoginModel
    {
        public string UserAdmin { get; set; }
        public string PassAdmin { get; set; }
        public bool RememberMe { get; set; }
    }
}