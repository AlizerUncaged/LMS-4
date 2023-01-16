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
using HOME.Handlers;
using HOME.Models;

namespace HOME
{
    public partial class CategoryPage : System.Web.UI.Page
    {
        public string makehtml = "";

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var DBCon = SqlInstance.Instance;
            MySqlCommand cmd = new MySqlCommand("Select * FROM category", DBCon);
            MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
            DataTable dtCat = new DataTable();
            adapt.Fill(dtCat);
            MySqlCommand cmd2 = new MySqlCommand("Select * FROM lessons", DBCon);
            MySqlDataAdapter adapt2 = new MySqlDataAdapter(cmd2);
            DataTable dtQuiz = new DataTable();
            adapt2.Fill(dtQuiz);

            List<Lesson> lessons = new List<Lesson>();
            string query = "SELECT lessonId, name, category, content FROM new_lessons";

            using (MySqlCommand command = new MySqlCommand(query, DBCon))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int lessonId = 0;
                        string name = "";
                        string category = "";
                        string content = "";
                        try
                        {
                            lessonId = reader.GetInt32("lessonId");

                            name = reader.GetString("name");
                            category = reader.GetString("category");
                            content = reader.GetString("content");
                        }
                        catch
                        {
                        }


                        Lesson lesson = new Lesson
                        {
                            LessonId = lessonId,
                            Name = name,
                            Category = category,
                            Content = content
                        };

                        lessons.Add(lesson);
                    }
                }
            }

            var categorized = lessons.GroupBy(x => x.Category).Select(x => x.First());
            var userId = Session["id"];
            foreach (var category in categorized)
            {
                makehtml += "<div class = 'category'> <h2>" + category.Category +
                            " </h2><hr><div class ='lessonTopicSec'>";
                foreach (var l in lessons.Where(x => x.Category == category.Category))
                {
                    // encode requried to we wont have problems setting these on html

                    // check if unlocked
                    var lessonTitleEncoded = Base64Encode(l.Name);
                    var lessonContentEncoded = Base64Encode(l.Content);
                    makehtml += $"<div onclick='setModal(\"" + lessonTitleEncoded + "\", \"" + lessonContentEncoded +
                                $"\", {l.LessonId}, {userId})' data-bs-toggle='modal' data-bs-target='#lesson-modal' class='lessonTopic'  id= '" +
                                l.Name +
                                "'><div class='lessonTopicCover'></div><div class = 'lessonTopicTitle'>" +
                                l.Name + "</div> </div>";
                }

                makehtml += "</div></div>";
            }

            foreach (DataRow row in dtCat.Rows)
            {
                makehtml += "<div class = 'category'> <h2>" + row["language"].ToString().ToUpper() +
                            " </h2><hr><div class ='lessonTopicSec'>";

                foreach (DataRow row2 in dtQuiz.Rows)
                {
                    if (row["language"].ToString().ToLower() == row2["lesson_category"].ToString().ToLower())
                    {
                        makehtml += "<div class = 'lessonTopic' onClick='qt_click(this.id)' runat = 'server' id= '" +
                                    row2["lesson_name"].ToString() +
                                    "'><div class='lessonTopicCover'></div><div class = 'lessonTopicTitle'>" +
                                    row2["lesson_name"].ToString() + "</div> </div>";

                        // makehtml += "<input type = 'hidden'runat='server' class='topicContainer' ID='hdnfld' ClientIDMode='Static' value = '" + row2["lesson_name"].ToString() + "'> </input>" + "<div class = 'quizTopic' onClick='qt_click(this.id)' runat = 'server' id= '" + row2["lesson_name"].ToString() + "'/>" + row2["lesson_name"].ToString() + "</div>";
                    }
                }

                makehtml += "</div></div>";
            }
        }
    }
}