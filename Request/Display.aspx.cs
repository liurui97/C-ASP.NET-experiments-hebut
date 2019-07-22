using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Display : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("获取表单数据并显示：" + "<br>");
        Response.Write("用户名：" + Request.QueryString["name"] + "<br>");
        Response.Write("密码：" + Request.QueryString["pass"] + "<br>");
        Response.Write("获取用户浏览器信息并显示：" + "<br>");
        HttpBrowserCapabilities bc = Request.Browser;
        Response.Write("浏览器=" + bc.Browser + "<br>");
        Response.Write("版本=" + bc.Version + "<br>");
        Response.Write("使用平台=" + bc.Platform + "<br>");
        Response.Write("是否支持测试版=" + bc.Beta + "<br>");
        Response.Write("是否为16位环境"+bc.Win16+"<br>");
        Response.Write("是否为32位环境"+bc.Win32+"<br>");
        Response.Write("是否支持框架="+bc.Frames+"<br>");
        Response.Write("是否支持表格"+bc.Tables+"<br>");
        Response.Write("是否支持Cookie"+bc.Cookies+"<br>");
        Response.Write("是否支持VB Script"+bc.VBScript+"<br>");
        Response.Write("是否支持Java Script"+bc.JavaScript+"<br>");
        Response.Write("是否支持Java Applets"+bc.JavaApplets+"<br>");
        Response.Write("是否支持ActiveX Controls="+bc.ActiveXControls+"<br>");
        Response.Write("获取服务器端环境并显示"+"<br>");
        Response.Write("当前网页虚拟路径"+Request.ServerVariables["URL"]+"<br>");
        Response.Write("实际路径"+Request.ServerVariables["PATH_TRANSLATED"]+"<br>");
        Response.Write("服务器名或IP"+Request.ServerVariables["SERVER_NAME"]+"<br>");
        Response.Write("服务器连接端口" + Request.ServerVariables["SERVER_PORT"]+"<br>");
        Response.Write("HTTP版本" + Request.ServerVariables["SERVER_PORTOCOL"]);
        Response.Write("客户主机名" + Request.ServerVariables["REMOTE_HOST"] + "<br>");
        Response.Write("浏览器" + Request.ServerVariables["HTTP_USER_AGENT"] + "<br>");
    }
}