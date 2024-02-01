using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlCommand cmd = new SqlCommand("delete from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                clearForm();
                GridView1.DataBind();

                Response.Write("<script>alert('Member is permanently deleted')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");

            }
        }

        // GO button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            GetMemberById();
        }
        // active button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("active");
        }
        // pending button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("pending");

        }
        // close button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("deactive");

        }

        //user defined functions
        void GetMemberById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox2.Text = dr[0].ToString();
                        TextBox7.Text = dr[10].ToString();
                        TextBox8.Text = dr[1].ToString();
                        TextBox3.Text = dr[2].ToString();
                        TextBox4.Text = dr[3].ToString();
                        TextBox9.Text = dr[4].ToString();
                        TextBox10.Text = dr[5].ToString();
                        TextBox11.Text = dr[6].ToString();
                        TextBox6.Text = dr[7].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        void updateMemberStatusById(string status)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();

                SqlCommand cmd = new SqlCommand("update member_master_tbl set account_status='" + status + "' where member_id='" + TextBox1.Text.Trim() + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                GridView1.DataBind();
            }
            catch(Exception ex)
            {

            }
            
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox3.Text = "";              
            TextBox4.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox6.Text = "";
        }
    }
}