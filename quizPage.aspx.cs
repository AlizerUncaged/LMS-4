using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Office2010.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HOME
{
    public partial class quizPage : System.Web.UI.Page
    {
        public string makehtml = "", intqid, answer;
        public static int i = 0, points = 0;
        public DataTable dtItems = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            var DBCon = Handlers.SqlInstance.Instance;
      

            intqid = hdnfld_quizID.Text;
            MySqlCommand cmd = new MySqlCommand("Select * FROM quizquestions where quiz_id='" + intqid + "'", DBCon);
            MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
            adapt.Fill(dtItems);
            if (i <= dtItems.Rows.Count)
            {
                if (dtItems.Rows.Count > 0)
                {
                    answer = dtItems.Rows[i]["optCorrect"].ToString();
                    makehtml += "<div class = 'item'><div class='question'>" +
                                dtItems.Rows[i]["questiontext"].ToString() + "</div>";

                    makehtml +=
                        "<div class ='choices'><label class='radio'><div class='choiceA'><input runat ='server' type='radio' name='answer' value='" +
                        dtItems.Rows[i]["optA"].ToString() + "' ID='optA'><span>A.) " +
                        dtItems.Rows[i]["optA"].ToString() + "</div></span></label>";
                    makehtml +=
                        "<label class='radio'><div class='choiceB'><input runat ='server' type='radio' name='answer' value='" +
                        dtItems.Rows[i]["optB"].ToString() + "' ID='opt'><span>B.) " +
                        dtItems.Rows[i]["optB"].ToString() + "</div></span></label>";
                    makehtml +=
                        "<label class='radio'><div class='choiceC'><input runat ='server' type='radio' name='answer' value='" +
                        dtItems.Rows[i]["optC"].ToString() + "' ID='optC'><span>C.) " +
                        dtItems.Rows[i]["optC"].ToString() + "</div></span></label>";
                    makehtml +=
                        "<label class='radio'><div class='choiceD'><input runat ='server' type='radio' name='answer' value='" +
                        dtItems.Rows[i]["optD"].ToString() + "' ID='optD'><span>D.) " +
                        dtItems.Rows[i]["optD"].ToString() + "</div></span></label>";
                }
            }

            Console.WriteLine();
            /**/
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Request.Form["answer"] != null)
            {
                if (Request.Form["answer"].ToString() == answer)
                {
                    points++;
                }
            }

            i++;
            int rowcount = dtItems.Rows.Count;
            if (i < (rowcount - 1))
            {
                if (dtItems.Rows.Count > 0)
                {
                    answer = dtItems.Rows[i]["optCorrect"].ToString();
                    makehtml = "";
                    makehtml += "<div class = 'item'><div class='question'>" +
                                dtItems.Rows[i]["questiontext"].ToString() + "</div>";
                    makehtml +=
                        "<div class ='choices'><label class='radio'><div class='choiceA'><input runat ='server' type='radio' name='answer' value='" +
                        dtItems.Rows[i]["optA"].ToString() + "' ID='optA'><span>A.) " +
                        dtItems.Rows[i]["optA"].ToString() + "</div></span></label>";
                    makehtml +=
                        "<label class='radio'><div class='choiceB'><input runat ='server' type='radio' name='answer' value='" +
                        dtItems.Rows[i]["optB"].ToString() + "' ID='opt'><span>B.) " +
                        dtItems.Rows[i]["optB"].ToString() + "</div></span></label>";
                    makehtml +=
                        "<label class='radio'><div class='choiceC'><input runat ='server' type='radio' name='answer' value='" +
                        dtItems.Rows[i]["optC"].ToString() + "' ID='optC'><span>C.) " +
                        dtItems.Rows[i]["optC"].ToString() + "</div></span></label>";
                    makehtml +=
                        "<label class='radio'><div class='choiceD'><input runat ='server' type='radio' name='answer' value='" +
                        dtItems.Rows[i]["optD"].ToString() + "' ID='optD'><span>D.) " +
                        dtItems.Rows[i]["optD"].ToString() + "</div></span></label>";
                }
            }
            else if (i == (rowcount - 1))
            {
                answer = dtItems.Rows[i]["optCorrect"].ToString();
                makehtml = "";
                makehtml += "<div class = 'item'><div class='question'>" + dtItems.Rows[i]["questiontext"].ToString() +
                            "</div>";
                makehtml +=
                    "<div class ='choices'><label class='radio'><div class='choiceA'><input runat ='server' type='radio' name='answer' value='" +
                    dtItems.Rows[i]["optA"].ToString() + "' ID='optA'><span>A.) " + dtItems.Rows[i]["optA"].ToString() +
                    "</div></span></label>";
                makehtml +=
                    "<label class='radio'><div class='choiceB'><input runat ='server' type='radio' name='answer' value='" +
                    dtItems.Rows[i]["optB"].ToString() + "' ID='opt'><span>B.) " + dtItems.Rows[i]["optB"].ToString() +
                    "</div></span></label>";
                makehtml +=
                    "<label class='radio'><div class='choiceC'><input runat ='server' type='radio' name='answer' value='" +
                    dtItems.Rows[i]["optC"].ToString() + "' ID='optC'><span>C.) " + dtItems.Rows[i]["optC"].ToString() +
                    "</div></span></label>";
                makehtml +=
                    "<label class='radio'><div class='choiceD'><input runat ='server' type='radio' name='answer' value='" +
                    dtItems.Rows[i]["optD"].ToString() + "' ID='optD'><span>D.) " + dtItems.Rows[i]["optD"].ToString() +
                    "</div></span></label>";
                Button1.Text = "Submit";
            }
            else if (i == rowcount)
            {
                Response.Redirect("resultsPage.aspx?Score=" + points + "&Items=" + rowcount + "&QuizID=" + intqid);
            }
        }


        protected void Load_Click(object sender, EventArgs e)
        {
            Button2.Enabled = false;
            Button2.Visible = false;
        }
    }
}