<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWiseReport.aspx.cs" Inherits="ProjectApp.UI.TestWiseReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Testwise Report</title>

    <link href="../jquery-ui.min.css" rel="stylesheet" />
    <link href="../Style.css" rel="stylesheet" />
    
    <style>
        #showButton {
             font-size: 0.9em;
    padding:2px 6px;
        }

        #testWiseReportGridView tr td, #testWiseReportGridView tr td {
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
             
            <legend><h2>Testwise Report</h2></legend>
             
             <br/>
             
        <div style="border:solid 1px black;border-radius:6px;">
		
		<br/><br/>
		
        <table width="80%">
            <tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;">
						   <asp:Label runat="server" Text="From Date"></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;">
                  <asp:TextBox ID="formDatePicker" runat="server"></asp:TextBox>
                </td>
            </tr>
			
			<tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;"><br/>
				 <asp:Label ID="Label1" runat="server" Text="To Date"></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;"><br/>
                    <asp:TextBox ID="toDatePicker" runat="server"></asp:TextBox>
                </td>
            </tr>
					
            
            <tr>
               <td>
			   
			   </td>
                
                <td style="padding-left: 20px; font-size: 1.3em; text-align: right;">
                    <br/>
                    <asp:Button ID="showButton" CssClass="showInTestwise" runat="server" OnClick="showButton_Click" Text="Show" />
                </td>
            </tr>
        </table>
		
		<br/><br/>
		
		</div>
        
		<br /><br/>
		
          <br/><br/>
             
             <center>
		  
		   <asp:GridView ID="testWiseReportGridView" CssClass="testWiseReportGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">

            <columns>
                <asp:TemplateField HeaderText="Serial No">
                         <ItemTemplate>
                         <%#Container.DataItemIndex+1%> 
                        </ItemTemplate>
                         </asp:TemplateField>
                 <asp:TemplateField HeaderText="Test Name">
                    <ItemTemplate >
                        <asp:Label runat="server" Text='<%#Eval("TestName") %>'>>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="TotalTest">
                    <ItemTemplate >
                        <asp:Label runat="server" Text='<%#Eval("TotalTest") %>'>>
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

            <AlternatingRowStyle BackColor="White" />
               <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
               <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    
              </center>
  
		
			<br/><br/>
			
			<table width="100%">
			
			 <tr>
			 
               <td width="60%">
			   
			   </td>
                
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
                yearRange: '1940:2016'
               
            });

            $("#toDatePicker").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "yy-mm-dd",
                yearRange: '1940:2016'
            });
        });
        </script>

</body>
</html>
