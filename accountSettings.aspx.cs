using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HOME
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        MySqlConnection DBCon = new MySqlConnection("Data Source = localhost; username=root; password=; database=techque_db;");

        protected void Page_Load(object sender, EventArgs e)
        {
            txtfname.Value = (string)Session["firstname"];
            txtlname.Value = (string)Session["lastname"];
            txtemailAddress.Value = (string)Session["username"];
            txtgender.Value = (string)Session["gender"];
            txtpass.Value = (string)Session["password"];
        }

        protected void signout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
        protected void submitbtn_Click(object sender, EventArgs e)
        {
            int id = (int)Session["id"];


            string updateQuery = "UPDATE techque_db.users SET firstname = @firstname, lastname = @lastname, gender = @gender, email = @email, password = @password WHERE user_id = @id";


            DBCon.Open();
            try
            {
                MySqlCommand command = new MySqlCommand(updateQuery, DBCon);
                command.Parameters.AddWithValue("@firstname", txtfname.Value.ToString());
                command.Parameters.AddWithValue("@lastname", txtlname.Value.ToString());
                command.Parameters.AddWithValue("@gender", txtgender.Value.ToString());
                command.Parameters.AddWithValue("@email", txtemailAddress.Value.ToString());
                command.Parameters.AddWithValue("@password", txtpass.Value.ToString());
                command.Parameters.AddWithValue("@id", id);

                if (command.ExecuteNonQuery() == 1)
                {
                    Response.Write("<script>alert('Data updated successfully')</script>");
                    DBCon.Close();
                }
                else
                {
                    Response.Write("<script>alert('Data not updated')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex + "')</script>");
            }





        }
    }
}