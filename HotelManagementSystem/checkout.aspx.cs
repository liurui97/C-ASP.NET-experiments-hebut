using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class checkout : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string Cno = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Cno = Request.QueryString["id"].ToString();
        if (Session["username"] == null)
        {
            Response.Write("<script language=javascript>window.alert('为了系统安全，请您重新登陆!');window.location.href('./login.aspx');</script>");
        }
        else
        {
            if (!IsPostBack)
            {
                ViewState["SortOrder"] = "CRarrive";
                ViewState["OrderDire"] = "ASC";

                Cno = Request.QueryString["id"].ToString();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
                conn.Open();
                SqlCommand mycoml = new SqlCommand("select * from CR where Cno='"+Cno+"'", conn);
                if (null == mycoml.ExecuteScalar())
                {
                    conn.Close();
                    Response.Write("<script language=javascript>window.alert('暂时没有此客户订房信息');</script>");
                }
                else
                {
                    conn.Close();
                    Show_RoomList();
                }
            }
        }
    }

    protected void Show_RoomList()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
        conn.Open();

        string str="select * from CR where Cno='"+Cno+"'";
        SqlDataAdapter myadapter = new SqlDataAdapter(str, conn);
        myadapter.Fill(ds, "CR");
        int count = ds.Tables[0].Rows.Count;        
        //排序用的
        /*DataView myView = new DataView(ds.Tables["CR"]);
        string sort=(string)ViewState["SortOrder"]+" "+(string)ViewState["OrderDire"];

        myView.Sort = sort;*/
        //结束排序
        detail.DataSource = ds;
        /*detail.DataSource = myView;
        detail.DataKeyNames = new string[] { "Rno" };*/
        detail.DataBind();
        conn.Close();
    }
    protected void detail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void detail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        /*SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
        try
        {
            conn.Open();

            string query = "select * from CR where Cno='" + Cno + "'";
            SqlDataAdapter myadapter = new SqlDataAdapter(query, conn);
            
            string Rno = detail.DataKeys[e.RowIndex].Value.ToString();
            string deleteString = "delete from CR where Cno='" + Cno + "' and Rno='" + Rno + "'";

            //Response.Write(Cno + "," + Rno);
            //这一部分是在数据库中删除数据
            //删除CR表
            SqlCommand mycomm = new SqlCommand(deleteString, conn);
            mycomm.ExecuteNonQuery();

            //删除CT表
            deleteString = "delete from RT where Rno='" + Rno + "'";
            mycomm = new SqlCommand(deleteString, conn);
            mycomm.ExecuteNonQuery();

            //这只是从数据表中查出，但是没有删除数据库
            myadapter.DeleteCommand = new SqlCommand(deleteString, conn);

            DataSet ds = new DataSet();
            myadapter.Fill(ds, "CR");

            detail.DataBind();

            Response.Write("<script language=avascript>window.alert('退房成功!');</script>");
            conn.Close();
        }
        catch (Exception ex)
        {
            Response.Write("<script language=avascript>window.alert('退房失败!');</script>");
        }
        finally
        {
            conn.Close();
        } */
        string url="Account.aspx?Cno="+Cno;
        Response.Redirect(url);
    }
    protected void export_Click(object sender, EventArgs e)
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
        detail.RenderControl(htw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void lnkbtnFrist_Click(object sender, EventArgs e)
    {

    }
    protected void lnkbtnPre_Click(object sender, EventArgs e)
    {

    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {

    }
    protected void lnkbtnLast_Click(object sender, EventArgs e)
    {

    }
    protected void detail_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void detail_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sPage = e.SortExpression;
        if (ViewState["SortOrder"].ToString() == sPage)
        {
            if (ViewState["OrderDire"].ToString() == "DESC")
            {
                ViewState["OrderDire"] = "ASC";
            }
            else
            {
                ViewState["OrderDire"] = "DESC";
            }
        }
        else
        {
            ViewState["SortOrder"] = e.SortExpression;
        }
        Show_RoomList();
    }
    protected void detail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //执行循环，保证每条数据都可以更新
        for (int i = -1; i < detail.Rows.Count; i++)
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