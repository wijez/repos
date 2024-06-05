﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TN_DNET.Areas.Admin.Code;
using TN_DNET.Areas.Admin.Models;
using Model.database;
using Model;
using System.Web.Security;

namespace TN_DNET.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {

            //var result = new Model.AccountModel().Login(model.UserAdmin, model.PassAdmin);
            //if (result && ModelState.IsValid)
            if (Membership.ValidateUser(model.UserAdmin, model.PassAdmin) && ModelState.IsValid)
            {
                //SessionHelper.SetSession(new UserSession() { UserAdmin = model.UserAdmin });
                FormsAuthentication.SetAuthCookie(model.UserAdmin, model.RememberMe);
                Console.WriteLine(Membership.ValidateUser(model.UserAdmin, model.PassAdmin));
                Console.WriteLine(ModelState.IsValid);
                return RedirectToAction("Index", "Home");
               
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
            }
            return View(model);
        }

    
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account", new { area = "Admin" });
        }

    }
}