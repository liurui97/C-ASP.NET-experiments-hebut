<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoEdit.aspx.cs" Inherits="InfoEdit" EnableEventValidation="false" %>

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
						        <asp:DropDownList ID="Status" runat="server" Height="25px" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="Status_SelectedIndexChanged">
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
                                <input id="DateTime" type="text" runat="server" onclick="WdatePicker()" placeholder="请选择日期" Height="25px" Width="80px" Class="Wdate"/>&nbsp;
                                <asp:DropDownList ID="Hour" runat="server" Height="25px" Width="60px">
                                    <asp:ListItem>00</asp:ListItem>
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>19</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                    <asp:ListItem>23</asp:ListItem>
                                </asp:DropDownList>
                                时&nbsp;
                                <asp:DropDownList ID="Second" runat="server" Height="25px" Width="60px">
                                    <asp:ListItem>00</asp:ListItem>
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>19</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                    <asp:ListItem>23</asp:ListItem>
                                    <asp:ListItem>24</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>26</asp:ListItem>
                                    <asp:ListItem>27</asp:ListItem>
                                    <asp:ListItem>28</asp:ListItem>
                                    <asp:ListItem>29</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>31</asp:ListItem>
                                    <asp:ListItem>32</asp:ListItem>
                                    <asp:ListItem>33</asp:ListItem>
                                    <asp:ListItem>34</asp:ListItem>
                                    <asp:ListItem>35</asp:ListItem>
                                    <asp:ListItem>36</asp:ListItem>
                                    <asp:ListItem>37</asp:ListItem>
                                    <asp:ListItem>38</asp:ListItem>
                                    <asp:ListItem>39</asp:ListItem>
                                    <asp:ListItem>40</asp:ListItem>
                                    <asp:ListItem>41</asp:ListItem>
                                    <asp:ListItem>42</asp:ListItem>
                                    <asp:ListItem>43</asp:ListItem>
                                    <asp:ListItem>44</asp:ListItem>
                                    <asp:ListItem>45</asp:ListItem>
                                    <asp:ListItem>46</asp:ListItem>
                                    <asp:ListItem>47</asp:ListItem>
                                    <asp:ListItem>48</asp:ListItem>
                                    <asp:ListItem>49</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                    <asp:ListItem>51</asp:ListItem>
                                    <asp:ListItem>52</asp:ListItem>
                                    <asp:ListItem>53</asp:ListItem>
                                    <asp:ListItem>54</asp:ListItem>
                                    <asp:ListItem>55</asp:ListItem>
                                    <asp:ListItem>56</asp:ListItem>
                                    <asp:ListItem>57</asp:ListItem>
                                    <asp:ListItem>58</asp:ListItem>
                                    <asp:ListItem>59</asp:ListItem>
                                    <asp:ListItem>60</asp:ListItem>
                                </asp:DropDownList>
                                分
					        </td>
				        </tr>
				        <tr>
					        <td>&nbsp;</td>
					        <td class="ui_text_lt">
                                <asp:Button ID="SubmitBtn" runat="server" CssClass="ui_input_btn01" Text="提交" OnClick="SubmitBtn_Click" />
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
