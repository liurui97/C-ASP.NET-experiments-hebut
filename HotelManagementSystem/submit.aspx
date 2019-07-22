<%@ Page Language="C#" AutoEventWireup="true" CodeFile="submit.aspx.cs" Inherits="submit" %>

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
    <title></title>
    <script type="text/javascript">
        $(document).ready(function () {
            /** 新增   **/
            $("#addBtn").fancybox({
                'href': 'add_user.aspx',
                'width': 733,
                'height': 530,
                'type': 'iframe',
                'hideOnOverlayClick': false,
                'showCloseButton': false,
                'onClosed': function () {
                    window.location.href = 'room.aspx';
                }
            });
        });
    </script>
</head>
<body>
    <form id="submitForm" name="submitForm" action="" method="post" runat="server">
        <div class="ui_content">
            <div class="ui_text_indent">
                <div id="box_border">
                    <asp:GridView ID="confirm" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPdding="3" DataKeyNames="Rno"  CellPadding="4" ForeColor="#333333" OnSelectedIndexChanged="confirm_SelectedIndexChanged">
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="序号">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
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
                            <asp:BoundField DataField="Rstatus" HeaderText="房间状态">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <div class="ui_content">
                        <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
                            <tr>
                                <td cssclass="ui_text_lt" width="80">身份证号</td>
                                <td cssclass="ui_text_lt">
                                    <asp:TextBox ID="idcard" Text="此处填写身份证号" runat="server" CssClass="ui_input_txt02" OnTextChanged="idcard_TextChanged"></asp:TextBox>
                                </td>
                                <td cssclass="ui_text_lt" width="80">客户名</td>
                                <td cssclass="ui_text_lt">
                                    <asp:TextBox ID="name" Text="此处填写用户姓名" runat="server" CssClass="ui_input_txt02"></asp:TextBox>
                                </td>
                                <td cssclass="ui_text_lt" width="80">手机号</td>
                                <td cssclass="ui_text_lt">
                                    <asp:TextBox ID="tel" Text="此处填写手机号" runat="server" CssClass="ui_input_txt02"></asp:TextBox>
                                </td>
                                <td cssclass="ui_text_lt" width="80">等级</td>
                                <td cssclass="ui_text_lt">
                                    <asp:DropDownList ID="level" runat="server" CssClass="ui_select02">
                                        <asp:ListItem>普通</asp:ListItem>
                                        <asp:ListItem>VIP</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="right">
                                    <asp:Button ID="submitbtn" runat="server" OnClick="submitbtn_click" Text="确定" CssClass="ui_input_btn01" />                        
                                </td>
                                <td colspan="4">
                                    <asp:Button ID="resetbtn" runat="server" OnClick="resetbtn_click" Text="重选" CssClass="ui_input_btn01" />
                                </td>
                            </tr>                          
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
