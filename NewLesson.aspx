<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" Inherits="HOME.NewLesson"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
    <head>
        <link href="bootstrap/css/bootstrap.css?v=1" rel="stylesheet"/>
        <link href="CSS/AdminHomePage%20css.css?v=3" rel="stylesheet"/>
        <link href="fontawesome-free-6.2.1-web/css/all.css" rel="stylesheet"/>
        <script src="https://cdn.jsdelivr.net/npm/marked/marked.min.js"></script>
    </head>
    <body>
    <div class="container m-4 row">
        <div class="col-6">
            <form class="m-4" method="post">
                <div class="form-group">
                    <label for="lessonTitle">Lesson Title</label>
                    <input autocomplete="off" name="title" value="<%= title %>" type="text" id="lessonTitle" class="form-control" aria-describedby="titleHelp">
                    <small id="titleHelp" class="form-text text-muted">The lesson's title.</small>
                </div>
                <div class="form-group">
                    <label for="lessonTitle">Lesson Category</label>
                    <input autocomplete="off" name="category" value="<%= category %>" type="text" id="lcategory" class="form-control" aria-describedby="lcategory">
                    <small id="lcategory" class="form-text text-muted">The lesson's category.</small>
                </div>
                <div class="form-group">
                    <label for="_lessonId2">Lesson Id</label>
                    <input autocomplete="off" readonly="readonly" value="<%= lessonId %>" name="lessonId" type="text" id="_lessonId2" class="form-control" aria-describedby="lcategory">
                    <small class="form-text text-muted">The original lesson ID.</small>
                </div>
                <%-- <div class="form-group"> --%>
                <%--     <label for="formFile" class="form-label">Thumbnail Image</label> --%>
                <%--     <input name="thumbnail" class="form-control" type="file" id="formFile"> --%>
                <%--     <small class="form-text text-muted">The lesson's thumbnail image.</small> --%>
                <%-- </div> --%>

                <div class="form-group">
                    <label for="lessonContent" class="form-label">Lesson Contents</label>
                    <textarea autocomplete="off" id="lessonContent" name="content" class="form-control" rows="4"  style="width: 100%"><%= content %></textarea>
                </div>

                <button type="submit" class="btn btn-primary rounded-1">Submit</button>
            </form>
        </div>
        <div class="col-6">

            <div class="m-2">
                <small class="form-text text-muted">Lesson preview.</small>
                <div class="" id="preview"></div>
            </div>
        </div>

        <script>
                        // Get the textarea element
                        var textarea = document.getElementById("lessonContent");
                        
                        // Add an event listener for the 'input' event
                        textarea.addEventListener("input", function() {
                          // Get the complete text of the textarea
                          var text = this.value;
                        document.getElementById('preview').innerHTML =
                              marked.parse(text);
                        });
                        </script>
    </div>
    </body>
    </html>
</asp:Content>