using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
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

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("/");
                return;
            }

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
                                " <i class = 'fa-solid fa-arrow-right' onClick='qc_click(this.id)' id ='" +
                                row +
                                "'></i> <hr><div class ='quizTopicSec'>" +
                                "";

                    // quizzes
                    makehtml += "<div class=\"swiper\"><div class=\"swiper-wrapper\">";
                    foreach (DataRow row2 in dtQuiz.Rows)
                    {
                        List<dynamic> allRequiredLessons = new List<dynamic>();

                        if (row == row2["language"].ToString())
                        {
                            bool lessonsViewed = true;

                            // required lessons check
                            if (row2["requiredLessons"] != null && row2["requiredLessons"] != DBNull.Value &&
                                !string.IsNullOrWhiteSpace(row2["requiredLessons"].ToString()))
                            {
                                // Check the required lessons
                                var requiredLessons =
                                    row2["requiredLessons"].ToString()
                                        .Split(',')
                                        .Where(x => !string.IsNullOrWhiteSpace(x))
                                        .Select(int.Parse).ToList();

                                string _sql = "SELECT * FROM new_lessons WHERE lessonId = @lessonId";


                                for (int i = 0; i < requiredLessons.Count; i++)
                                {
                                    using (MySqlCommand _command = new MySqlCommand(_sql, DBCon))
                                    {
                                        _command.Parameters.AddWithValue("@lessonId", requiredLessons[i]);
                                        using (MySqlDataReader reader = _command.ExecuteReader())
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

                                                dynamic requiredLesson = new ExpandoObject();

                                                requiredLesson.name = name;
                                                requiredLesson.id = lessonId;
                                                requiredLesson.category = category;
                                                requiredLesson.content = content;

                                                allRequiredLessons.Add(requiredLesson);
                                            }
                                        }
                                    }

                                    // cmd.Parameters.AddWithValue("@lessonId", requiredLessons[i]);
                                    //
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

                            string viewLessonButtons = "<div class='d-flex flex-wrap overflow-hidden' style='height: 150px'><div class=\"vertical-swiper\"> <div class=\"swiper-wrapper\">";
                            foreach (dynamic requiredLesson in allRequiredLessons)
                            {
                                viewLessonButtons +=
                                    $"<div class=\"swiper-slide\"><a class='btn btn-primary row m-2' data-bs-toggle='modal' data-bs-target='#lesson-modal'  onclick=\"setModal('{Base64Encode(requiredLesson.name)}', '{Base64Encode(requiredLesson.content)}', {requiredLesson.id}, 0, true)\"><i class=\"bi bi-book\"></i> {requiredLesson.name}</a></div>";
                            }

                            viewLessonButtons += "</div></div></div>";

                            string newline = "\n";
                            string newlineDelimitedString =
                                string.Join(newline, allRequiredLessons.Select(x => x.name));
                            string encodedString = Base64Encode(HttpUtility.HtmlEncode(newlineDelimitedString));


                            // makehtml += "<button type = 'button' >" + row2["title"].ToString()+"</button>";
                            makehtml +=
                                $"<div class ='swiper-slide quizTopic' " +
                                $">{viewLessonButtons}<div class = 'quizTopicTitle' "+    (lessonsViewed
                                    ? "onClick='qt_click(this.id)' runat = 'server' id='" + row2["id"].ToString() + "'"
                                    : $"data-bs-toggle='modal' data-bs-target='#lesson-modal' onclick=\"setModal('{Base64Encode("You need to view the following lessons first.")}', '{encodedString}', 0, 0, false);\"") +"><i class=\"bi bi-pencil-fill me-2\"></i>" +
                                (!lessonsViewed ? "<i class=\"bi bi-lock-fill\"></i>" : string.Empty) +
                                row2["title"].ToString() + "</div></div>";
                        }
                    }

                    makehtml += "</div></div></div></div>";
                }
            }
        }
    }
}