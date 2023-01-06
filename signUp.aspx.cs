using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HOME
{
    public partial class signUp : System.Web.UI.Page
    {
        MySqlConnection DBCon = new MySqlConnection("Data Source = localhost; username=root; password=; database=techque_db");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            string gender = genderOptions.SelectedItem.Value.ToString();


             

            MySqlCommand cmd = new MySqlCommand("Select * FROM `users` WHERE email ='" + txtemailAddress.Text + "'", DBCon);
            MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            adapt.Fill(DT);
            DBCon.Open();

           
                if (txtpassword.Text != txtconfirmpass.Text)
                {
                    messagelabel.Text = "Password and Confirm Password must be indentical!";
                    messagelabel.Visible = true;
                    messagelabel.ForeColor = System.Drawing.Color.Red;

                }
                else
                {
                    if (DT.Rows.Count > 0)
                    {
                        messagelabel.Text = "Email Already taken";
                        messagelabel.Visible = true;
                        messagelabel.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        MySqlCommand insertcmd = new MySqlCommand("Insert Into `users` (`firstname`, `lastname`,`gender` ,`email`, `password`, `admin_id`) " +
                        "VALUES('" + txtfirstname.Text + "','" + txtlastname.Text + "','" + gender + "','" + txtemailAddress.Text + "','" + txtpassword.Text + "', NULL)", DBCon);
                        insertcmd.ExecuteNonQuery();

                        messagelabel.Text = "Sign up Succesfully Please Login first!";
                        messagelabel.Visible = true;
                        messagelabel.ForeColor = System.Drawing.Color.Green;
                        Response.Redirect("Login.aspx");

                    }
                }
        }
    }
}