using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XIT.Test.BLL;
using XIT.Test.Model;

namespace XIT.Test.Web.TSM
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UserId"] !=null)
                {
                    UserBLL bll = new UserBLL();
                    //页面传值
                    UserModel model = bll.GetUserById(Convert.ToInt32(Request.QueryString["UserId"]));
                    //给页面赋值
                    Name_txt.Text =Convert.ToString( model.UserName);
                    pwd_txt.Text = Convert.ToString(model.Passwords);
                    RadioButtonList1.SelectedValue = Convert.ToString( model.Sex);
                    phone_txt.Text = Convert.ToString(model.Phone);
                    email_txt.Text =Convert.ToString( model.Email);
                    birthday_txt.Text = Convert.ToString( model.Birthday);

                }
            }
        }

        protected void AddUser_btn_Click(object sender, EventArgs e)
        {
            UserModel model = new UserModel();
            model.UserName = Name_txt.Text;
            model.Passwords =Convert.ToString(pwd_txt.Text);
            model.Sex = Convert.ToInt32(RadioButtonList1.SelectedValue);
            model.Phone = Convert.ToInt32(phone_txt.Text);
            model.Email = Convert.ToString(email_txt.Text);
            model.Birthday = Convert.ToDateTime(birthday_txt.Text);
            UserBLL bll = new UserBLL();
            int result = 0;
            //与数据库交互
            if (Request.QueryString["UserId"] == null)
            {
                result = bll.AddUser(model);
            }
            else
            {
                //获取浏览器上的id
                model.UserId = Convert.ToInt32(Request.QueryString["UserId"]);
                //调用更新方法，更新model
                result = bll.UpdateUser(model);
            }
            if (result > 0)
            {
                if (result == 100)
                {
                    Response.Write("<script>alert('添加用户已经存在!')</script>");
                    return;
                }
                Response.Write("<script>alert('添加成功!')</script>");
                Response.Redirect("UserList.aspx");
                return;
            }
            else
            {
                Response.Write("<script>alert('添加失败!')</script>");
            }
        }
    }
}