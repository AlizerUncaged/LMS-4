<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="Certificates.aspx.cs" Inherits="HOME.Certificates" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <h1>CERTIFICATES</h1>
            </center>
        </div>
        <div class='category'>
            <div class="d-flex flex-row mb-3 mt-3">
                
            </div>
        </div>

        <div class="container"> <%= certificates %></div>
    </form>
    </body>
    <script>
                 function qtRecords_click(clicked_id) {
                     var id = this.id;
                     localStorage.setItem("quizid", clicked_id);
    
                     location.href = "AdminQuizRecords.aspx";
    
                 }
                 function qtAdd_click(clicked_id) {
                     var id = this.id;
                     localStorage.setItem("language", clicked_id);
    
                     location.href = "Add_EditQuiz.aspx";
    
                 }
                    function setModal(src)
                             {
                                  document.getElementById('mo').src = src;
                                     window.location = src;
                             }
                             
             </script>
    </html>

    <div class="modal fade" tabindex="-1" id="lesson-modal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 id="lesson-title" class="modal-title">hello</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body overflow-hidden" id="lesson-content">
                    <iframe class="container" id="mo"></iframe>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>