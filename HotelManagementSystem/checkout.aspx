<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkout.aspx.cs" Inherits="checkout"  EnableEventValidation="false" %>

<!DOCTYPE html>
<script runat="server">

</script>


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
	.alt td{ background:black !important;}
</style>
</head>
<body>
	<form id="submitForm" runat="server">
		<input type="hidden" name="allIDCheck" value="" id="allIDCheck"/>
		<input type="hidden" name="fangyuanEntity.fyXqName" value="" id="fyXqName"/>
		<div id="container">			
			<div class="ui_content">
				<div class="ui_tb">
                    <asp:GridView ID="detail" runat="server" align="center" Width="100%"
                        AutoGenerateColumns="False" DataKeyNames="Rno"
                        AllowPaging="True" AllowSorting="True" CellPadding="4" 
                        ForeColor="#333333" OnRowDeleting="detail_RowDeleting" 
                        OnSelectedIndexChanged="detail_SelectedIndexChanged1" OnSorting="detail_Sorting" 
                        OnRowDataBound="detail_RowDataBound"
                        >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="序号">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="Rno" HeaderText="房间号" SortExpression="Rno" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRarrive" HeaderText="入住时间" SortExpression="CRarrive" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRleave" HeaderText="离开时间" SortExpression="CRleave" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            
                            <asp:TemplateField HeaderText="删除">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="delete" CommandName="Delete" Text="删除" OnClientClick="return confirm('你确定删除吗?')" />
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
                        <asp:Button ID="export" runat="server" Text="导出" OnClick="export_Click" CssClass="ui_input_btn01"/>
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
<div style="display:none"><script src='http://v7.cnzz.com/stat.php?id=155540&web_id=155540' language='JavaScript' charset='gb2312'></script></div>
</body>
</html>
