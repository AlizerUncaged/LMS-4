<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="HOMEPAGE.aspx.cs" Inherits="HOME.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.3/font/bootstrap-icons.css">
    <link href="CSS/HOMEPAGE css.css?v=27" rel="stylesheet"/> 
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous">

    <link
        rel="stylesheet"
        href="https://cdn.jsdelivr.net/npm/swiper@8/swiper-bundle.min.css"/>

    <script src="https://cdn.jsdelivr.net/npm/swiper@8/swiper-bundle.min.js"></script>
    <div class="home">
        <div class="header-grad">
            <center>
                <h1>Welcome, <%= Session["firstname"] %>!</h1>
                <h2>Below is a list of quizzes you have not answered as well the lessons</h2>
            </center>
        </div>
        <div class="quiz-sec m-2" id="quiz-sec"><%= makehtml %></div>
    </div>

    <script type="text/javascript">
            function qlesson(clicked_id) {
                    var id = this.id;
                    localStorage.setItem("title", clicked_id);
    
                    location.href = "lesson.aspx";
    
                }
    function gotoLesson_click(clicked_id) {

                localStorage.setItem("text", clicked_id); 

                location.href("lesson.aspx");
            }
            
        function qt_click(clicked_id) {
            localStorage.setItem("quizID", clicked_id);
            location.href = "startPage.aspx";

        }

        function qc_click(clicked_id) {
            localStorage.setItem("quizCategory", clicked_id);
            location.href = "QuizCategoryPage.aspx";
        }
        
               function setModal(title, text, id, userId, refreshOnClose)
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
                         
                         if (refreshOnClose === true)
                            document.getElementById('close-button').onclick = function(){location.reload();};
                         
                            document.getElementById('lesson-content').innerHTML =
                              marked.parse(atob(text));
                            
                            
                    }

                    
       
      new Swiper('.swiper', {
          // Optional parameters
          direction: 'horizontal',
          loop: false,
          
            // If we need pagination
            pagination: {
              el: '.swiper-pagination',
            },
            
        });
            
           new Swiper('.vertical-swiper', {
              // Optional parameters
              direction: 'vertical',
            });
           
    </script>
    <style>
        .vertical-swiper {
          height: 150px;
        }
    </style>

    <div class="modal fade" tabindex="-1" id="lesson-modal" data-backdrop="static" >
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 id="lesson-title" class="modal-title">hello</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body overflow-hidden" id="lesson-content">

                </div>
                <div class="modal-footer">
                    <button id="close-button" type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    </html>

</asp:Content>