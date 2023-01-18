using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using HOME.Models;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;

namespace HOME
{
    public partial class Certificates : Page
    {
        public string certificates = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            var DBCon = Handlers.SqlInstance.Instance;
            var currentUserId = Session["id"];

            List<string> categories = new List<string>();
            string query = "SELECT language FROM quiz";

            using (MySqlCommand command = new MySqlCommand(query, DBCon))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            categories.Add(reader.GetString("language"));
                        }
                        catch
                        {
                        }
                    }
                }
            }

            categories = categories.Distinct().ToList();

            // Get all quiz attempts from the user.
            List<dynamic> finishedQuizzes = new List<dynamic>();

            string sql = "SELECT quiz_id, date FROM quizattempts WHERE userid = @userId";
            using (MySqlCommand cmd = new MySqlCommand(sql, DBCon))
            {
                cmd.Parameters.AddWithValue("@userId", currentUserId);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic currentQuizzes = new System.Dynamic.ExpandoObject();

                        int quizId = reader.GetInt32(0);
                        string date = reader.GetString(1);

                        currentQuizzes.quizId = quizId;
                        currentQuizzes.date = date;

                        finishedQuizzes.Add(currentQuizzes);
                    }
                }
            }

            List<dynamic> quizList = new List<dynamic>();

            sql = "SELECT id, language, title FROM quiz";
            using (MySqlCommand cmd = new MySqlCommand(sql, DBCon))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dynamic quiz = new System.Dynamic.ExpandoObject();
                        quiz.id = reader.GetInt32("id");
                        quiz.language = reader.GetString("language");
                        quiz.title = reader.GetString("title");
                        quizList.Add(quiz);

                        var finishedQuiz = finishedQuizzes.Where(x => x.quizId == quiz.id);
                        foreach (var fQuiz in finishedQuiz)
                        {
                            fQuiz.language = quiz.language;
                        }
                    }
                }
            }

            List<dynamic> finishedCategoriesData = new List<dynamic>();

            finishedQuizzes = finishedQuizzes.GroupBy(x => x.quizId).Select(x => x.First()).ToList();

            foreach (string category in categories)
            {
                int finishedQuizzesInCategory = finishedQuizzes.Count(x => x.language == category);
                int totalQuizzesInCategory = quizList.Count(x => x.language == category);

                if (finishedQuizzesInCategory == totalQuizzesInCategory)
                {
                    dynamic finishedCategory = new System.Dynamic.ExpandoObject();
                    finishedCategory.language = category;
                    finishedCategory.quizzes = string.Join(", ", quizList.Select(x => x.title.Trim()));
                    finishedCategory.totalQuizzes = totalQuizzesInCategory;
                    finishedCategoriesData.Add(finishedCategory);
                }
                else
                {
                }
            }

            int certificatesc = 0;
            foreach (var row in categories.Where(y => finishedCategoriesData.Any(x => x.language == y)))
            {
                certificatesc++;
                certificates += "<div class = 'category'>" + row +
                                " <i class = 'fa-solid fa-arrow-right' onClick='qc_click(this.id)' id ='" +
                                row +
                                "'></i> <hr><div class ='quizTopicSec'><div class=\"swiper\"><div class=\"swiper-wrapper\">";

                foreach (dynamic rcertificate in finishedCategoriesData)
                {
                    List<string> lessonNames = new List<string>();

                    if (row == rcertificate.language.ToString())
                    {
                        string encodedString = HttpUtility.HtmlEncode(rcertificate.quizzes);

                        var url =
                            $"/Certificate?category={row}&quizQuestionCount={rcertificate.totalQuizzes}&quizQuestions={encodedString}";
                        // makehtml += "<button type = 'button' >" + row2["title"].ToString()+"</button>";
                        certificates +=
                            $"<div data-bs-toggle='modal' data-bs-target='#lesson-modal'  onclick='setModal(\"{url}\")' class ='swiper-slide quizTopic' " +
                            "'><div class='quizTopicCover'></div><div class = 'quizTopicTitle'>" +
                            rcertificate.language.ToString() + " Category</div></div>";
                    }
                }

                certificates += "</div></div></div></div>";
            }

            if (certificatesc == 0)
            {
                certificates = "<p>No certificates! Finish a quiz.</p>";
            }
        }
    }
}