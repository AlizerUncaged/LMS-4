<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminCategoryPage.aspx.cs" Inherits="HOME.AdminCategoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
    <head>
        <title>Lesson Category</title>
        <link href="bootstrap/css/bootstrap.css?v=1" rel="stylesheet"/>
        <link href="CSS/AdminHomePage%20css.css?v=3" rel="stylesheet"/>
        <link href="fontawesome-free-6.2.1-web/css/all.css" rel="stylesheet"/>
        <style>
            
         
        </style>
    </head>
    <body>
    <form>
        <div class="header-grad">
            <center>
                <h1>LESSONS</h1>
            </center>
        </div>
        
        <div class='category'>
            <div class="d-flex flex-row mb-3 mt-3">
                <a href="/NewLesson" class="btn btn-primary rounded-1">
                    <i class="fa-solid fa-plus"></i> Add Lesson
                </a>
            </div>
        </div>

        <div class="container"> <%= newLessons %></div>

        <div class="container"> <%= makehtml %></div>
    </form>

    <script>
            function qtAdd_click(clicked_id) {
                var id = this.id;
                localStorage.setItem("cat", clicked_id);

                location.href = "AdminAdd_EditLesson.aspx";
            }

            function qt_click(clicked_id) {
                var id = this.id;
                localStorage.setItem("title", clicked_id);

                location.href = "AdminLesson.aspx";

            }
        </script>
    </body>
    </html>
</asp:Content>