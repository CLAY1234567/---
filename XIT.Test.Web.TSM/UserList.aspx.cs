using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XIT.Test.Model;
using XIT.Test.BLL;

namespace XIT.Test.Web.TSM
{
    
    public partial class UserList : System.Web.UI.Page
    {
       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            UserBLL bll = new UserBLL();
            Repeater1.DataSource=bll.GetUserList();
            Repeater1.DataBind();

            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                UserModel model = bll.GetUserById(Convert.ToInt32( Session["UserId"]));
                Label1_txt.Text = model.UserName;


            }
        }
        /// <summary>
        /// 注册 repeater事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            UserBLL bll = new UserBLL();
            //获取当前操作的类型，参数
            string cmdType = e.CommandName;
            string UserId = e.CommandArgument.ToString();
            if (cmdType == "update")
            {
                //跳转页面，根据id显示信息
                Response.Redirect("AddUser.aspx?UserId=" + UserId);
            }
            else
            {
                int result = bll.DeleteUser(Convert.ToInt32( UserId));
                if (result > 0)
                {
                    Response.Redirect("UserList.aspx");
                }
                else
                {
                    Response.Write("<script>alert('删除失败！');</script>");
                }
            }

            

        }
    }
}