using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;            //引入命名空间
using System.Data.SqlClient;  //引入命名空间
using System.Configuration;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string sql = "insert into Room values('" + TextBox1.Text.ToString() + "','" + TextBox2.Text.ToString() + "','" + TextBox3.Text.ToString() + "','" + TextBox5.Text.ToString() + "')";
            SqlConnection conn = new SqlConnection("Server=localhost;Database=Hotel;User ID=sa;PWD=123456");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            Response.Write("<script>alert('添加成功');window.location.href=('Default.aspx');</script>");
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {

    }
}