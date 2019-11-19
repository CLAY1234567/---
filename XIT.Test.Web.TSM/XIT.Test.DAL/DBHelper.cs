using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace XIT.Test.DAL
{
    public class DBHelper
    {
        //数据库连接字段
        public static readonly string connStr = ConfigurationManager.ConnectionStrings["practiceConnectionString"].ConnectionString;

        /// <summary>
        /// 查询首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object ExcuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    command.Parameters.AddRange(parameters);
                    return command.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExcuteSqlDateReader(string sql, params SqlParameter[] parameters)
        {
                SqlConnection connection = new SqlConnection(connStr);

                using (SqlCommand command = new SqlCommand(sql, connection))
               {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.Parameters.AddRange(parameters);
                //返回结果，关闭连接
                return command.ExecuteReader(CommandBehavior.CloseConnection);

                }
        }
        /// <summary>
        /// 非查询 添加，修改，删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExcuteNonQuery(string sql,params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    command.Parameters.AddRange(parameters);
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
