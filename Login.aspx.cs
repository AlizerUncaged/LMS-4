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
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var DBCon = Handlers.SqlInstance.Instance;
            var DBCon2 = Handlers.SqlInstance.Instance;
            MySqlCommand cmd =
                new MySqlCommand(
                    "Select * FROM `users` WHERE email ='" + textusername.Text + "' AND password ='" + textpass.Text +
                    "'", DBCon);
            MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            adapt.Fill(DT);


            if (DT.Rows.Count > 0) // user
            {
                messagelabel.Text = "Successfully Login";
                messagelabel.Visible = true;
                messagelabel.ForeColor = System.Drawing.Color.Green;
                Session["username"] = textusername.Text;
                Session["type"] = "user";
                foreach (DataRow row in DT.Rows)
                {
                    Session["firstname"] = row["firstname"];
                    Session["lastname"] = row["lastname"];
                    Session["gender"] = row["gender"];
                    Session["password"] = row["password"];
                    Session["email"] = row["email"];
                    Session["suspended"] = false;
                    if (!DBNull.Value.Equals(row["is_suspended"]))
                    {
                        Session["suspended"] = row["is_suspended"];
                    }

                    Session["id"] = row["user_id"];
                    Session["pfpUrl"] = row["pfpUrl"];
                    break;
                }

                Response.Redirect("HOMEPAGE.aspx");
            }


            MySqlCommand cmd2 =
                new MySqlCommand(
                    "Select * FROM `admin_user` WHERE email ='" + textusername.Text + "' AND password ='" +
                    textpass.Text + "'", DBCon2);

            MySqlDataAdapter adapt2 = new MySqlDataAdapter(cmd2);

            DataTable DT2 = new DataTable();

            adapt2.Fill(DT2);


            if (DT2.Rows.Count > 0) // admin
            {
                messagelabel.Text = "Successfully Login";
                messagelabel.Visible = true;
                messagelabel.ForeColor = System.Drawing.Color.Green;
                Session["username"] = textusername.Text;
                Session["type"] = "admin";
                foreach (DataRow row2 in DT2.Rows)
                {
                    Session["adminid"] = row2["id"];
                    Session["firstname"] = row2["firstname"];
                    Session["lastname"] = row2["lastname"];
                    Session["password"] = row2["password"];
                    Session["email"] = row2["email"];
                    Session["pfpUrl"] = row2["pfpUrl"];
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