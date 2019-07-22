using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<font color=white>现在是：" + DateTime.Now.ToString() + "</font><br>");
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if (UserName.Text == "" || PassWord.Text == "")
        {
            Response.Write("<script language=javascript>window.alert('用户名和密码不能为空!');</script>");
        }
        else if (UserName.Text == "admin"&&PassWord.Text == "pass"){
            Response.Redirect("<script language='javascript'>window.showModalDialog('Show.aspx')</script>");
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('用户名和密码不正确!');</script>");
        }
    }
}