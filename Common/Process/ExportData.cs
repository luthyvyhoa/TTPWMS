using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Process
{
    public static class ExportData
    {
        public static bool ExportExcel(DataTable source,string fileName, string url)
        {
            try
            {
                string path = url + fileName;//System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                string fileExport = path + "_" + System.DateTime.Now.ToString("yyMMddHHmmss") + ".xlsx";
                var datasource = source;
                DevExpress.XtraGrid.GridControl grdReport = new DevExpress.XtraGrid.GridControl();
                DevExpress.XtraGrid.Views.Grid.GridView grvReport = new DevExpress.XtraGrid.Views.Grid.GridView(grdReport);
                grdReport.MainView = grvReport;
                grdReport.ForceInitialize();
                grdReport.BindingContext = new BindingContext();
                grdReport.DataSource = datasource;
                grvReport.PopulateColumns();

                // Export data to excel file
                grvReport.ExportToXlsx(fileExport);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }
    }
}
