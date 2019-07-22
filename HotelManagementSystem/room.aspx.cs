using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Room : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Write("<script language=javascript>window.alert('请先登录!');window.location.href('./login.aspx');</script>");
        }
        if(!IsPostBack)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
            conn.Open();
            string today = DateTime.Now.ToShortDateString();//查询出当天所有客房的信息，并显示在页面中
            string str = "select * from Room where Room.Rno not in ( select RT.Rno from RT where RT.RTtime='" + today + "')";
            SqlCommand mycoml = new SqlCommand(str, conn);
            if (null == mycoml.ExecuteScalar())
            {
                conn.Close();
                Response.Write("<script language=javascript>window.alert('本时间暂时没有空房');window.location.href('./introduce.aspx');</script>");
            }
            else
            {
                conn.Close();
                databind(str);
            }
        }
    }
    protected void databind(string str)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
        conn.Open();

        SqlDataAdapter myadapter = new SqlDataAdapter(str,conn);
        DataSet ds = new DataSet();
        myadapter.Fill(ds);
        room.DataSource=ds;
        room.DataBind();
        this.ddlCurrentPage.Items.Clear();
        for (int i = 1; i <= this.room.PageCount; i++)
        {
            this.ddlCurrentPage.Items.Add(i.ToString());
        }
        this.ddlCurrentPage.SelectedIndex = this.room.PageIndex;
        conn.Close();
    }

    protected void databind1()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
        conn.Open();
        string today = DateTime.Now.ToShortDateString();//查询出当天所有客房的信息，并显示在页面中
        SqlDataAdapter myadapter = new SqlDataAdapter("select Room.Rno,Room.Rpr,Room.Rtype from Room,RT where Room.Rno=RT.Rno and RT.RTtime='" + today + "'", conn);
        DataSet ds = new DataSet();
        myadapter.Fill(ds);
        room.DataSource = ds;
        room.DataBind();
        this.ddlCurrentPage.Items.Clear();
        for (int i = 1; i <= this.room.PageCount; i++)
        { 
            this.ddlCurrentPage.Items.Add(i.ToString());
        }
        this.ddlCurrentPage.SelectedIndex = this.room.PageIndex;
        conn.Close();
    }

    protected void sd_click(object sender, EventArgs e)
    {
        if (this.arriveTextBox.Value.ToString() == null || this.leaveTextBox.Value.ToString() == null)
        {
            Response.Write("<script language=javascript>window.alert('入住日期和离开日期不能为空');</script>");
        }
        else{
            string str = "";
        int count = 0;
        string arriveTime = "";
        string leaveTime = "";
        arriveTime = this.arriveTextBox.Value.ToString();
        leaveTime = this.leaveTextBox.Value.ToString();
        for (int i = 0; i < this.room.Rows.Count; i++)
        {
            if (((CheckBox)room.Rows[i].FindControl("select")).Checked)
            {
                str += room.Rows[i].Cells[1].Text.ToString() + "@";
                count = count + 1;
            }
        }
        Response.Redirect("submit.aspx?mes=" + str + "&num=" + count+"&arriveTime="+arriveTime+"&leaveTime="+leaveTime);
        }       
    }
    protected void room_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void CalenderImageButton_click(object sender, ImageClickEventArgs e)
    {
        
    }
    protected void CalenderTextBox_TextChanged(object sender, EventArgs e)
    {

    }
    protected void leaveTextBox_TextChanged(object sender, EventArgs e)
    {

    }
    protected void leaveImageButton_click(object sender, ImageClickEventArgs e)
    {
        //leaveCalender.Visible = true;
    }
    protected void arriveCalender_SelectionChanged(object sender, EventArgs e)
    {
        /*arriveTextBox.Text = arriveCalender.SelectedDate.ToShortDateString();
        arriveCalender.Visible = false;
        arriveCalender.Focus();*/
    }
    protected void arriveImageButton_click(object sender, ImageClickEventArgs e)
    {
        //arriveCalender.Visible = true;
    }
    protected void arriveTextBox_TextChanged(object sender, EventArgs e)
    {

    }
    protected void leaveCalender_SelectionChanged(object sender, EventArgs e)
    {
        /*leaveTextBox.Text = leaveCalender.SelectedDate.ToShortDateString();
        leaveCalender.Visible = false;
        leaveCalender.Focus();*/
    }
    protected void SelectType_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    //查询房间
    protected void search(object sender, EventArgs e)
    {
        string str1;
        string arriveTime = "";
        string leaveTime = "";
        string today = DateTime.Now.ToShortDateString();
        arriveTime = this.arriveTextBox.Value.ToString();
        leaveTime = this.leaveTextBox.Value.ToString();

        string today1 = DateTime.Now.ToString("yyyy-MM-dd");
        if (this.arriveTextBox.Value.ToString() == null || this.leaveTextBox.Value.ToString() == null)
        {
            Response.Write("<script language=javascript>window.alert('入住日期和离开日期不能为空');</script>");
        } 
        if (arriveTime.CompareTo(today1) < 0 || leaveTime.CompareTo(today1) < 0)
        {
            Response.Write("<script language=javascript>window.alert('入住日期和离开日期不能早于当日');</script>");
        }
        else
        {
            //Response.Write("<script language=javascript>window.alert('入住日期和离开日期不能早于当日');</script>");
            if (!this.SelectType.SelectedValue.ToString().Equals("全部类型"))
            {
                str1 = "select Room.Rno,Room.Rpr,Room.Rtype from Room where Room.Rno not in ( select RT.Rno from RT where RT.RTtime between '" + arriveTime + "' and '" + leaveTime + "') and Room.Rtype='" + SelectType.SelectedValue.ToString() + "'";
            }
            else
                str1 = "select Room.Rno,Room.Rpr,Room.Rtype from Room where Room.Rno not in ( select RT.Rno from RT where RT.RTtime between '" + arriveTime + "' and '" + leaveTime + "')";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
            conn.Open();
            SqlCommand mycoml = new SqlCommand(str1, conn);
            if (mycoml.ExecuteScalar() != null)//如果查询到数据
            {
                conn.Close();
                databind(str1);

            }
            else//查询到数据
            {
                conn.Close();
                Response.Write("<script language=javascript>window.alert('本时间暂时没有空房');window.location.href('./introduce.aspx');</script>");
            }
        }
    }
    protected void room_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //执行循环，保证每条数据都可以更新
        for (int i = -1; i < room.Rows.Count; i++)
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
        //遍历所有行设置边框样式
        foreach (TableCell tc in e.Row.Cells)
        { tc.Attributes["style"] = "border-color:Black"; }
        this.lblCurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.room.PageIndex + 1, this.room.PageCount);

        //用索引来取得编号
        if (e.Row.RowIndex != -1)
        {
            int id = room.PageIndex * room.PageSize + e.Row.RowIndex + 1;
            //e.Row.Cells[0].Text = id.ToString();
        }
    }
    protected void lnkbtnPre_Click(object sender, EventArgs e)
    {
        if (this.room.PageIndex > 0)
        {
            this.room.PageIndex = this.room.PageIndex - 1;
            databind1();
        }
    }
    protected void lnkbtnFrist_Click(object sender, EventArgs e)
    {
        this.room.PageIndex = 0;
        databind1();
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        if (this.room.PageIndex < this.room.PageCount)
        {
            this.room.PageIndex = this.room.PageIndex + 1;
            databind1();
        }
    }
    protected void lnkbtnLast_Click(object sender, EventArgs e)
    {
        this.room.PageIndex = this.room.PageCount;
        databind1();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.room.PageIndex = ddlCurrentPage.SelectedIndex + 1;
        databind1();
    }
    protected void room_DataBound(object sender, EventArgs e)
    {

    }
}