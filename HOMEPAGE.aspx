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