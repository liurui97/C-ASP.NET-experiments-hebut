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
        if (Session["name"] == null || Session["pass"] == null)
        {
            Response.Write("<script language=javascript>window.alert('为了您的安全，请先登录!');window.location.href=('Login.aspx');</scrip>");
        }
        else
        {
            label2.Text = Session["xianshi"].ToString();
        }
    }
}