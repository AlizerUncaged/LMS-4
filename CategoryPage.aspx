<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="CategoryPage.aspx.cs" Inherits="HOME.CategoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
    <head>
        <title>Lesson Category</title>
        <link href="CSS/CategoryPage%20css.css" rel="stylesheet"/>
        <script src="https://cdn.jsdelivr.net/npm/marked/marked.min.js"></script>
    </head>
    <body>
    <form>
        <div class="header-grad">
            <center>
                <h1>LESSONS</h1>
            </center>
        </div>
        
        <%-- <button type="button" class="btn btn-primary"> --%>
        <%--     Launch demo modal --%>
        <%-- </button> --%>

        <div class="container"> <%= makehtml %></div>
    </form>

    <script>
            function gotoLesson_click(clicked_id) {

                localStorage.setItem("text", clicked_id); 

                location.href("lesson.aspx");
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

                location.href = "lesson.aspx";

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
                <div class="modal-body" id="lesson-content">
                    
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    </html>

</asp:Content>