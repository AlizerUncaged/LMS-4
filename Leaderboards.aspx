<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Leaderboards.aspx.cs" Inherits="HOME.Leaderboards" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
    <head>
        <link href="CSS/AdminHomePage%20css.css?v=3" rel="stylesheet"/>
        <link href="fontawesome-free-6.2.1-web/css/all.css" rel="stylesheet"/>
    </head>
    <body>
    <form>
        <div class="header-grad">
            <center>
                <h1>LEADERBOARDS</h1>
            </center>
        </div>
        <div class='category'>
            <div class="d-flex flex-row mb-3 mt-3">

            </div>
        </div>

        <div class="container" id="printtable">
            <%
                if (!leaderboards.Any())
                {
                    %><p>No one took the quiz yet...</p><%
                }
                foreach (dynamic user in leaderboards)
               { %>
                <div class="m-2 d-flex flex-row align-items-center align-items-center">

                    <div class="  d-flex flex-row  align-middle">
                        <p class="me-2 align-middle d-inline-block"><%= leaderboards.IndexOf(user) + 1 %></p>
                        <i class="bi bi-trophy me-2 d-inline-block"></i>
                    </div>

                    <img src="<%= HttpUtility.HtmlDecode(user.pfpUrl) %>" class="rounded-circle img-fluid" alt="" style="border: 1px solid #ddd;
                                 border-radius: 4px; padding: 5px; width: 50px; height: 50px"/>

                    <div class="container align-middle">
                        <p class="me-2 align-middle d-inline-block"><%= user.firstName %></p>
                        <p class="me-2 align-middle d-inline-block"><%= user.lastName %></p>
                        <p class="me-2 align-middle d-inline-block text-primary">Total Score: <b><%= user.score %></b> out of <%= user.outOf%></p>
                    </div>
                </div>
            <% } %>
        </div>
        <div class="container">
            <button onclick="PrintElem('printtable')" class="btn-primary btn rounded-1"><i class="bi bi-printer-fill"></i> Print</button>
        </div>
    </form>
    </body>
    <script>
    
    function PrintElem(elem)
    {
        var mywindow = window.open('', 'PRINT', 'height=400,width=600');
    
        mywindow.document.write('<html><head>  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous"><title>' + document.title  + '</title>');
        mywindow.document.write('</head><body >');
        mywindow.document.write('<h1>' + document.title  + '</h1>');
        mywindow.document.write(document.getElementById(elem).innerHTML);
        mywindow.document.write('</body></html>');
    
        mywindow.document.close(); // necessary for IE >= 10
        mywindow.focus(); // necessary for IE >= 10*/
    
        mywindow.print();
        mywindow.close();
    
        return false;
    }
    
                    function setModal(src)
                             {
                                  document.getElementById('mo').src = src;
                                     window.location = src;
                             }
                             
             </script>
    </html>

    <div class="modal fade" tabindex="-1" id="lesson-modal-mute">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 id="lesson-title" class="modal-title">hello</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body overflow-hidden" id="lesson-content">
                    <iframe class="container" id="mo"></iframe>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>