using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TN_DNET.Areas.Admin.Models;
using Model;

namespace TN_DNET.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index(int limit = 1, int offset = 10)
        {
            var iplBook = new BookModel();
            var model = iplBook.ListAll(limit, offset);
            return View(model);
        }
        public ActionResult Login()
        {
            return View("~/Areas/Admin/Views/Account/Index.cshtml");
        }
    }
}