<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditLine.aspx.cs" Inherits="EditLine" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>酒店信息管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <script type="text/javascript" src="scripts/jquery/jquery-1.7.1.js"></script>
    <link href="style/authority/basic_layout.css" rel="stylesheet" type="text/css">
    <link href="style/authority/common_style.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="scripts/authority/commonAll.js"></script>
    <script type="text/javascript" src="scripts/jquery/jquery-1.4.4.min.js"></script>
    <script src="scripts/My97DatePicker/WdatePicker.js" type="text/javascript" defer="defer"></script>
    <script type="text/javascript" src="scripts/artDialog/artDialog.js?skin=default"></script>
    <script type="text/javascript" language="javascript">
        function DatePicker() {
            WdatePicker();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <form id="submitForm" name="submitForm" action="/xngzf/archives/initFangyuan.action" method="post">
	        <div id="container">
		        <div class="ui_content">
			        <table  cellspacing="0" cellpadding="5" width="100%" align="left" border="0">
                        <tr>
					        <td class="ui_text_rt">报修时间&nbsp;&nbsp;</td>
					        <td class="ui_text_lt">
						        <input id="ReportTime" type="text" runat="server" onclick="WdatePicker()" placeholder="请选择日期" Height="25px" Width="80px" Class="Wdate"/>
					        </td>
				        </tr>
				        <tr>
					        <td class="ui_text_rt">报修房间号&nbsp;&nbsp;</td>
					        <td class="ui_text_lt">
						        <asp:TextBox ID="RoomNo" runat="server" Height="20px" CssClass="ui_text_lt"></asp:TextBox>
					        </td>
				        </tr>
                        <tr>
                            <td class="ui_text_rt">报修客户姓名&nbsp;&nbsp;</td>
                            <td class="ui_text_lt">
                                <asp:TextBox ID="Name" runat="server" Height="20px" CssClass="ui_text_lt"></asp:TextBox>
                            </td>
                        </tr>
				        <tr>
					        <td class="ui_text_rt">客户联系方式&nbsp;&nbsp;</td>
					        <td class="ui_text_lt">
						        <asp:TextBox ID="Tel" runat="server" Height="20px" CssClass="ui_text_lt"></asp:TextBox>
					        </td>
				        </tr>
				        <tr>
					        <td class="ui_text_rt">办理人</td>
					        <td class="ui_text_lt">
                                <asp:DropDownList ID="Manager" runat="server" Height="25px" Width="150px">
                                    <asp:ListItem>---请选择---</asp:ListItem>
                                    <asp:ListItem>123456</asp:ListItem>
                                    <asp:ListItem>283746</asp:ListItem>
                                    <asp:ListItem>910293</asp:ListItem>
                                </asp:DropDownList>
					        </td>
				        </tr>
				        <tr>
					        <td class="ui_text_rt">报修详情</td>
					        <td class="ui_text_lt">
						        <asp:TextBox ID="Detail" runat="server" TextMode="MultiLine" Rows="5" Width="250px"></asp:TextBox>
					        </td>
				        </tr>
				        <tr>
					        <td class="ui_text_rt">处理状态</td>
					        <td class="ui_text_lt">
						        <asp:DropDownList ID="Status" runat="server" Height="25px" Width="150px" AutoPostBack="true">
                                    <asp:ListItem>---请选择---</asp:ListItem>
                                    <asp:ListItem>待维修</asp:ListItem>
                                    <asp:ListItem>待更换</asp:ListItem>
                                    <asp:ListItem>已维修</asp:ListItem>
                                    <asp:ListItem>已更换</asp:ListItem>
                                    <asp:ListItem>其他(请注明)</asp:ListItem>
						        </asp:DropDownList>
                                <asp:TextBox ID="StatusDetail" runat="server" Height="22px" Width="150px" placeholder="其他状态信息"></asp:TextBox>
					        </td>
				        </tr>
				        <tr>
					        <td class="ui_text_rt">处理完成时间</td>
					        <td class="ui_text_lt">
                                <input id="FixedTime" type="text" runat="server" onclick="WdatePicker()" placeholder="请选择日期" Height="25px" Width="80px" Class="Wdate"/>
					        </td>
				        </tr>
				        <tr>
					        <td>&nbsp;</td>
					        <td class="ui_text_lt">
                                <asp:Button ID="SubmitBtn" runat="server" CssClass="ui_input_btn01" Text="修改" OnClick="SubmitBtn_Click" />
                                <asp:Button ID="ResetBtn" runat="server" CssClass="ui_input_btn01" Text="重置" OnClick="ResetBtn_Click" />
                                <asp:Button ID="Back" runat="server" CssClass="ui_input_btn01" Text="返回" OnClick="Back_Click" />
					        </td>
				        </tr>
			        </table>
		        </div>
	        </div>
        </form>
    </form>
</body>
</html>
