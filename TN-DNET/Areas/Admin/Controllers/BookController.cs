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
    public class BookController : Controller
    {
        // GET: Admin/Book
        public ActionResult Index(int limit = 1 , int offset = 10)
        {
       
            var iplBook = new BookModel();
            var model = iplBook.ListAll(limit, offset);
            return View(model);
        }

        // GET: Admin/Book/Details/5
        public ActionResult Details(int id)
        {
            var model = new BookModel();
            var book = model.GetBookById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Admin/Book/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new BookModel();
                    int res = model.Create(
                        collection.title,
                        collection.author_id,
                        collection.price,
                        collection.images,
                        collection.category_id,
                        collection.descriptions,
                        collection.published,
                        collection.view_count ?? 0
                    );

                    Console.WriteLine("res", res);
                    if (res > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Add Book failed");
                    }
                }
                Console.WriteLine("(ModelState.IsValid", ModelState.IsValid);
              
                return View(collection);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi: " + ex.Message);
                return View();
            }
        }


        // GET: Admin/Book/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new BookModel();
            var book = model.GetBookById(id);
            return View(book);
        }

        // POST: Admin/Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,author_id,price,images,category_id,descriptions,published,view_count")] Book collection)
        {
            try
            {
                // Kiểm tra tính hợp lệ của dữ liệu được truyền vào
                if (ModelState.IsValid)
                {
                    var model = new BookModel();
                    int books = model.UpdateBook(
                        collection.id,
                        collection.title,
                        collection.author_id,
                        collection.price,
                        collection.images,
                        collection.category_id,
                        collection.descriptions,
                        collection.published,
                        collection.view_count ?? 0
                    );

                    // Nếu cập nhật thành công, chuyển hướng đến Index
                    if (books > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật sách thất bại.");
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

        // GET: Admin/Book/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new BookModel();
            var book = model.GetBookById(id);
            return View(book);
        }

        // POST: Admin/Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var model = new BookModel();
                int books = model.DeleteBook(id);

                if (books > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Xóa sách thất bại.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi: " + ex.Message);
            }

            var book = new BookModel().GetBookById(id);
            if (book == null)
            {
                ModelState.AddModelError("", "Sách không tồn tại.");
                return View("Delete");
            }

            return View("Delete", book);
        }

    }
}
