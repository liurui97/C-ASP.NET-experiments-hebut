using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataSet ds2 = new DataSet();
    DataSet ds3 = new DataSet();
    string arriveTime = "";
    string leaveTime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Write("<script language=javascript>window.alert('为了系统安全，请您重新登陆!');window.location.href('./login.aspx');</script>");
        }
        else
        {
            string Cno = Request.QueryString["Cno"];
            if(!String.IsNullOrEmpty(Cno))
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
                conn.Open();
                //开始查找房费并添加到第一个表
                string selectstring = "select top 1 C.Cno,Rpr,CRarrive,CRleave from Room R,CR C where R.Rno = C.Rno and C.Cno = '" + Cno + "' order by C.CRleave DESC";
                SqlDataAdapter myadapter = new SqlDataAdapter(selectstring, conn);
                myadapter.Fill(ds, "account");
                account.DataSource = ds;
                account.DataBind();

                arriveTime = account.Rows[0].Cells[2].Text;
                leaveTime = account.Rows[0].Cells[3].Text;
                DateTime arrivedt = Convert.ToDateTime(arriveTime);
                DateTime leavedt = Convert.ToDateTime(leaveTime);
                int daycount = leavedt.Day - arrivedt.Day;
                string Rpr = account.Rows[0].Cells[1].Text;
                float roomcost = daycount * float.Parse(Rpr);
                (account.Rows[0].Cells[4].Controls[1] as Label).Text = "" + roomcost;

                //开始查找物品消费并添加到第二个表
                selectstring = "select Cno,RTime,Gname,Gprice,Rnum from Record, Goods where Record.RTime between '" + arriveTime + "' and '" + leaveTime + "' and Record.Gno = Goods.Gno and Cno = '" + Cno + "'";
                SqlDataAdapter myadapter2 = new SqlDataAdapter(selectstring, conn);
                myadapter2.Fill(ds2, "account2");
                account2.DataSource = ds2;
                account2.DataBind();
                float goodcost;
                float sumgoodcost = 0;
                for (int i = 0; i < this.account2.Rows.Count; i++)
                {
                    goodcost = float.Parse(account2.Rows[i].Cells[3].Text) * int.Parse(account2.Rows[i].Cells[4].Text);
                    (account2.Rows[i].Cells[5].Controls[1] as Label).Text = "" + goodcost;
                    sumgoodcost += goodcost;
                }

                //填写汇总表
                selectstring = "select top 1 Cno from Client where Cno ='" + Cno + "'";
                SqlDataAdapter myadapter3 = new SqlDataAdapter(selectstring, conn);
                myadapter3.Fill(ds3, "account3");
                account3.DataSource = ds3;
                account3.DataBind();

                (account3.Rows[0].Cells[1].Controls[1] as Label).Text = "" + roomcost;
                (account3.Rows[0].Cells[2].Controls[1] as Label).Text = "" + sumgoodcost;
                (account3.Rows[0].Cells[3].Controls[1] as Label).Text = "" + (sumgoodcost + roomcost);
                conn.Close();
            }
            
        }

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
        account.RenderControl(htw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        this.Image1.Visible = true;
    }
    protected void goback(object sender, EventArgs e) {
        Response.Redirect("room.aspx");
    }


    protected void search_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
        conn.Open();
        //开始查找房费并添加到第一个表
        string selectstring = "select top 1 C.Cno,Rpr,CRarrive,CRleave from Room R,CR C where R.Rno = C.Rno and C.Cno = '" + TextBox1.Text.ToString().Trim() + "' order by C.CRleave DESC";
        SqlDataAdapter myadapter = new SqlDataAdapter(selectstring, conn);
        myadapter.Fill(ds, "account");
        account.DataSource = ds;
        account.DataBind();

        arriveTime = account.Rows[0].Cells[2].Text;
        leaveTime = account.Rows[0].Cells[3].Text;
        DateTime arrivedt = Convert.ToDateTime(arriveTime);
        DateTime leavedt = Convert.ToDateTime(leaveTime);
        int daycount = leavedt.Day - arrivedt.Day;
        string Rpr = account.Rows[0].Cells[1].Text;
        float roomcost = daycount * float.Parse(Rpr);
        (account.Rows[0].Cells[4].Controls[1] as Label).Text = "" + roomcost;

        //开始查找物品消费并添加到第二个表
        selectstring = "select Cno,RTime,Gname,Gprice,Rnum from Record, Goods where Record.RTime between '" + arriveTime + "' and '" + leaveTime + "' and Record.Gno = Goods.Gno and Cno = '" + TextBox1.Text.ToString().Trim()+"'";
        SqlDataAdapter myadapter2 = new SqlDataAdapter(selectstring, conn);
        myadapter2.Fill(ds2,"account2");
        account2.DataSource = ds2;
        account2.DataBind();
        float goodcost;
        float sumgoodcost=0;
        for (int i = 0; i < this.account2.Rows.Count; i++)
        {
            goodcost= float.Parse(account2.Rows[i].Cells[3].Text)*int.Parse(account2.Rows[i].Cells[4].Text);
            (account2.Rows[i].Cells[5].Controls[1] as Label).Text = "" + goodcost;
            sumgoodcost += goodcost;
        }

        //填写汇总表
        selectstring = "select top 1 Cno from Client where Cno ='" + TextBox1.Text.ToString().Trim() + "'";
        SqlDataAdapter myadapter3 = new SqlDataAdapter(selectstring, conn);
        myadapter3.Fill(ds3, "account3");
        account3.DataSource = ds3;
        account3.DataBind();
        
        (account3.Rows[0].Cells[1].Controls[1] as Label).Text = "" + roomcost;
        (account3.Rows[0].Cells[2].Controls[1] as Label).Text = "" + sumgoodcost;
        (account3.Rows[0].Cells[3].Controls[1] as Label).Text = "" + (sumgoodcost+ roomcost);
        conn.Close();
    }
    protected void account_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //执行循环，保证每条数据都可以更新
        for (int i = -1; i < account.Rows.Count; i++)
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
    protected void account2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //执行循环，保证每条数据都可以更新
        for (int i = -1; i < account2.Rows.Count; i++)
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
    protected void account3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //执行循环，保证每条数据都可以更新
        for (int i = -1; i < account3.Rows.Count; i++)
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