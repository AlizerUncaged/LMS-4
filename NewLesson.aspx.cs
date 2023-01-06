using System;
using System.Diagnostics;
using System.Web.UI;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HOME
{
    public partial class NewLesson : Page
    {
        public string connectionString = "Data Source = localhost; username=root; password=; database=techque_db";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var title = Request.Form["title"];
                var contents = Request.Form["content"];
                var category = Request.Form["category"];
                
                string query = "INSERT INTO new_lessons (name, content, category) VALUES (@name, @content, @category)";
            
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", title);
                        command.Parameters.AddWithValue("@content", contents);
                        command.Parameters.AddWithValue("@category", category);

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                Console.WriteLine("Added");

            }
        }
    }
}