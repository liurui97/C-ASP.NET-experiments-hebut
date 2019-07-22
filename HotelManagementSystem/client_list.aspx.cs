using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class client_list : System.Web.UI.Page
{
    DataSet ds = new DataSet();
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
                SqlCommand mycoml = new SqlCommand("select * from Client", conn);
                if (null == mycoml.ExecuteScalar())
                {
                    conn.Close();
                    Response.Write("<script language=javascript>window.alert('暂时没有用户信息');</script>");
                }
                else
                {
                    conn.Close();
                    Show_UserList();
                }
            }
        }
        
    }
    protected void Show_UserList()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
        conn.Open();

        SqlDataAdapter myadapter = new SqlDataAdapter("select * from Client", conn);
        myadapter.Fill(ds,"Client");

        user.DataSource = ds;
        user.DataBind();

        this.ddlCurrentPage.Items.Clear();
        for (int i = 1; i <= this.user.PageCount; i++)
        { this.ddlCurrentPage.Items.Add(i.ToString()); }
        this.ddlCurrentPage.SelectedIndex = this.user.PageIndex;

        conn.Close();
    }

    protected bool Delete(string Cno)
    {
        return true;
    }
    protected void GridView_user_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void searchBtn_Click(object sender, EventArgs e)
    {

    }
    protected void searchBtn_Click1(object sender, EventArgs e)
    {

    }
    protected void user_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
        try
        {
            conn.Open();

            string query = "select * from Client";
            SqlDataAdapter myadapter = new SqlDataAdapter(query, conn);

            string deleteString = "delete from Client where Cno='" + user.DataKeys[e.RowIndex].Value.ToString() + "'";
            //这一部分是在数据库中删除数据
            SqlCommand mycomm = new SqlCommand(deleteString, conn);
            mycomm.ExecuteNonQuery();

            //这只是从数据表中查出，但是没有删除数据库
            
            myadapter.DeleteCommand = new SqlCommand(deleteString, conn);
            DataSet ds = new DataSet();
            //myadapter = new SqlDataAdapter("select * from Client", conn);
            myadapter.Fill(ds, "Client");

            Response.Write("<script language=avascript>window.alert('删除成功!');</script>");
            //DataTable dataTable = new DataTable();
            this.user.DataSource = ds;
            user.DataBind();            
        }
        catch (Exception ex)
        {
            Response.Write("<script language=avascript>window.alert('删除用户信息失败!');</script>");
        }
        finally
        {
            conn.Close();
        }        
    }
    protected void deleteBtn_Click(object sender, EventArgs e)
    {

    }
    protected void searchBtn_Click2(object sender, EventArgs e)
    {
        string selectString="";
        string idcardString=idcard.Text.ToString();
        string clientnameString=clientname.Text.ToString();
        string phonenumString=phonenum.Text.ToString();
        string levelString=level.SelectedValue.ToString();

        if (idcardString== "" && clientnameString == "" && phonenumString == "" && levelString=="")
        {
            Response.Write("<script language=javascript>window.alert('至少填写一项筛选条件');</script>");
        }
        else if (idcardString== "" && clientnameString == "" && phonenumString == "" && levelString!="")
        {
            selectString = "select * from Client where Clev='" + levelString + "'";
        }
        else if (idcardString == "" && clientnameString == "" && phonenumString != "" && levelString != "")
        {
            selectString = "select * from Client where Ctel='" + phonenumString + "' and Clev='" + levelString + "'";
        }
        else if (idcardString == "" && clientnameString == "" && phonenumString != "" && levelString == "")
        {
            selectString = "select * from Client where Ctel='" + phonenumString + "'";
        }
        else if (idcardString == "" && clientnameString != "" && phonenumString == "" && levelString == "")
        {
            selectString="select * from Client where Cname='"+clientnameString+"'";
        }
        else if (idcardString == "" && clientnameString != "" && phonenumString == "" && levelString != "")
        {
            selectString = "select * from Client where Cname='" + clientnameString + "' and Clev='" + levelString + "'";
        }
        else if (idcardString == "" && clientnameString != "" && phonenumString != "" && levelString == "")
        {
            selectString = "select * from Client where Cname='" + clientnameString + "' and Ctel='" + phonenumString + "'";
        }
        else if (idcardString == "" && clientnameString != "" && phonenumString != "" && levelString != "")
        {
            selectString = "select * from Client where Cname='"+clientnameString+"' and  Ctel='" + phonenumString + "' and Clev='" + levelString + "'";
        }
        else if (idcardString != "" && clientnameString == null && phonenumString == null && levelString == null)
        {
            selectString = "select * from Client where Cno='" + idcardString + "'";
        }
        else if (idcardString != "" && clientnameString == "" && phonenumString == "" && levelString != "")
        {
            selectString = "select * from Client where Cno='" + idcardString + "' and Clev='"+levelString+"'";
        }
        else if (idcardString != "" && clientnameString == "" && phonenumString != "" && levelString == "")
        {
            selectString = "select * from Client where Cno='" + idcardString + "' and Ctel='" + phonenumString + "'";
        }
        else if (idcardString != "" && clientnameString == "" && phonenumString != "" && levelString != "")
        {
            selectString = "select * from Client where Cno='" + idcardString + "' and Ctel='" + phonenumString + "' and Clev='"+levelString+"'";
        }
        else if (idcardString != "" && clientnameString != "" && phonenumString == "" && levelString == "")
        {
            selectString = "select * from Client where Cno='" + idcardString + "' and Cname='" + clientnameString + "'";
        }
        else if (idcardString != "" && clientnameString != "" && phonenumString == "" && levelString != "")
        {
            selectString = "select * from Client where Cno='" + idcardString + "' and Cname='" + clientnameString + "' and Clev='"+levelString+"'";
        }
        else if (idcardString != "" && clientnameString != "" && phonenumString != "" && levelString == "")
        {
            selectString = "select * from Client where Cno='" + idcardString + "' and Cname='" + clientnameString + "' and Ctel='" + phonenumString + "'";
        }
        else if (idcardString != "" && clientnameString != "" && phonenumString != "" && levelString != "")
        {
            selectString = "select * from Client where Cno='"+idcardString+"' and Cname='" + clientnameString + "' and  Ctel='" + phonenumString + "' and Clev='" + levelString + "'";
        }

        //Response.Write(selectString);
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
        conn.Open();
        SqlCommand mycoml = new SqlCommand(selectString, conn);

        if (null == mycoml.ExecuteScalar())
        {
            conn.Close();
            Response.Write("<script language=javascript>window.alert('暂时没有用户信息');</script>");
        }
        else
        {
            SqlDataAdapter myadapter = new SqlDataAdapter(selectString, conn);
            myadapter.Fill(ds, "Client");

            user.DataSource = ds;
            user.DataBind();
            conn.Close();
        }
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
        user.RenderControl(htw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void user_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //第二列为身份证号码
            e.Row.Cells[1].Attributes.Add("style", "vnd.ms-excel.numberformat:@;");
            e.Row.Cells[5].Attributes.Add("style", "vnd.ms-excel.numberformat:@;");
            e.Row.Cells[6].Attributes.Add("style", "vnd.ms-excel.numberformat:@;");
        }

        this.lblCurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.user.PageIndex + 1, this.user.PageCount);
        //遍历所有行设置边框样式
        foreach (TableCell tc in e.Row.Cells)
        { tc.Attributes["style"] = "border-color:Black"; }
        //用索引来取得编号
        if (e.Row.RowIndex != -1)
        {
            int id = user.PageIndex * user.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }    


    }
    protected void user_RowCreated(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            //判断是否表头
            case DataControlRowType.Header:
                //第一行表头
                TableCellCollection tcHeader = e.Row.Cells;
                tcHeader.Clear();

                tcHeader.Add(new TableHeaderCell());
                tcHeader[0].Attributes.Add("colspan", "8");
                tcHeader[0].Text = "基本信息</th></tr><tr>";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[1].Attributes.Add("bgcolor", "Azure");
                tcHeader[1].Text = "序号";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[2].Attributes.Add("bgcolor", "Azure");
                tcHeader[2].Text = "身份证号";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[3].Attributes.Add("bgcolor", "Azure");
                tcHeader[3].Text = "客户名";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[4].Attributes.Add("bgcolor", "Azure");
                tcHeader[4].Text = "手机号";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[5].Attributes.Add("bgcolor", "Azure");
                tcHeader[5].Text = "等级";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[6].Attributes.Add("bgcolor", "Azure");
                tcHeader[6].Text = "详情";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[7].Attributes.Add("bgcolor", "Azure");
                tcHeader[7].Text = "修改用户信息";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[8].Attributes.Add("bgcolor", "Azure");
                tcHeader[8].Text = "删除";
                break;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        user.PageIndex = ddlCurrentPage.SelectedIndex;
        Show_UserList();
    }
    protected void lnkbtnFrist_Click(object sender, EventArgs e)
    {
        this.user.PageIndex = 0;
        Show_UserList();
    }
    protected void lnkbtnPre_Click(object sender, EventArgs e)
    {
        if (this.user.PageIndex > 0)
        {
            this.user.PageIndex = this.user.PageIndex - 1;
            Show_UserList();
        }
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        if (this.user.PageIndex < this.user.PageCount)
        {
            this.user.PageIndex = this.user.PageIndex + 1;
            Show_UserList();
        }
    }
    protected void lnkbtnLast_Click(object sender, EventArgs e)
    {
        this.user.PageIndex = this.user.PageCount;
        Show_UserList();
    }
}