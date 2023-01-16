<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountSettings.aspx.cs" Inherits="HOME.WebForm12" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
    <style>
 

* {
    font-family: 'Fredoka', sans-serif;
    overflow-x: hidden;
}
/* The sidebar menu */
.sidebar {
    background: linear-gradient(177deg, rgba(255,255,255,1) 0%, rgba(108,116,221,1) 0%, rgba(66,49,185,1) 44%, rgba(43,18,120,1) 83%);
    height: -webkit-fill-available;
    width: 230px;
    position: fixed;
    z-index: 1;
    top: -18px;
    left: 0px;
    overflow-x: hidden;
    padding-top: 20px;
}



    /* The navigation menu links */
    .sidebar a {
        padding: 1px 30px 6px 40px;
        font-size: 20px;
        color: #cecfe8;
        text-decoration: none;
        display: block;
    }

.account a {
    text-align: right;
    font-family: 'Fredoka', sans-serif;
    padding: 0px 20px 10px 0px !important;
    position: absolute;
    border: none;
    font-size: 20px;
    right: 0;
    text-decoration: none;
    bottom: 30px;
    color: #cecfe8;
    width: -webkit-fill-available;
}

.logout {
    text-align: right;
    font-family: 'Fredoka', sans-serif;
    padding: 0px 20px 10px 0px !important;
    position: absolute;
    border: none;
    font-size: 20px;
    right: 0;
    text-decoration: none;
    bottom: 0;
    color: #cecfe8;
    width: -webkit-fill-available;
    background-color: transparent;
    border: none;
    color: #cecfe8;
}


/* When you mouse over the navigation links, change their color */
.sidebar a:hover {
    text-decoration: none;
    color: #f1f1f1;
}

.logout:hover {
    text-decoration: none;
    color: #f1f1f1;
}

.content {
    margin-left: 230px;
}
.row {
    margin-right: 15px;
    margin-left: 15px;
}

.container {
    width: 100%;
}

.h3 {
    color: rgba(66,49,185,1);
    font-family: Fredoka, sans-serif;
}

.form-control {
    border: 1px solid black;
    width: 50%;
}

.genderlbl {
    padding-right: 20px;
}

.form-check-input {
    padding-right: 15px;
}

label {
    font-weight: bold;
    padding-left: 21%;
}


/* The sidebar menu */
@media screen and (max-width: 768px) {
    .sidebar {
        display: flex;
        justify-content: left;
        height: auto;
        width: auto;
        position: relative;
        z-index: 1;
        top: -18px;
        left: 0px;
        overflow-x: hidden;
        padding-top: 20px;
    }


        /* The navigation menu links */
        .sidebar a {
            padding: 5px 5px 5px 5px;
            display: flex;
            text-decoration: none;
            font-size: 2vw;
            color: #cecfe8;
            font-family: 'Fredoka', sans-serif;
        }

    .content {
        margin-left: auto;
        overflow: hidden;
        margin-top: -20px;
    }

    .account a {
        text-align: right;
        font-family: 'Fredoka', sans-serif;
        padding: 0px 20px 10px 40px !important;
        position: absolute;
        border: none;
        font-size: 20px;
        right: 0;
        text-decoration: none;
        bottom: 30px;
        color: #cecfe8;
        width: -webkit-fill-available;
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
    }

    .logout {
        text-align: right;
        font-family: 'Fredoka', sans-serif;
        padding: 0px 20px 10px 0px !important;
        position: absolute;
        border: none;
        font-size: 20px;
        right: 0;
        text-decoration: none;
        bottom: 0;
        color: #cecfe8;
        width: -webkit-fill-available;
        background-color: transparent;
        border: none;
        color: #cecfe8;
    }
}

#Button1 {
    margin: -100px;
}

.back {
    height: 15px;
    width: 14px;
}

.row {
    height: auto;
}

h1 {
    font-weight: 600;
}


    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <div class = "sidebar">
            <a href="HOMEPAGE.aspx">Home</a>
            <a href="HOMEPAGE.aspx#quiz-sec">Quizzes</a>
            <a href="CategoryPage.aspx">Lessons</a>
            <a href="#">Records</a>
            <a href="#">Certificates</a>
            <a href="userProfile.aspx">Profile</a>
            <a href="#">Account Settings</a>
            <a href="aboutUs.aspx">About</a>
            <div class ="account">
              
            <a class ="userLogged" href="userProfile.aspx" ><%=Session["firstname"]%> <%=Session["lastname"]%> </a>
           
            <asp:Button runat="server" CssClass ="logout" class="logout" Text="Sign Out" id="logout" onClick="signout_Click"></asp:Button>
            </div>
        </div>
     
     <div class ="content">
          <section>
            <div class="vh-75">
                 <CENTER> <h1>ACCOUNT SETTINGS</h1></CENTER>
                    <div class="p-5 row">
                        <div class="ml-5 how-img">
                                <%
                                                  string pfpUrl = "/images/user.png";
                                                  
                                                  if (Session["pfpUrl"] != null && Session["pfpUrl"] != DBNull.Value)
                                                  {
                                                      pfpUrl = (string)Session["pfpUrl"];
                                                  }
                                                  
                                                  Console.WriteLine(pfpUrl);
                                        %>
                                         <img src="<%= HttpUtility.HtmlDecode(pfpUrl) %>" class="rounded-circle img-fluid" alt="" style="border: 1px solid #ddd;
                                                                         border-radius: 4px; padding: 5px; width: 175px; height: 175px";/>
<%--                             <img src="images/profile.png" class="rounded-circle img-fluid" alt="" style="border: 1px solid #ddd; --%>
<%--                                  border-radius: 4px; padding: 5px; width: 175px; height: 175px";/> --%>
                        </div>
                        <div class="col-md-6 p-5">
                            <h2><%= Session["firstname"].ToString().ToUpper()%> <%= Session["lastname"].ToString().ToUpper() %> </h2>    
                    </div>
                </div>
            </div>
        </section>  
            <hr />
       <div class="row"> 
           
               <div class="container">
                   <div class="card" >
                       <div class="form-outline p-1">
                           <label class="form-label" for="">FIRSTNAME</label>
                         <center><input type="text" runat="server" ID="txtfname" class="form-control form-control-lg"/> </center>   

                            <label class="form-label" for="">LASTNAME</label>
                          <center><input type="text" runat="server" ID="txtlname"   class="form-control form-control-lg"/>  </center> 

                      <label class="form-label" for="">E-MAIL</label>
                        <center>  <input type="text" runat="server" ID="txtemailAddress" class="form-control form-control-lg" />  </center> 
                     
                           <label class="form-label" for="">GENDER</label>
                          <center> <input type="text" ID="txtgender" runat="server" class="form-control form-control-lg"   /> </center>   
                      <label class ="form-label" for=""> PASSWORD</label>
                           <center>  <input type="password" ID="txtpass" runat="server" class="form-control form-control-lg"  /> </center>
                             <center><input type="checkbox" onclick="myFunction()">Show Password</input></center>
                
                    </div>
                   </div>
                    <center><asp:Button runat="server" ID="submitbtn" Text="SUBMIT" OnClick="submitbtn_Click" /></center>
                </div>
               
       </div>
                <script>
                    function myFunction() {
                        var x = document.getElementById("txtpass");
                        if (x.type === "password") {
                            x.type = "text";
                        } else {
                            x.type = "password";
                        }
                    }
                </script>  
            
            
        </div>
        </form>
    
</body>
</html>
