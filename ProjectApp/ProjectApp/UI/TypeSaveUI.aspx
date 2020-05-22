<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypeSaveUI.aspx.cs" Inherits="ProjectApp.UI.TypeSaveUI" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8"/>
    <title>Test Type Setup</title>
    <link href="../Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <div class="wrapper">
            
        <br/><br/><br/>
            
             <div class="commonwrapper">
            
        <img class="banner" src="../banner.JPG" />
        <hr/><hr/>
            
        <br/>
         
                  <center>
                 <a href="IndexUI.aspx" style="text-align: right;">
                     <p class="menu" style="padding: 5px; text-align: right;">
                         Go to Menu
                     </p>
                 </a>
                 </center>         
        
         <br/><br/>
        
            
         <fieldset style="padding:5px">
             
            <legend><h2>Test Type Setup</h2></legend>
             
             <br/>
             
          
        <table width="80%">
            <tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;">
         
                    <asp:Label ID="Label1" runat="server" Text=" Type Name : "></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;">
                    <asp:TextBox ID="typeNameTextBox" required="required" runat="server" Width="277px" ></asp:TextBox>

                </td>
            </tr>
            
            <tr>
               <td></td>
                
                <td style="padding-left: 20px; font-size: 1.3em; text-align: right;">
                    <br/>
                    <asp:Button ID="saveButton" class="tyesavebutton" runat="server" Text="Save" OnClick="saveButton_Click" />
                </td>
            </tr>
        </table>
             
             <br /><br/>
             <center>
                 
             
              <asp:Label ID="messagelabel" class="typemessagelabel" runat="server"></asp:Label>
                 
                 </center>

             <br/><br/><br/>


       <br/>
                 
                  <asp:GridView ID="typeGridView" class="testtypegridview" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">


            <columns>
                <asp:TemplateField HeaderText="Serial No">
                         <ItemTemplate>
                         <%#Container.DataItemIndex+1%> 
                        </ItemTemplate>
                         </asp:TemplateField>
                 <asp:TemplateField HeaderText="Type Name">
                    <ItemTemplate >
                        <asp:Label runat="server" Text='<%#Eval("TypeName") %>'>>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </columns>
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
             <br/><br/><br/>
		 </fieldset>
</div>

</div>
    
    </div>
    </form>
</body>
</html>
