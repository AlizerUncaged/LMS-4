<%-- <%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="HOME.WebForm3" %> --%>
<%@ Page Title="" Language="C#" AutoEventWireup="true" Inherits="HOME.userProfile" %>

<!DOCTYPE html>

<html>
<head>
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet"/>
    <link href="CSS/userProfile%20css.css" rel="stylesheet"/>
</head>
<body>
<section>
    <%
        string pfpUrl = "/images/user.png";

        if (Session["pfpUrl"] != null && Session["pfpUrl"] != DBNull.Value && !string.IsNullOrWhiteSpace(Session["pfpUrl"].ToString()))
        {
            pfpUrl = (string)Session["pfpUrl"];
        }

        Console.WriteLine(pfpUrl);
    %>
    <div class="vh-75">
        <div class="p-5 row">
            <div class="ml-5 how-img">
                <img src="<%= HttpUtility.HtmlDecode(pfpUrl) %>" class="rounded-circle img-fluid" alt="" style="border: 1px solid #ddd;
                                 border-radius: 4px; padding: 5px; width: 175px; height: 175px";/>
            </div>
            <div class="col-md-6 p-5">
                <h2><%= Session["firstname"] %> <%= Session["lastname"] %> </h2>
            </div>
        </div>
    </div>
</section>
<form method="post">
    <div class="row">
        <div class="container-fluid">
            <div class="card ml-3">
                <div class="form-outline p-1">
                    <label class="form-label" for="">E-Mail</label>
                    <input type="text" name="email" ID="txtemailAddress" class="form-control form-control-lg" value="<%= Session["email"] %>"/>
                    <% if (Session["type"].ToString() != "admin")
                       {
                    %>
                        <label class="form-label" for="">Gender</label>
                        <input name="gender" type="text" ID="txtgender" class="form-control form-control-lg" value="<%= Session["gender"] %>"/>
                    <% }
                    %>
                    
                    <label class="form-label" for="asdasd">Profile Picture Url</label>
                    <input name="pfpUrl" type="text" ID="asdasd" class="form-control form-control-lg" value="<%= Session["gender"] %>"/>

                    <label class="form-label" for=""> Password</label>
                    <input name="password" type="password" ID="txtpass" class="form-control form-control-lg" value="<%= Session["password"] %>"/>
                </div>
            </div>

        </div>
    </div>
    <div class="container row mt-2">
        <%
            Console.WriteLine(Session["type"]);
            if ((string)Session["type"] == "user")
            { %>
            <a class="btn btn-primary rounded-1 m-3" href="/HOMEPAGE">Back</a>
        <% } %>

        <% if ((string)Session["type"] == "admin")
           { %>
            <a class="btn btn-primary rounded-1 m-3" href="/AdminHomePage">Back</a>
        <% } %>

        <button type="submit" class="btn btn-primary rounded-1 m-3">Save</button>
    </div>
</form>
</body>
</html>
<%-- </asp:Content> --%>