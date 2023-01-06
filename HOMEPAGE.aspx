<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="HOMEPAGE.aspx.cs" Inherits="HOME.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
    <link href="CSS/HOMEPAGE%20css.css?v=23" rel="stylesheet"/>
    <div class="home">
        <div class="header-grad">
            <center>
                <h1>Welcome, <%= Session["firstname"] %>!</h1>
                <h2>Below is a list of quizzes you have not answered:</h2>
            </center>
        </div>
        <div class="quiz-sec m-2" id="quiz-sec"><%= makehtml %></div>
    </div>

    <script type="text/javascript">

        function qt_click(clicked_id) {
            localStorage.setItem("quizID", clicked_id);
            location.href = "startPage.aspx";

        }

        function qc_click(clicked_id) {
            localStorage.setItem("quizCategory", clicked_id);
            location.href = "QuizCategoryPage.aspx";
        }
    </script>
    </html>

</asp:Content>