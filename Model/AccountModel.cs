using Model.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Model
{

    public class AccountModel
    {
        private BookLibraryDBContext context = null;

        public AccountModel()
        {
            context = new BookLibraryDBContext();
        }

        public bool Login(string UserAdmin, string PassAdmin)
        {
            var sqlParams = new[]
       {
            new SqlParameter("@UserAdmin", UserAdmin),
            new SqlParameter("@PassAdmin", PassAdmin)
        };
            const string sql = "EXEC sp_signin_user @UserAdmin, @PassAdmin";
            var isAuthenticated = context.Database.SqlQuery<bool>(sql, sqlParams).SingleOrDefault();
            return isAuthenticated;
        } 
    }
}
