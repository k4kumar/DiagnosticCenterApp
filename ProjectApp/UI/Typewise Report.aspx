<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Typewise Report.aspx.cs" Inherits="ProjectApp.UI.Typewise_Report" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Typewise Report</title>

    <link href="../jquery-ui.min.css" rel="stylesheet" />
    <link href="../Style.css" rel="stylesheet" />
    
    <style>
        #showButton {
             font-size: 0.9em;
    padding:2px 6px;
        }

        #typeWiseReportGridView tr th, #typeWiseReportGridView tr td {
             text-align: center;
    font-size: 1.2em;
    padding: 6px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        
        <div class="wrapper">
            
        <br/><br/><br/>
            
             <div class="commonwrapper">
            
        <img class="banner" src="../banner.jpg" />
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
             
            <legend><h2>Typewise Report</h2></legend>
             
             <br/>
             
        <div style="border:solid 1px black;border-radius:6px;">
		
		<br/><br/>
		
        <table width="80%">
            <tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;">
						   <asp:Label runat="server" Text="From Date"></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;">
                  <asp:TextBox ID="formDatePicker" required="required" runat="server"></asp:TextBox>
                </td>
            </tr>
			
			<tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;"><br/>
				 <asp:Label ID="Label1" runat="server" Text="To Date"></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;"><br/>
                    <asp:TextBox ID="toDatePicker" required="required" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
					    
                    <td>
                            
                            <br/>

                        </td>
                        <td>
                            <br/>
                        </td>
					    
					</tr>
					
            
            <tr>
                <td style="padding-left: 20px; font-size: 1.3em; text-align: right;">
			      <br/>
			       <asp:Button ID="pdfButton" CssClass="showInTestwise" runat="server" OnClick="pdfButton_Click" Text="PDF" />
			   
			   </td>

                <td style="padding-left: 20px; font-size: 1.3em; text-align: right;">
                    <br/>
                    <asp:Button ID="showButton" CssClass="showInTestwise" runat="server" OnClick="showButton_Click" Text="Show" />
                </td>
            </tr>
        </table>
		
		<br/>
             <input type="text" id="fromDateHidden" runat="server" style="display: none;"/>
            
            <input type="text" id="toDateHidden" runat="server" style="display: none;"/>
            
            <br/>
		
		</div>
        
		<br /><br/>
		
          <br/><br/>
             
             <center>
		  
		   <asp:GridView ID="typeWiseReportGridView" CssClass="testWiseReportGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">

            <columns>
                <asp:TemplateField HeaderText="Serial No">
                         <ItemTemplate>
                         <%#Container.DataItemIndex+1%> 
                        </ItemTemplate>
                         </asp:TemplateField>
                 <asp:TemplateField HeaderText="Test Type">
                    <ItemTemplate >
                        <asp:Label runat="server" Text='<%#Eval("TypeName") %>'>>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Tests">
                    <ItemTemplate >
                        <asp:Label runat="server" Text='<%#Eval("NumberOfTests") %>'>>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Amount">
                    <ItemTemplate >
                        <asp:Label ID="totalLabel" runat="server" Text='<%#Eval("TotalAmount") %>'>>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        
                </columns>

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
               <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
               <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    
              </center>
  
		
			<br/><br/>
			
			<table width="100%">
			
			 <tr>
			 
               <td width="60%">
			   
			       &nbsp;</td>
                
                <td style="padding-left: 20px; font-size: 1.3em; text-align: right;">
                 
				 <br/>
				 
				 <asp:Label ID="Label2" runat="server" Text="Total"></asp:Label>
				 &nbsp;
				<asp:TextBox ID="totalAmountTextBox" runat="server" Width="157px"></asp:TextBox>
				 
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
            $("#formDatePicker").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "yy-mm-dd",
                yearRange: '2000:2030'

            });

            $("#toDatePicker").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "yy-mm-dd",
                yearRange: '2000:2030'
            });
        });
        </script>

</body>
</html>
