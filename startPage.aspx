<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="startPage.aspx.cs" Inherits="HOME.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
<head >
    <title>Start Page</title>
    <link href="CSS/startPage%20css.css" rel="stylesheet" />
</head>
<body>
        <div class="row pt-3 ml-3">
            <asp:Button ID="Back" CssClass="button" runat="server" Text="Back" OnClick="Back_Click"  />  
        </div>
        <div class="row pt-5 justify-content-center">       
             <asp:TextBox type ="hidden" runat="server" ID="hdnfld" ClientID="hdnfld" ClientIDMode="Static">
            </asp:TextBox>
                <h1 id ="quizTitle"><%=quiztitle %></h1>
            <h5></h5>
        </div>
        <div class ="description"><%=quizdesc %></div>
         <div class="row pt-3 pb-3 justify-content-center">
                 <asp:Button CssClass ="button" ID = 'Button1' class='startButton' runat='server' Text='Start' OnClick='Start_Click'/>
        </div>
        <hr />
        <div class="row justify-content-center">
            <div class="subDate col-5" align="center">Date</div>
            <div class="subScore col-5"align="center">Score</div>

             <%=attempts %>

        <asp:Button ID = "Button2" class="loadButton" CssClass="loadButton" runat="server" OnClick ="Load_Click"/>
 
    <script type="text/javascript">
        document.getElementById("hdnfld").value = localStorage.getItem("quizID");
        document.getElementById('<%=Button2.ClientID %>').click();


    </script>
</body>
</html>
</asp:Content>
