<%@ Page Language="C#" AutoEventWireup="true" CodeFile="room.aspx.cs" Inherits="Room" %>

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
    <script src="scripts/My97DatePicker/WdatePicker.js" type="text/javascript" defer="defer"></script>
    <link rel="stylesheet" type="text/css" href="style/authority/jquery.fancybox-1.3.4.css" media="screen"></link>
    <script type="text/javascript" src="scripts/artDialog/artDialog.js?skin=default"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container" runat="server">
            <div class="ui_content">
                <div class="ui_text_indent">
                    <div id="box_border">
                         <div id="box_top">搜索</div>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="CalenderUpdatePanel" runat="server">
                            <ContentTemplate>
                                <input id="arriveTextBox" type="text" runat="server" onclick="WdatePicker()" placeholder="请选择日期" Height="25px" Width="80px" Class="Wdate"/>
                                <input id="leaveTextBox" type="text" runat="server" onclick="WdatePicker()" placeholder="请选择日期" Height="25px" Width="80px" Class="Wdate"/>
   
                                <asp:DropDownList ID="SelectType" runat="server"
                                    OnSelectedIndexChanged="SelectType_SelectedIndexChanged1" Height="25px" Width="80px">
                                    <asp:ListItem>单人房</asp:ListItem>
                                    <asp:ListItem>双人房</asp:ListItem>
                                    <asp:ListItem>大床房</asp:ListItem>
                                    <asp:ListItem Selected="True">全部类型</asp:ListItem>
                                </asp:DropDownList>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div id="box_bottom">
                            <asp:Button ID="Button1" runat="server" Text="查询" Width="70px" OnClick="search" CssClass="ui_input_btn01" />
                        </div>
                    </div>
                </div>
                <div class="ui_content" runat="server">
                    <div class="ui_tb" runat="server">
                        <asp:GridView ID="room" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" DataKeyNames="Rno" Width="100%"
                            AllowSorting="True" ForeColor="#333333" OnSelectedIndexChanged="room_SelectedIndexChanged" ShowFooter="false" PageSize="10" OnRowDataBound="room_RowDataBound" OnDataBound="room_DataBound">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="选择">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="select" runat="server" Visible="true" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Rno" HeaderText="房间号">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Rtype" HeaderText="房间类型">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Rpr" HeaderText="房间价格">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        <div class="ui_frt">
                            <asp:Button ID="lnkbtnPre" runat="server" OnClick="lnkbtnPre_Click" Text="上一页" CssClass="ui_input_btn01"></asp:Button>
                            <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                            <asp:Button ID="lnkbtnNext" runat="server" OnClick="lnkbtnNext_Click" Text="下一页" CssClass="ui_input_btn01"></asp:Button>
                            <asp:Button ID="lnkbtnLast" runat="server" OnClick="lnkbtnLast_Click" Text="尾页" CssClass="ui_input_btn01"></asp:Button>
                            跳转到第<asp:DropDownList ID="ddlCurrentPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            </asp:DropDownList>页
                            <asp:Button ID="sd" runat="server" Text="订房" Width="70px" OnClick="sd_click" CssClass="ui_input_btn01" />
                        </div>                       
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
