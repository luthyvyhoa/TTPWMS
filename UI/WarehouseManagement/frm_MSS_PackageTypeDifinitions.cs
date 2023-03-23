using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;
using UI.Helper;

namespace UI.WarehouseManagement
{
    public partial class frm_MSS_PackageTypeDifinitions : Form
    {
        private DataProcess<QCMaster> dataProcess = new DataProcess<QCMaster>();
        private BindingList<QCMaster> bindingList = null;
        private IList<DVTQuyCach> listMeasure = null;
        public frm_MSS_PackageTypeDifinitions()
        {
            InitializeComponent();
        }

        private void frm_MSS_PackageTypeDifinitions_Load(object sender, EventArgs e)
        {
            this.LoadMeasure();
            var dataSource = this.dataProcess.Select().ToList();
            this.bindingList = new BindingList<QCMaster>(dataSource);
            this.grdQC.DataSource = this.bindingList;
            this.AddNewRow();
        }

        private void LoadMeasure()
        {
            DataProcess<DVTQuyCach> dataProcess = new DataProcess<DVTQuyCach>();
            this.listMeasure = dataProcess.Select().ToList();
            this.rpi_lke_Measure.DataSource = this.listMeasure;
            this.rpi_lke_Measure.DisplayMember = "TenDVT";
            this.rpi_lke_Measure.ValueMember = "DVTID";
        }
        private void AddNewRow()
        {
            if (this.bindingList.Count(p => p.PackageTypeID <= 0) <= 0)
            {
                var newQC = new QCMaster();
                newQC.PackageTypeID = 0;
                newQC.Value1 = 1;
                newQC.Value2 = 1;
                newQC.CreatedBy = AppSetting.CurrentUser.LoginName;
                newQC.CreatedTime = DateTime.Now;
                this.bindingList.Add(newQC);
                this.grvQC.RefreshData();
            }
        }

        private void grvQC_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;
                //decimal value1 = Convert.ToInt32(this.grvQC.GetFocusedRowCellValue("Value1"));
                //decimal value2 = Convert.ToInt32(this.grvQC.GetFocusedRowCellValue("Value2"));
                decimal value1 = Convert.ToDecimal(this.grvQC.GetFocusedRowCellValue("Value1"));
                decimal value2 = Convert.ToDecimal(this.grvQC.GetFocusedRowCellValue("Value2"));
                int mearSureID = Convert.ToInt32(this.grvQC.GetFocusedRowCellValue("MeasureID"));
                if (value1 <= 0 || value2 <= 0 || mearSureID <= 0) return;
                var currentMeasure = this.listMeasure.Where(m => m.DVTID == mearSureID).FirstOrDefault();
                string packageTypeName = "";
                if (value1>1 && value2>1)
                {
                    packageTypeName = Convert.ToString(value1) + "x" + Convert.ToString(value2) + currentMeasure.TenDVT;
                }else if(value1==1 && value2>1)
                {
                    packageTypeName =Convert.ToString(value2) + currentMeasure.TenDVT;
                }else if(value1>1 && value2==1)
                {
                    packageTypeName = Convert.ToString(value1) + currentMeasure.TenDVT;
                }
                else
                {
                    packageTypeName = Convert.ToString(value1) + currentMeasure.TenDVT;
                }
                 
                string packageName = Convert.ToString(this.grvQC.GetFocusedRowCellValue("PackageName"));
                if (packageTypeName != packageName)
                    this.grvQC.SetFocusedRowCellValue("PackageName", packageTypeName);
                var currentQC = (QCMaster)this.grvQC.GetRow(e.RowHandle);
                if (currentQC.PackageTypeID > 0)
                {
                    //update
                    this.dataProcess.Update(currentQC);
                }
                else
                {
                    //Insert
                    this.dataProcess.Insert(currentQC);
                    this.AddNewRow();
                }
            }
            catch (Exception ex)
            {
            }


        }
    }
}
