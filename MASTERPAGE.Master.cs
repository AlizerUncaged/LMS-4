using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Spreadsheet;

namespace HOME
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Page load");
            var key = "type";

            if (Session[key] == null || Convert.IsDBNull(Session[key]))
            {
                // redirect the user
                Console.WriteLine("user is not logged in!");
                Response.Redirect("/");
            }


            if (bool.Parse(Session["suspended"].ToString()))
            {
                Response.Redirect("/Suspended.aspx");
                return;
            }

            var DBCon = Handlers.SqlInstance.Instance;

            var DBCon2 = Handlers.SqlInstance.Instance;

            var DBCon3 = Handlers.SqlInstance.Instance;
            // Remove invalid quizzes with empty titles.
            string sql = "DELETE FROM quiz WHERE TRIM(title) = '' OR title IS NULL";

            using (MySqlCommand cmd = new MySqlCommand(sql, DBCon))
            {
                cmd.ExecuteNonQuery();
            }

            // Remove invalid ``requiredLessons`` ids in ``quiz`` table.
            sql = "SELECT * FROM quiz";
            using (MySqlCommand cmd = new MySqlCommand(sql, DBCon))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string requiredLessons = reader.GetString("requiredLessons");
                        var mainQuizId = reader.GetInt32("id");

                        string[] lessonIds =
                            requiredLessons.Split(',').Where(x => int.TryParse(x, out var _)).ToArray();
                        
                        if (lessonIds.Any())
                        {
                            List<string> validLessonIds = new List<string>();
                            for (int i = 0; i < lessonIds.Length; i++)
                            {
                                int lessonId = int.Parse(lessonIds[i]);
                                string checkSql = "SELECT lessonId FROM new_lessons WHERE lessonId = @lessonId";
                                using (MySqlCommand checkCmd = new MySqlCommand(checkSql, DBCon2))
                                {
                                    checkCmd.Parameters.AddWithValue("@lessonId", lessonId);
                                    int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                                    if (exists > 0)
                                    {
                                        validLessonIds.Add(lessonIds[i]);
                                    }
                                }
                            }

                            string updatedLessons = string.Join(",", validLessonIds);
                            string updateSql = "UPDATE quiz SET requiredLessons = @updatedLessons WHERE id = @quizId";
                            using (MySqlCommand updateCmd = new MySqlCommand(updateSql, DBCon3))
                            {
                                updateCmd.Parameters.AddWithValue("@updatedLessons", updatedLessons);
                                updateCmd.Parameters.AddWithValue("@quizId", mainQuizId);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

        protected void signout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}