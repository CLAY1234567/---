<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="XIT.Test.Web.TSM.UserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1_txt" runat="server"></asp:Label>:登录成功
        </div> 
        <div>
            <a href="AddUser.aspx">添加用户</a>
        </div>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <HeaderTemplate>
            <table>
                <tr>
                    <th>用户名</th>
                    <th>性别</th>
                    <th>电话</th>
                    <th>邮箱</th>
                    <th>生日</th>
                </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%#Eval("UserName") %></td>
                    <td><%#Eval("Sex").ToString() == "0" ? "男" : "女"%> </td>
                    <td><%#Eval("Phone") %></td>
                    <td><%#Eval("Email") %></td>
                    <td><%#Eval("Birthday") %></td>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="update" CommandArgument='<%#Eval("UserId") %>'>修改</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="delete" CommandArgument='<%#Eval("UserId") %>'>删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
            </table>
            </FooterTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
