using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Goods : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string arriveTime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Write("<script language=javascript>window.alert('为了系统安全，请您重新登陆!');window.location.href('./login.aspx');</script>");
        }
        else
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
                conn.Open();
                SqlCommand mycoml = new SqlCommand("select * from Goods", conn);
                if (null == mycoml.ExecuteScalar())
                {
                    conn.Close();
                    Response.Write("<script language=javascript>window.alert('暂时没有商品信息');</script>");
                }
                else
                {
                    conn.Close();
                    Show_GoodsList();
                }
            }
        }

    }
    protected void Show_GoodsList()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
        conn.Open();

        SqlDataAdapter myadapter = new SqlDataAdapter("select * from Goods", conn);
        myadapter.Fill(ds, "Goods");

        goods.DataSource = ds;
        goods.DataBind();

        this.ddlCurrentPage.Items.Clear();
        for (int i = 1; i <= this.goods.PageCount; i++)
        { this.ddlCurrentPage.Items.Add(i.ToString()); }
        this.ddlCurrentPage.SelectedIndex = this.goods.PageIndex;

        conn.Close();
    }

    protected bool Delete(string Cno)
    {
        return true;
    }
    protected void exportBtn_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AppendHeader("Content-Disposition", "attachment;filename=FileName.xls");
        //设置输出流为简体中文
        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        //设置输出文件类型为excel文件。
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        goods.RenderControl(htw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        goods.PageIndex = ddlCurrentPage.SelectedIndex;
        Show_GoodsList();
    }
    protected void lnkbtnFrist_Click(object sender, EventArgs e)
    {
        this.goods.PageIndex = 0;
        Show_GoodsList();
    }
    protected void lnkbtnPre_Click(object sender, EventArgs e)
    {
        if (this.goods.PageIndex > 0)
        {
            this.goods.PageIndex = this.goods.PageIndex - 1;
            Show_GoodsList();
        }
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        if (this.goods.PageIndex < this.goods.PageCount)
        {
            this.goods.PageIndex = this.goods.PageIndex + 1;
            Show_GoodsList();
        }
    }
    protected void lnkbtnLast_Click(object sender, EventArgs e)
    {
        this.goods.PageIndex = this.goods.PageCount;
        Show_GoodsList();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string msg = "123";
        Page.Controls.Add(new LiteralControl("window.alert('" + msg + "')"));
    }
    protected void ImageButton1_Click(object sender, GridViewCommandEventArgs e)
    {
        int id = 0;
        GridView mygv = new GridView();
        mygv = (GridView)Page.FindControl("goods");
        if (mygv != null)
        {
            if (e.CommandName == "send")
            {
                id = Convert.ToInt32(e.CommandArgument);
            }
            TextBox textBox = new TextBox();
            textBox = (TextBox)mygv.Rows[id].FindControl("TextBox1");
            if (textBox != null)
            {
                int num = int.Parse(textBox.Text);
                num++;
                textBox.Text = "" + num;
            }
            else
            {
                string msg = "123";
                Page.Controls.Add(new LiteralControl("window.alert('" + msg + "')"));
            }
        }

    }

    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string time = DateTime.Now.ToString();
        //建立数据库连接
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
        conn.Open();
        //插入用户信息
        string insertString = "";
        string num = "";
        for (int i = 0; i < this.goods.Rows.Count; i++)
        {
            num = (goods.Rows[i].Cells[4].Controls[1] as DropDownList).Text;
            if (!num.Equals("0"))
            {
                insertString= "insert into Record values ('"+this.TextBox1.Text.ToString()+"','"+ goods.Rows[i].Cells[0].Text+"','"+ time+"','"+num+"')";
                Response.Write(insertString);
                SqlCommand mycomm = new SqlCommand(insertString, conn);
                mycomm.ExecuteNonQuery();
            }
            else {
               
            }
        }
        Response.Write("<script language=javascript>window.alert('购买成功!');</script>");
        conn.Close();
    }
    protected void goods_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //执行循环，保证每条数据都可以更新
        for (int i = -1; i < goods.Rows.Count; i++)
        {
            //首先判断是否是数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标停留时更改背景色
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#00A9FF'");
                //当鼠标移开时还原背景色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }
    }
}