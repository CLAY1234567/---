using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XIT.Test.DAL;
using Newtonsoft.Json;
using XIT.Test.Model;

namespace XIT.Test.Web.TSM.TsetAjax
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            UserDAL dal = new UserDAL();
            //设置输出的数据类型
            context.Response.ContentType = "application/json";
            //调用dal
            List<UserModel> datas = dal.UserList();
            //转换json字符串
            string json = JsonConvert.SerializeObject(datas);
            //输出数据到浏览器
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}