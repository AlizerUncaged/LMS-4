<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminAdd_EditLesson.aspx.cs" Inherits="HOME.Add_EditLesson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<!DOCTYPE html>

<html>
<head>
      
    <link href="CSS/Add_EditLesson%20css.css" rel="stylesheet" />
    
</head>
   <body>
                      
           <form>
               <div class="title">
                   <asp:TextBox type ="hidden" runat="server" ID="hdnfld" ClientID="hdnfld" ClientIDMode="Static"></asp:TextBox>
                   <asp:TextBox type ="text" runat="server" ID="title" ClientID="title" ClientIDMode="Static" CssClass="input_title"></asp:TextBox>
                
                        <center class="placeholder"> LESSON TITLE </center>
                </div>

       <div class="mid">
           <div class="cover">
               <div class="txt">COVER IMAGE</div><div class ="button"><asp:FileUpload ID="Upload" runat="server"  onchange="ShowPreview(this)"/></div>
               <asp:Image ID="impPrev" runat="server" Height="200px" />  

              
           </div>
           <div class="lesson">
                <div class="txt">LESSON FILE</div><div class ="button"><asp:FileUpload ID="FileUpload1" runat="server"  onchange="ShowPreview(this)"/></div>
           </div>
       </div>

    <div class="preview">

    </div>
               <asp:button ID="Add" runat="server" Text="Submit" onclick="submit_Click"/>

           </form>


            
</body>
    <script>
        document.getElementById("hdnfld").value = localStorage.getItem("lessonID");
        function ShowPreview(input) {  
            if (input.files && input.files[0]) {  
                var ImageDir = new FileReader();  
                ImageDir.onload = function(e) {  
                    Jquery
                    $('#impPrev').attr('src', e.target.result);  
                    var image = document.getElementyId("impPrev");
                    image.src = e.target.result;
                }  
                ImageDir.readAsDataURL(input.files[0]);  
            }  
        }  </script>
    
</html>
</asp:Content>
