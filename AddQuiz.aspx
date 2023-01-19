<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" Inherits="HOME.AddQuiz"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
    <head>
        <%-- <link href="bootstrap/css/bootstrap.css?v=1" rel="stylesheet"/> --%>
        <%-- <link href="CSS/AdminHomePage%20css.css?v=3" rel="stylesheet"/> --%>
        <%-- <link href="fontawesome-free-6.2.1-web/css/all.css" rel="stylesheet"/> --%>
        <%-- <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.3/font/bootstrap-icons.css"> --%>
        <script src="https://cdn.jsdelivr.net/npm/marked/marked.min.js"></script>
    </head>
    <body>
    <div class="container m-4 row">
        <div class="col-12">
            <form class="m-4" method="post">
                <div class="form-group">
                    <label for="lessonTitle">Quiz Id</label>
                    <input autocomplete="off" name="quizId" value="<%= lessonId %>" type="text" id="quizId" class="form-control" aria-describedby="titleHelp">
                    <small id="quizId" class="form-text text-muted">The quiz's title.</small>
                </div>
                <div class="form-group">
                    <label for="lessonTitle">Quiz Title</label>
                    <input autocomplete="off" name="title" value="<%= title %>" type="text" id="lessonTitle" class="form-control" aria-describedby="titleHelp">
                    <small id="titleHelp" class="form-text text-muted">The quiz's title.</small>
                </div>
                <div class="form-group">
                    <label for="lessonTitle">Quiz Language</label>
                    <input autocomplete="off" name="language" value="<%= category %>" type="text" id="lcategory" class="form-control" aria-describedby="lcategory">
                    <small id="lcategory" class="form-text text-muted">The lesson's language.</small>
                </div>
                <div class="form-group">
                    <label for="_lessonId2">Time Limit</label>
                    <input autocomplete="off" value="<%= timeLimit %>" name="timeLimit" type="text" id="_lessonId2" class="form-control" aria-describedby="lcategory">
                    <small class="form-text text-muted">Time limit in seconds.</small>
                </div>
                <div class="form-group mb-4">
                    <label for="_lessonId2">Required Lessons</label>
                    <input autocomplete="off" value="<%= requiredLessons %>" name="requiredLessons" type="text" id="_lessonId2" class="form-control" aria-describedby="lcategory">
                    <small class="form-text text-muted">Lesson IDs of prerequisites.</small>
                </div>

                <%-- <div class="form-group"> --%>
                <%--     <label for="formFile" class="form-label">Thumbnail Image</label> --%>
                <%--     <input name="thumbnail" class="form-control" type="file" id="formFile"> --%>
                <%--     <small class="form-text text-muted">The lesson's thumbnail image.</small> --%>
                <%-- </div> --%>

                <script>
                function addQuiz()
                {
                    var myDiv = document.getElementById("question");
                    var divClone = myDiv.cloneNode(true); // the true is for deep cloning
                    var parentDiv = document.getElementById("questions");
                    parentDiv.appendChild(divClone);
                    
                    return false;
                }
                </script>
                <div class="row container">
                    <h2><i class="bi bi-file-diff-fill m-0"></i> Quiz Questions</h2>
                    <button class="btn btn-primary" onclick="return addQuiz()"><i class="bi bi-plus-square"></i> Add Question</button>
                </div>

                <div class="row m-2" id="questions">
                    <% foreach (var q in quizQuestions)
                       {
                    %>
                        <div class="row mb-4">
                            <div class="form-group">
                                <label>Question Title</label>
                                <input value="<%= q.questiontext %>" autocomplete="off" name="question[][title]" type="text" class="form-control" aria-describedby="lcategory">
                                <small class="form-text text-muted">Question title.</small>
                            </div>
                            <div class="form-group">
                                <label>Answers</label>
                                <input value="<%= q.optA %>,<%= q.optB %>, <%= q.optC %>, <%= q.optD %>"  autocomplete="off" name="question[][answers]" type="text" class="form-control" aria-describedby="lcategory">
                                <small class="form-text text-muted">Answers separated by comma.</small>
                            </div>
                            <div class="form-group">
                                <label>Correct Answer</label>
                                <input value="<%= q.optCorrect %>" autocomplete="off" name="question[][correctAnswers]" type="text" class="form-control" aria-describedby="lcategory">
                                <small class="form-text text-muted">The correct answer.</small>
                            </div>
                        </div>
                    <%
                       }
                    %>
                    <div class="row mb-4" id="question">
                        <div class="form-group">
                            <label>Question Title</label>
                            <input autocomplete="off" name="question[][title]" type="text" class="form-control" aria-describedby="lcategory">
                            <small class="form-text text-muted">Time limit in seconds.</small>
                        </div>
                        <div class="form-group">
                            <label>Answers</label>
                            <input autocomplete="off" name="question[][answers]" type="text" class="form-control" aria-describedby="lcategory">
                            <small class="form-text text-muted">Answers separated by comma.</small>
                        </div>
                        <div class="form-group">
                            <label>Correct Answer</label>
                            <input autocomplete="off" name="question[][correctAnswers]" type="text" class="form-control" aria-describedby="lcategory">
                            <small class="form-text text-muted">The correct answer.</small>
                        </div>
                    </div>
                </div>

                <button type="submit" class="btn btn-success rounded-1 mt-4"><i class="bi bi-plus-square"></i> Add Quiz</button>
            </form>
        </div>
        <%-- <div class="col-6"> --%>
        <%-- --%>
        <%--     <div class="m-2"> --%>
        <%--         <small class="form-text text-muted">Lesson preview.</small> --%>
        <%--         <div class="" id="preview"></div> --%>
        <%--     </div> --%>
        <%-- </div> --%>

        <script>
                        // Get the textarea element
                        // var textarea = document.getElementById("lessonContent");
                        //
                        // // Add an event listener for the 'input' event
                        // textarea.addEventListener("input", function() {
                        //   // Get the complete text of the textarea
                        //   var text = this.value;
                        // document.getElementById('preview').innerHTML =
                        //       marked.parse(text);
                        // });
                        </script>
    </div>
    </body>
    </html>
</asp:Content>