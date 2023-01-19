<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="HOME.AdminHomePage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
    <head>
        <link href="bootstrap/css/bootstrap.css?v=1" rel="stylesheet"/>
        <link href="CSS/AdminHomePage%20css.css?v=3" rel="stylesheet"/>
        <link href="fontawesome-free-6.2.1-web/css/all.css" rel="stylesheet"/>
    </head>
    <body>
    <form>
        <div class="header-grad">
            <center>
                <h1>QUIZZES</h1>
            </center>
        </div>
        <div class='category'>
            <div class="d-flex flex-row mb-3 mt-3">
                <a href="AddQuiz.aspx" class="btn btn-primary rounded-1">
                    <i class="fa-solid fa-plus"></i> Add Quiz
                </a>
            </div>
        </div>

        <div class="container"> <%= makehtml %></div>
    </form>
    </body>
    <script>
             function qtRecords_click(clicked_id) {
                 // var id = this.id;
                 // localStorage.setItem("quizid", clicked_id);
                 //
                 // location.href = "AdminQuizRecords.aspx";

             }
             function qtAdd_click(clicked_id) {
                 // var id = this.id;
                 // localStorage.setItem("language", clicked_id);
                 //
                 // location.href = "Add_EditQuiz.aspx";

             }
         </script>
    </html>
</asp:Content>