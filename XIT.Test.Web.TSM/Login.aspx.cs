using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XIT.Test.BLL;

namespace XIT.Test.Web.TSM
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Login_btn_Click(object sender, EventArgs e)
        {
            //获取用户名，密码
            string name = UserName_txt.Text;
            string pwd = Passwords_txt.Text;
            UserBLL bll = new UserBLL();
            object result = bll.LoginIn(name, pwd);
            int num = Convert.ToInt32(result);

            if (result == null)
            {
                Response.Write("<script>alert('用户名或密码不正确！')</script>");
            }
            else
            {
                Session.Add("UserId", num);
                Response.Redirect("UserList.aspx");
            }
        }
    }
}