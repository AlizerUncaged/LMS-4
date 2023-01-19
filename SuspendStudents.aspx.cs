using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace HOME
{
    public partial class SuspendStudents : Page
    {
        public List<dynamic> students = new List<dynamic>();

        protected void Page_Load(object sender, EventArgs e)
        {

            var DBCon = Handlers.SqlInstance.Instance;
            string userId = Request.QueryString["userid"];
            string suspended = Request.QueryString["suspended"];
            string sql;
            
            if (!string.IsNullOrWhiteSpace(userId))
            {
                sql = "UPDATE users SET is_suspended = @suspended WHERE user_id = @userId";
                
                using (MySqlCommand cmd = new MySqlCommand(sql, DBCon))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@suspended", suspended);
                    cmd.ExecuteNonQuery();
                }
            }
            List<dynamic> users = new List<dynamic>();
            sql = "SELECT user_id, firstname, lastname, gender, email, is_suspended, pfpUrl FROM users";
            using (MySqlCommand cmd = new MySqlCommand(sql, DBCon))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic user = new ExpandoObject();
                        user.user_id = reader.GetInt32("user_id");
                        user.firstname = reader.GetString("firstname");
                        user.lastname = reader.GetString("lastname");
                        user.gender = reader.GetString("gender");
                        user.email = reader.GetString("email");

                        user.is_suspended = false;

                        if (!DBNull.Value.Equals(reader["is_suspended"]))
                        {
                            user.is_suspended = bool.Parse(reader.GetString("is_suspended"));
                        }

                        user.pfpUrl = "/images/user.png";

                        if (!DBNull.Value.Equals(reader["pfpUrl"]))
                        {
                            user.pfpUrl = reader.GetString("pfpUrl");
                        }

                        users.Add(user);
                    }
                }
            }

            students = users;
        }
    }
}