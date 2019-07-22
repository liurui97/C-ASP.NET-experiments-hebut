<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="scripts/jquery/jquery-1.7.1.js"></script>
    <link href="style/authority/basic_layout.css" rel="stylesheet" type="text/css">
    <link href="style/authority/common_style.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="scripts/authority/commonAll.js"></script>
    <script type="text/javascript" src="scripts/fancybox/jquery.fancybox-1.3.4.js"></script>
    <script type="text/javascript" src="scripts/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="style/authority/jquery.fancybox-1.3.4.css" media="screen"></link>
    <script type="text/javascript" src="scripts/artDialog/artDialog.js?skin=default"></script>
    <title>商品信息</title>
    <script type="text/javascript">
        $(document).ready(function () {
            /** 新增   **/
            $("#addBtn").fancybox({
                'href': 'house_edit.html',
                'width': 733,
                'height': 530,
                'type': 'iframe',
                'hideOnOverlayClick': false,
                'showCloseButton': false,
                'onClosed': function () {
                    window.location.href = 'house_list.html';
                }
            });

            /** 导入  **/
            $("#importBtn").fancybox({
                'href': '/xngzf/archives/importFangyuan.action',
                'width': 633,
                'height': 260,
                'type': 'iframe',
                'hideOnOverlayClick': false,
                'showCloseButton': false,
                'onClosed': function () {
                    window.location.href = 'house_list.html';
                }
            });

            /**编辑   **/
            $("a.edit").fancybox({
                'width': 733,
                'height': 530,
                'type': 'iframe',
                'hideOnOverlayClick': false,
                'showCloseButton': false,
                'onClosed': function () {
                    window.location.href = 'house_list.html';
                }
            });
        });

        /** 模糊查询来电用户  **/
        function search() {
            $("#submitForm").attr("action", "house_list.html?page=" + 1).submit();
        }

        /** 新增   **/
        function add() {
            $("#submitForm").attr("action", "/xngzf/archives/luruFangyuan.action").submit();
        }
    </script>
    <style>
        .alt td {
            background: black !important;
        }
    </style>
</head>
<body>
    <form id="submitForm" runat="server">
        <input type="hidden" name="allIDCheck" value="" id="allIDCheck" />
        <input type="hidden" name="fangyuanEntity.fyXqName" value="" id="fyXqName" />
                    <div id="container" runat="server">
            <div class="ui_content">
                <div class="ui_text_indent">
                    <div id="box_border">
                        <div id="box_top">搜索</div>
                        <div id="box_center">
                            <asp:Label ID="Label1" runat="server" Text="身份证号："></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="ui_input_txt02"></asp:TextBox>
                            <asp:Button ID="search" runat="server" CssClass="ui_input_btn01" OnClick="search_Click" Text="查询" />
                            </div>
                        <div id="box_bottom">
                            <asp:Button ID="submit" runat="server" Text="结算" CssClass="ui_input_btn01" OnClick="submit_Click" />
                <asp:Button ID="submit0" runat="server" Text="返回主页" CssClass="ui_input_btn01" OnClick="goback" />
                        </div>
                        </div>
                    </div>
                <div class="ui_content" runat="server">
                    <div class="ui_tb" runat="server">
                        <asp:GridView ID="account" runat="server" align="center" Width="100%"
                            AutoGenerateColumns="False" DataKeyNames="Cno"
                            AllowPaging="True" CellPadding="5" ForeColor="#333333" OnRowDataBound="account_RowDataBound">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Cno" HeaderText="客户身份证号" ReadOnly="True" SortExpression="Cno" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Rpr" HeaderText="房间单价" SortExpression="Gname" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CRarrive" HeaderText="入住时间" SortExpression="Gname" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CRleave" HeaderText="结算时间" SortExpression="Gname" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="总费用">
                                    <ItemTemplate>
                                        <asp:Label ID="cost" runat="server" Text="Label"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
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
                    </div>

                    <div class="ui_tb" runat="server">
                        <asp:GridView ID="account2" runat="server" align="center" Width="100%"
                            AutoGenerateColumns="False" DataKeyNames="Cno"
                            AllowPaging="True" CellPadding="5" ForeColor="#333333" OnRowDataBound="account2_RowDataBound">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Cno" HeaderText="客户身份证号" ReadOnly="True" SortExpression="Cno" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RTime" HeaderText="购买时间" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Gname" HeaderText="物品名" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Gprice" HeaderText="单价" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Rnum" HeaderText="购买数量" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="单项金额">
                                    <ItemTemplate>
                                        <asp:Label ID="goodcost" runat="server" Text="Label"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
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
                    </div>

                    <div class="ui_tb" runat="server">
                        <asp:GridView ID="account3" runat="server" align="center" Width="100%"
                            AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="Cno" CellPadding="5" ForeColor="#333333" OnRowDataBound="account3_RowDataBound">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Cno" HeaderText="客户身份证号" ReadOnly="True" SortExpression="Cno" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="房费总额">
                                    <ItemTemplate>
                                        <asp:Label ID="cost1" runat="server" Text="Label"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="超市消费总额">
                                    <ItemTemplate>
                                        <asp:Label ID="cost2" runat="server" Text="Label"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="总消费">
                                    <ItemTemplate>
                                        <asp:Label ID="sumcost" runat="server" Text="Label"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
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
                    </div>

                </div>
            </div>
            <div style="display: none">
                <script src='http://v7.cnzz.com/stat.php?id=155540&web_id=155540' language='JavaScript' charset='gb2312'></script>
            </div>
            <div class="ui_text_ct">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/account/Screenshot_2019-05-08-11-12-50-465_com.tencent.mm.png" visible ="false"/>
            </div>
        </div>
    </form>
</body>
</html>
