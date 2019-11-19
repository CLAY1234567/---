using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using XIT.Test.Model;

namespace XIT.Test.DAL
{
   public class UserDAL
    {
        UserModel model = new UserModel();
        /// <summary>
        /// 数据库登录验证方法
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Passwords"></param>
        /// <returns></returns>
        public object LoginIn(string UserName,string Passwords)
        {
            //查询数据库的账号密码
            string sql = "select * from Info where UserName=@UserName and Passwords=@Passwords";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@UserName", UserName);
            parameters[1] = new SqlParameter("@Passwords", Passwords);
            //首行首列
            object result = DBHelper.ExcuteScalar(sql,parameters);
            return result;

        }
        
        /// <summary>
        /// 根据id查询信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public UserModel GetUserById(int UserId)
        {
           
            string sql = "select * from Info where UserId=@UserId";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@UserId", UserId);
            SqlDataReader reader = DBHelper.ExcuteSqlDateReader(sql,parameters);
            //判断有没有数据行,HasRows--有没有数据行
            if (reader.HasRows)
            {
                //读取第一条数据
                while (reader.Read())
                {
                    //model.UserId =Convert.ToInt32( reader["UserId"]);
                    model.UserName = reader["UserName"].ToString();                   
                    model.Passwords =Convert.ToString( reader["Passwords"]);
                    model.Sex = Convert.ToInt32(reader["Sex"]);
                    model.Phone= Convert.ToInt32(reader["Phone"]);
                    model.Email= reader["Email"].ToString();
                    model.Birthday = Convert.ToDateTime(reader["Birthday"]);
                }
            }
            return model;
        }

        /// <summary>
        /// 查询用户所有信息
        /// </summary>
        /// <returns></returns>
        public List<UserModel> GetUserList()
        {
            //根据id查询用户所有信息
            string sql = "select UserId,Passwords,UserName,Sex,Phone,Email,Birthday from Info where IaDelete=0";
            List<UserModel> list = new List<UserModel>();
            SqlDataReader reader = DBHelper.ExcuteSqlDateReader(sql);
           
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserModel model = new UserModel();
                    model.UserId = Convert.ToInt32(reader["UserId"]);
                    model.UserName = reader["UserName"].ToString();
                    model.Passwords =Convert.ToString( reader["Passwords"]);
                    model.Sex= Convert.ToInt32(reader["Sex"]);
                    model.Phone= Convert.ToInt32(reader["Phone"]);
                    model.Email= reader["Email"].ToString();
                    model.Birthday= Convert.ToDateTime(reader["Birthday"]);
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 统计
        /// </summary>
        /// <returns></returns>
        public List<UserModel> UserList()
        {
            //根据id查询用户所有信息
            string sql = "select UserId,Passwords,UserName,Sex,Phone,Email,Birthday from Info where IaDelete=0";
            List<UserModel> list = new List<UserModel>();
            SqlDataReader reader = DBHelper.ExcuteSqlDateReader(sql);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserModel model = new UserModel();
                    model.UserId = Convert.ToInt32(reader["UserId"]);
                    model.UserName = reader["UserName"].ToString();
                    model.Passwords = Convert.ToString(reader["Passwords"]);
                    model.Sex = Convert.ToInt32(reader["Sex"]);
                    model.Phone = Convert.ToInt32(reader["Phone"]);
                    model.Email = reader["Email"].ToString();
                    model.Birthday = Convert.ToDateTime(reader["Birthday"]);
                    list.Add(model);
                }
            }
            return list;
        }

        public int AddUser(UserModel model)
        {
            //查询语句
            string sql = "insert into Info values(@UserName,@Passwords,@Sex,@Phone,@Email,@Birthday,default)";
            //添加参数
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserName", model.UserName));
            parameters.Add(new SqlParameter("@Passwords", model.Passwords));
            parameters.Add(new SqlParameter("@Sex", model.Sex));
            parameters.Add(new SqlParameter("@Phone", model.Phone));
            parameters.Add(new SqlParameter("@Email", model.Email));
            parameters.Add(new SqlParameter("@Birthday", model.Birthday));
            //调用DBhelper执行插入语句
            //去重，判断有没有相同用户
            string sqlExist = "select UserId from Info where UserName=@UserName";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@UserName", model.UserName);
            object exObj = DBHelper.ExcuteScalar(sqlExist,sqlParameters);
            int result = 0;
            if (exObj != null)
            {
                result = 100;
                return result;
            }
            result = DBHelper.ExcuteNonQuery(sql,parameters.ToArray());
            //返回结果
            return result;
            

        }

        public int UpdateUser(UserModel model)
        {
            //查询语句
            string sql = "update Info set UserName=@UserName,Passwords=@Passwords,Sex=@Sex,Phone=@Phone,Email=@Email,Birthday=@Birthday  where UserId=@UserId";
            //添加参数
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserId", model.UserId));
            parameters.Add(new SqlParameter("@UserName",model.UserName));
            parameters.Add(new SqlParameter("@Passwords", model.Passwords));
            parameters.Add(new SqlParameter("@Sex", model.Sex));
            parameters.Add(new SqlParameter("@Phone", model.Phone));
            parameters.Add(new SqlParameter("@Email", model.Email));
            parameters.Add(new SqlParameter("@Birthday", model.Birthday));
            int result = DBHelper.ExcuteNonQuery(sql,parameters.ToArray());
            return result;
        }

        /// <summary>
        /// 软删除 只查询IaDelete=0 的用户信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int DeleteUser(int UserId)
        {
            //string sql = "delete  from Info where UserId=@UserId";
            string sql = "update Info set IaDelete = 1 where UserId=@UserId";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@UserId", UserId);
            int result = DBHelper.ExcuteNonQuery(sql,parameters);
            return result;
        }



    }
}
