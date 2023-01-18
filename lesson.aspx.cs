using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using OpenXmlPowerTools;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Bibliography;

namespace HOME
{

   
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void signout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.Visible = false;

            // Retrieve the DOCX file from the database
            byte[] docxData = GetDocxFileFromDatabase();

            // Save the DOCX file to a temporary file
            string tempFileName = Path.GetTempFileName();
            File.WriteAllBytes(tempFileName, docxData);

            // Open the DOCX file using the Open XML SDK
            using (WordprocessingDocument doc = WordprocessingDocument.Open(tempFileName, false))
            {
                // Get the main document part
                MainDocumentPart mainPart = doc.MainDocumentPart;

                // Build a string builder to hold the document's text
                StringBuilder sb = new StringBuilder();

                // Iterate through the paragraphs in the document
                foreach (Paragraph p in mainPart.Document.Body.Elements<Paragraph>())
                {

                    // Iterate through the runs in the paragraph
                    foreach (Run r in p.Elements<Run>())
                    {
                        // Get the text of the run
                        string text = r.InnerText;

                        // Check for line breaks within the run
                        foreach (OpenXmlElement element in r.Elements())
                        {
                            if (element is Break)
                            {
                                // Add a new line character
                                text += Environment.NewLine;
                            }
                        }

                        // Check if the paragraph is centered
                        if (p.ParagraphProperties.Justification != null &&
                            p.ParagraphProperties.Justification.Val.HasValue &&
                            p.ParagraphProperties.Justification.Val.Value == JustificationValues.Center)
                        {
                            // If the paragraph is centered, wrap the text in a div with a centered style
                            text = "<div style='text-align: center'>" + text + "</div>";
                        }

                        // Append the text to the string builder
                        sb.Append(text);
                    }
                    sb.Append("<br>");
                }

                // Get the document's text
                string docText = sb.ToString();
                
                // Set the Text property of the Label control
                label1.InnerHtml = docText;
            }

            // Delete the temporary file
            File.Delete(tempFileName);



        }
        private byte[] GetDocxFileFromDatabase()
        {
            string l_name = Hidden1.Value;
            byte[] docxData = null;

           
                var connection = Handlers.SqlInstance.Instance;

                string sql = "SELECT lesson_content FROM lessons WHERE lesson_name = @lesson_name";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@lesson_name", l_name);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            docxData = (byte[])reader["lesson_content"];
                        }
                    }
                }
            

            return docxData;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoryPage.aspx");
        }
    }


}


