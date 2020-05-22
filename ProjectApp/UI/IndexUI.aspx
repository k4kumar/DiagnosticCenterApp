<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUI.aspx.cs" Inherits="ProjectApp.UI.IndexUI" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="UTF-8"/>
    <title>Diagnostic Centre Menu</title>

    <link href="../Style.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="wrapper">
            
        <br/><br/><br/>
            
             <div class="commonwrapper">
            
        <img class="banner" src="../banner.jpg" />
            
        <hr/><hr/>

                 <br/><br/>
            
        <p class="declare">
            Welcome to the automated data management system for
        </p>
        <p class="declare shadow">
            People's Care Diagnostic Center
        </p>

                 <br/><br/>
        <hr/>
                 <br/>
        
            
         <fieldset style="padding:5px">
             
            <legend><h2>Menu</h2></legend>
             
             <br/>
             
          
        <table width="100%">
            <tr>
                <td width="50%">
          <a href="TypeSaveUI.aspx" style="margin-left: 10px;">
          <p class="menu">
              Test Type Setup
          </p>
          </a> 
                </td>
                
                <td style="text-align: right; margin-right: 10px;">
                    
           <a href="TestSaveUI.aspx">
            <p class="menu">
              Test Setup
          </p>
        </a><br/>
                </td>
            </tr>
            
            <tr>
                <td width="50%">
                    <br/><br />
          <a href="TestRequestEntryUI.aspx" style="margin-left: 10px;">
          <p class="menu">
              Test Request Entry
          </p>
          </a> 
                </td>
                
               <td style="text-align: right; margin-right: 10px;">
                   <br/><br/>
                    
           <a href="PaymentUI.aspx">
            <p class="menu">
              Payment
          </p>
        </a><br/>
                </td>
            </tr>
            
             <tr>
                <td width="50%">
                    <br/><br />
          <a href="TestWiseReport.aspx" style="margin-left: 10px;">
          <p class="menu">
              Testwise Report
          </p>
          </a> 
                </td>
                
               <td style="text-align: right; margin-right: 10px;">
                   <br/><br/>
                    
           <a href="Typewise Report.aspx">
            <p class="menu">
              Typewise Report
          </p>
        </a><br/>
                </td>
            </tr>
            
             <tr>
               
                 <td colspan="2">
                     <br/><br/>
                     
                     <center>
                   
                     <a href="UnpaidBillReportUI.aspx">
                         
                      <p class="menu">
                          Unpaid Bill Report 
                     </p>

                     </a>
                         
                         </center>

                 </td>

            </tr>

        </table>
             <br/><br/><br/>


        </fieldset>
                 
                 <br/><br/><br/>
       
               
        </div>
            <br/><br/>

        </div>
       
    </div>
    </form>
</body>
</html>
