using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TN_DNET.Common
{
    [Serializable] 
    public class UserLogin
    {
        
        public string UserAdmin { set; get; }
        public string FullName { set; get; }
    }
}