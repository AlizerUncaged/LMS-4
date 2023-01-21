using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Xml;

namespace HOME
{
    public partial class AdminHomePage1 : System.Web.UI.Page
    {
        public string makehtml = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            var dbCon = Handlers.SqlInstance.Instance;

            List<string> categories = new List<string>();
            string sql = "SELECT DISTINCT language FROM quiz";

            using (MySqlCommand cmd = new MySqlCommand(sql, dbCon))
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categories.Add(reader["language"].ToString());
                }

                reader.Close();
            }

            if (Request.QueryString["action"] != null && Request.QueryString["action"] == "delete" &&
                Request.QueryString["quizId"] != null)
            {
                sql = "DELETE FROM quizattempts WHERE quiz_id = @quizId";
                using (MySqlCommand cmd = new MySqlCommand(sql, dbCon))
                {
                    cmd.Parameters.AddWithValue("@quizId", Request.QueryString["quizId"]);
                    cmd.ExecuteNonQuery();
                }
                
                sql = "DELETE FROM quizquestions WHERE quiz_id = @quizId";
                using (MySqlCommand cmd = new MySqlCommand(sql, dbCon))
                {
                    cmd.Parameters.AddWithValue("@quizId", Request.QueryString["quizId"]);
                    cmd.ExecuteNonQuery();
                }
                
                sql = "DELETE FROM quiz WHERE id = @quizId";
                using (MySqlCommand cmd = new MySqlCommand(sql, dbCon))
                {
                    cmd.Parameters.AddWithValue("@quizId", Request.QueryString["quizId"]);
                    cmd.ExecuteNonQuery();
                }
            }

            categories = categories.Distinct().ToList();

            MySqlCommand cmd2 = new MySqlCommand("Select * FROM quiz", dbCon);
            MySqlDataAdapter adapt2 = new MySqlDataAdapter(cmd2);
            DataTable dtQuiz = new DataTable();
            adapt2.Fill(dtQuiz);
            foreach (var row in categories)
            {
                makehtml += "<div class = 'category'>" + row +
                            " <i class = 'fa-solid fa-file-circle-plus fa-xs' onClick='qtAdd_click(this.id)' id ='" +
                            row + "'></i> <hr><div class ='quizTopicSec'>";

                foreach (DataRow row2 in dtQuiz.Rows)
                {
                    if (row == row2["language"].ToString())
                    {
                        // makehtml += "<button type = 'button' >" + row2["title"].ToString()+"</button>";
                        makehtml +=
                            "<div class = 'quizTopic' onClick='qtRecords_click(this.id)' runat = 'server' id= '" +
                            row2["id"].ToString() +
                            $"'><div class='quizTopicCover'><a href='?quizId={row2["id"]}&action=delete'><i  class = 'fa-solid fa-trash-can fa-2xs'  id ='" +
                            row2["id"].ToString() +
                            $"tc'></i></a><a class='m-2' href='/Leaderboards?quizId={row2["id"]}'><i class = 'bi bi-trophy-fill text-success'  id ='" +
                            row2["id"].ToString() +
                            $"et'></i></a><a class='m-2' href='/AddQuiz?editQuizId={row2["id"]}'><i class=\"bi bi-pencil-square\"></i></a></div><div class = 'quizTopicTitle'>" +
                            row2["title"].ToString() + "</div> </div>";
                    }
                }

                makehtml += "</div></div>";
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
        }
    }
}