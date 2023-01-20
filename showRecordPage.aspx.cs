using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HOME
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button2.Enabled = false;
            string quizid = hdnfld.Text;
            Response.Write(quizid);

            var DBCon = Handlers.SqlInstance.Instance;
            MySqlCommand cmd =
                new MySqlCommand(
                    "Select * FROM quizattempts WHERE userid ='" + Session["id"] + "' AND quiz_id ='" + quizid + "'",
                    DBCon);
            MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
            DataTable dtQDeets = new DataTable();
            adapt.Fill(dtQDeets);

            if (dtQDeets.Rows.Count > 0)
            {
                MySqlCommand cmd2 = new MySqlCommand("Select * FROM quiz WHERE id ='" + quizid + "'", DBCon);
                MySqlDataAdapter adapt2 = new MySqlDataAdapter(cmd2);
                DataTable dtQDeets2 = new DataTable();
                adapt.Fill(dtQDeets2);
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button3.Enabled = false;
            Button2.Visible = false;
            Button3.Visible = false;
            int userid = (int)Session["id"];
            string quizid = hdnfld.Text;
            int quiz = Int32.Parse(quizid);


            var DBCon = Handlers.SqlInstance.Instance;



            string sql = "Select title FROM quiz WHERE id = '" + quiz + "'";
            MySqlCommand command = new MySqlCommand(sql, DBCon);

            string result = (string)command.ExecuteScalar();
            Recordtitle.InnerText = result;


            MySqlCommand cmd =
                new MySqlCommand(
                    "Select * FROM quizattempts WHERE quiz_id = '" + quiz + "' AND userid = '" + userid + "'", DBCon);

            MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            adapt.Fill(DT);


            if (DT.Rows.Count > 0)
            {
                sql =
                    "SELECT score, items, date FROM quizattempts WHERE quiz_id = @quizid AND userid = @userid";
                command = new MySqlCommand(sql, DBCon);

                command.Parameters.AddWithValue("@quizid", quiz);
                command.Parameters.AddWithValue("@userid", userid);


                GridView1.DataSource = command.ExecuteReader();
                GridView1.DataBind();
            }
            else
            {
                messagebox.InnerText = "NO RECORD AVAILABLE";
            }
        }
    }
}