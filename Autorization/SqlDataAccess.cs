using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace Autorization_form
{
    public static class SqlDataAccess
    {
        public static int RegisterUser(UserForm user, out string login)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                { 
                    cnn.Execute("insert into Users (Login, HashPass) values (@Login, @HashPass)", user);
                    login = user.Login;
                }
                catch
                {
                    login = null;
                    return -1;
                }
            }
            return 1;
        }

        public static List<UserForm> GetUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Query<UserForm>("select * from Users", new DynamicParameters()).ToList<UserForm>();
            }
        }

        public static int LogInUser(UserForm user, out string login)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var DBUser = GetUsers()
                    .Where(u => u.Login == user.Login)
                    .FirstOrDefault();
                if (DBUser == default(UserForm))
                {
                    login = null;
                    return -1;
                }
                    
                if (DBUser.HashPass != user.HashPass)
                {
                    login = null;
                    return 0;
                }
                login = DBUser.Login;  
            } 
            return 1;
        }

        public static string LoadConnectionString(string id="Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
