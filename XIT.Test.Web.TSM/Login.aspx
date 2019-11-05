<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="XIT.Test.Web.TSM.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户名:<asp:TextBox ID="UserName_txt" runat="server"></asp:TextBox>
        </div>

        <div>
            密码:<asp:TextBox ID="Passwords_txt" runat="server"></asp:TextBox>
        </div>
       
            <asp:Button ID="Login_btn" runat="server" Text="登录" OnClick="Login_btn_Click" />
        
    </form>
</body>
</html>
