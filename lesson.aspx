<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lesson.aspx.cs" Inherits="HOME.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Fredoka:wght@300;400;500;600;700&display=swap" rel="stylesheet">
    <link href="CSS/lesson%20css.css?v=2" rel="stylesheet"/>

</head>
<body>
<form id="form1" runat="server">
    <div class="content">
        <asp:Button ID="Button1" runat="server" OnClientClick="abc()" Text="Button"
                    onclick="Button1_Click"/>
        <asp:Button ID="Back" CssClass="back" runat="server" Text="Back" OnClick="Back_Click" Width="70px"
                    Height="50px" font-size="Medium" BorderStyle="Solid"/>
        <script>
            
            function abc() {
                var str = localStorage.getItem("title");
                document.getElementById("Hidden1").value = str;click();
               

            }

        </script>
        <script>
                  window.onload = function () {
                      document.getElementById('Button1').click();


                  }
              </script>
        <div>
            <center>
                <div class="row">
                    <h1 id="title">Quiz Title</h1>
                </div>
            </center>
            <script>document.getElementById("title").innerHTML = localStorage.getItem("title").toUpperCase();</script>
            <div class="row">
                <input id="Hidden1" type="hidden" runat="server"/>
                <label id="label1" runat="server" style="font-size: 20px;"></label>

            </div>
        </div>

    </div>
</form>

</body>