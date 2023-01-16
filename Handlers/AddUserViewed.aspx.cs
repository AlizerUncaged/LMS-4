using System;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace HOME.Handlers
{
    public partial class AddUserViewed : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Adding Lesson Metadata");

            var DBCon = SqlInstance.Instance;
            var lessonId = Request.Form["lessonId"];
            var userId = Session["id"];
            Console.WriteLine("LessonId: " + lessonId);
            Console.WriteLine("userId: " + userId);

            if (!string.IsNullOrWhiteSpace(lessonId) && userId != null)
            {
                string sql = $"INSERT INTO lessonmetadata(lessonId, usersViewed) VALUES ('{lessonId}', '{userId}')";

                using (MySqlCommand cmd = new MySqlCommand(sql, DBCon))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}