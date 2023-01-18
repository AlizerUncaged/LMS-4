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
                            "'><div class='quizTopicCover'><i runat='server' class = 'fa-solid fa-trash-can fa-2xs' onClick='Delete_Click' id ='" +
                            row2["id"].ToString() +
                            "tc'></i><i runat='server' class = 'fa-solid fa-pen-to-square fa-2xs' onClick='Edit_Click' id ='" +
                            row2["id"].ToString() + "et'></i></div><div class = 'quizTopicTitle'>" +
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