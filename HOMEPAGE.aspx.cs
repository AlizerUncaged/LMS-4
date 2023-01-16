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
using HOME.Handlers;

namespace HOME
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string makehtml = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            var DBCon = SqlInstance.Instance;
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
                makehtml += "<div class = 'category'>" + row["language"].ToString() +
                            " <i class = 'fa-solid fa-arrow-right' onClick='qc_click(this.id)' id ='" +
                            row["language"].ToString() +
                            "'></i> <hr><div class ='quizTopicSec'><div class=\"swiper\"><div class=\"swiper-wrapper\">";

                foreach (DataRow row2 in dtQuiz.Rows)
                {
                    if (row["language"].ToString() == row2["language"].ToString())
                    {
                        // Check the required lessons
                        var requiredLessons = row2["requiredLessons"].ToString()
                            .Split(',')
                            .Select(int.Parse);

                        // makehtml += "<button type = 'button' >" + row2["title"].ToString()+"</button>";
                        makehtml +=
                            "<div class ='swiper-slide quizTopic' onClick='qt_click(this.id)' runat = 'server' id= '" +
                            row2["id"].ToString() +
                            "'><div class='quizTopicCover'></div><div class = 'quizTopicTitle'><i class=\"bi bi-lock-fill\"></i>" +
                            row2["title"].ToString() + "</div></div>";
                    }
                }

                makehtml += "</div></div></div></div>";
            }
        }
    }
}