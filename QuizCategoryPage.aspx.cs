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
    public partial class WebForm7 : System.Web.UI.Page
    {
        public string makehtml = "";
        MySqlConnection DBCon = new MySqlConnection("Data Source = localhost; username=root; password=; database=techque_db;");
        protected void Page_Load(object sender, EventArgs e)
        {
            string language = "", quiz = "";
            DBCon.Open();
            MySqlCommand cmd = new MySqlCommand("Select * FROM category", DBCon);
            MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
            DataTable dtCat = new DataTable();
            adapt.Fill(dtCat);
            MySqlCommand cmd2 = new MySqlCommand("Select * FROM quiz", DBCon);
            MySqlDataAdapter adapt2 = new MySqlDataAdapter(cmd2);
            DataTable dtQuiz = new DataTable();
            adapt2.Fill(dtQuiz);
            foreach (DataRow row in dtCat.Rows)
            {
                makehtml += "<div class = 'category'> <h2>" + row["language"].ToString().ToUpper() + " </h2><hr><div class ='quizTopicSec'>";

                foreach (DataRow row2 in dtQuiz.Rows)
                {
                    if (row["language"].ToString().ToLower() == row2["language"].ToString().ToLower())
                    {
                        makehtml += "<div class = 'quizTopic' onClick='qt_click(this.id)' runat = 'server' id= '" + row2["id"].ToString() + "'><div class='quizTopicCover'></div><div class = 'quizTopicTitle'>" + row2["title"].ToString() + "</div> </div>";
                    }
                }

                makehtml += "</div></div>";
            }


        }
    }
}
