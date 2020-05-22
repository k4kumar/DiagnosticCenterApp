
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRequestEntryUI.aspx.cs" Inherits="ProjectApp.UI.TestRequestEntryUI" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8"/>
    <title>Test Request Entry</title>
    <link href="../Style.css" rel="stylesheet" />
    
    <link href="../jquery-ui.min.css" rel="stylesheet" />

   </head>
<body>
    <form id="form1" runat="server">
        <br />
    <div >
        
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
             
            <legend><h2>Test Request Entry</h2></legend>
             
             <br/>
             
          
        <table width="80%">
            <tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;">
						  <asp:Label ID="Label2" runat="server" Text="Name of the Patient"></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;">
                  <asp:TextBox ID="patientNameTextBox" required="required"  runat="server"></asp:TextBox>
                </td>
            </tr>
			
			<tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;"><br/>
					<asp:Label ID="Label1" runat="server" Text="Date of Birth"></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;"><br/>
                   <input type="text" required="required"  runat="server" id="datepicker"/>
                </td>
            </tr>
			
			<tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;"><br/>
					<asp:Label ID="Label4" runat="server" Text="Mobile No."></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;"><br/>
                   <asp:TextBox ID="mobileNoTextBox" required="required"  runat="server"></asp:TextBox>
                </td>
            </tr>
			
			<tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;"><br/>
					<asp:Label ID="Label5" runat="server" Text="Select Test"></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;"><br/>
                   <asp:DropDownList ID="testSelectDropDownList" required="required"  CssClass="testSelectDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="testSelectDropDownList_SelectedIndexChanged">
                       </asp:DropDownList>
                </td>
            </tr>
			
			<tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;"><br/>
					 <asp:Label ID="Label6" runat="server" Text="Fee"></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;"><br/>
                   <asp:TextBox ID="feeTextBox" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
			
			
            
            <tr>
               <td>
			   
			   </td>
                
                <td style="padding-left: 20px; font-size: 1.3em; text-align: right;">
                    <br/>
                    <asp:Button ID="addButton" class="testrequestaddbutton" runat="server" OnClick="addButton_Click" Text="Add" Height="37px" Width="67px" />
                </td>
            </tr>
        </table>
             
             <br /><br/>
             <center>
                 
             
              <asp:Label ID="messageShowlabel" class="testrequestmessagelabel" runat="server"></asp:Label>
                 
            

             <br/><br/><br/><br/>
			 
			 <asp:GridView ID="testSelectGridView" CssClass="testSelectGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" OnRowDataBound="testSelectGridView_RowDataBound" style="margin-right: 47px" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <columns>
                 <asp:TemplateField HeaderText="Serial No">
                         <ItemTemplate>
                         <%#Container.DataItemIndex+1%> 
                        </ItemTemplate>
                         </asp:TemplateField>

                <asp:TemplateField HeaderText="Test Name">
                    <ItemTemplate >
                        <asp:Label ID="nameLabel" runat="server" Text='<%#Eval("TestName") %>'>>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Fee">
                    <ItemTemplate >
                        <asp:Label ID="feeLabel" runat="server" Text='<%#Eval("Fee") %>'>>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
               
                </columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
			 
			 <br/><br/>

			</center>

			<table width="80%">
            <tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;">
						  <asp:Label ID="Label7" runat="server" Text="Total"></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;">
                  <asp:TextBox ID="totalTextBox" runat="server" Enabled="False" Width="161px"></asp:TextBox>
                </td>
            </tr>
			
			 <tr>
               <td>
			   
			   </td>
                
                <td style="padding-left: 20px; font-size: 1.3em; text-align: right;">
                    <br/>
                    <asp:Button ID="saveButton" class="testrequestsavebutton" runat="server" Text="Save" OnClick="saveButton_Click" />
                </td>
            </tr>

			</table>


				<br/><br/><br/>
		 </fieldset>
</div>

</div>    
    </div>
    </form>
    
    <script src="../Scripts/jquery-1.4.4.min.js"></script>
    <script src="../Scripts/jquery.ui.core.min.js"></script>
    <script src="../Scripts/jquery.ui.datepicker.min.js"></script>

     <script>
         $(function () {
             $("#datepicker").datepicker({
                 dateFormat: "yy-mm-dd",
                 changeMonth: true,
                 changeYear: true,
                 yearRange: '1940:2016'

             });
         });
  </script>

</body>
</html>
