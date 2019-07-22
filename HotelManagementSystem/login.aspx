<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>酒店管理系统</title>
    <link href="style/authority/login_css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="scripts/jquery/jquery-1.7.1.js"></script>
</head>
<body>
    <div id="login_center">
		<div id="login_area">
			<div id="login_box">
				<div id="login_form">
					<form id="submitForm" action="" method="post" runat="server">
						<div id="login_tip">
							<span id="login_err" class="sty_txt2"></span>
						</div>
						<div>
                             用户名:<asp:TextBox ID="username" runat="server" CssClass="username" OnTextChanged="username_TextChanged"></asp:TextBox>
						</div>
						<div>
							密&nbsp;&nbsp;&nbsp;&nbsp;码:<asp:TextBox ID="password" runat="server" CssClass="pwd" textmode="Password"></asp:TextBox>
						</div>
						<div id="btn_area">
                            <asp:Button ID="login_sub" Cssclass="login_btn" text="登  录" runat="server" OnClick="login_sub_Click"/>
                            <asp:Button ID="login_ret" Cssclass="login_btn" text="重  置" runat="server"/>
						</div>
					</form>
				</div>
			</div>
		</div>
	</div>
</body>
</html>
