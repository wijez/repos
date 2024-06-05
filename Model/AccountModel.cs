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

        public bool Register(string UserAdmin, string PassAdmin, string FullName)
        {
            try
            {
                var sqlParams = new[]
                {
            new SqlParameter("@UserAdmin", UserAdmin),
            new SqlParameter("@PassAdmin", PassAdmin),
            new SqlParameter("@FullName", FullName)
        };
                const string sql = "EXEC AddUser @UserAdmin, @PassAdmin, @FullName";
                var isRegistered = context.Database.SqlQuery<int>(sql, sqlParams).SingleOrDefault();
                Console.WriteLine(isRegistered);
                return isRegistered==1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while registering user: " + ex.Message);
                return false; // Trả về false để biểu thị rằng quá trình đăng ký thất bại
            }
        
    }

    }
}