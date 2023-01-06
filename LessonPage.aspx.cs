using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HOME
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        public static string fileString;
        public string filePath;

        public string fileContents;
        MySqlConnection DBCon = new MySqlConnection("Data Source = localhost; username=root; password=; database=techque_db;");
        protected void Page_Load(object sender, EventArgs e)
        {
            filePath = "C:\\Users\\xagde\\Desktop\\DashBoardFurigana\\myfile.txt";

            fileContents = File.ReadAllText(filePath);






        }
    }
}