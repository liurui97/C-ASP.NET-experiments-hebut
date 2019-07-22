<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户注册</title>
    <style type="text/css">
        .auto-style1 {
            width: 70px;
        }
        .auto-style2 {
            height: 70px;
            width: 63px;
        }
        .auto-style3 {
            height: 105px;
            width: 63px;
        }
    </style>
</head>
<body background="images/back1.jpg">
    <!--这是一个表单-->
    <form runat="server" id="form2">
        <!--表单中的一个表-->
        <table border="0" cellpadding="0" align="center" style="width: 900px">
            <tr valign="top">
                <!--其中一行的内容是一个表-->
                <td align="center" style="height:561px">
                    <table style="width:500px;height:338px;border-right:blue thin solid ;border-top:blue thin solid;border-left:blue thin solid;border-bottom:blue thin solid;">
                        <tr>
                            <td style="width:849px;height:21px;font-size:50px;background-color:aqua;"align="center">会员注册</td>
                        </tr>
                        <tr>
                            <td style="width:849px;height:331px;"align="center">
                                <!--在单元格里面嵌套一个表-->
                                <table style="width:859px; height:270px">
                                    <tr>
                                        <td class="auto-style1">姓名:</td>
                                        <td style="text-align:left;width:232px;">
                                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">性别:</td>
                                        <td style="text-align:left;width:232px;"><!--<asp:ListItem Text="男" Value="male" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="女" Value="female"></asp:ListItem>-->
                                            <asp:RadioButtonList ID="Sex" runat="server" RepeatDirection="Horizontal" BackColor="White" style="margin-left: 0px">
                                                
                                            </asp:RadioButtonList>                                                
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">血型:</td>
                                        <td style="text-align:left;width:232px"><!--<asp:ListItem>O型</asp:ListItem>
                                                <asp:ListItem>A型</asp:ListItem>
                                                <asp:ListItem>B型</asp:ListItem>
                                                <asp:ListItem>AB型</asp:ListItem>-->
                                            <asp:DropDownList ID="Blood" runat="server" OnSelectedIndexChanged="Blood_SelectedIndexChanged">
                                                
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">兴趣:</td>
                                        <td style="text-align:left;width:232px;height:47px;vertical-align:super;"><!--<asp:ListItem>绘画</asp:ListItem>
                                                <asp:ListItem>唱歌</asp:ListItem>
                                                <asp:ListItem>跳舞</asp:ListItem>
                                                <asp:ListItem>旅游</asp:ListItem>-->
                                            <asp:CheckBoxList ID="Intrest" runat="server" RepeatDirection="Horizontal" BackColor="White" Width="336px" OnSelectedIndexChanged="Intrest_SelectedIndexChanged">
                                                
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3">头像:</td>
                                        <td style="width:232px;text-align:left;color:#ff3333;height:105px;">
                                            <table style="background-color:white">
                                                <tr>
                                                    <td style="width:55px;height:54px">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/12.jpg" Height="143px" Width="142px"/>
                                                    </td>
                                                    <td style="width:55px;height:54px">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/13.jpg" Height="140px" Width="148px"/>
                                                    </td>
                                                    <td style="width:55px;height:54px">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/14.jpg" Height="142px" Width="154px" />
                                                    </td>
                                                    <td style="width:55px;height:54px">
                                                        <asp:Image ID="Image4" runat="server" ImageUrl="~/images/15.jpg" Height="139px" Width="146px" />
                                                    </td>
                                                    <td style="width:55px;height:54px">
                                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/images/16.jpg" Height="138px" Width="142px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:55px">
                                                        <asp:RadioButton ID="R1" runat="server" GroupName="pic" Text="女孩1" />
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="R2" runat="server" GroupName="pic" Text="女孩2" />
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="R3" runat="server" GroupName="pic" Text="女孩3" />
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="R4" runat="server" GroupName="pic" Text="女孩4" />
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="R5" runat="server" GroupName="pic" Text="女孩5" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td colspan="3";style="height:40px" valign="middle">
                                            <asp:Button ID="show" runat="server" Text="注册" OnClick="show_Click1" Width="81px" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Panel ID="MSG" runat="server" Height="90px" Width="125px" Visible="false">
                                    <asp:Label ID="MSGName" runat="server"></asp:Label><br />
                                    <asp:Label ID="MSGSex" runat="server"></asp:Label><br />
                                    <asp:Label ID="MSGBlood" runat="server"></asp:Label><br />
                                    <asp:Label ID="MSGIntert" runat="server"></asp:Label><br />
                                    <asp:Label ID="MSGPic" runat="server"></asp:Label>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>               
            </tr>
        </table>
    </form>
</body>
</html>
