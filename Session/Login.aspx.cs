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

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        Session["name"] = this.UserName.Text.ToString();
        Session["pass"] = this.PassWord.Text.ToString();
        Session["xianshi"] = this.label1.Text.ToString();
        Response.Redirect("Display.aspx");
    }
}