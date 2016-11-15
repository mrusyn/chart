<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Columncharts.aspx.cs" Inherits="WorkingwithGooglecharts.HelperCharts" %>

  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title>TestResultStatistics</title>  
</head>  
<body>  
    <form id="ChartForm" runat="server">  
     <div runat="server" id="d">
        <script type="text/javascript" src="http://www.google.com/jsapi"></script>  
        <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
        
  
        <br />  
        <br />  
        <asp:Literal ID="TotalTestNumber_ltScripts" runat="server"></asp:Literal>    
        <asp:Literal ID="TestMethodName_ltScripts" runat="server"></asp:Literal>   
        <asp:Literal ID="TestAutomated_ltScripts" runat="server"></asp:Literal>   
        <asp:Literal ID="TestCategory_ltScripts" runat="server"></asp:Literal>   

        <div id="piechart" style="width: 900px; height: 500px;"></div>
        <div id="TotalTestNumber_chart_div" style="width: 2000px; height: 800px;"></div>
        <div id="TestMethodName_chart_div" style="width: 2000px; height: 3000px;"></div>   
        <div id="TestCategory_chart_div" style="width: 2000px; height: 3000px;"></div>   
     </div>  
    </form>  
</body>  
</html> 
