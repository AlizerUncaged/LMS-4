<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="HOME.signUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet"/>
    <style>
        *{
            min-height: 100%;
            font-family: 'Fredoka', sans-serif '';
        }
        body{
           
            background: linear-gradient(177deg, rgba(255,255,255,1) 0%, rgba(108,116,221,1) 0%, rgba(66,49,185,1) 44%, rgba(43,18,120,1) 83%);
        }
        section{
             min-height: 725px;
        }
        .gradient-custom {
            background: white;
            border: 1px solid black;
             background: linear-gradient(177deg, rgba(255,255,255,1) 0%, rgba(108,116,221,1) 0%, rgba(66,49,185,1) 44%, rgba(43,18,120,1) 83%);
        }
        h3{
            color:  rgba(66,49,185,1);
            font-family: Fredoka, sans-serif;
        }
        

        .form-control {
            border: 1px solid black;
        }
        .genderlbl{
            padding-right: 20px;
            padding-bottom: 0px;
        }
        .form-check-input{
            padding-right: 15px;
        }

       
       
    </style>

</head>
<body>
<form id="form1" runat="server">
    <section class="vh-100 gradient-custom">
        <div class="container h-100">
            <div class="row justify-content-center align-items-center h-100">
                <div class="col-12 col-lg-9 col-xl-7">
                    <div class="card shadow-2-strong card-registration" style="border-radius: 15px; margin-top:50px;">
                        <div class="card-body p-4 p-md-5">
                            <h3 class="mb-4 pb-2 pb-md-0 mb-md-5">Sign Up</h3>
                            <form>

                                <div class="row">
                                    <div class="col-md-6 mb-4">

                                        <div class="form-outline">
                                            <label class="form-label" for="firstName">First Name</label>
                                            <asp:TextBox ID="txtfirstname" runat="server" ToolTip="Enter Firstname" class="form-control form-control-lg"
                                                         placeholder="Enter First name">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                                                                        ControlToValidate="txtfirstname"
                                                                        ErrorMessage="First name is a required field."
                                                                        ForeColor="Red">
                                            </asp:RequiredFieldValidator>

                                        </div>

                                    </div>
                                    <div class="col-md-6 mb-4">

                                        <div class="form-outline">
                                            <label class="form-label" for="lastName">Last Name</label>
                                            <asp:TextBox ID="txtlastname" runat="server" ToolTip="Enter lastname" class="form-control form-control-lg"
                                                         placeholder="Enter Last name">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                                                                        ControlToValidate="txtlastname"
                                                                        ErrorMessage="Last name is a required field."
                                                                        ForeColor="Red">
                                            </asp:RequiredFieldValidator>

                                        </div>

                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-md-6 mb-4 d-flex align-items-center">
                                        <div class="form-outline">
                                            <label class="form-label" for="">Profile Pic URL</label>
                                            <asp:TextBox ID="txtPfpUrl" runat="server" ToolTip="Enter Email" class="form-control form-control-lg"
                                                         placeholder="Image URL">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6 mb-4 d-flex align-items-center">
                                        <div class="form-outline">
                                            <label class="form-label" for="">Email</label>
                                            <asp:TextBox ID="txtemailAddress" runat="server" ToolTip="Enter Email" class="form-control form-control-lg"
                                                         placeholder="Enter a valid email address">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
                                                                        ControlToValidate="txtemailAddress"
                                                                        ErrorMessage="Email is a required field."
                                                                        ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label class="form-label genderlbl" for="femaleGender">Gender</label>

                                        <asp:RadioButtonList ID="genderOptions" runat="server" RepeatLayout="Flow" class="form-check form-check-inline">
                                            <asp:ListItem Value="Male" class="form-check-input">Male</asp:ListItem>
                                            <asp:ListItem Value="Female" class="form-check-input">Female</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"
                                                                    ControlToValidate="genderOptions"
                                                                    ErrorMessage="Gender is a required field."
                                                                    ForeColor="Red">
                                        </asp:RequiredFieldValidator>


                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6 mb-4 pb-2">
                                        <div class="form-outline">
                                            <label class="form-label" for="txtPass">Password</label>
                                            <asp:TextBox ID="txtpassword" runat="server" ToolTip="Enter Password" class="form-control form-control-lg"
                                                         placeholder="Enter Password" type="password">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server"
                                                                        ControlToValidate="txtpassword"
                                                                        ErrorMessage="Password is a required field."
                                                                        ForeColor="Red">
                                            </asp:RequiredFieldValidator>

                                        </div>


                                    </div>
                                    <div class="col-md-6 mb-1 pb-1">
                                        <div class="form-outline">
                                            <label class="form-label" for="txtConfirmpass">Confirm Password</label>
                                            <asp:TextBox ID="txtconfirmpass" runat="server" ToolTip="Confirm Password" class="form-control form-control-lg"
                                                         placeholder="Confirm Password" type="password">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server"
                                                                        ControlToValidate="txtConfirmpass"
                                                                        ErrorMessage="Confirm password is a required field."
                                                                        ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                </div>
                                <p>
                                    <asp:Label ID="messagelabel" runat="server" Text=""/>
                                </p>
                                <div class="mt-1 pt-1 ">
                                    <center>
                                        <asp:Button runat="server" class="btn btn-primary btn-lg" type="submit" text="Sign Up" OnClick="SignUp_Click"/>
                                    </center>
                                </div>
                                <p class="small fw-bold mt-2 pt-1 mb-0">
                                    Already have an account?
                                    <a href="login.aspx"
                                       class="link-danger">
                                        Log in
                                    </a>
                                </p>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</form>
</body>
</html>