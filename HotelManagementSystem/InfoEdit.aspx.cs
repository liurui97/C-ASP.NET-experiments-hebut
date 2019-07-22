using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class InfoEdit : System.Web.UI.Page
{
    SqlConnection con = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["Sqlserver"].ConnectionString;  //定义数据库连接字符串
        DateTime.Disabled = true;
        Hour.Enabled = false;
        Second.Enabled = false;
        StatusDetail.Enabled = false;
    }

    //提交按钮响应事件
    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        string sql = null;
        //获取填写信息
        string roomNo = this.RoomNo.Text.ToString();
        string clientName = this.Name.Text.ToString();
        string tel = this.Tel.Text.ToString();
        string manager = this.Manager.SelectedItem.Text.ToString();
        string detail = this.Detail.Text.ToString();
        string status = this.Status.SelectedItem.Text.ToString();
        if(status.Equals("其他(请注明)"))
        {
            status = this.StatusDetail.Text.ToString();
        }
        if (status.Equals("已更换") || status.Equals("已维修"))
        {
            string fixTime = this.DateTime.Value.ToString() + this.Hour.SelectedItem.Text.ToString() + this.Second.SelectedItem.Text.ToString();
            sql = "INSERT INTO Repair(Rtime,Rroom,Rname,Rtel,Rmanager,Rmark,Rcondition,Rfixtime) VALUES('" + System.DateTime.Now.ToString() + "','" + roomNo + "','" + clientName + "','" + tel + "','" + manager + "','" + detail + "','" + status + "','" + fixTime + "')";
        }
        else
        {
            sql = "INSERT INTO Repair(Rtime,Rroom,Rname,Rtel,Rmanager,Rmark,Rcondition) VALUES('" + System.DateTime.Now.ToString() + "','" + roomNo + "','" + clientName + "','" + tel + "','" + manager + "','" + detail + "','" + status + "')";
        }
        //写入数据库
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);//操作语句和链接工具
        int i = cmd.ExecuteNonQuery();//执行操作返回影响行数
        if (i > 0)
        {
            Response.Write("<script language=javascript>window.alert('信息添加成功！');</script>");
            clear();
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('信息添加失败，请稍后重试！');</script>");
        }
        con.Close();
    }

    //根据处理状态的选择情况执行相应的操作
    protected void Status_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Status.SelectedItem.Text.ToString().Equals("其他(请注明)"))
        {
            StatusDetail.Enabled = true;
        }
        else if (Status.SelectedItem.Text.ToString().Equals("已维修") || Status.SelectedItem.Text.ToString().Equals("已更换"))
        {
            DateTime.Disabled = false;
            Hour.Enabled = true;
            Second.Enabled = true;
        }
        else
        {
            DateTime.Disabled = true;
            Hour.Enabled = false;
            Second.Enabled = false;
            StatusDetail.Enabled = false;
        }
    }

    //重置按钮
    protected void ResetBtn_Click(object sender, EventArgs e)
    {
        clear();
    }

    //清除表单内容
    private void clear()
    {
        this.RoomNo.Text = "";
        this.Name.Text = "";
        this.Tel.Text = "";
        this.Manager.SelectedIndex = 0;
        this.Detail.Text = "";
        this.Status.SelectedIndex = 0;
        this.StatusDetail.Text = "";
        this.DateTime.Value = "";
        this.Hour.SelectedIndex = 0;
        this.Second.SelectedIndex = 0;
    }

    //返回按钮，返回报修信息页面
    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("FixItem.aspx");
    }
}