using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.database;
using PagedList;
using PagedList.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace TN_DNET.Areas.Admin.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Admin/Author
        public ActionResult Index(int limit = 1, int offset = 10)
        {
            var iplAuthor = new AuthorModel();
            var model = iplAuthor.ListAll(limit, offset);
            return View(model);
        }

        // GET: Admin/Author/Details/5
        public ActionResult Details(int id)
        {
            var model = new AuthorModel();
            var author = model.GetAuthorById(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Admin/Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new AuthorModel();
                    int res = model.Create(
                        collection.author_name,
                        collection.email,
                        collection.address
                    );

                    if (res > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Add author failed");
                    }
                }
                return View(collection);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi: " + ex.Message);
                return View();
            }
        }

        // POST: Admin/Author/Create

        public ActionResult Create()
        {
            return View();
        }

        // GET: Admin/Author/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new AuthorModel();
            var author = model.GetAuthorById(id);
            return View(author);
        }

        // POST: Admin/Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,author_name,email,address")] Author collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new AuthorModel();
                    int authors = model.UpdateAuthor(
                        collection.id,
                        collection.author_name,
                        collection.email,
                        collection.address
                    );

                    if (authors > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật tác giả thất bại.");
                    }
                }

                return View(collection);
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi vào log nếu cần thiết
                ModelState.AddModelError("", "Đã xảy ra lỗi: " + ex.Message);
                return View(collection);
            }
        }

        // GET: Admin/Author/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new AuthorModel();
            var author = model.GetAuthorById(id);
            return View(author);
        }

        // POST: Admin/Author/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var model = new AuthorModel();
                int authors = model.DeleteAuthor(id);

                if (authors > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Xóa tác giả thất bại.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi: " + ex.Message);
            }

            var author = new AuthorModel().GetAuthorById(id);
            if (author == null)
            {
                ModelState.AddModelError("", "Tác giả không tồn tại.");
                return View("Delete");
            }

            return View("Delete", author);
        }

    }

}
