<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="recordPage.aspx.cs" Inherits="HOME.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <html>
    <head>
        <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
       <link href="CSS/CategoryPage%20css.css" rel="stylesheet" />
    </head>
    <body>
    <form>
        <div class="header-grad"><center><h1>RECORDS</h1></center></div>
        
        <div class ="container"> <%=makehtml %></div>
        
        </form>
    </body>
         <script>
             function qt_click(clicked_id) {
                 var id = this.id;
                 localStorage.setItem("recordtitle", clicked_id);

                 location.href = "showRecordPage.aspx";

             }
         </script>
</html>
</asp:Content>
