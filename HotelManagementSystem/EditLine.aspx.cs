using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class EditLine : System.Web.UI.Page
{
    SqlConnection con = null;
    string id;
    string reportTime, roomNo, name, tel, manager, detail, fixstatus, status, statusDetail, fixedTime;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["Sqlserver"].ConnectionString;  //定义数据库连接字符串
        con.Open();
        id = Request["id"];
        string query = "SELECT * FROM Repair WHERE _ID='" + id + "'";
        DataSet ds = new DataSet();
        SqlDataAdapter obj = new SqlDataAdapter();
        obj.SelectCommand = new SqlCommand(query, con);
        obj.Fill(ds);
        SqlCommand objSqlCommand = new SqlCommand(query, con);
        SqlDataReader objSqlReader = objSqlCommand.ExecuteReader();
        while (objSqlReader.Read())
        {
            this.ReportTime.Value = objSqlReader.GetValue(1).ToString(); 
            reportTime = objSqlReader.GetValue(1).ToString();
            this.RoomNo.Text = objSqlReader.GetValue(2).ToString();
            roomNo = objSqlReader.GetValue(2).ToString();
            this.Name.Text = objSqlReader.GetValue(3).ToString();
            name = objSqlReader.GetValue(3).ToString();
            this.Tel.Text = objSqlReader.GetValue(4).ToString();
            tel = objSqlReader.GetValue(4).ToString();
            this.Manager.SelectedValue = objSqlReader.GetValue(5).ToString();
            manager = objSqlReader.GetValue(5).ToString();
            this.Detail.Text = objSqlReader.GetValue(6).ToString();
            detail = objSqlReader.GetValue(6).ToString();
            string fixStatus=objSqlReader.GetValue(7).ToString();
            if (fixStatus.Equals("待维修") || fixStatus.Equals("待更换"))
            {
                this.Status.SelectedValue = objSqlReader.GetValue(7).ToString();
                status = objSqlReader.GetValue(7).ToString();
                statusDetail = "";
                fixedTime = "";
                this.StatusDetail.Enabled = false;
                this.FixedTime.Disabled = true;
            }
            else if(fixStatus.Equals("已维修") || fixStatus.Equals("已更换"))
            {
                this.Status.SelectedValue = objSqlReader.GetValue(7).ToString();
                this.StatusDetail.Enabled = false;
                this.FixedTime.Value = objSqlReader.GetValue(8).ToString();
                status = objSqlReader.GetValue(7).ToString();
                statusDetail = "";
                fixedTime = objSqlReader.GetValue(8).ToString(); ;
            }
            else
            {
                this.Status.SelectedValue = "其他(请注明)";
                status = "其他(请注明)";
                this.StatusDetail.Text = objSqlReader.GetValue(7).ToString();
                statusDetail = objSqlReader.GetValue(7).ToString();
                this.FixedTime.Disabled = true;
                fixedTime = "";
            }
        }
        con.Close();
    }

    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("FixItem.aspx");
    }

    //重置按钮响应函数
    protected void ResetBtn_Click(object sender, EventArgs e)
    {
        clear();
    }

    //重置表单内容
    private void clear()
    {
        this.ReportTime.Value = reportTime;
        this.RoomNo.Text = roomNo;
        this.Name.Text = name;
        this.Tel.Text = tel;
        this.Manager.SelectedValue = manager;
        this.Detail.Text = detail;
        this.Status.SelectedValue = status;
        this.StatusDetail.Text = statusDetail;
        this.FixedTime.Value = fixedTime;
    }

    //提交修改信息
    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        string sql = null;
        string report = this.ReportTime.Value.ToString();
        string rno = this.RoomNo.Text.ToString();
        string cname = this.Name.Text.ToString();
        string ctel = this.Tel.Text.ToString();
        string rmanager = this.Manager.SelectedValue.ToString();
        string rdetail = this.Detail.Text.ToString();
        string rstatus=this.Status.SelectedValue.ToString();
        if (rstatus.Equals("其他(请注明)"))
        {
            rstatus = this.StatusDetail.Text.ToString();
        }
        if (rstatus.Equals("已维修") || rstatus.Equals("已更换"))
        {
            string rfixtime = this.FixedTime.Value.ToString();
            sql = "UPDATE Repair SET Rtime='"+report+"',Rroom='"+rno+"',Rname='"+cname+"',Rtel='"+ctel+"',Rmanager='"+rmanager+"',Rmark='"+rdetail+"',Rcondition='"+rstatus+"',Rfixtime='"+rfixtime+"' WHERE _ID='"+id+"'";
        }
        else
        {
            sql = "UPDATE Repair SET Rtime='" + report + "',Rroom='" + rno + "',Rname='" + cname + "',Rtel='" + ctel + "',Rmanager='" + rmanager + "',Rmark='" + rdetail + "',Rcondition='" + rstatus + "' WHERE _ID='" + id + "'";
        }
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);//操作语句和链接工具
        int i = cmd.ExecuteNonQuery();//执行操作返回影响行数
        if (i > 0)
        {
            Response.Write("<script language=javascript>window.alert('信息修改成功！');</script>");
            Response.Redirect("FixItem.aspx");
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('信息修改失败，请稍后重试！');</script>");
        }
        con.Close();
    }
}