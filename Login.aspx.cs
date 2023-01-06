using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HOME
{
    
    public partial class Login : System.Web.UI.Page
    {
       
        MySqlConnection DBCon = new MySqlConnection("Data Source = localhost; username=root; password=; database=techque_db");
        MySqlConnection DBCon2 = new MySqlConnection("Data Source = localhost; username=root; password=; database=techque_db");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("Select * FROM `users` WHERE email ='" + textusername.Text + "' AND password ='" + textpass.Text + "'", DBCon);
            MySqlCommand cmd2 = new MySqlCommand("Select * FROM `admin_user` WHERE email ='" + textusername.Text + "' AND password ='" + textpass.Text + "'", DBCon2);
            MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
            MySqlDataAdapter adapt2 = new MySqlDataAdapter(cmd2);
            DataTable DT = new DataTable();
            DataTable DT2 = new DataTable();
            adapt.Fill(DT);
            adapt2.Fill(DT2);

            DBCon.Open();
            DBCon2.Open();

            if (DT.Rows.Count > 0)
            {
                messagelabel.Text = "Successfully Login";
                messagelabel.Visible = true;
                messagelabel.ForeColor = System.Drawing.Color.Green;
                Session["username"] = textusername.Text;
                foreach (DataRow row in DT.Rows)
                {
                    Session["firstname"] = row["firstname"];
                    Session["lastname"] = row["lastname"];
                    Session["gender"] = row["gender"];
                    Session["password"] = row["password"];
                    Session["id"] = row["user_id"];
                }
                Response.Redirect("HOMEPAGE.aspx");
                
            }
            else if(DT2.Rows.Count > 0)
            {
                messagelabel.Text = "Successfully Login";
                messagelabel.Visible = true;
                messagelabel.ForeColor = System.Drawing.Color.Green;
                Session["username"] = textusername.Text;
                foreach (DataRow row2 in DT2.Rows)
                {
                    Session["adminid"] = row2["id"];
                    Session["firstname"] = row2["firstname"];
                    Session["lastname"] = row2["lastname"];
                    Session["password"] = row2["password"];
                }
                Response.Redirect("AdminHomePage.aspx");
            }
            else
            {
                messagelabel.Text = "Invalid user or password";
                messagelabel.Visible = true;
                messagelabel.ForeColor = System.Drawing.Color.Red; 
            }
        }
    }
}