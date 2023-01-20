<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="QuizCategoryPage.aspx.cs" Inherits="HOME.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
    <head>
        <link href="CSS/AdminHomePage%20css.css" rel="stylesheet"/>
    </head>
    <body>
    <form>
        <div class="header-grad">
            <center>
                <h1>QUIZZES</h1>
            </center>
        </div>

        <div class="container"> <%= makehtml %></div>
    </form>
    </body>
    <script>
             function qt_click(clicked_id) {
                 localStorage.setItem("quizID", clicked_id);
                 location.href = "startPage.aspx";

             }
        function setModal(title, text, id, userId)
                         {
                                 // send to api
                                 
                               // fetch('/Handlers/AddUserViewed', {
                               //     method: 'POST',
                               //     headers:{
                               //       'Content-Type': 'application/x-www-form-urlencoded'
                               //     },    
                               //     body: new URLSearchParams({
                               //         'lessonId': id,
                               //         'userId': userId,
                               //     })
                               // });
                               
                              document.getElementById('lesson-title').innerHTML = atob(title);
                                 document.getElementById('lesson-content').innerHTML =
                                   marked.parse(atob(text));
                                 
                                 
                         }
     
                         
             
             const swiper = new Swiper('.swiper', {
               // Optional parameters
               direction: 'horizontal',
               loop: false,
             });
         </script>

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