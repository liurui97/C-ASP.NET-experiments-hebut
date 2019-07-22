using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //页面首次调用或刷新时将控件内容置为空
            this.username.Text = "";
            this.password.Text = "";
        }
    }
    protected void login_sub_Click(object sender, EventArgs e)
    {
        //采用连接的方式进行查询
        if (this.username.Text.ToString() == null || this.password.Text.ToString() == null)
        {
            Response.Write("<script language=javascript>window.alert('为了您的安全,请先登录！');window.location.href('login.aspx');</script>");
        }
        else
        {
            string strConn = "Server=localhost;Database=Hotel;UID=sa;PWD=123456";
            //建立连接对象
            SqlConnection conn = new SqlConnection(strConn);
            //SQL语句
            //string str = "select * from Manager where Mno='" + this.username.Text.ToString() + "'and Mpwd='" + this.password.Text.ToString() + "'";
            string str = "select * from Manager where Mno=@Mno and Mpwd=@Mpwd";
            //建立数据库命令对象
            //建立数据库命令对象
            SqlCommand comm = new SqlCommand(str, conn);
            //打开连接
            conn.Open();
            byte[] result = Encoding.Default.GetBytes(this.password.Text.Trim());  //输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);//加密后的登陆明文密码
            this.password.Text = BitConverter.ToString(output).Replace("-", ""); //为输出加密文本的文本框
            //执行命令，影响返回的行数
            comm.Parameters.Add("@Mno", System.Data.SqlDbType.Char, 6);
            comm.Parameters.Add("@Mpwd", System.Data.SqlDbType.VarChar, 32);
            comm.Parameters["@Mno"].Value = this.username.Text.ToString();
            comm.Parameters["@Mpwd"].Value = this.password.Text.ToString();
            SqlDataReader dr = comm.ExecuteReader();
            try
            {                
                if (dr.Read())
                {
                    Session["username"] = this.username.Text.ToString();
                    Session["password"] = this.password.Text.ToString();
                    Response.Redirect("./index.aspx");
                }
                else
                {
                    Response.Write("<script language=javascript>window.alert('用户名或密码错误，请重新登陆！');window.location.href('login.aspx');</script>");
                    
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script language=javascript>window.alert('登陆失败!');window.location.href('login.aspx');");
            }
            finally
            {
                dr.Close();
                conn.Close();
            }
        }
    }
    protected void username_TextChanged(object sender, EventArgs e)
    {

    }
}