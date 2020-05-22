<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnpaidBillReportUI.aspx.cs" Inherits="ProjectApp.UI.UnpaidBillReportUI" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset ="UTF-8"/>
    <title>
        Unpaid Bill Report
    </title>
    
    <link href="../jquery-ui.min.css" rel="stylesheet" />
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
                 <a href="IndexUI.aspx" style="text-align: right;">
                     <p class="menu" style="padding: 5px; text-align: right;">
                         Go to Menu
                     </p>
                 </a>        
        
         <br/><br/>
        
            
         <fieldset style="padding:5px">
             
            <legend><h2>Unpaid Bill Report</h2></legend>
             
             <br/>
             
        <div style="border:solid 1px black;border-radius:6px;">
		
		<br/><br/>
		
        <table width="80%">
            <tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;">
						   <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;">
                  <asp:TextBox ID="fromDateTextBox" runat="server" ToolTip="YYYY-MM-DD"></asp:TextBox>
                </td>
            </tr>
			
			<tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;"><br/>
				 <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;"><br/>
                   <asp:TextBox ID="toDateTextBox" runat="server" ToolTip="YYYY-MM-DD"></asp:TextBox>
                </td>
            </tr>
					
            
            <tr>
               <td>
			   
			   </td>
                
                <td style="padding-left: 20px; font-size: 1.3em; text-align: right;">
                    <br/>
						<asp:Button ID="showButton" CssClass="unpaidShowButton" runat="server" Text="Show" Width="104px" OnClick="showButton_Click" />
                </td>
            </tr>
        </table>
		
		<br/><br/>
		
		</div>
        
		<br /><br/>
		
          <br/><br/>
             
             <center>
		  
		  <asp:GridView ID="unpaidBillGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                
                <columns>
                 <asp:TemplateField HeaderText="Serial No">
                         <ItemTemplate>
                         <%#Container.DataItemIndex+1%> 
                        </ItemTemplate>
                         </asp:TemplateField>

                <asp:TemplateField HeaderText="Bill Number">
                    <ItemTemplate >
                        <asp:Label ID="billNoLabel" runat="server" Text='<%#Eval("BillNo") %>'>>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                <asp:TemplateField HeaderText="Contact No.">
                    <ItemTemplate >
                        <asp:Label ID="contactLabel" runat="server" Text='<%#Eval("Contact") %>'>>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Patient Name">
                    <ItemTemplate >
                        <asp:Label ID="patientNameLabel" runat="server" Text='<%#Eval("PatientName") %>'>>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Bill Amount">
                    <ItemTemplate >
                        <asp:Label ID="billAmountLabel" runat="server" Text='<%#Eval("BillAmount") %>'>>
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
                 
             </center>
		
			<br/><br/>
			
			<table width="100%">
			
			 <tr>
			 
               <td width="60%">
			   
			   </td>
                
                <td style="padding-left: 20px; font-size: 1.3em; text-align: right;">
                 
				 <br/>
				 
				 <asp:Label ID="Label3" runat="server" Text="Total"></asp:Label>
				 &nbsp;
				 <asp:TextBox ID="totalTextBox" CssClass="totalTextBoxInUnpaid" runat="server" Width="153px"></asp:TextBox>
				 
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

             $("#fromDateTextBox").datepicker({
                 dateFormat: "yy-mm-dd",
                 changeMonth: true,
                 changeYear: true,
                 yearRange: '1940:2016'
             });

             $("#toDateTextBox").datepicker({
                 dateFormat: "yy-mm-dd",
                 changeMonth: true,
                 changeYear: true,
                 yearRange: '1940:2016'
             });

         });
  </script>


</body>
</html>
