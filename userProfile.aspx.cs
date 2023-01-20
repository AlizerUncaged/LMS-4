using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HOME
{
    public partial class userProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var DBCon = Handlers.SqlInstance.Instance;

            if (IsPostBack)
            {
                var email = Request.Form["emails"];
                var gender = Request.Form["gender"];
                var password = Request.Form["password"];
                var userId = Session["id"].ToString();

                if (Request.Form["type"].ToString() == "admin")
                    using (var command = new MySqlCommand())
                    {
                        command.Connection = DBCon;
                        command.CommandText =
                            "UPDATE admin_user SET email = @email, password = @password WHERE id = @userId";
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@userId", userId);
                        command.ExecuteNonQuery();
                    }
                else
                    using (var command = new MySqlCommand())
                    {
                        command.Connection = DBCon;
                        command.CommandText =
                            "UPDATE users SET email = @email, password = @password, gender = @gender WHERE user_id = @userId";
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@userId", userId);
                        command.ExecuteNonQuery();
                    }
            }
        }
    }
}