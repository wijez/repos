using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TN_DNET.Areas.Admin.Code
{
    [Serializable]
    public class UserSession
    {
        public string UserAdmin { get; set; }
        public string PassAdmin { get; set; }
    }
}