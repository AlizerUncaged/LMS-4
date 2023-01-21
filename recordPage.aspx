<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="recordPage.aspx.cs" Inherits="HOME.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
    <head>
        <link href="bootstrap/css/bootstrap.css" rel="stylesheet"/>
        <%-- <link href="CSS/CategoryPage%20css.css" rel="stylesheet"/> --%>
        <link href="CSS/AdminHomePage%20css.css?v=3" rel="stylesheet"/>
    </head>
    <body>
    <form>
        <div class="header-grad">
            <center>
                <h1>RECORDS</h1>
            </center>
        </div>
        <div class="quiz-sec m-2">
            <%
                string Base64Encode(string plainText)
                {
                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                    return System.Convert.ToBase64String(plainTextBytes);
                }

                var categories = actions.GroupBy(x => x.language).Select(x => x.First());

                actions = actions.OrderByDescending(x => x.score).GroupBy(x => x.quizId).Select(x => x.First()).ToList();

                foreach (var category in categories)
                {
                    var quizInCategory = actions.Where(x => x.language == category.language);
            %>
                <div class='category'>
                    <%= category.language %> <i class='fa-solid fa-arrow-right'></i><hr>
                    <div class='quizTopicSec'>
                        <%
                            foreach (dynamic record in actions.Where(x => x.language == category.language))
                            {
                        %>
                            <div onclick="setModal('<%= Base64Encode(record.language) %>', '<%= Base64Encode($"## {record.title}\n### Total Score\n### {record.score} out of {record.items}\n### Took on {record.date}") %> ')" class='p-2 quizTopic' data-bs-toggle='modal' data-bs-target='#lesson-modal'>
                                <div class='quizTopicTitle'>
                                    <i class="bi bi-eye-fill"></i>
                                    <%= record.title %>
                                </div>
                            </div>
                        <% }
                        %>
                    </div>
                </div>
            <%
                }

            %>
            <%-- <table class="table m-4"> --%>
            <%--     <thead> --%>
            <%--     <tr> --%>
            <%--         <th scope="col">#</th> --%>
            <%--         <th scope="col">Quiz Title</th> --%>
            <%--         <th scope="col">Category</th> --%>
            <%--         <th scope="col">Score</th> --%>
            <%--         <th scope="col">Total Items</th> --%>
            <%--         <th scope="col">Date Taken</th> --%>
            <%--     </tr> --%>
            <%--     </thead> --%>
            <%--     <tbody> --%>
            <%--     <% foreach (dynamic record in actions) --%>
            <%--        { --%>
            <%--     %> --%>
            <%--         <tr> --%>
            <%--             <th scope="row"><%= record.id %></th> --%>
            <%--             <td><%= record.title %></td> --%>
            <%--             <td><%= record.language %></td> --%>
            <%--             <td><%= record.score %></td> --%>
            <%--             <td><%= record.items %></td> --%>
            <%--             <td><%= DateTime.Parse(record.date).ToString("dddd, MMMM dd, yyyy") %></td> --%>
            <%--         </tr> --%>
            <%--     <% } --%>
            <%--     %> --%>
            <%--     </tbody> --%>
            <%-- </table> --%>
        </div>
    </form>
    </body>
    <script>
           function setModal(title, text, id, userId, refreshOnClose)
                        {
                            
                             document.getElementById('lesson-title').innerHTML = atob(title);
                             
                             if (refreshOnClose === true)
                                document.getElementById('close-button').onclick = function(){location.reload();};
                             
                                document.getElementById('lesson-content').innerHTML =
                                  marked.parse(atob(text));
                                
                                
                        }
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
                    <button id="close-button" type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    </html>
</asp:Content>