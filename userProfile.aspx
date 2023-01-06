﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="HOME.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <!DOCTYPE html>

<html>
<head>
      <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="CSS/userProfile%20css.css" rel="stylesheet" />
</head>
   <body>
        <section>
            <div class="vh-75">
                
                    <div class="p-5 row">
                        <div class="ml-5 how-img">
                            <img src="images/profile.png" class="rounded-circle img-fluid" alt="" style="border: 1px solid #ddd;
                                 border-radius: 4px; padding: 5px; width: 175px; height: 175px";/>
                        </div>
                        <div class="col-md-6 p-5">
                            <h2><%= Session["firstname"]%> <%= Session["lastname"]%> </h2>    
                    </div>
                </div>
            </div>
        </section>    
       <div class="row"> 
               <div class="col-sm">
                   <div class="card ml-3" >
                       <div class="form-outline p-1">
                      <label class="form-label" for="">E-MAIL</label>
                         <input type="text" ID="txtemailAddress"  class="form-control form-control-lg" disabled="disabled" Placeholder="<%= Session["username"]%>"/>   
                     
                           <label class="form-label" for="">GENDER</label>
                          <input type="text" ID="txtgender" class="form-control form-control-lg" disabled="disabled" Placeholder="<%= Session["gender"]%>" />    
                      <label class ="form-label" for=""> PASSWORD</label>
                            <input type="password" ID="txtpass" class="form-control form-control-lg" disabled="disabled" value="<%= Session["password"]%>" /> 
                
                    </div>
                   </div>
     
                </div>

           
           <div class="col-sm">
                   <div class="card" style="width: 40%; padding: 10px">
                      CERTIFICATE
                       
                                   
                   </div>
               </div>





       </div>
   </body>
</html>
</asp:Content>
