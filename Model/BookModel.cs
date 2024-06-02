using Model.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;
namespace Model
{
    public class BookModel
    {
        private BookLibraryDBContext context = null;

        public BookModel()
        {
            context = new BookLibraryDBContext();
        }

        public IEnumerable<Book> ListAll(int limit, int offset)
        {
            var list = context.Database.SqlQuery<Book>("GetAllBooks").ToPagedList(limit, offset);
            return list; 
        }

        public int Create(string title, int? author_id, decimal? price, string images, int? category_id, string descriptions, DateTime? published, int view_count = 0)
        {
            object[] sqlparams =  {
        new SqlParameter("@title", title ?? (object)DBNull.Value),
        new SqlParameter("@author_id", author_id ?? (object)DBNull.Value),
        new SqlParameter("@price", price ?? (object)DBNull.Value),
        new SqlParameter("@images", images ?? (object)DBNull.Value),
        new SqlParameter("@category_id", category_id ?? (object)DBNull.Value),
        new SqlParameter("@descriptions", descriptions ?? (object)DBNull.Value),
        new SqlParameter("@published", published ?? (object)DBNull.Value),
        new SqlParameter("@view_count", view_count)
    };

            int res = context.Database.ExecuteSqlCommand("AddBook @title, @author_id, @price, @images, @category_id, @descriptions, @published, @view_count", sqlparams);
            return res;
        }


        public int UpdateBook(int? id, string title, int? author_id, decimal? price, string images, int? category_id, string descriptions, DateTime? published, int? view_count)
        {
            object[] sqlparams =  {
        new SqlParameter("@id", id),
        new SqlParameter("@title", title),
        new SqlParameter("@author_id", author_id),
        new SqlParameter("@price", price),
        new SqlParameter("@images", images),
        new SqlParameter("@category_id", category_id),
        new SqlParameter("@descriptions", descriptions),
        new SqlParameter("@published", published),
        new SqlParameter("@view_count", view_count)
    };

            int res = context.Database.ExecuteSqlCommand("EXEC UpdateBook @id, @title, @author_id, @price, @images, @category_id, @descriptions, @published, @view_count", sqlparams);
            return res;
        }



        public int DeleteBook(int? id)
        {
        
            object[] sqlparams = {
                 new SqlParameter("@id", id)
            };

            int res = context.Database.ExecuteSqlCommand("DeleteBook @id", sqlparams);
           return res;
           
        }

        public object GetBookById(int id)
        {
            return context.Books.Find(id);
        }

    }
}
