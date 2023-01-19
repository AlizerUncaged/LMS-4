<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" Inherits="HOME.SuspendStudents"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <head>
        <link href="CSS/AdminHomePage%20css.css" rel="stylesheet"/>
    </head>
    <form>
        <div class="header-grad">
            <center>
                <h1>STUDENTS</h1>
            </center>
        </div>
        <div class='category'>
            <div class="d-flex flex-row mb-3 mt-3">

            </div>
        </div>

        <div class="container" id="printtable">
            <%
                if (!students.Any())
                {
            %>
                <p>There are no students...</p><%
                }
                foreach (dynamic user in students)
                { %>
                <div class="m-2 d-flex flex-row align-items-center align-items-center">

                    <div class="  d-flex flex-row  align-middle">
                        <p class="me-2 align-middle d-inline-block"><%= user.user_id %></p>
                        <i class="bi bi-person-badge d-inline-block m-2"></i>
                    </div>

                    <img src="<%= HttpUtility.HtmlDecode(user.pfpUrl) %>" class="rounded-circle img-fluid" alt="" style="border: 1px solid #ddd;
                                 border-radius: 4px; padding: 5px; width: 50px; height: 50px"/>

                    <div class="container align-middle">
                        <p class="me-2 align-middle d-inline-block"><%= user.firstname %></p>
                        <p class="me-2 align-middle d-inline-block"><%= user.lastname %></p>
                        <p class="me-2 align-middle d-inline-block text-primary">
                            <b><%= user.email %></b> <%= user.gender %>
                        </p>
                    </div>

                    <a class="btn btn-<%= user.is_suspended ? "warning" : "success" %> m-2" href="?suspended=<%= user.is_suspended ? "false" : "true" %>&userid=<%= user.user_id %>">
                        <i class="bi bi-dash-circle-dotted"></i> <%= user.is_suspended ? "Unsuspend" : "Suspend" %>
                    </a>
                    <p class="m-2"> <%= user.is_suspended ? "Suspended!" : "" %></p>
                </div>
            <% } %>
        </div>
    </form>
</asp:Content>