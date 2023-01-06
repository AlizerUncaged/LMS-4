<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE.Master" AutoEventWireup="true" CodeBehind="showRecordPage.aspx.cs" Inherits="HOME.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
        <head>
            <link href="CSS/recordPage%20css.css" rel="stylesheet" />
         </head>
            <body>
                          
                <div class ="divtoprint" id="DivToPrint" runat="server">
                    <div class="header-grad"><center><h1>RECORD</h1></center></div>
                    <div class="hidden-control">
                        <asp:TextBox type ="hidden" runat="server" ID="hdnfld" ClientID="hdnfld" ClientIDMode="Static">
                        </asp:TextBox>
                        <asp:Button ID = "Button2" class="loadButton" CssClass="loadButton" runat="server" OnClick="Button2_Click"/>
                    </div>
                    <center>
                        <h2 id="messagebox" runat="server"></h2>
                    </center>   
                    <script type="text/javascript">
                        document.getElementById("hdnfld").value = localStorage.getItem("recordtitle");
                        document.getElementById('<%=Button2.ClientID %>').click();
                    </script>
                    
                    <div class="informations">
                        <center><h3 runat="server" id="Recordtitle"></h3></center>
                         <center>
                        <label  class="lblname">Name: </label>
                        <label runat="server" class="lblname" id="lblname"> <%=Session["firstname"].ToString().ToUpper()%> <%=Session["lastname"].ToString().ToUpper()%></label>
                       
                        <asp:GridView ID="GridView1" CssClass="infoGrid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="score" HeaderText="Score" />
                                <asp:BoundField DataField="items" HeaderText="Over" />
                                 <asp:BoundField DataField="date" HeaderText="Date Taken" />
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            
                        </asp:GridView>
                            <aside>
                             <button id="printBtn" class="printBtn">Print</button>
                                </aside>
                            </center>
                       <script type="text/javascript">
                           document.getElementById('printBtn').addEventListener('click', () => { window.print() });
                        // Prints area to which class was assigned only
                       </script>
                       
                   <div class="hidden-control">
                        
                        <asp:Button ID = "Button3" class="loadButton2" CssClass="loadButton2" runat="server" OnClick="Button3_Click"/>
                    </div>
                    

                    <script type="text/javascript">
                      
                        document.getElementById('<%=Button3.ClientID %>').click();
                    </script>

                    </div>
                    
                </div>

      




            </body>
    </html>
</asp:Content>
