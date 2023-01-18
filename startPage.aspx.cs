using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HOME
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        public static string quiztitle, quizid, quizdesc = "", attempts;
        public int qID;

        protected void Page_Load(object sender, EventArgs e)
        {
            quizPage.i = 0;

            quizPage.points = 0;
            quizid = hdnfld.Text;


            /*string sql = "SELECT COUNT(attempt_id) FROM quizattempts WHERE userid = @value";
            MySqlCommand cmd = new MySqlCommand(sql, DBCon);
            cmd.Parameters.AddWithValue("@value", id);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

        if (count > 0)
        {
            //magselect sa db ng attempt
            //count ata
            //ilagay sa label
        }
        else if (count == 3)
        {
            //disable button
        }
        else
        {
            labeldate.InnerText = "No attempts made";
        }*/
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("HOMEPAGE.aspx");
        }

        protected void Start_Click(object sender, EventArgs e)
        {
            Response.Redirect("quizPage.aspx");
        }

        protected void Load_Click(object sender, EventArgs e)
        {
            var DBCon = Handlers.SqlInstance.Instance;

            Button2.Enabled = false;
            Button2.Visible = false;
            MySqlCommand cmd = new MySqlCommand("Select * FROM quiz WHERE id ='" + quizid + "'", DBCon);
            MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
            DataTable dtQDeets = new DataTable();
            adapt.Fill(dtQDeets);

            foreach (DataRow row in dtQDeets.Rows)
            {
                quiztitle = row["title"].ToString();
            }

            MySqlCommand cmd2 =
                new MySqlCommand(
                    "Select * FROM quizattempts WHERE quiz_id ='" + quizid + "' AND userid ='" +
                    Session["id"].ToString() + "'", DBCon);
            MySqlDataAdapter adapt2 = new MySqlDataAdapter(cmd2);
            DataTable dtAttempts = new DataTable();
            adapt2.Fill(dtAttempts);
            if (dtAttempts != null)
            {
                if (dtAttempts.Rows.Count > 0 && dtAttempts.Rows.Count < 3)
                {
                    attempts = "";
                    foreach (DataRow row2 in dtAttempts.Rows)
                    {
                        attempts += "<div class ='attemptRow'><div class = 'attemptDate'>" + row2["date"].ToString() +
                                    "</div><div class = 'attemptScore'>" + row2["score"].ToString() + "</div></div>";
                    }
                }
                else if (dtAttempts.Rows.Count >= 3)
                {
                    Button1.Enabled = false;
                    attempts = "";
                    foreach (DataRow row2 in dtAttempts.Rows)
                    {
                        attempts += "<div class ='attemptRow'><div class = 'attemptDate'>" + row2["date"].ToString() +
                                    "</div><div class = 'attemptScore'>" + row2["score"].ToString() + "</div></div>";
                    }
                }
                else
                {
                    attempts = "<div class ='attemptNone'>No attempts made.</div>";
                }
            }
        }
    }
}