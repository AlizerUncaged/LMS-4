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
    public partial class resultsPage : System.Web.UI.Page
    {
        public string scoreheader="", scoremessage, datetime,intqid,count,userid,attempts;
        public string points, all;
        public int score, items;
        DateTime date = DateTime.Now.Date;
        protected void Page_Load(object sender, EventArgs e)
        {
            userid = Session["id"].ToString();
            quizPage.i = 0;
            quizPage.points = 0;
            datetime = date.ToString("MMMM dd yyyy");
            points = Request.QueryString["Score"].ToString();
            all = Request.QueryString["Items"].ToString();
            score=Convert.ToInt32(points);
            items = Convert.ToInt32(all);
            intqid = Request.QueryString["QuizID"].ToString();
            scoreheader = "You scored: " + score + "/" + items;
           
            var DBCon = Handlers.SqlInstance.Instance;

            MySqlCommand cmd = new MySqlCommand("INSERT INTO quizattempts(`quiz_id`,`userid`,`score`,`items`,`date`) " + "VALUES(" + intqid + ", " + userid + ", " + score + ", " + items + ", '" + datetime + "')", DBCon);
            //MySqlCommand cmd = new MySqlCommand("INSERT INTO `quizattempts`(`quiz_id`,`userid,`score`,`items`,`date`) "+"VALUES("+intqid+", " + userid +", "+score+", "+items+", '"+datetime+"')", DBCon);
            cmd.ExecuteNonQuery();
            MySqlCommand cmd2 = new MySqlCommand("Select * FROM quizattempts WHERE quiz_id ='" + intqid + "' AND userid ='" + Session["id"].ToString() + "'", DBCon);
            MySqlDataAdapter adapt2 = new MySqlDataAdapter(cmd2);
            DataTable dtAttempts = new DataTable();
            adapt2.Fill(dtAttempts);
            if (dtAttempts != null)
            {
                if (dtAttempts.Rows.Count > 0)
                {
                    attempts = "";
                    foreach (DataRow row2 in dtAttempts.Rows)
                    {
                        attempts += "<div class ='attemptRow'><div class = 'attemptDate'>" + row2["date"].ToString() + "</div><div class = 'attemptScore'>" + row2["score"].ToString() + "</div></div>";
                    }
                }
                else
                {
                    attempts = "<div class ='attemptNone'>No attempts made.</div>";
                }

            }
            if (score == items)
            {
                scoremessage = "Congratulations! You received full marks for this quiz! You may download your certificate in the <a href ='#'>certificates page.</a>"+ count;

            }
            else if (score >= (0.75 * items))
            {
                scoremessage = "Good job! You're on your way to fully mastering the topic. Read the available <a href = 'CategoryPage.aspx'>lesson materials in TechQue</a> and see if you can get full marks on your next attempt. You may also download your certificate in the <a href ='#'>certificates page.</a>" + count;
            }
            else if(score == (items / 2) && score < (0.75*items))
            {
                scoremessage = "You passed! You got half of the questions correct. Read the available <a href = 'CategoryPage.aspx'>lesson materials in TechQue</a> and see if you can do better." + count;
            }
            else if(score < (items/2))
            {
                scoremessage = "Nice try. You failed the quiz. Read the available <a href = 'CategoryPage.aspx'>lesson materials in TechQue</a> and see if you can get full marks on your next attempt. Good luck!" + count;
            }

            
        }
    }
}