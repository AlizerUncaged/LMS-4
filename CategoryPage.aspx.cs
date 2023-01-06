using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI.WebControls.WebParts;
using System.Net;
using System.Text;

namespace HOME
{
    public partial class CategoryPage : System.Web.UI.Page
    {
        public string makehtml = "";
        MySqlConnection DBCon = new MySqlConnection("Data Source = localhost; username=root; password=; database=techque_db;");
        protected void Page_Load(object sender, EventArgs e)
        {
            DBCon.Open();
            MySqlCommand cmd = new MySqlCommand("Select * FROM category", DBCon);
            MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
            DataTable dtCat = new DataTable();
            adapt.Fill(dtCat);
            MySqlCommand cmd2 = new MySqlCommand("Select * FROM lessons", DBCon);
            MySqlDataAdapter adapt2 = new MySqlDataAdapter(cmd2);
            DataTable dtQuiz = new DataTable();
            adapt2.Fill(dtQuiz);
            foreach (DataRow row in dtCat.Rows)
            {
                makehtml += "<div class = 'category'> <h2>" + row["language"].ToString().ToUpper() + " </h2><hr><div class ='lessonTopicSec'>";

                foreach (DataRow row2 in dtQuiz.Rows)
                {
                    if (row["language"].ToString().ToLower() == row2["lesson_category"].ToString().ToLower())
                    {
                        makehtml += "<div class = 'lessonTopic' onClick='qt_click(this.id)' runat = 'server' id= '" + row2["lesson_name"].ToString() + "'><div class='lessonTopicCover'></div><div class = 'lessonTopicTitle'>" + row2["lesson_name"].ToString() + "</div> </div>";

                        // makehtml += "<input type = 'hidden'runat='server' class='topicContainer' ID='hdnfld' ClientIDMode='Static' value = '" + row2["lesson_name"].ToString() + "'> </input>" + "<div class = 'quizTopic' onClick='qt_click(this.id)' runat = 'server' id= '" + row2["lesson_name"].ToString() + "'/>" + row2["lesson_name"].ToString() + "</div>";
                    }
                }

                makehtml += "</div></div>";
            }



        }


    }
}