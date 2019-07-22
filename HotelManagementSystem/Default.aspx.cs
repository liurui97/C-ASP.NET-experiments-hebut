using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;            //引入命名空间
using System.Data.SqlClient;  //引入命名空间
using System.Configuration;
using System.Data.OleDb;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=yes'";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //初始化table
            bind_gv();
        }

        if (!Page.IsPostBack)
        {
            SqlConnection con = new SqlConnection("Server=localhost;Database=Hotel;User ID=sa;PWD=123456");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from [Room]";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            this.DropDownList5.DataSource = ds;
            this.DropDownList5.DataTextField = "Rtype";
            this.DropDownList5.DataBind();
            this.DropDownList6.DataSource = ds;
            this.DropDownList6.DataTextField = "Rpr";
            this.DropDownList6.DataBind();
            this.DropDownList8.DataSource = ds;
            this.DropDownList8.DataTextField = "Rstatus";
            this.DropDownList8.DataBind();
        }
        string fileName = "content/student.xls";
        fileName = Server.MapPath(fileName);
        connStr = string.Format(connStr, fileName);//连接字符串
    }
    private void BindList()
    {
        string sql = "select * from [Sheet1$]";
        OleDbConnection conn = new OleDbConnection(connStr);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);

        OleDbDataAdapter da = new OleDbDataAdapter(cmd);

        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind_gv();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {//取消编辑状态的事件

        GridView1.EditIndex = -1;

        bind_gv();

    }
    //更新
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        string Rno = GridView1.DataKeys[e.RowIndex].Value.ToString();
        //防止非法的输入，预防脚本攻击 
        string Rtype = Server.HtmlDecode(((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString());
        string Rpr = Server.HtmlDecode(((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString());
        string Rlocal = Server.HtmlDecode(((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString());
        SqlConnection Con = new SqlConnection("Server=localhost;Database=Hotel;User ID=sa;PWD=123456");
        try
        {
            string UpdateStr = "UPDATE Room SET Rtype='" + Rtype + "',Rlocal='" + Rlocal + "' WHERE Rno='" + Rno + "'";
            SqlCommand Cmd = new SqlCommand(UpdateStr, Con);
            //尽可能晚的打开连接，尽早的关闭连接 
            Con.Open();
            Cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            bind_gv();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('编辑出错，请重新填写');</script>");
            GridView1.EditIndex = -1;
            bind_gv();
        }
        //要及时的关闭打开的连接，提高程序的性能 
        finally
        {
            Con.Dispose();
        } 
    }

    //删除
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sqlstr = "delete from Room where Rno='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        SqlConnection sqlcon = new SqlConnection("Server=localhost;Database=Hotel;User ID=sa;PWD=123456");
        SqlCommand sqlcom = new SqlCommand(sqlstr, sqlcon);
        sqlcon.Open();
        sqlcom.ExecuteNonQuery();
        sqlcon.Close();
        bind_gv();
    }
    protected void bind_gv()
    {
        string sqlstr = "select * from Room";
        SqlConnection sqlcon = new SqlConnection("Server=localhost;Database=Hotel;User ID=sa;PWD=123456");
        SqlDataAdapter myda = new SqlDataAdapter(sqlstr, sqlcon);
        DataSet myds = new DataSet();
        sqlcon.Open();
        myda.Fill(myds, "Room");
        GridView1.DataSource = myds;
        GridView1.DataKeyNames = new string[] { "Rno" };
        GridView1.DataBind();
        sqlcon.Close();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Server=localhost;Database=Hotel;User ID=sa;PWD=123456");
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = string.Format("select * from [Room] where Rtype='{0}'", this.DropDownList5.SelectedValue.ToString());//按照第一个下拉框选中的值搜索！
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        this.DropDownList5.DataSource = ds;
        this.DropDownList5.DataTextField = "Rtype";
        this.DropDownList5.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection("Server=localhost;Database=Hotel;User ID=sa;PWD=123456");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = string.Format("select * from [Room] where Rtype='{0}'", this.DropDownList5.SelectedValue.ToString());
            //cmd.CommandType = CommandType.Text;
            //Response.Write(cmd.CommandText);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            this.GridView1.DataSource = ds; //将查询出的结果给gridview展示
            this.GridView1.DataBind();
        }
        catch (Exception ep)
        {
            Response.Write("<script> alert('请正确输入内容！')</script>");
        }
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Server=localhost;Database=Hotel;User ID=sa;PWD=123456");
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = string.Format("select * from [Room] where Rpr={0}", this.DropDownList6.SelectedValue.ToString());//按照第一个下拉框选中的值搜索！
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        this.DropDownList6.DataSource = ds;
        this.DropDownList6.DataTextField = "Rpr";
        this.DropDownList6.DataBind();
    }

    protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Server=localhost;Database=Hotel;User ID=sa;PWD=123456");
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = string.Format("select * from [Room] where Rlocal={0}", this.DropDownList8.SelectedValue.ToString());//按照第一个下拉框选中的值搜索！
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        this.DropDownList8.DataSource = ds;
        this.DropDownList8.DataTextField = "Rstatus";
        this.DropDownList8.DataBind();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bind_gv();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //执行循环，保证每条数据都可以更新
        for (int i = -1; i < GridView1.Rows.Count; i++)
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
        // 取得显示页数的那一列。
        GridViewRow pagerRow = GridView1.BottomPagerRow;
        if (pagerRow != null)
        {
            // 取得显示目前所在页数的 Label 控件。
            Label pageLabel = (Label)(pagerRow.Cells[0].FindControl("lblCurrentPage"));

            if (pageLabel != null)
            {
                // 计算目前所在的页数。
                int currentPage = GridView1.PageIndex + 1;

                pageLabel.Text = currentPage.ToString() +
                    " / " + GridView1.PageCount.ToString();
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default2.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //1.选择的文件上传到服务器的文件夹
            string type = Path.GetExtension(FileUpload1.FileName);
            string fileNamae = "content/" +FileUpload1.FileName;
            //保存
            FileUpload1.SaveAs(Server.MapPath(fileNamae));
                
            //2.把刚上传的这个excel文件中的内容查询出来
            string Rno = "";
            string Rtype = "";
            string Rpr = "";
            string Rlocal = "";
            int i = 0;
            string sql = "select * from [Sheet1$]";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql,conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds=new DataSet();
            da.Fill(ds, "aa");
            DataTable dt = ds.Tables["aa"];
           
            foreach (DataRow item in dt.Rows)
            {
                Rno = item["Rno"].ToString();
                Rtype = item["Rtype"].ToString();
                Rpr = item["Rpr"].ToString();
                Rlocal = item["Rlocal"].ToString();
                string sqli = "insert into sheet1 values('@a','@b','@c','@d')";
                SqlConnection conni = new SqlConnection("Server=localhost;Database=Hotel;User ID=sa;PWD=123456");
                conni.Open();
                SqlCommand cmdi = new SqlCommand(sqli, conni);
                SqlParameter[] pm = new SqlParameter[4];
                pm[0] = new SqlParameter("@a", Rno);
                pm[1] = new SqlParameter("@b", Rtype);
                pm[2] = new SqlParameter("@c", Rpr);
                pm[3] = new SqlParameter("@d", Rlocal);
                foreach (SqlParameter item1 in pm)
                {
                    cmdi.Parameters.Add(item1);
                }
               i+= cmdi.ExecuteNonQuery();
               conni.Close();
            }
            if (i>1)
            {
                Response.Write("导入成功");
            }
            else
            {
                Response.Write("导入失败");
            }
            
            conn.Close();
            //一条条的插入列sqlserver数据库中
            
            
          
        }
    protected void Button4_Click(object sender, EventArgs e)
    {
        /*//1.复制一份模板,将temp复制一份
        string oldpath = Server.MapPath("content/student.xls");
        string npath = Server.MapPath("content/temp.xls");
        if (File.Exists(npath))
        {
            File.Delete(npath);
        }
        File.Copy(oldpath, npath);
        //2.查询数据表
        string sql = "select * from Room";
        SqlConnection conn = new SqlConnection("Server=localhost;Database=Hotel;User ID=sa;PWD=123456");
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "bb");
        DataTable dt = ds.Tables["bb"];
        //3、将数据插入到表格中

        string sqlOleDb = "insert into [Sheet1$] values('@a','@b','@c','@d')";
        OleDbParameter[] pms = new OleDbParameter[4];
        OleDbConnection oconn = new OleDbConnection(connStr);
        oconn.Open();
        OleDbCommand ocmd = new OleDbCommand(sqlOleDb, oconn);
        foreach (DataRow item in dt.Rows)
        {
            string Rno = item["Rno"].ToString();
            string Rtype = item["Rtype"].ToString();
            string Rpr = item["Rpr"].ToString();
            string Rlocal = item["Rlocal"].ToString();
            pms[0] = new OleDbParameter("@a", Rno);
            pms[1] = new OleDbParameter("@b", Rtype);
            pms[2] = new OleDbParameter("@c", Rpr);
            pms[3] = new OleDbParameter("@d", Rlocal);
            foreach (OleDbParameter itemo in pms)
            {
                ocmd.Parameters.Add(itemo);
            }
            ocmd.ExecuteNonQuery();

        }
        conn.Close();
        oconn.Close();


        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attchment;filename=aaa.xls");
        FileStream fs = new FileStream(Server.MapPath("content/temp.xls"), FileMode.Open, FileAccess.Read, FileShare.Read);
        Stream st = Response.OutputStream;
        byte[] bt = new byte[102400];
        while (true)
        {
            int len = fs.Read(bt, 0, bt.Length);
            if (len == 0) break;
            st.Write(bt, 0, len);
            Response.Flush();
        } fs.Close();
        Response.End();
        Response.Write("导出成功");*/
        /*Response.Clear();
        Response.AppendHeader("Content-Disposition", "attachment;filename=FileName.xls");
        //设置输出流为简体中文
        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        //设置输出文件类型为excel文件。
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        GridView1.RenderControl(htw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();*/
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
        Response.Charset = "";

        // If you want the option to open the Excel file without saving then 
        // comment out the line below 
        // Response.Cache.SetCacheability(HttpCacheability.NoCache); 
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        //GV is the ID of gridview 
        this.GridView1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End(); 
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET 
         server control at run time. */
    } 
}