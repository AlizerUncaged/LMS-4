<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="LessonPage.aspx.cs" Inherits="HOME.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%= fileContents %>
</asp:Content>