<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FixItem.aspx.cs" Inherits="FixItem" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="scripts/jquery/jquery-1.7.1.js"></script>
    <link href="style/authority/basic_layout.css" rel="stylesheet" type="text/css">
    <link href="style/authority/common_style.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="scripts/authority/commonAll.js"></script>
    <script type="text/javascript" src="scripts/fancybox/jquery.fancybox-1.3.4.js"></script>
    <script type="text/javascript" src="scripts/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="style/authority/jquery.fancybox-1.3.4.css" media="screen"></link>
    <script type="text/javascript" src="scripts/artDialog/artDialog.js?skin=default"></script>
    <title>酒店信息管理系统</title>
</head>
<body>
    <form id="form1" runat="server">
		<div id="container">
				<div class="ui_text_indent">
					<div id="box_border">
						<div id="box_top">搜索</div>
						<div id="box_center">
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;搜索方式&nbsp;
                            <asp:DropDownList ID="SearchWay" runat="server" Width="200px" Height="30px">
                                <asp:ListItem>按房间号搜索</asp:ListItem>
                                <asp:ListItem>按房间类型搜索</asp:ListItem>
                                <asp:ListItem>按楼层搜索</asp:ListItem>
                                <asp:ListItem>按房间状态搜索</asp:ListItem>
                                <asp:ListItem>按时间搜索</asp:ListItem>
                                <asp:ListItem>按操作人搜索</asp:ListItem>
                                <asp:ListItem>按客户信息搜索</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;搜索条件&nbsp;
                            <asp:TextBox ID="SearchInfo" runat="server" Width="200px" Height="30px" placeholder="请输入搜索方式对应信息"></asp:TextBox>
						</div>
						<div id="box_bottom">
                            <div id="box_bottom_left" style="text-align:left;float:left">
                                <asp:Button ID="ShowAll" runat="server" Text="全部信息" CssClass="ui_input_btn01" OnClick="ShowAll_Click" />
                                <asp:Button ID="Query" runat="server" Text="查询" CssClass="ui_input_btn01" OnClick="Query_Click" />
                                <asp:Button ID="Add" runat="server" Text="添加" CssClass="ui_input_btn01" OnClick="Add_Click" />
                                <asp:Button ID="Delete" runat="server" Text="删除" CssClass="ui_input_btn01" OnClick="Delete_Click" />
                            </div>
                            <asp:FileUpload ID="FileUpload" runat="server"/>
                            <asp:Button ID="Import" runat="server" Text="导入" CssClass="ui_input_btn01" OnClick="Import_Click" />
                            <asp:Button ID="Export" runat="server" Text="导出" CssClass="ui_input_btn01" OnClick="Export_Click" />
						</div>
					</div>
				</div>
			<div class="ui_tb">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:GridView ID="RoomList" runat="server"
                        AutoGenerateColumns="False"
                        DataKeyNames="_ID" 
                        width="100%"
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        AllowSorting="True"
                        AllowPaging="True"
                        PageSize="12"
                        OnRowDataBound="RoomList_RowDataBound" >
                        <AlternatingRowStyle CssClass="alt" />
                        <Columns>
                            <asp:TemplateField HeaderText="选择">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Select" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Rtime" HeaderText="报修时间">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Rroom" HeaderText="客房编号">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Rname" HeaderText="客户姓名">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Rtel" HeaderText="客户电话">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Rmanager" HeaderText="办理人">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Rmark" HeaderText="情况描述">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Rcondition" HeaderText="维修状态">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Rfixtime" HeaderText="维修时间">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:Button ID="Edit" runat="server" OnClick="Edit_OnClick" Text="编辑" Width="40px" />
                                    <asp:Button ID="DeleteItem" runat="server" OnClick="DeleteItem_OnClick" Text="删除" Width="40px" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="pgr" />
                    </asp:GridView>
                </asp:Panel>
            </div>
        </div>
	</form>
</body>
</html>