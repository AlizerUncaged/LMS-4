using System;
using System.Web.UI;

namespace HOME
{
    public partial class Suspended : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void signout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}