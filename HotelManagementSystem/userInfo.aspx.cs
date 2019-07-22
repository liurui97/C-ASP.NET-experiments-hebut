using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Write("<script language=javascript>window.alert('请先登录!');window.location.href('./login.aspx');</script>");
        }
        if (!IsPostBack)
        {
            string Cno=Request.QueryString["id"].ToString();
            SqlConnection conn = new SqlConnection("Server=localhost;Database=Hotel;UID=sa;PWD=123456");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Client Where Cno='" + Cno + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            //将用户信息填入
            if (dr.Read())
            {
                this.idcard.Text = dr["Cno"].ToString();
                this.name.Text = dr["Cname"].ToString();
                this.tel.Text = dr["Ctel"].ToString();
                this.level.Items.FindByValue(dr["Clev"].ToString()).Selected = true;
            }
            else
            {
                Response.Write("<script language=javascript>window.alert('查看用户信息出现错误，请稍后重试!');window.loction.href('./client_list.aspx');</script>");
            }
            conn.Close();
        }
    }
    protected void submitButton_Click(object sender, EventArgs e)
    {
        string Cno = Request.QueryString["id"].ToString();
        SqlConnection conn = new SqlConnection("Server=localhost;Database=Hotel;UID=sa;PWD=123456");
        conn.Open();

        //获取三个文本框和一个下拉菜单的内容
        string nameString = this.name.Text.ToString();
        string telString = this.tel.Text.ToString();
        string levelString = this.level.SelectedValue.ToString();

        SqlCommand cmd = new SqlCommand("update Client set Cname='"+nameString+"',Ctel='"+telString+"',Clev='"+levelString+"' where Cno='"+Cno+"'", conn);
        int count= cmd.ExecuteNonQuery();

        if (count > 0)
        {
            Response.Write("<script language=javascript>window.alert('修改成功!');</script>");
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('修改失败!');</script>");
        }

        conn.Close();
    }
}