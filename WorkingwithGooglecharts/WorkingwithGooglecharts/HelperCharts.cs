using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WorkingwithGooglecharts
{
    public partial class HelperCharts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindChart_TestCategory();
                BindChart_TestMethodName();
                BindChart_TotalTestNumber();
                BindChart_TestAutomated();
            }
        }

        private void BindGvData()
        {
            gvData.DataSource = GetChartData();
            gvData.DataBind();
        }

        private void BindChart_TestCategory()
        {

            DataTable TestCategory_dsChartData = new DataTable();
            StringBuilder TestCategory_strScript = new StringBuilder();

            try
            {

                TestCategory_dsChartData = GetChartData_TestCategory();

                TestCategory_strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart', 'bar']});</script>
  
                    <script type='text/javascript'>  
                    function drawChart() {         
                    var data = google.visualization.arrayToDataTable([['CategoryName', 'NumberOfPassedTest', 'NumberOfFailedTest'],");

                foreach (DataRow row in TestCategory_dsChartData.Rows)
                {
                    TestCategory_strScript.Append("['" + row["CategoryName"] + "'," + (100 * (int)row["NumberOfPassedTest"]) / ((int)row["NumberOfFailedTest"] + (int)row["NumberOfPassedTest"]) + "," + (100 * (int)row["NumberOfFailedTest"]) / ((int)row["NumberOfFailedTest"] + (int)row["NumberOfPassedTest"]) + "],");
                }
                TestCategory_strScript.Remove(TestCategory_strScript.Length - 1, 1);
                TestCategory_strScript.Append("]);");

                TestCategory_strScript.Append("var options = { title : 'Passed/Failed tests', vAxis: {title: 'CategoryName'},  "
                                 + "hAxis: {title: 'Number, %'}, chartArea: {width: '50%'}, isStacked: true };");

                TestCategory_strScript.Append(" var chart = new google.visualization.BarChart(document.getElementById('TestCategory_chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawChart);");
                TestCategory_strScript.Append(" </script>");
                TestCategory_ltScripts.Text = TestCategory_strScript.ToString();
            }
            catch
            {
            }
            finally
            {
                TestCategory_dsChartData.Dispose();
                TestCategory_strScript.Clear();
            }
        }

        private void BindChart_TestMethodName()
        {

            DataTable TestMethodName_dsChartData = new DataTable();
            StringBuilder TestMethodName_strScript = new StringBuilder();

            try
            {

                TestMethodName_dsChartData = GetChartData_TestMethodName();

                TestMethodName_strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart', 'bar']});</script>
  
                    <script type='text/javascript'>  
                    function drawChart() {         
                    var TestMethodName_data = google.visualization.arrayToDataTable([['TestName', 'NumberOfPassedTest', 'NumberOfFailedTest'],");

                foreach (DataRow row in TestMethodName_dsChartData.Rows)
                {
                    TestMethodName_strScript.Append("['" + row["TestName"] + "'," + (100 * (int)row["NumberOfPassedTest"]) / ((int)row["NumberOfFailedTest"] + (int)row["NumberOfPassedTest"]) + "," + (100 * (int)row["NumberOfFailedTest"]) / ((int)row["NumberOfFailedTest"] + (int)row["NumberOfPassedTest"]) + "],");
                }
                TestMethodName_strScript.Remove(TestMethodName_strScript.Length - 1, 1);
                TestMethodName_strScript.Append("]);");

                TestMethodName_strScript.Append("var options = { title : 'Passed/Failed tests', vAxis: {title: 'TestName'},  "
                                 + "hAxis: {title: 'Number, %'}, chartArea: {width: '50%'}, isStacked: true };");

                TestMethodName_strScript.Append(" var chart = new google.visualization.BarChart(document.getElementById('TestMethodName_chart_div'));  chart.draw(TestMethodName_data, options); } google.setOnLoadCallback(drawChart);");
                TestMethodName_strScript.Append(" </script>");
                TestMethodName_ltScripts.Text = TestMethodName_strScript.ToString();
            }
            catch
            {
            }
            finally
            {
                TestMethodName_dsChartData.Dispose();
                TestMethodName_strScript.Clear();
            }
        }

        private void BindChart_TotalTestNumber()
        {
            DataTable TotalTestNumber_dsChartData = new DataTable();
            StringBuilder TotalTestNumber_strScript = new StringBuilder();

            try
            {

                TotalTestNumber_dsChartData = GetChartData();

                TotalTestNumber_strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawVisualization() {         
                    var TotalTestNumber_data = google.visualization.arrayToDataTable([  
                    ['Date', 'TotalTestNumber'],");

                foreach (DataRow row in TotalTestNumber_dsChartData.Rows)
                {
                    TotalTestNumber_strScript.Append("['" + row["Date"] + "'," + row["TotalTestNumber"] + "],");
                }
                TotalTestNumber_strScript.Remove(TotalTestNumber_strScript.Length - 1, 1);
                TotalTestNumber_strScript.Append("]);");

                TotalTestNumber_strScript.Append("var options = { title : 'Total number of tests by date', vAxis: {title: 'TotalTestNumber'},  "
                                                 + "hAxis: {title: 'Date'}};");
                TotalTestNumber_strScript.Append(" var chart = new google.visualization.AreaChart(document.getElementById('TotalTestNumber_chart_div'));  chart.draw(TotalTestNumber_data, options); } google.setOnLoadCallback(drawVisualization);");
                TotalTestNumber_strScript.Append(" </script>");

                TotalTestNumber_ltScripts.Text = TotalTestNumber_strScript.ToString();

            }
            catch
            {
            }
            finally
            {
                TotalTestNumber_dsChartData.Dispose();
                TotalTestNumber_strScript.Clear();

            }
        }

        private void BindChart_TestAutomated()
        {
            
            StringBuilder TestAutomated_strScript = new StringBuilder();

            try
            {
                TestAutomated_strScript.Append(@"<script type='text/javascript'>  
                google.charts.load('current', {'packages':['corechart']});
      
                google.charts.setOnLoadCallback(drawChart);
                  function drawChart() {
                    var data = google.visualization.arrayToDataTable([
                      ['Task', 'Hours per Day'],
                      ['Automated test cases',     200],
                      ['Not automated test cases',      80]
                    ]);

                    var options = {
                      title: 'Automated test cases'
                    };

                 var chart = new google.visualization.PieChart(document.getElementById('piechart'));

                 chart.draw(data, options);
      }");
                
                TestAutomated_strScript.Append(" </script>");

                TestAutomated_ltScripts.Text = TestAutomated_strScript.ToString();

            }
            catch
            {
            }
            finally
            {

                TestAutomated_strScript.Clear();

            }
        }


        private DataTable GetChartData_TestMethodName()
        {
            DataSet dsData = new DataSet();
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                SqlDataAdapter sqlCmd = new SqlDataAdapter("dbo.GetAllTestMethodData", sqlCon);
                sqlCmd.SelectCommand.CommandText = "exec master.dbo.GetAllTestMethodData";
                sqlCon.Open();

                sqlCmd.Fill(dsData);

                sqlCon.Close();
            }
            catch
            {
                throw;
            }
            return dsData.Tables[0];

        }

        private DataTable GetChartData_TestCategory()
        {
            DataSet dsData = new DataSet();
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                SqlDataAdapter sqlCmd = new SqlDataAdapter("dbo.GetTestCategories", sqlCon);
                sqlCmd.SelectCommand.CommandText = "exec master.dbo.GetTestCategories";
                sqlCon.Open();

                sqlCmd.Fill(dsData);

                sqlCon.Close();
            }
            catch
            {
                throw;
            }
            return dsData.Tables[0];

        }

        
        /// <summary>  
        /// fetch data from mdf file saved in app_data  
        /// </summary>  
        /// <returns>DataTable</returns>  
        private DataTable GetChartData()
        {
            DataSet dsData = new DataSet();
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                SqlDataAdapter sqlCmd = new SqlDataAdapter("SELECT TOP 1000 Date,TotalTestNumber FROM [TestResult_DB].[dbo].[TestRuns]", sqlCon);

                sqlCmd.Fill(dsData);

                sqlCon.Close();
            }
            catch
            {
                throw;
            }
            return dsData.Tables[0];
        }
    }
}
