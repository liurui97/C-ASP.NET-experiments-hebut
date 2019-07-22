<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Debug="true" EnableEventValidation = "false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="scripts/jquery/jquery-1.7.1.js"></script>
    <link href="style/authority/basic_layout.css" rel="stylesheet" type="text/css">
    <link href="style/authority/common_style.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="scripts/authority/commonAll.js"></script>
    <script type="text/javascript" src="scripts/fancybox/jquery.fancybox-1.3.4.js"></script>
    <script type="text/javascript" src="scripts/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="style/authority/jquery.fancybox-1.3.4.css" media="screen"></link>
    <script type="text/javascript" src="scripts/artDialog/artDialog.js?skin=default"></script>
    <title></title>
    <script language="javascript" type="text/javascript">

    </script>
</head>
<body runat="server">
    <form id="form1" runat="server">
        <input type="hidden" name="allIDCheck" value="" id="allIDCheck" />
        <input type="hidden" name="fangyuanEntity.fyXqName" value="" id="fyXqName" />
        <div id="container" runat="server">
            <div class="ui_content" runat="server">
                <div class="ui_text_indent" runat="server">
                    <div id="box_border" runat="server">
                        <div id="box_top">搜索</div>
                        <div id="box_center">
                            房间类型
							 
                            <asp:DropDownList ID="DropDownList5" runat="server"
                                OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp;房间价格
							 
                            <asp:DropDownList ID="DropDownList6" runat="server"
                                OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp;&nbsp;位置&nbsp; 
                            <asp:DropDownList ID="DropDownList8" runat="server"
                                OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div id="box_bottom">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查看" CssClass="ui_input_btn01" />
                            &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="新增" CssClass="ui_input_btn01" />
                            &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
                            &nbsp;&nbsp;
                            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="导入" CssClass="ui_input_btn01" />
                            &nbsp;&nbsp;
                            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="导出" CssClass="ui_input_btn01" />
                        </div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                            Width="100%" CellPadding="4"
                            ForeColor="#333333"
                            OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                            OnPageIndexChanging="GridView1_PageIndexChanging"
                            AllowPaging="True" PageSize="8"
                            OnRowCancelingEdit="GridView1_RowCancelingEdit"
                            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
                            OnRowUpdating="GridView1_RowUpdating"
                            OnRowDataBound="GridView1_RowDataBound"
                            DataKeyNames="Rno" Style="margin-right: 0px">
                            <Columns>
                                <asp:BoundField AccessibleHeaderText="Ture" DataField="Rno" HeaderText="房间编号">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Rtype" HeaderText="房间类型"
                                    ItemStyle-Width="180" AccessibleHeaderText="true">
                                    <ItemStyle Width="180px" HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Rpr" HeaderText="房间价格"
                                    ItemStyle-Width="180">
                                    <ItemStyle Width="180px" HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Rstatus" HeaderText="房间位置">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:CommandField ShowEditButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:CommandField ShowDeleteButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                            </Columns>
                            <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="第一页" LastPageText="末页" />
                            <PagerTemplate>
                                <table width="100%">
                                    <tr>
                                        <td width="75%">
                                            <asp:LinkButton ID="imgBtnFirst" runat="server" CommandArgument="First" CommandName="Page"
                                                Text="第一页" ToolTip="第一页" />
                                            <asp:LinkButton ID="imgBtnPrev" runat="server" CommandArgument="Prev" CommandName="Page"
                                                Text="上一页" ToolTip="上一页" />
                                            <asp:LinkButton ID="imgBtnNext" runat="server" CommandArgument="Next" CommandName="Page"
                                                Text="下一页" ToolTip="下一页" />
                                            <asp:LinkButton ID="imgBtnLast" runat="server" CommandArgument="Last" CommandName="Page"
                                                Text="最后页" ToolTip="最后页" />
                                        </td>
                                        <td align="right" width="25%">页数：5<asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </PagerTemplate>
                            <AlternatingRowStyle BackColor="White" />
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
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
