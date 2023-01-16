<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="HOMEPAGE.aspx.cs" Inherits="HOME.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
    <link href="CSS/HOMEPAGE%20css.css?v=24" rel="stylesheet"/>
    <link
      rel="stylesheet"
      href="https://cdn.jsdelivr.net/npm/swiper@8/swiper-bundle.min.css"
    />
    
    <script src="https://cdn.jsdelivr.net/npm/swiper@8/swiper-bundle.min.js"></script>
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
        
        const swiper = new Swiper('.swiper', {
          // Optional parameters
          direction: 'horizontal',
          loop: false,
        });
    </script>
    
    </html>

</asp:Content>