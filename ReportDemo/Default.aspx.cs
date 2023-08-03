using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;


namespace ReportDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = @"Data Source=DESKTOP-T9QAGET\SQLEXPRESS;Initial Catalog=reportRDLC;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("select * from userR where id = 1", con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            con.Close();

                            ReportDataSource source = new ReportDataSource("DataSetReport", dataTable);
                            ReportViewer.LocalReport.DataSources.Clear();
                            ReportViewer.LocalReport.ReportPath = "Template.rdlc";
                            ReportViewer.LocalReport.DataSources.Add(source);
                            ReportViewer.DataBind();
                        }
                    }
                }
            }
        }
    }
}