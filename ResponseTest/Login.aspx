<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Response的使用</title>
    <link rel="stylesheet" type="text/css" href="login.css"/>
</head>
<body>
    <div id="login_frame">
        <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="3" style="text-align:center">
                    用户登陆
                </td>
            </tr>
            <tr>
                <td style="width:128px">
                    <asp:Label CssClass="label_input" runat="server">用户名：</asp:Label></td>
                <td style="width:183px" colspan="2">
                    <asp:TextBox ID="UserName" runat="server" CssClass="text_field"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:128px">
                    <asp:Label CssClass="label_input" runat="server">密&nbsp;码：</asp:Label></td>
                <td colspan="2" style="width:183px">
                    <asp:TextBox ID="PassWord" runat="server" TextMode="Password" CssClass="text_field"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="align-content:center">
                    <asp:Button ID="submit" Text="提交" runat="server" OnClick="submit_Click" CssClass="btn_login"/>
                    <asp:Button ID="cancel" Text="重置" runat="server" CssClass="btn_login"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
    </div>
    
</body>
</html>
