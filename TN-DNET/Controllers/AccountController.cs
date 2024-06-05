using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TN_DNET.Areas.Admin.Models;


namespace TN_DNET.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        
        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register()
        {
            return View();
        }

    }
}