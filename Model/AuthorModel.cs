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
    public class AuthorModel
    {
        private BookLibraryDBContext context = null;

        public AuthorModel()
        {
            context = new BookLibraryDBContext();
        }

        public IEnumerable<Author> ListAll(int limit, int offset)
        {
            var list = context.Database.SqlQuery<Author>("GetAllAuthors").ToPagedList(limit, offset);
            return list;
        }

        public int Create(string author_name, string email, string address)
        {
            object[] sqlparams =  {
        new SqlParameter("@author_name", author_name ?? (object)DBNull.Value),
        new SqlParameter("@email", email ?? (object)DBNull.Value),
        new SqlParameter("@address", address ?? (object)DBNull.Value)
    };

            int res = context.Database.ExecuteSqlCommand("AddAuthor @author_name, @email , @address", sqlparams);
            return res;
        }


        public int UpdateAuthor(int? id, string author_name, string email, string address)
        {
            object[] sqlparams =  {
        new SqlParameter("@id", id),
        new SqlParameter("@author_name", author_name ),
        new SqlParameter("@email", email ),
        new SqlParameter("@address", address)
    };

            int res = context.Database.ExecuteSqlCommand("EXEC UpdateAuthor @id, @author_name, @email , @address", sqlparams);
            return res;
        }



        public int DeleteAuthor(int? id)
        {

            object[] sqlparams = {
                 new SqlParameter("@id", id)
            };

            int res = context.Database.ExecuteSqlCommand("DeleteAuthor @id", sqlparams);
            return res;

        }

        public object GetAuthorById(int id)
        {
            return context.Authors.Find(id);
        }
    }
}
