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
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.3/font/bootstrap-icons.css">
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
            
            function setModal(title, text, id, userId)
            {
                    // send to api
                    
                  fetch('/Handlers/AddUserViewed', {
                      method: 'POST',
                      headers:{
                        'Content-Type': 'application/x-www-form-urlencoded'
                      },    
                      body: new URLSearchParams({
                          'lessonId': id,
                          'userId': userId,
                      })
                  });
                  
                 document.getElementById('lesson-title').innerHTML = atob(title);
                    document.getElementById('lesson-content').innerHTML =
                      marked.parse(atob(text));
                    
                    
            }
            function qt_click(clicked_id) {
                var id = this.id;
                localStorage.setItem("title", clicked_id);

                location.href = "AdminLesson.aspx";

            }
        </script>
    </body>

    <div class="modal fade" tabindex="-1" id="lesson-modal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 id="lesson-title" class="modal-title">hello</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body overflow-hidden" id="lesson-content">

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    </html>
</asp:Content>