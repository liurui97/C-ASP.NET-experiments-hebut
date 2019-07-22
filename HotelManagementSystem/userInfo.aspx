<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userInfo.aspx.cs" Inherits="userInfo" %>

<!DOCTYPE html>
<html>
<head>
    <title>信息管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <script type="text/javascript" src="scripts/jquery/jquery-1.7.1.js"></script>
    <link href="style/authority/basic_layout.css" rel="stylesheet" type="text/css">
    <link href="style/authority/common_style.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="scripts/authority/commonAll.js"></script>
    <script type="text/javascript" src="scripts/jquery/jquery-1.4.4.min.js"></script>
    <script src="scripts/My97DatePicker/WdatePicker.js" type="text/javascript" defer="defer"></script>
    <script type="text/javascript" src="scripts/artDialog/artDialog.js?skin=default"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /*
             * 提交
             */
            $("#submitbutton").click(function () {
                if (validateForm()) {
                    checkFyFhSubmit();
                }
            });

            /*
             * 取消
             */
            $("#cancelbutton").click(function () {
                /**  关闭弹出iframe  **/
                window.parent.$.fancybox.close();
            });

            var result = 'null';
            if (result == 'success') {
                /**  关闭弹出iframe  **/
                window.parent.$.fancybox.close();
            }
        });

        /** 检测房源房号是否存在  **/
        function checkFyFh() {
            // 分别获取小区编号、栋号、层号、房号
            var fyID = $('#fyID').val();
            var fyXqCode = $("#fyXq").val();
            var fyDh = $("#fyDh").val();
            var fyCh = $("#fyCh").val();
            var fyFh = $("#fyFh").val();
            if (fyXqCode != "" && fyDh != "" && fyCh != "" && fyFh != "") {
                // 给房屋坐落地址赋值
                $("#fyZldz").val($('#fyDh option:selected').text() + fyCh + "-" + fyFh);
                // 异步判断该房室是否存在，如果已存在，给用户已提示哦
                $.ajax({
                    type: "POST",
                    url: "checkFyFhIsExists.action",
                    data: { "fangyuanEntity.fyID": fyID, "fangyuanEntity.fyXqCode": fyXqCode, "fangyuanEntity.fyDhCode": fyDh, "fangyuanEntity.fyCh": fyCh, "fangyuanEntity.fyFh": fyFh },
                    dataType: "text",
                    success: function (data) {
                        // 					alert(data);
                        // 如果返回数据不为空，更改“房源信息”
                        if (data == "1") {
                            art.dialog({ icon: 'error', title: '友情提示', drag: false, resize: false, content: '该房室在系统中已经存在哦，\n请维护其他房室数据', ok: true, });
                            $("#fyFh").css("background", "#EEE");
                            $("#fyFh").focus();
                            return false;
                        }
                    }
                });
            }
        }

        /** 检测房源房号是否存在并提交form  **/
        function checkFyFhSubmit() {
            // 分别获取小区编号、栋号、层号、房号
            var fyID = $('#fyID').val();
            var fyXqCode = $("#fyXq").val();
            var fyDh = $("#fyDh").val();
            var fyCh = $("#fyCh").val();
            var fyFh = $("#fyFh").val();
            if (fyXqCode != "" && fyDh != "" && fyCh != "" && fyFh != "") {
                // 给房屋坐落地址赋值
                $("#fyZldz").val($('#fyDh option:selected').text() + fyCh + "-" + fyFh);
                // 异步判断该房室是否存在，如果已存在，给用户已提示哦
                $.ajax({
                    type: "POST",
                    url: "checkFyFhIsExists.action",
                    data: { "fangyuanEntity.fyID": fyID, "fangyuanEntity.fyXqCode": fyXqCode, "fangyuanEntity.fyDhCode": fyDh, "fangyuanEntity.fyCh": fyCh, "fangyuanEntity.fyFh": fyFh },
                    dataType: "text",
                    success: function (data) {
                        // 					alert(data);
                        // 如果返回数据不为空，更改“房源信息”
                        if (data == "1") {
                            art.dialog({ icon: 'error', title: '友情提示', drag: false, resize: false, content: '该房室在系统中已经存在哦，\n请维护其他房室数据', ok: true, });
                            $("#fyFh").css("background", "#EEE");
                            $("#fyFh").focus();
                            return false;
                        } else {
                            $("#submitForm").attr("action", "/xngzf/archives/saveOrUpdateFangyuan.action").submit();
                        }
                    }
                });
            }
            return true;
        }

        /** 表单验证  **/
        function validateForm() {
            if ($("#fyXqName").val() == "") {
                art.dialog({ icon: 'error', title: '友情提示', drag: false, resize: false, content: '填写房源小区', ok: true, });
                return false;
            }
            if ($("#fyDh").val() == "") {
                art.dialog({ icon: 'error', title: '友情提示', drag: false, resize: false, content: '填写房源栋号', ok: true, });
                return false;
            }
            if ($("#fyCh").val() == "") {
                art.dialog({ icon: 'error', title: '友情提示', drag: false, resize: false, content: '填写房源层号', ok: true, });
                return false;
            }
            if ($("#fyFh").val() == "") {
                art.dialog({ icon: 'error', title: '友情提示', drag: false, resize: false, content: '填写房源房号', ok: true, });
                return false;
            }
            if ($("#fyZongMj").val() == "") {
                art.dialog({ icon: 'error', title: '友情提示', drag: false, resize: false, content: '填写房源面积', ok: true, });
                return false;
            }
            if ($("#fyJizuMj").val() == "") {
                art.dialog({ icon: 'error', title: '友情提示', drag: false, resize: false, content: '填写计租面积', ok: true, });
                return false;
            }
            if ($("#fyZldz").val() == "") {
                art.dialog({ icon: 'error', title: '友情提示', drag: false, resize: false, content: '填写房源座落地址', ok: true, });
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="submitForm" name="submitForm" action="" method="post" runat="server">
        <input type="hidden" name="fyID" value="14458625716623" id="fyID" />
        <div id="container">
            <div class="ui_content">
                <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
                    <tr>
                        <td class="ui_text_rt" width="50%">身 份 证 号</td>
                        <td class="ui_text_lt">
                            <asp:TextBox ID="idcard" CssClass="ui_input_txt02" ReadOnly="true" runat="server">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui_text_rt">姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 名</td>
                        <td class="ui_text_lt">
                            <asp:TextBox ID="name" CssClass="ui_input_txt02" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui_text_rt">手&nbsp;&nbsp; 机&nbsp;&nbsp; 号</td>
                        <td class="ui_text_lt">
                            <asp:TextBox ID="tel" CssClass="ui_input_txt02" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="ui_text_rt">等&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 级</td>
                        <td class="ui_text_lt">
                            <asp:DropDownList ID="level" runat="server" CssClass="ui_select02">
                                <asp:ListItem Value="普通">普通</asp:ListItem>
                                <asp:ListItem Value="VIP">VIP</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="submitButton" Text="提交" CssClass="ui_input_btn01" runat="server" OnClick="submitButton_Click" /></td>
                        <td>
                            <asp:Button ID="cancelButton" Text="取消" CssClass="ui_input_btn01" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
    <div style="display: none">
        <script src='http://v7.cnzz.com/stat.php?id=155540&web_id=155540' language='JavaScript' charset='gb2312'></script>
    </div>
</body>
</html>
