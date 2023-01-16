<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="aboutUs.aspx.cs" Inherits="HOME.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <head>
        <title>About Us</title>
    <style>
       
        body{
             background: white;
        }
        .header{
            margin-top: 20px;
        }

        .top{
            margin-bottom: 50px;
        }
        .devs{
            border: 1px solid black;
        }
        .info{
            margin-bottom: 1px;
        }
        img{
            margin-top: 5px;
        }
        

    </style>
        </head>
    <body>
   <section class="top">
       <center>
            <hr />
                <h2 class="header">ABOUT US</h2>
           <hr />
            <span class="text-md-center justify-content-md-center">TechQue is a website project for 2nd year student. Techque is made for every Programmer students.
                TechQue is here test the knowledge of the students about programming with various languages like c#, java, and python and also give readings about the programming languages. 
            </span>
       </center>
   </section>
        <section>
            <center>
                <hr />
                 <h3 class="header">ACKNOWLEDGEMENT</h3>
                <hr />
                    <span class="text-md-center justify-content-md-center">
                        We would like to express our gratitude to  <a href="https://www.w3schools.com/">W3School</a>,<a href="https://www.tutorialsteacher.com/"> TutorialsTeacher </a>, and
                        <a href="https://quizizz.com/?lng=en"> Quizizz </a> for providing valuable resources and materials that have greatly aided in the development of our website. 
                        We have utilized the content from these sources to enhance the user experience and provide accurate and useful information to our visitors. We are thankful for the opportunity to reference 
                        and utilize their work and are grateful for their contributions to the online learning community. Thank you to <a href="https://www.w3schools.com/">W3School</a>,<a href="https://www.tutorialsteacher.com/"> TutorialsTeacher </a>, and
                        <a href="https://quizizz.com/?lng=en"> Quizizz </a> for your support and for helping us to create a valuable resource for our users.
                    </span>
            </center>
        </section>
   <section>
      <div class="container">
         <div class="row">
            <div class="col-12">
               <center>
                <hr />
                  <h3 class="header">OUR DEVELOPERS</h3>
                <hr />
               </center>
            </div>
         </div>
         <div class="row first">
            <div class="col-md-6">
               <center class="devs">
                  <img width="150px" height="150" src="images/soliven.jpg"/>
                  <h4>Denzill Soliven</h4>
                  <p class="text-center info">Database Designer</p>
                  <p class="text-center info">K11935433</p>
               </center>
            </div>
            <div class="col-md-6 ">
                <center class="devs">
                  <img width="150px" height="150" src="images/xander.jpg"/>
                  <h4>Xander Deloso</h4>
                  <p class="text-center info">UI Designer</p>
                  <p class="text-center info">k11936891</p>
               </center>
            </div>
             
         </div>
      </div>
       <br />
      <div class="container">
         <div class="row second">
            <div class="col-md-6">
               <center class="devs">
                  <img width="150px" height="150" src="images/raprap.png"/>
                  <h4>Raphael Macatangay</h4>
                  <p class="text-center info">Lead Programmer</p>
                  <p class="text-center info">k11936058</p>
               </center>
            </div>
            <div class="col-md-6">
               <center class="devs">
                  <img width="150px" height="150" src="images/evangelista.jpg"/>
                  <h4>Francis Evangelista</h4>
                  <p class="text-center info">Project Manager</p>
                  <p class="text-center info">k11941993</p>
               </center>
            </div>
         </div>
      </div>
   </section>
    <p></p>
</body>
</asp:Content>
