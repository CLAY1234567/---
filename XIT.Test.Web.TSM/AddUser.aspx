<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="XIT.Test.Web.TSM.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                用户名:<asp:TextBox ID="Name_txt" runat="server"></asp:TextBox></div>
            <div>
                <div>
                    密码:<asp:TextBox ID="pwd_txt" runat="server"></asp:TextBox>
                </div>
            </div>
                性别:<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Selected="True" Value="0">男</asp:ListItem>
                <asp:ListItem Value="1">女</asp:ListItem>
            </asp:RadioButtonList>
            <div>
                电话:<asp:TextBox ID="phone_txt" runat="server"></asp:TextBox>
            </div>
              
            <div>
                邮箱:<asp:TextBox ID="email_txt" runat="server"></asp:TextBox>
            </div>

            <div>
                生日:<asp:TextBox ID="birthday_txt" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="AddUser_btn" runat="server" Text="确定" OnClick="AddUser_btn_Click" />
            
        </div>
    </form>
</body>
</html>
