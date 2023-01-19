using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace HOME
{
    public partial class Leaderboards : Page
    {
        public List<dynamic> leaderboards = new List<dynamic>();

        protected void Page_Load(object sender, EventArgs e)
        {
            var DBCon = Handlers.SqlInstance.Instance;

            // var currentUserId = Session["id"];
            var quizId = Request.QueryString["quizId"];

            List<dynamic> orderedUsers = new List<dynamic>();

            string sql = $"SELECT * FROM quizattempts WHERE quiz_id = {quizId} ORDER BY score DESC";

            using (MySqlCommand cmd = new MySqlCommand(sql, DBCon))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic userData = new ExpandoObject();
                        userData.userId = reader.GetInt32("userid");
                        userData.score = reader.GetInt32("score");
                        userData.outOf = reader.GetInt32("items");
                        orderedUsers.Add(userData);
                    }
                }
            }

            foreach (var userId in orderedUsers)
            {
                sql = "SELECT * FROM users WHERE user_id = @userId";
                using (MySqlCommand cmd = new MySqlCommand(sql, DBCon))
                {
                    cmd.Parameters.AddWithValue("@userId", userId.userId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstname = reader.GetString("firstname");
                            string lastname = reader.GetString("lastname");
                            var pfpUrl = reader.GetString("pfpUrl");
                            userId.firstName = firstname;
                            userId.lastName = lastname;

                            userId.pfpUrl = pfpUrl;
                            if (string.IsNullOrWhiteSpace(pfpUrl))
                            {
                                userId.pfpUrl = "/images/user.png";
                            }
                        }
                    }
                }
            }

            leaderboards = orderedUsers;
        }
    }
}