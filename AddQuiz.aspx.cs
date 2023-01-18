using System;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace HOME
{
    public partial class AddQuiz : Page
    {
        public string lessonId = "-1";
        public string title = "";
        public string category = "";
        public string timeLimit = "";
        public string requiredLessons = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            var conn = Handlers.SqlInstance.Instance;

            if (IsPostBack)
            {
                var newQuizTitle = Request.Form["title"];
                var newQuizLanguage = Request.Form["language"];
                var newTimeLimit = Request.Form["timeLimit"];
                var newRequiredLessons = Request.Form["requiredLessons"];
                string[][] question = new[]
                {
                    Request.Form.GetValues("question[][title]"), // 0
                    Request.Form.GetValues("question[][answers]"), // 1
                    Request.Form.GetValues("question[][correctAnswers]") // 2
                };

                string sql =
                    "INSERT INTO quiz (language, title, timelimit, requiredLessons) VALUES (@language, @title, @timelimit, @requiredLessons)";
                long quizId = 0;
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@language", newQuizLanguage);
                    cmd.Parameters.AddWithValue("@title", newQuizTitle);
                    cmd.Parameters.AddWithValue("@timelimit", newTimeLimit);
                    cmd.Parameters.AddWithValue("@requiredLessons", newRequiredLessons);
                    cmd.ExecuteNonQuery();

                    quizId = cmd.LastInsertedId;
                }

                for (int i = 0; i < question[0].Length; i++)
                {
                    string[] options = question[1][i].Split(',');
                    string optA = "",
                        optB = "",
                        optC = "",
                        optD = "";

                    try
                    {
                        optA = options[0];
                        optB = options[1];
                        optC = options[2];
                        optD = options[3];
                    }
                    catch
                    {
                        
                    }

                    string optCorrect = question[2][i];
                    string questionText = question[0][i];
                    int qorder = i + 1;

                    string query =
                        "INSERT INTO quizquestions (quiz_id, qorder, questiontext, optA, optB, optC, optD, optCorrect) VALUES (@quizId, @qorder, @questionText, @optA, @optB, @optC, @optD, @optCorrect)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@quizId", quizId);
                        cmd.Parameters.AddWithValue("@qorder", qorder);
                        cmd.Parameters.AddWithValue("@questionText", questionText);
                        cmd.Parameters.AddWithValue("@optA", optA);
                        cmd.Parameters.AddWithValue("@optB", optB);
                        cmd.Parameters.AddWithValue("@optC", optC);
                        cmd.Parameters.AddWithValue("@optD", optD);
                        cmd.Parameters.AddWithValue("@optCorrect", optCorrect);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}