<%@ Page Language="C#" CodeBehind="Suspended.aspx.cs" Inherits="HOME.Suspended" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <%-- <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" /> --%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>
    <link href="datatables/datatables.min.css" rel="stylesheet"/>
    <link href="fontawesome-free-6.2.1-web/css/all.css" rel="stylesheet"/>

    <script src="https://cdn.jsdelivr.net/npm/marked/marked.min.js"></script>
    <link href="CSS/MASTERPAGE%20css.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.3/font/bootstrap-icons.css">
    <link rel="icon" type="image/png" href="/images/TechQue logo.png"/>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Fredoka:wght@300;400;500;600;700&display=swap" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.6/dist/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.2.1/dist/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>

    <title>Suspended!</title>
</head>
<body>
<form id="htmlForm" runat="server">
    <div class="sidebar">

        <h2 class="text-light mt-4 ms-4 me-4">
            <%
                string pfpUrl = "/images/user.png";

                if (Session["pfpUrl"] != null && Session["pfpUrl"] != DBNull.Value)
                {
                    pfpUrl = (string)Session["pfpUrl"];
                }

                Console.WriteLine(pfpUrl);
            %>
            <img src="<%= HttpUtility.HtmlDecode(pfpUrl) %>" class="rounded-circle img-fluid" alt="" style="border: 1px solid #ddd;
                                                 border-radius: 4px; padding: 5px; width: 150px; height: 150px";/>
            Welcome, <%= Session["firstname"] %>!
        </h2>
        <p class="text-light mb-2 me-4 ms-4" style="opacity: 0.5;">Student</p>
        <div class="account">

            <asp:Button runat="server" CssClass="logout" class="logout" Text="Sign Out" id="logout" onClick="signout_Click"></asp:Button>
        </div>
    </div>

    <div class="content ">
        <h1 class="text-danger m-4">Your account has been suspended!</h1>
        <p class="m-4">You may try contacting your instructor</p>
    </div>
</form>
</body>
</html>