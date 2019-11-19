using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XIT.Test.DAL;
using XIT.Test.Model;

namespace XIT.Test.BLL
{
    public class UserBLL
    {
        UserDAL dal = new UserDAL();

        public object LoginIn(string UserName, string Passwords)
        {
            return dal.LoginIn(UserName, Passwords);
        }

        public UserModel GetUserById(int UserId)
        {
            return dal.GetUserById(UserId);
        }

        public List<UserModel> GetUserList()
        {
            return dal.GetUserList();
        }

        public int AddUser(UserModel model)
        {
            return dal.AddUser(model);
        }

        public int UpdateUser(UserModel model)
        {
            return dal.UpdateUser(model);
        }

        public int DeleteUser(int UserId)
        {
            return dal.DeleteUser(UserId);
        }
        }
}
