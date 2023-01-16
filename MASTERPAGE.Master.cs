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
        }
      
        protected void signout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }


    }
}