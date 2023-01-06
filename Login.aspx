<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HOME.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
    <link href="https://fonts.googleapis.com/css2?family=Fredoka:wght@300;400;500;600;700&display=swap" rel="stylesheet">

    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
    <style>
        *{
            font-family: Fredoka, sans-serif;
        }
     body{
         background: linear-gradient(177deg, rgba(255,255,255,1) 0%, rgba(108,116,221,1) 0%, rgba(66,49,185,1) 44%, rgba(43,18,120,1) 83%);
     }
     h3{
         text-align: center;
        
     }
     .container{
         padding: 30px;
         background: rgba(255,255,255,1);
         border-radius: 50px;
     }
     divider:after,
    .divider:before {
        content: "";
        flex: 1;
        height: 1px;
      
     }
    .h-custom {
        height: calc(100% - 73px);
    }
    @media (max-width: 450px) {
        .h-custom {
            height: 100%;
        }
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <section class="vh-100">
         <div class="container-fluid h-custom">
             <div class="row d-flex justify-content-center align-items-center h-100">
                 <div class="col-md-9 col-lg-6 col-xl-5">
                     <img src="images/TechQue%20logo.png" class="img-fluid" alt="Sample image"/>
                 </div>
      <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
        <form>   
            <div class="container">

                <h3>LOG IN</h3>
                <hr />
          <!-- Email input -->
          <div class="form-outline mb-4">
              <label class="form-label" for="textusername" >Email address</label>
              <asp:TextBox ID="textusername" runat="server" ToolTip="Enter User Name" class="form-control form-control-lg"
              placeholder="Enter a valid email address">
           
            </asp:TextBox>
          </div>

          <!-- Password input -->
          <div class="form-outline mb-3">
               <label class="form-label" for="textpass">Password</label>
              <asp:TextBox ID="textpass" runat="server" ToolTip="Enter User Name" class="form-control form-control-lg"
              placeholder="Enter password" type="password">
               </asp:TextBox>
              <input type="checkbox" onclick="myFunction()">Show Password </input>
          </div>
            <p><asp:Label ID="messagelabel" runat="server" Text=""/></p>

          <div class="d-flex justify-content-between align-items-center"></div>
              <center>
                 <div class="text-center text-lg-start mt-4 pt-2 ">
                       <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button1" runat="server" Text="Log In" OnClick="Button1_Click"
                       style="padding-left: 2.5rem; padding-right: 2.5rem;"/>
                 <p class="small fw-bold mt-2 pt-1 mb-0">Don't have an account? <a href="signUp.aspx"
                 class="link-danger">Register</a></p>
                  </div>
              </center>
            </div>
        </form>
      </div>
    </div>
  </div>
 
   
</section>
    </form>
    <script>
        function myFunction() {
            var x = document.getElementById("textpass");
            if (x.type === "password") {
                x.type = "text";
            } else {
                x.type = "password";
            }
        }
    </script>
</body>
</html>
