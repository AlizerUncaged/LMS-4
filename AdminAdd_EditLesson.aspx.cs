using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;


namespace HOME
{
    public partial class Add_EditLesson : System.Web.UI.Page
    {
        MySqlConnection DBCon = new MySqlConnection("Data Source = localhost; username=root; password=; database=techque_db");
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            MySqlCommand insertcmd = new MySqlCommand("Insert Into `lessons` (`lesson_name`, `lesson_category`,`lesson_content`) " + "VALUES(@Title,@Category,@Content)", DBCon);
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                    insertcmd.Parameters.AddWithValue("@Title", title.Text);
                    insertcmd.Parameters.AddWithValue("@Category", filename);
                    insertcmd.Parameters.AddWithValue("@Title", filename);


                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);

            insertcmd.ExecuteNonQuery();
        }
        protected void Load_Click(object sender, EventArgs e)
        {
        }
    }
}