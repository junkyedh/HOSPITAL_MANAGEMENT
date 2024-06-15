using Microsoft.Reporting.WinForms;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
{
    public partial class FormReport : Form
    {
        private HOSPITAL_MANAGEMENT_SOURCE.Report reportDataset;
        private Microsoft.Reporting.WinForms.ReportDataSource reportDataSource;
        public string ReportType { get; set; }
        public int ObjectID { get; set; }
        public DateTime DATEFROM { get; set; }
        public DateTime DATETO { get; set; }
        public DataTable ReportData { get; set; }

        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {


            //Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();

            //// Set the processing mode
            //this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

            //// Set the report data source
            //reportDataSource.Name = "DataSetName"; // Change DataSetName to your actual DataSet name in the report
            //reportDataSource.Value = ReportData;

            //// Set the report embedded resource
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "HOSPITAL_MANAGEMENT_SOURCE.FormReport.rdlc"; // Change Report1 to your actual report name

            //// Add the report data source to the report viewer
            //this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            //this.reportViewer1.RefreshReport();
            //Tao file report moi
            
            this.reportDataset = new Report();
            this.reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            switch (ReportType)
            {
                case "EC":
                    ReportTableAdapters.ECTableAdapter ECTableAdapter = new ReportTableAdapters.ECTableAdapter();
                    ECTableAdapter.Fill(reportDataset.EC);
                    this.reportDataSource.Name = "EC";
                    this.reportDataSource.Value = this.reportDataset.EC;
                    

                    //this.reportViewer1.LocalReport.ReportEmbeddedResource = "HOSPITAL_MANAGEMENT_SOURCE.Report.EC.rdlc";
                    break;
                case "MEDICINEBILL":
                    ReportTableAdapters.MEDICINEBILLTableAdapter MEDICINEBILLTableAdapter = new ReportTableAdapters.MEDICINEBILLTableAdapter();
                    MEDICINEBILLTableAdapter.Fill(reportDataset.MEDICINEBILL);

                    this.reportDataSource.Name = "MEDICINEBILL";
                    this.reportDataSource.Value = this.reportDataset.MEDICINEBILL;

                    //this.reportViewer1.LocalReport.ReportEmbeddedResource = "HOSPITAL_MANAGEMENT_SOURCE.Report.EC.rdlc";

                    break;
            }
            this.reportViewer1.LocalReport.DataSources.Add(this.reportDataSource);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        //private string connectionString = "Server=ep-jolly-cherry-a5ub2x8e.us-east-2.aws.neon.tech;Port=5432;Database=hospital_management;User ID=hospital_management_owner;Password=sIFZ6kcA0iTj;";

        //public string ReportType { get; set; }
        //public int ObjectID { get; set; }

        //public FormReport()
        //{
        //    InitializeComponent();
        //}

        //public void LoadReport()
        //{

        //    this.reportDataset = new Report();
        //    this.reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
        //    this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
        //    DataTable data = GetDataFromPostgreSQL();

        //    // Bind data source to report
        //    ReportDataSource reportDataSource = new ReportDataSource("DataSetName", data);
        //    reportViewer1.LocalReport.DataSources.Add(reportDataSource);

        //    // Set report embedded resource path
        //    reportViewer1.LocalReport.ReportEmbeddedResource = "HOSPITAL_MANAGEMENT_SOURCE.Report1.rdlc";

        //    // Refresh report
        //    reportViewer1.RefreshReport();
        //}

        //private DataTable GetDataFromPostgreSQL()
        //{
        //    DataTable dataTable = new DataTable();

        //    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        // Modify the query based on ReportType and ObjectID
        //        string query = $"SELECT * FROM your_table WHERE ReportType = '{ReportType}' AND ObjectID = {ObjectID}";

        //        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection))
        //        {
        //            adapter.Fill(dataTable);
        //        }
        //    }

        //    return dataTable;
        //}
    }
}
