<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="CategoryPage.aspx.cs" Inherits="HOME.CategoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
    <head>
        <title>Lesson Category</title>
        <link href="CSS/CategoryPage%20css.css" rel="stylesheet" />
        <style>
            
         
        </style>
    </head>
    <body>
    <form>
        <div class="header-grad"><center><h1>LESSONS</h1></center></div>
        
        <div class ="container"> <%=makehtml %></div>
        </form>

        <script>
            function gotoLesson_click(clicked_id) {

                localStorage.setItem("text", clicked_id); 

                location.href("lesson.aspx");
            }

            function qt_click(clicked_id) {
                var id = this.id;
                localStorage.setItem("title", clicked_id);

                location.href = "lesson.aspx";

            }
        </script>
    </body>
</html>
</asp:Content>