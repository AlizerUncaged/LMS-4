<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="QuizCategoryPage.aspx.cs" Inherits="HOME.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <html>
    <head>
       <link href="CSS/AdminHomePage%20css.css" rel="stylesheet" />
    </head>
    <body>
    <form>
        <div class="header-grad"><center><h1>QUIZZES</h1></center></div>
        
        <div class ="container"> <%=makehtml %></div>
        </form>
    </body>
         <script>
             function qt_click(clicked_id) {
                 localStorage.setItem("quizID", clicked_id);
                 location.href = "startPage.aspx";

             }
         </script>
</html>
</asp:Content>
