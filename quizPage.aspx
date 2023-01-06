<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="quizPage.aspx.cs" Inherits="HOME.quizPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quiz Page</title>
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="CSS/quizPage%20css.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Fredoka:wght@300;400;500;600;700&display=swap" rel="stylesheet">
</head>
<body>
    <div class="page">
    <form id="form1" runat="server" method="post">
        <asp:TextBox type ="hidden" runat="server" ID="hdnfld_quizID" ClientID="hdnfld_quizID" ClientIDMode="Static">
            </asp:TextBox>
        <div class="item"><%=makehtml %></div>
        <asp:Button ID="Button1" class="Submit" CssClass="Submit" runat="server" Text="Next" OnClick="Submit_Click" />
        <asp:Button ID = "Button2" class="loadButton" CssClass="loadButton" runat="server" OnClick ="Load_Click"/>
    </form>
        </div>
    
    <script type="text/javascript">
        document.getElementById("hdnfld_quizID").value = localStorage.getItem("quizID");
        document.getElementById('<%=Button2.ClientID %>').click();

    </script>
</body>
</html>
