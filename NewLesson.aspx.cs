using System;
using System.Diagnostics;
using System.Web.UI;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HOME
{
    public partial class NewLesson : Page
    {
        public string lessonId = "-1";
        public string title = "";
        public string category = "";
        public string content = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            var connection = Handlers.SqlInstance.Instance;
            var action = Request.QueryString["action"];

            lessonId = Request.QueryString["lessonId"];

            if (int.TryParse(lessonId, out var parsedL))
            {
                if (parsedL >= 0)
                {
                    string query = "SELECT name, content, category FROM new_lessons WHERE lessonId = @lessonId";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@lessonId", lessonId);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                title = reader["name"].ToString();
                                content = reader["content"].ToString();
                                category = reader["category"].ToString();
                            }
                            else
                            {
                                Console.WriteLine("Lesson not found.");
                            }
                        }
                    }
                }
            }
            
            if (!string.IsNullOrWhiteSpace(action) && action == "deleteLesson")
            {
                string query = "DELETE FROM new_lessons WHERE lessonId = @lessonId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@lessonId", lessonId);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Lesson deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Lesson not found.");
                    }
                }
                
                    
                Response.Redirect("/AdminCategoryPage.aspx");
            }

            if (IsPostBack)
            {
                

                var title = Request.Form["title"];
                var contents = Request.Form["content"];
                var category = Request.Form["category"];
                var lessonId = Request.Form["lessonId"]; // assuming lessonId is a string in the form

                
                
                if (string.IsNullOrWhiteSpace(lessonId) || lessonId == "-1")
                {
                    string query =
                        "INSERT INTO new_lessons (name, content, category) VALUES (@name, @content, @category)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", title);
                        command.Parameters.AddWithValue("@content", contents);
                        command.Parameters.AddWithValue("@category", category);

                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("Added");
                }
                else
                {
                    string query =
                        "UPDATE new_lessons SET name=@name, content=@content, category=@category WHERE lessonId=@lessonId";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@lessonId", lessonId);
                        command.Parameters.AddWithValue("@name", title);
                        command.Parameters.AddWithValue("@content", contents);
                        command.Parameters.AddWithValue("@category", category);
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("Row updated");
                }
            }
        }
    }
}