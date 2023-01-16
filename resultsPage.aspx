<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="resultsPage.aspx.cs" Inherits="HOME.resultsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
    <head>
        <link href="CSS/resultsPage%20css.css" rel="stylesheet" />
        <title runat="server">Results</title>
    </head>

    <div class="score_header"><%=scoreheader %></div>
            <hr />
    <div class="score_message"><%=scoremessage %></div><hr />
    <div class="past_attempts row justify-content-center">
            <div class="subDate col-5" align="center">Date</div>
            <div class="subScore col-5"align="center">Score</div>

             <%=attempts %>
        </div>

    </html>
</asp:Content>
