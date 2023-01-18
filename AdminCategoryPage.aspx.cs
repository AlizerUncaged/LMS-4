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
using HOME.Models;

namespace HOME
{
    public partial class AdminCategoryPage : System.Web.UI.Page
    {
        public string makehtml = "";
        public string newLessons = "";


        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var DBCon = Handlers.SqlInstance.Instance;

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

            // new lessons
            var categorized = lessons.GroupBy(x => x.Category);

            foreach (IEnumerable<Lesson> row in categorized)
            {
                newLessons += "<div class = 'category'>" + row.FirstOrDefault().Category +
                              " <i class = 'fa-solid fa-file-circle-plus fa-xs' onClick='qtAdd_click(this.id)' id ='" +
                              row.FirstOrDefault().Category + "'></i> <hr><div class ='quizTopicSec'>";

                foreach (Lesson row2 in row)
                {
                    newLessons +=
                        "<input type = 'hidden'runat='server' class='topicContainer' ID='hdnfld' ClientIDMode='Static' value = '" +
                        row2.Name.ToString() + "'> </input>" +
                        "<div class = 'quizTopic' id= '" +
                        row2.Name.ToString() +
                        $"'><div class='quizTopicCover'><a href='NewLesson?action=deleteLesson&lessonId={row2.LessonId}'><i class = 'fa-solid fa-trash-can fa-2xs' onClick='Delete_Click' id ='" +
                        row2.LessonId.ToString() +
                        $"tc'></i></a><a href='/NewLesson?lessonId={row2.LessonId}'><i runat='server' class = 'fa-solid fa-pen-to-square fa-2xs' id ='" +
                        row2.LessonId.ToString() + "et'></i></a><i onclick='setModal(\"" + Base64Encode(row2.Name) + "\", \"" +
                        Base64Encode(row2.Content) +
                        $"\", {row2.LessonId}, {0})' data-bs-toggle='modal' data-bs-target='#lesson-modal' class=\"bi bi-eye-fill text-black-50 m-2\" style='cursor: pointer'></i></div><div class = 'quizTopicTitle'>" +
                        $"<p class='opacity-50'>ID: {row2.LessonId}</p>" +
                        row2.Name.ToString() + "</div> </div>";
                }

                newLessons += "</div></div>";
            }

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
                makehtml += "<div class = 'category'>" + row["language"].ToString() +
                            " <i class = 'fa-solid fa-file-circle-plus fa-xs' onClick='qtAdd_click(this.id)' id ='" +
                            row["language"].ToString() + "'></i> <hr><div class ='quizTopicSec'>";

                foreach (DataRow row2 in dtQuiz.Rows)
                {
                    if (row["language"].ToString().ToLower() == row2["lesson_category"].ToString().ToLower())
                    {
                        makehtml +=
                            "<input type = 'hidden'runat='server' class='topicContainer' ID='hdnfld' ClientIDMode='Static' value = '" +
                            row2["lesson_name"].ToString() + "'> </input>" +
                            "<div class = 'quizTopic'  id= '" +
                            row2["lesson_name"].ToString() +
                            "'><div class='quizTopicCover'><i runat='server' class = 'fa-solid fa-trash-can fa-2xs' onClick='Delete_Click' id ='" +
                            row2["lesson_id"].ToString() +
                            "tc'></i><i runat='server' class = 'fa-solid fa-pen-to-square fa-2xs' onClick='Edit_Click' id ='" +
                            row2["lesson_id"].ToString() + "et'></i></div><div class = 'quizTopicTitle'>" +
                            row2["lesson_name"].ToString() + "</div> </div>";
                    }
                }

                makehtml += "</div></div>";
            }
        }
    }
}