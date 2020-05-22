<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentUI.aspx.cs" Inherits="ProjectApp.UI.PaymentUI" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8"/>
    <title>Payment</title>
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
             
            <legend><h2>Payment</h2></legend>
             
             <br/>
             
        <div style="border:solid 1px black;border-radius:6px;">
            <br/><br/>
             
        <table width="80%">
             
              
            <input type="text" id="hideSomething" runat="server" style="display: none;"/>
            
            <input type="text" id="hideObject" runat="server" style="display: none;"/>
               
          

            <tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;"><br/>
						   <asp:Label ID="Label1" runat="server" Text="Bill No."></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;"><br/>
                  <asp:TextBox ID="billNoTextBox" onKeyup="ClearMobile()" runat="server" Width="202px"></asp:TextBox>
                </td>
            </tr>
			
			<tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;"><br/>
				 <asp:Label ID="Label2" runat="server" Text="Mobile No."></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;"><br/>
                   <asp:TextBox ID="mobileNoTextBox" onKeyup="ClearBill()" runat="server" Width="201px"></asp:TextBox>
                </td>
            </tr>
					
            
            <tr>
               <td>
			   
			   </td>
                
                <td style="padding-left: 20px; font-size: 1.3em; text-align: right;">
                    <br/>
                    <asp:Button ID="searchButton" class="paySearchButton" runat="server" Text="Search" OnClick="searchButton_Click" Height="35px" />
                </td>
            </tr>
        </table>
            <br/><br/>
		
		</div>
             
		<br /><br/>
		
        <div style="border:solid 1px black;border-radius:6px;">
        
         <br/><br/>

        <table width="80%">
            <tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;">
						 <asp:Label ID="Label5" runat="server" Text="Amount"></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;">
					<asp:TextBox ID="amountTextBox" runat="server" Enabled="False" Width="213px" ForeColor="Black"></asp:TextBox>
                </td>
            </tr>
			
			<tr>
                <td width="40%" style="text-align:right; font-size: 1.4em;"><br/>
				  <asp:Label ID="Label9000" runat="server" Text="Due Date"></asp:Label>
                </td>
                
                <td style="padding-left: 20px; font-size: 1.3em;text-align: right;"><br/>
                   <asp:TextBox ID="dueDateTextBox" runat="server" Enabled="False" Width="212px" ForeColor="Black"></asp:TextBox>
                </td>
            </tr>
					
            
            <tr>
               <td>
			   
			   </td>
                
                <td style="padding-left: 20px; font-size: 1.3em; text-align: right;">
                    <br/>
                    <asp:Button ID="payButton" runat="server" Text="Pay" OnClick="payButton_Click" />
                </td>
            </tr>
        </table>
            
            <br/><br/>
            
            <center>

            <asp:Label ID="messageLabel" CssClass="paymentMessageLabel" runat="server"></asp:Label>
            
             </center>
            
            <br/><br/><br/>
		
		</div>
		
		<br/><br/><br/>
		
        <center>

		
         
        </center>   
		
		<br/><br/><br/>
		
		
		</fieldset>
</div>
            
            <br/><br/><br/><br/>

</div>
        
    </div>
    </form>
    
    
    <script src="../jquery-3.1.1.min.js"></script>
    <script src="../Scripts/PaymentScript.js"></script>

</body>
</html>
