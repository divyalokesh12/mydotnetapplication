using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            var queryString = "select *from Employees";
            var dbConnection = new SqlConnection(dbConnectionString);
            var dataAdapter = new SqlDataAdapter(queryString, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
    }
}