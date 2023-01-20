using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HOME.Handlers;

namespace HOME
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string makehtml = "";

        MySqlConnection DBCon =
            new MySqlConnection("Data Source = localhost; username=root; password=; database=techque_db;");

        protected void Page_Load(object sender, EventArgs e)
        {
            var DBCon = SqlInstance.Instance;


            List<string> categories = new List<string>();
            string sql = "SELECT DISTINCT language FROM quiz";

            using (MySqlCommand cmd = new MySqlCommand(sql, DBCon))
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categories.Add(reader["language"].ToString());
                }

                reader.Close();
            }

            var sqlCommand = "Select * FROM quiz";
            var validator = new SqlValidator.Validator();
            if (validator.Recheck(sqlCommand))
            {
                MySqlCommand cmd2 = new MySqlCommand(sqlCommand, DBCon);
                MySqlDataAdapter adapt2 = new MySqlDataAdapter(cmd2);
                DataTable dtQuiz = new DataTable();
                adapt2.Fill(dtQuiz);
                foreach (var row in categories)
                {
                    makehtml += "<div class = 'category'>" + row +
                                " <i class = 'fa-solid fa-arrow-right'  id ='" +
                                row +
                                "'></i> <hr><div class ='quizTopicSec'><div class=\"swiper\"><div class=\"swiper-wrapper\">";

                    foreach (DataRow row2 in dtQuiz.Rows)
                    {
                        List<string> allLessonNames = new List<string>();

                        if (row == row2["language"].ToString())
                        {
                            bool lessonsViewed = true;

                            if (row2["requiredLessons"] != null && row2["requiredLessons"] != DBNull.Value &&
                                !string.IsNullOrWhiteSpace(row2["requiredLessons"].ToString()))
                            {
                                // Check the required lessons
                                var requiredLessons =
                                    row2["requiredLessons"].ToString()
                                        .Split(',')
                                        .Where(x => !string.IsNullOrWhiteSpace(x))
                                        .Select(int.Parse).ToList();

                                allLessonNames = new List<string>();
                                string _sql = "SELECT name FROM new_lessons WHERE lessonId = @lessonId";

                                using (MySqlCommand cmd = new MySqlCommand(_sql, DBCon))
                                {
                                    for (int i = 0; i < requiredLessons.Count; i++)
                                    {
                                        cmd.Parameters.AddWithValue("@lessonId", requiredLessons[i]);

                                        allLessonNames.Add(cmd.ExecuteScalar().ToString());
                                        cmd.Parameters.Clear();
                                    }
                                }


                                // Check first if valid.
                                var quizId = row;
                                int userId = (int)Session["id"];
                                // Connect to the database

                                // Get the required lesson IDs for the quiz
                                var command = new MySqlCommand("SELECT requiredLessons FROM quiz WHERE id = @quizId",
                                    DBCon);
                                command.Parameters.AddWithValue("@quizId", quizId);

                                // Split the required lesson IDs into an array

                                // Check if the user has viewed each required lesson
                                foreach (var requiredLessonId in requiredLessons)
                                {
                                    command = new MySqlCommand(
                                        "SELECT COUNT(*) FROM lessonMetadata WHERE lessonId = @lessonId AND usersViewed LIKE @userId",
                                        DBCon);
                                    command.Parameters.AddWithValue("@lessonId", requiredLessonId);
                                    command.Parameters.AddWithValue("@userId", "%" + userId + "%");
                                    if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                                    {
                                        // Response.Redirect("LessonNotViewed.aspx");
                                        lessonsViewed = false;
                                    }
                                }
                            }

                            string newline = "\n";
                            string newlineDelimitedString = string.Join(newline, allLessonNames);
                            string encodedString = Base64Encode(HttpUtility.HtmlEncode(newlineDelimitedString));


                            // makehtml += "<button type = 'button' >" + row2["title"].ToString()+"</button>";
                            makehtml +=
                                $"<div class ='swiper-slide quizTopic' " +
                                (lessonsViewed
                                    ? "onClick='qt_click(this.id)' runat = 'server' id= "
                                    : $"data-bs-toggle='modal' data-bs-target='#lesson-modal' onclick=\"setModal('{Base64Encode("You need to view the following lessons first.")}', '{encodedString}', 0, 0);\"") +
                                " '" +
                                row2["id"].ToString() +
                                "'><div class='quizTopicCover'></div><div class = 'quizTopicTitle'>" +
                                (!lessonsViewed ? "<i class=\"bi bi-lock-fill\"></i>" : string.Empty) +
                                row2["title"].ToString() + "</div></div>";
                        }
                    }

                    makehtml += "</div></div></div></div>";
                }
            }

            // string language = "", quiz = "";
            // DBCon.Open();
            // MySqlCommand cmd = new MySqlCommand("Select * FROM category", DBCon);
            // MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
            // DataTable dtCat = new DataTable();
            // adapt.Fill(dtCat);
            // MySqlCommand cmd2 = new MySqlCommand("Select * FROM quiz", DBCon);
            // MySqlDataAdapter adapt2 = new MySqlDataAdapter(cmd2);
            // DataTable dtQuiz = new DataTable();
            // adapt2.Fill(dtQuiz);
            // foreach (DataRow row in dtCat.Rows)
            // {
            //     makehtml += "<div class = 'category'> <h2>" + row["language"].ToString().ToUpper() + " </h2><hr><div class ='quizTopicSec'>";
            //
            //     int quizzes = 0;
            //     foreach (DataRow row2 in dtQuiz.Rows)
            //     {
            //         if (row["language"].ToString().ToLower() == row2["language"].ToString().ToLower())
            //         {
            //             makehtml += "<div class = 'quizTopic' onClick='qt_click(this.id)' runat = 'server' id= '" + row2["id"].ToString() + "'><div class='quizTopicCover'></div><div class = 'quizTopicTitle'>" + row2["title"].ToString() + "</div> </div>";
            //         }
            //
            //         quizzes++;
            //     }
            //
            //     if (quizzes <= 0)
            //     {
            //         makehtml += "<p>No quizzes for this category.</p>";
            //     }
            //
            //     makehtml += "</div></div>";
            // }
        }
    }
}