using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*string str = "Server=localhost;Database=Register;UID=sa;PWD=123456";
        SqlConnecion conn = new SqlConnecion(str);
        SqlCommand selcomm = new SqlCommand("select * from Sex");
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand();
        try
        {
            conn.open();
        }*/
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Server=localhost;Database=Register;UID=sa;PWD=123456";
        SqlCommand selcomm1 = new SqlCommand("select * from Sex",conn);
        SqlCommand selcomm2 = new SqlCommand("select * from BLOOD", conn);
        SqlCommand selcomm3 = new SqlCommand("select * from Intrest", conn);
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        
        try
        {
            conn.Open();
            dataAdapter.SelectCommand = selcomm1;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet,"Sex");
            Sex.DataSource = dataSet.Tables[0];
            Sex.DataTextField = "sex";
            Sex.DataValueField = "sex";
            Sex.DataBind();

            dataAdapter.SelectCommand = selcomm2;
            dataAdapter.Fill(dataSet, "Blood");
            Blood.DataSource = dataSet.Tables[1];
            Blood.DataTextField = "blood";
            Blood.DataValueField = "blood";
            Blood.DataBind();

            dataAdapter.SelectCommand = selcomm3;
            dataAdapter.Fill(dataSet, "Intrest");
            Intrest.DataSource = dataSet.Tables[2];
            Intrest.DataTextField = "intrest";
            Intrest.DataValueField = "intrest";
            Intrest.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            conn.Close();
        }
    }
    protected void show_Click1(object sender, EventArgs e)
    {
        MSG.Visible = true;
        MSGName.Text = "姓名：" + UserName.Text.ToString();
        MSGSex.Text = "性别：" + Sex.GetType().GetProperty("sex");//Sex.SelectedItem.Text.ToString();
        MSGBlood.Text = "血型：" + Blood.SelectedValue;//Blood.SelectedItem.Text.ToString();
        MSGIntert.Text = "兴趣：";
        for (int i = 0; i < Intrest.Items.Count; i++)
        {
            if (Intrest.Items[i].Selected)
            {
                MSGIntert.Text = MSGIntert.Text + Intrest.Items[i].Text.Trim();
            }
        }
        MSGPic.Text = "头像：";
        if (R1.Checked)
        {
            MSGPic.Text = MSGPic.Text+R1.Text.Trim();
        }
        if (R2.Checked)
        {
            MSGPic.Text = MSGPic.Text+R2.Text.Trim();
        }
        if (R3.Checked)
        {
            MSGPic.Text = MSGPic.Text + R3.Text.Trim();
        } 
        if (R4.Checked)
        {
            MSGPic.Text = MSGPic.Text + R4.Text.Trim();
        } 
        if (R5.Checked)
        {
            MSGPic.Text = MSGPic.Text + R5.Text.Trim();
        }
    }
    protected void Intrest_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Blood_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}