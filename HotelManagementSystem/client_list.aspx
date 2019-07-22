<%@ Page Language="C#" AutoEventWireup="true" CodeFile="client_list.aspx.cs" Inherits="client_list" EnableEventValidation="false" %>

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
    <title>用户信息</title>
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
        /** 用户角色   **/
        var userRole = '';

        /** 模糊查询来电用户  **/
        function search() {
            $("#submitForm").attr("action", "house_list.html?page=" + 1).submit();
        }

        /** 新增   **/
        function add() {
            $("#submitForm").attr("action", "/xngzf/archives/luruFangyuan.action").submit();
        }

        /** Excel导出  **/
        function exportExcel() {
            if (confirm('您确定要导出吗？')) {
                var fyXqCode = $("#fyXq").val();
                var fyXqName = $('#fyXq option:selected').text();
                //	 		alert(fyXqCode);
                if (fyXqCode == "" || fyXqCode == null) {
                    $("#fyXqName").val("");
                } else {
                    //	 			alert(fyXqCode);
                    $("#fyXqName").val(fyXqName);
                }
                $("#submitForm").attr("action", "/xngzf/archives/exportExcelFangyuan.action").submit();
            }
        }

        /** 删除 **/
        function del(fyID) {
            // 非空判断
            if (fyID == '') return;
            if (confirm("您确定要删除吗？")) {
                $("#submitForm").attr("action", "/xngzf/archives/delFangyuan.action?fyID=" + fyID).submit();
            }
        }

        /** 批量删除 **/
        function batchDel() {
            if ($("input[name='IDCheck']:checked").size() <= 0) {
                art.dialog({ icon: 'error', title: '友情提示', drag: false, resize: false, content: '至少选择一条', ok: true, });
                return;
            }
            // 1）取出用户选中的checkbox放入字符串传给后台,form提交
            var allIDCheck = "";
            $("input[name='IDCheck']:checked").each(function (index, domEle) {
                bjText = $(domEle).parent("td").parent("tr").last().children("td").last().prev().text();
                // 			alert(bjText);
                // 用户选择的checkbox, 过滤掉“已审核”的，记住哦
                if ($.trim(bjText) == "已审核") {
                    // 				$(domEle).removeAttr("checked");
                    $(domEle).parent("td").parent("tr").css({ color: "red" });
                    $("#resultInfo").html("已审核的是不允许您删除的，请联系管理员删除！！！");
                    // 				return;
                } else {
                    allIDCheck += $(domEle).val() + ",";
                }
            });
            // 截掉最后一个","
            if (allIDCheck.length > 0) {
                allIDCheck = allIDCheck.substring(0, allIDCheck.length - 1);
                // 赋给隐藏域
                $("#allIDCheck").val(allIDCheck);
                if (confirm("您确定要批量删除这些记录吗？")) {
                    // 提交form
                    $("#submitForm").attr("action", "/xngzf/archives/batchDelFangyuan.action").submit();
                }
            }
        }

        /** 普通跳转 **/
        function jumpNormalPage(page) {
            $("#submitForm").attr("action", "house_list.html?page=" + page).submit();
        }

        /** 输入页跳转 **/
        function jumpInputPage(totalPage) {
            // 如果“跳转页数”不为空
            if ($("#jumpNumTxt").val() != '') {
                var pageNum = parseInt($("#jumpNumTxt").val());
                // 如果跳转页数在不合理范围内，则置为1
                if (pageNum < 1 | pageNum > totalPage) {
                    art.dialog({ icon: 'error', title: '友情提示', drag: false, resize: false, content: '请输入合适的页数，\n自动为您跳到首页', ok: true, });
                    pageNum = 1;
                }
                $("#submitForm").attr("action", "house_list.html?page=" + pageNum).submit();
            } else {
                // “跳转页数”为空
                art.dialog({ icon: 'error', title: '友情提示', drag: false, resize: false, content: '请输入合适的页数，\n自动为您跳到首页', ok: true, });
                $("#submitForm").attr("action", "house_list.html?page=" + 1).submit();
            }
        }
    </script>
    <style>
        .alt td {
            background: black !important;
        }
    </style>
</head>
<body>
    <form  runat="server">
        <input type="hidden" name="allIDCheck" value="" id="allIDCheck" />
        <input type="hidden" name="fangyuanEntity.fyXqName" value="" id="fyXqName" />
        <div id="container" runat="server">
            <div class="ui_content">
                <div class="ui_text_indent">
                    <div id="box_border">
                        <div id="box_top">搜索</div>
                        <div id="box_center">
                            身份证号
                            <asp:TextBox ID="idcard" runat="server" CssClass="ui_input_txt02"></asp:TextBox>
                            客户名							
                            <asp:TextBox ID="clientname" runat="server" CssClass="ui_input_txt02"></asp:TextBox>
                            手机号							
                            <asp:TextBox ID="phonenum" runat="server" CssClass="ui_input_txt02"></asp:TextBox>
                            等级							
                            <asp:DropDownList ID="level" runat="server" CssClass="ui_select02">
                                <asp:ListItem Value="普通">普通</asp:ListItem>
                                <asp:ListItem Value="VIP">VIP</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="box_bottom">
                            <asp:Button ID="searchBtn" CssClass="ui_input_btn01" runat="server" Text="搜索" OnClick="searchBtn_Click2" />
                            <asp:Button ID="exportBtn" CssClass="ui_input_btn01" runat="server" Text="导出" OnClick="exportBtn_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="ui_content" runat="server">
                <div class="ui_tb" runat="server">
                    <asp:GridView ID="user" runat="server" align="center" Width="100%"
                        AutoGenerateColumns="False" DataKeyNames="Cno"
                        AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333"
                        OnSelectedIndexChanged="GridView_user_SelectedIndexChanged" OnRowDeleting="user_RowDeleting1"
                        OnRowCreated="user_RowCreated" OnRowDataBound="user_RowDataBound">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="序号">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Cno" HeaderText="身份证号" ReadOnly="True" SortExpression="Cno">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Cname" HeaderText="客户名" SortExpression="Cname">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Ctel" HeaderText="手机号" SortExpression="Ctel">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Clev" HeaderText="等级" SortExpression="Clev">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="Cno" DataNavigateUrlFormatString="checkout.aspx?id={0}"
                                DataTextField="Cno" DataTextFormatString="{0:#&gt;&gt;}" HeaderText="详情" NavigateUrl="~/checkout.aspx" Text="超链接">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:HyperLinkField>
                            <asp:HyperLinkField DataNavigateUrlFields="Cno" DataNavigateUrlFormatString="userInfo.aspx?id={0}"
                                DataTextField="Cno" DataTextFormatString="{0:#&gt;&gt;}" HeaderText="修改用户信息" NavigateUrl="~/userInfo.aspx" Text="超链接">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:HyperLinkField>
                            <asp:TemplateField HeaderText="删除">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="delete" CommandName="Delete" Text="删除" OnClientClick="return confirm('你确定删除吗?')" CommandArgument='<%#Bind("Cno")%>' />
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

                    <asp:SqlDataSource ID="UserSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HotelConnectionString %>" SelectCommand="SELECT * FROM [Client]"
                        UpdateCommand="update [Client] set Cname=@Cname,Ctel=@Ctel,Clev=@Clev where Cno=@Cno"></asp:SqlDataSource>
                    <div class="ui_frt">
                        <asp:Button ID="lnkbtnFrist" runat="server" OnClick="lnkbtnFrist_Click" Text="首页" CssClass="ui_input_btn01"></asp:Button>
                        <asp:Button ID="lnkbtnPre" runat="server" OnClick="lnkbtnPre_Click" Text="上一页" CssClass="ui_input_btn01"></asp:Button>
                        <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                        <asp:Button ID="lnkbtnNext" runat="server" OnClick="lnkbtnNext_Click" Text="下一页" CssClass="ui_input_btn01"></asp:Button>
                        <asp:Button ID="lnkbtnLast" runat="server" OnClick="lnkbtnLast_Click" Text="尾页" CssClass="ui_input_btn01"></asp:Button>
                        跳转到第<asp:DropDownList ID="ddlCurrentPage" CssClass="ui_select02" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>页
                    </div>
                </div>
            </div>
        </div>
    </form>
    <div style="display: none">
        <script src='http://v7.cnzz.com/stat.php?id=155540&web_id=155540' language='JavaScript' charset='gb2312'></script>
    </div>
</body>
</html>
