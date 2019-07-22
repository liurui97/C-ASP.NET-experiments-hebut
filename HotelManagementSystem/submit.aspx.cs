using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class submit : System.Web.UI.Page
{
    //定义本界面使用的变量
    //客户身份证号
    string idcardString = "";
    //客户姓名
    string nameString = "";
    //入住时间
    string arriveTime = "";
    //离开时间
    string leaveTime = "";
    //客户手机号
    string telString = "";
    //客户等级
    string levelString = "";

    //从字符串中获取时间
    int arriveyear,arrivemonth,arriveday;
    int leaveyear,leavemonth,leaveday;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Write("<script language=javascript>window.alert('请先登录!');window.location.href('./login.aspx');</script>");
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["mes"] != null)
            {
                string message = "";
                message = Request.QueryString["mes"].ToString();
                //Response.Write(message);
                string[] split = message.Split(new Char[] { '@' });
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
                conn.Open();
                string selstr = "";
                switch (getnum())
                {
                    case 1:
                        selstr = "select * from Room where Rno='" + split[0] + "'";
                        break;
                    case 2:
                        selstr = "select * from Room where Rno in('" + split[0] + "','" + split[1] + "')";
                        break;
                    case 3:
                        selstr = "select * from Room where Rno in('" + split[0] + "','" + split[1] + "','" + split[2] + "')";
                        break;
                    case 4:
                        selstr = "select * from Room where Rno in('" + split[0] + "','" + split[1] + "','" + split[2] + "','" + split[3] + "')";
                        break;
                }
                SqlDataAdapter da = new SqlDataAdapter(selstr, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Room");
                this.confirm.DataSource = ds;
                confirm.DataBind();
                conn.Close();
            }
        }
    }

    //接受从房间界面传过来的数值，代表选择的房间个数
    protected int getnum()
    {
        if (Request.QueryString["num"] != null)
        {
            int n = int.Parse(Request.QueryString["num"].ToString());
            return n;
        }
        else
        {
            return 0;
        }
    }
    protected void confirm_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void resetbtn_click(object sender, EventArgs e)
    {
        Response.Write("<script language=javascript>window.location.href('./room.aspx');</script>");
    }
    protected void submitbtn_click(object sender, EventArgs e)
    {
        //获取上一个页面的时间信息
        arriveTime=Request.QueryString["arriveTime"].ToString();
        //离开时间
        leaveTime=Request.QueryString["leaveTime"].ToString();
        //从字符串中获取年月日
        DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
        dtFormat.ShortDatePattern = "yyyy-MM-dd";
        DateTime arrivedt = Convert.ToDateTime(arriveTime, dtFormat);
        DateTime leavedt = Convert.ToDateTime(leaveTime, dtFormat);
        //DateTime.Parse(leaveTime);

        arriveyear=arrivedt.Year;
        arrivemonth=arrivedt.Month;
        arriveday=arrivedt.Day;

        leaveyear=leavedt.Year;
        leavemonth=leavedt.Month;
        leaveday=leavedt.Day;

        //获取本页面中的用户信息
        //身份证号
        idcardString=idcard.Text.ToString();
        //客户姓名
        nameString=name.Text.ToString();
        //手机号
        telString=tel.Text.ToString();
        //等级
        levelString=level.Text.ToString();

        if (idcardString == "" || telString == "")
        {
            Response.Write("<script language=javascript>window.alert('身份证号与手机号不能为空，请填写后重新添加!');</script>");
        }
        else
        {
            //建立数据库连接
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
            string selectString = "select * from Client Where Cno='" + idcardString + "'";
            string insertString;
            try
            {
                conn.Open();
                SqlCommand mycomm = new SqlCommand(selectString, conn);
                SqlDataReader dr = mycomm.ExecuteReader();
                if (dr.Read())
                {
                    //这位客户在本酒店入住过
                    Response.Write("<script language=javascript>window.alert('这是一位老住客，请注意服务态度!');</script>");
                    dr.Close();
                    //首先进行用户信息的插入
                    for (int i = 0; i < this.confirm.Rows.Count; i++)
                    {
                        //这个插入应该写Cno、Rno、CRarrive、CRleave
                        string Rno = confirm.Rows[i].Cells[1].Text.ToString();
                        insertString = "insert into CR(Cno,Rno,CRarrive,CRleave)values('" + idcardString + "','" + Rno + "','" + arriveTime + "','" + leaveTime + "');";
                        mycomm = new SqlCommand(insertString, conn);
                        mycomm.ExecuteNonQuery();

                        //这里进行入住天数的计算，先假定只用日期相减就可以了
                        for (int j = arriveday; j < leaveday; j++)
                        {
                            insertString = "insert into RT(Rno,RTtime) values('" + Rno + "','" + arriveyear + "-" + arrivemonth + "-" + arriveday + "')";
                            mycomm = new SqlCommand(insertString, conn);
                            mycomm.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                    Response.Write("<script language=javascript>window.alert('添加住房信息成功!');</script>");
                    Response.Redirect("client_list.aspx");
                }else
                {
                    dr.Close();
                    //插入用户信息
                    insertString = "insert into Client(Cno,Cname,Ctel,Clev) values('" + idcardString + "','" + nameString + "','" + telString + "','" + levelString + "');";
                    mycomm = new SqlCommand(insertString, conn);
                    mycomm.ExecuteNonQuery();
                    //现在只是用作注释
                    Response.Write("<script language=javascript>window.alert('添加用户信息成功!');</script>");
                    //首先进行用户信息的插入
                    for (int i = 0; i < this.confirm.Rows.Count; i++)
                    {
                        //这个插入应该写Cno、Rno、CRarrive、CRleave
                        string Rno = confirm.Rows[i].Cells[1].Text.ToString();
                        insertString = "insert into CR(Cno,Rno,CRarrive,CRleave)values('" + idcardString + "','" + Rno + "','" + arriveTime + "','" + leaveTime + "');";
                        mycomm = new SqlCommand(insertString, conn);
                        mycomm.ExecuteNonQuery();

                        //这里进行入住天数的计算，先假定只用日期相减就可以了
                        for (int j = arriveday; j < leaveday; j++)
                        {
                            insertString = "insert into RT(Rno,RTtime) values('" + Rno + "','" + arriveyear + "-" + arrivemonth + "-" + arriveday + "')";
                            mycomm = new SqlCommand(insertString, conn);
                            mycomm.ExecuteNonQuery();
                        }
                    }
                    
                    conn.Close();
                    Response.Write("<script language=javascript>window.alert('添加住房信息成功!');window.location.href('client_list.aspx');</script>");
                    Response.Redirect("client_list.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script language=javascript>window.alert('不能重复添加!');</script>");
            }
            finally
            {

                conn.Close();
            }
        }
    }
    protected void idcard_TextChanged(object sender, EventArgs e)
    {

    }
}