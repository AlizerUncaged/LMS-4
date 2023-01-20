using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HOME
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        public List<dynamic> actions = new List<dynamic>();

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentUserId = Session["id"];
            var connection = Handlers.SqlInstance.Instance;
            using (var command = new MySqlCommand())
            {
                command.Connection = connection;
                command.CommandText =
                    "SELECT attempt_id, quiz_id, score, items, date FROM quizattempts WHERE userid = @userId";
                command.Parameters.AddWithValue("@userId", currentUserId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic attempt = new ExpandoObject();
                        attempt.id = reader.GetInt32("attempt_id");
                        attempt.quizId = reader.GetInt32("quiz_id");
                        attempt.score = reader.GetString("score");
                        attempt.items = reader.GetString("items");
                        attempt.date = reader.GetString("date");
                        actions.Add(attempt);
                    }
                }
            }

            foreach (dynamic action in actions)
            {
                var quizId = action.quizId.ToString();
                
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id, language, title FROM quiz WHERE id = @quizId";
                    command.Parameters.AddWithValue("@quizId", quizId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            action.title = reader.GetString("title");
                            action.language = reader.GetString("language");
                            // var quiz = new
                            // {
                            //     Id = reader.GetInt32("id"),
                            //     Language = reader.GetString("language"),
                            //     Title =,
                            // };
                            // Do something with the quiz data
                        }
                    }
                }
                
            }

            // sned
        }
    }
}