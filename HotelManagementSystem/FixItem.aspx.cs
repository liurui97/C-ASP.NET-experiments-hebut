using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data.OleDb;

public partial class FixItem : System.Web.UI.Page
{
    SqlConnection con = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["Sqlserver"].ConnectionString;  //定义数据库连接字符串
        if(!this.IsPostBack)
            getData();
    }

    //读取数据库内容
    protected void getData()
    {   
        SqlCommand com = new SqlCommand();              //定义数据库操作命令对象
        com.Connection = con;                           //连接数据库
        com.CommandText = "select * from Repair"; //定义执行查询操作的sql语句
        SqlDataAdapter da = new SqlDataAdapter();       //创建数据适配器对象
        da.SelectCommand = com;                         //执行数据库操作命令
        DataSet ds = new DataSet();                     //创建数据集对象
        da.Fill(ds);                        //填充数据集
        RoomList.DataSource = ds.Tables[0].DefaultView;//设置gridview控件的数据源为创建的数据集ds
        RoomList.DataBind(); 
    }

    //单击查询按钮
    protected void Query_Click(object sender, EventArgs e)
    {
        string select = SearchWay.SelectedItem.Text;
        string info = SearchInfo.Text;
        string search = null;
        if (select.Equals("按房间号搜索"))
        {
            search = "Rroom='" + info + "'";
        }
        else if (select.Equals("按房间类型搜索"))
        {

        }
        else if (select.Equals("按楼层搜索"))
        {
            search = "Rroom LIKE '" + info + "%'";            
        }
        else if (select.Equals("按房间状态搜索"))
        {
            search = "Rcondition='" + info + "'";
        }
        else if (select.Equals("按时间搜索"))
        {
            search = "Rtime='" + info + "'";
        }
        else if (select.Equals("按操作人搜索"))
        {
            search = "Rmanager='" + info + "'";
        }
        else if (select.Equals("按客户信息搜索"))
        {
            search = "Rname='" + info + "' OR Rtel='" + info + "'";
        }
        else
        {

        }
        SqlCommand com = new SqlCommand();              //定义数据库操作命令对象
        com.Connection = con;                           //连接数据库
        com.CommandText = "SELECT * FROM Repair WHERE " + search; //定义执行查询操作的sql语句
        SqlDataAdapter da = new SqlDataAdapter();       //创建数据适配器对象
        da.SelectCommand = com;                         //执行数据库操作命令
        DataSet ds = new DataSet();                     //创建数据集对象
        da.Fill(ds);                        //填充数据集
        RoomList.DataSource = ds.Tables[0].DefaultView;//设置gridview控件的数据源为创建的数据集ds
        RoomList.DataBind(); 
    }

    //显示全部数据
    protected void ShowAll_Click(object sender, EventArgs e)
    {
        getData();
    }

    //单击添加按钮
    protected void Add_Click(object sender, EventArgs e)
    {
        Response.Redirect("InfoEdit.aspx");
    }

    //鼠标停留时在某行高亮
    protected void RoomList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //执行循环，保证每条数据都可以更新
        for (int i = -1; i < RoomList.Rows.Count; i++)
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

    //批量删除按钮
    protected void Delete_Click(object sender, EventArgs e)
    {
        int countItem = 0;
        foreach (GridViewRow dgi in this.RoomList.Rows)
        {
            CheckBox cb = (CheckBox)dgi.FindControl("Select");
            if (cb.Checked)
            {
                int index = dgi.RowIndex;
                string lineNo = this.RoomList.DataKeys[index].Value.ToString();
                //以下执行删除操作
                string strSql = "DELETE FROM Repair WHERE _ID='" + lineNo + "'";
                con.Open();
                SqlCommand com = new SqlCommand(strSql, con);
                int num = com.ExecuteNonQuery();
                if (num > 0)
                {
                    countItem++;
                }
                con.Close();
            }
        }
        Response.Write("<script>alert('成功删除所选" + countItem + "条记录！');</script>");
        getData();
    }

    //导出数据表为Excel表格
    protected void Export_Click(object sender, EventArgs e)
    {
        RoomList.BottomPagerRow.Visible = false;//导出到Excel表后，隐藏分页部分
        RoomList.Columns[0].Visible = false;
        RoomList.Columns[9].Visible = false;//隐藏“编辑”“删除”列
        RoomList.AllowPaging = false;//取消分页，便于导出所有数据，不然只能导出当前页面的几条数据
        getData();
        DateTime dt = DateTime.Now;//给导出后的Excel表命名，结合表的用途以及系统时间来命名
        string filename = dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString();
        /*在导出前对相应列添加格式化的数据类型，以下为格式化为字符串型*/
        foreach (GridViewRow dg in this.RoomList.Rows)
        {
            dg.Cells[2].Attributes.Add("style", "vnd.ms-excel.numberformat: @;");
            dg.Cells[4].Attributes.Add("style", "vnd.ms-excel.numberformat: @;");
            dg.Cells[5].Attributes.Add("style", "vnd.ms-excel.numberformat: @;");
        }
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode("报修情况表" + filename, System.Text.Encoding.UTF8) + ".xls");//导出文件命名
        Response.ContentEncoding = System.Text.Encoding.UTF7;//如果设置为"GB2312"则中文字符可能会乱码
        Response.ContentType = "applicationshlnd.xls";
        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
        Panel1.RenderControl(oHtmlTextWriter);//Add the Panel into the output Stream.
        Response.Write(oStringWriter.ToString());//Output the stream.
        Response.Flush();
        Response.End();
    }

    //导出数据时必须要重写
    public override void VerifyRenderingInServerForm(Control control) { }

    //删除某一行数据
    protected void DeleteItem_OnClick(object sender, EventArgs e)
    {
        int row = ((GridViewRow) ((Button) sender).NamingContainer).RowIndex;
        string lineNo = this.RoomList.DataKeys[row].Value.ToString();
        //数据库操作
        string sql = "DELETE FROM Repair WHERE _ID='" + lineNo + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);//操作语句和链接工具
        int i = cmd.ExecuteNonQuery();//执行操作返回影响行数
        if (i > 0)
        {
            Response.Write("<script language=javascript>window.alert('信息删除成功！');</script>");
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('信息删除失败，请稍后重试！');</script>");
        }
        getData();
        con.Close();
    }

    //编辑按钮
    protected void Edit_OnClick(object sender, EventArgs e)
    {
        int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        string lineNo = this.RoomList.DataKeys[row].Value.ToString();
        Response.Redirect("EditLine.aspx?id="+lineNo);
    }

    //导入Excel数据表
    protected void Import_Click(object sender, EventArgs e)
    {
        /*string excelUrl = this.Server.MapPath(@"Repair.xlsx");
        string str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelUrl + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=0\"";
        OleDbConnection ole = new OleDbConnection(str);
        ole.Open();
        OleDbCommand olecom = ole.CreateCommand();
        olecom.CommandText = "SELECT * FROM [Sheet1$]";
        OleDbDataAdapter adpt = new OleDbDataAdapter();
        adpt.SelectCommand = olecom;
        DataSet ds = new DataSet();
        adpt.Fill(ds);
        this.RoomList.DataSource = ds;
        this.RoomList.DataBind();*/
        con.Open();
        string excelUrl = this.Server.MapPath(@"Repair.xlsx");
        string str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelUrl + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=0\"";
        OleDbConnection ole = new OleDbConnection(str);
        ole.Open();
        OleDbCommand olecom = ole.CreateCommand();
        olecom.CommandText = "SELECT * FROM [Sheet1$]";
        OleDbDataAdapter adpt = new OleDbDataAdapter();
        adpt.SelectCommand = olecom;
        DataSet ds = new DataSet();
        adpt.Fill(ds);
        DataRow[] dr = ds.Tables[0].Select();
        int rowsnum = ds.Tables[0].Rows.Count;
        this.RoomList.DataSource = ds;
        this.RoomList.DataBind();
        if (rowsnum == 0)
        {
            Response.Write("<script language=javascript>window.alert('Excel表为空！');</script>");
        }
        else
        {
            for (int i = 0; i < dr.Length; i++)
            {
                //Excel表所对应的栏位
                string id, rtime, rroom, rname, rtel, rmanager, rmark, rcondition, rfixtime;
                id = dr[i]["_ID"].ToString().Trim();
                rtime = dr[i]["Rtime"].ToString().Trim();
                rroom = dr[i]["Rroom"].ToString().Trim();
                rname = dr[i]["Rname"].ToString().Trim();
                rtel = dr[i]["Rtel"].ToString().Trim();
                rmanager = dr[i]["Rmanager"].ToString().Trim();
                rmark = dr[i]["Rmark"].ToString().Trim();
                rcondition = dr[i]["Rcondition"].ToString().Trim();
                rfixtime = dr[i]["Rfixtime"].ToString().Trim();
                string insertStr = "INSERT INTO Repair(Rtime,Rroom,Rname,Rtel,Rmanager,Rmark,Rcondition,Rfixtime) VALUES('" + rtime + "','" + rroom + "','" + rname + "','" + rtel + "','" + rmanager + "','" + rmark + "','" + rcondition + "','" + rfixtime + "')";
                SqlCommand cmd = new SqlCommand(insertStr, con);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    Response.Write("<script language=javascript>window.alert('Excel表导入数据库成功！');</script>");
                }
            }
        }
    }
}