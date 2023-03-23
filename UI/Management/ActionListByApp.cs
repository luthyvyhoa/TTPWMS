using Common.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Management
{
    public partial class ActionListByApp : Form
    {
        private IList<object> controlList = new List<object>();
        IList<ActioAppInfo> actioAppInfos = new List<ActioAppInfo>();
        ActioAppInfo appInfo = null;
        public ActionListByApp()
        {
            InitializeComponent();
        }
        private void GetPropertiesForm(Form frm)
        {
            if (frm.Controls.Count > 0)
                foreach (Control item in frm.Controls[0].Controls)
                {
                    appInfo = new ActioAppInfo();
                    appInfo.FunctionName = frm.Name;
                    appInfo.FunctionTitle = frm.Text;
                    this.GetActionName(item, appInfo);
                    actioAppInfos.Add(appInfo);
                }

            if (frm.Controls.Count > 1)
            {
                foreach (Control item in frm.Controls[1].Controls)
                {
                    appInfo = new ActioAppInfo();
                    appInfo.FunctionName = frm.Name;
                    appInfo.FunctionTitle = frm.Text;
                    this.GetActionName(item, appInfo);
                    actioAppInfos.Add(appInfo);
                }
            }
        }
        private void GetPropertiesBaseForm(Common.Controls.frmBaseForm frmBase)
        {
            foreach (BarItem item in frmBase.rbcbase.Items)
            {
                appInfo = new ActioAppInfo();
                appInfo.FunctionName = frmBase.Name;
                appInfo.FunctionTitle = frmBase.Text;
                this.GetActionNameRibbon(item, appInfo);
                actioAppInfos.Add(appInfo);
            }
            foreach (Control item in frmBase.Controls[0].Controls)
            {
                appInfo = new ActioAppInfo();
                appInfo.FunctionName = frmBase.Name;
                appInfo.FunctionTitle = frmBase.Text;
                this.GetActionName(item, appInfo);
                actioAppInfos.Add(appInfo);
            }

            if (frmBase.Controls.Count > 1)
            {
                foreach (Control item in frmBase.Controls[1].Controls)
                {
                    appInfo = new ActioAppInfo();
                    appInfo.FunctionName = frmBase.Name;
                    appInfo.FunctionTitle = frmBase.Text;
                    this.GetActionName(item, appInfo);
                    actioAppInfos.Add(appInfo);
                }
            }
        }
        private void GetPropertiesRibbonForm(DevExpress.XtraBars.Ribbon.RibbonForm frmRibbon)
        {
            foreach (Control item in frmRibbon.Controls[0].Controls)
            {
                appInfo = new ActioAppInfo();
                appInfo.FunctionName = frmRibbon.Name;
                appInfo.FunctionTitle = frmRibbon.Text;
                this.GetActionName(item, appInfo);
                actioAppInfos.Add(appInfo);
            }

            if (frmRibbon.Controls.Count > 1)
            {
                foreach (Control item in frmRibbon.Controls[1].Controls)
                {
                    appInfo = new ActioAppInfo();
                    appInfo.FunctionName = frmRibbon.Name;
                    appInfo.FunctionTitle = frmRibbon.Text;
                    this.GetActionName(item, appInfo);
                    actioAppInfos.Add(appInfo);
                }
            }
        }
        private void ActionListByApp_Load(object sender, EventArgs e)
        {
            Type formType = typeof(Form);
            Type ribbonType = typeof(DevExpress.XtraBars.Ribbon.RibbonForm);
            Type userType = typeof(UserControl);
            Form frm = null;
            DevExpress.XtraBars.Ribbon.RibbonForm frmRibbon = null;
            UserControl urc = null;
            IList<string> typeParam = new List<string>();
            IList<Type> argsType = new List<Type>();
            IList<object> argsData = new List<object>();
            int count = 0;
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                switch (type.BaseType.Name)
                {
                    case "Form":
                    case "frmBaseFormNormal":
                        if (type.GetConstructors().Length > 0)
                        {
                            argsType = CreateParamsByType(type.GetConstructors()[0].GetParameters());
                            argsData = CreateParams(type.GetConstructors()[0].GetParameters());
                        }
                        ConstructorInfo ctorFrom = type.GetConstructor(argsType.ToArray());
                        if (ctorFrom != null)
                        {
                            try
                            {
                                frm = (Form)ctorFrom.Invoke(argsData.ToArray());
                                this.GetPropertiesForm(frm);
                            }
                            catch (Exception ex)
                            {
                              
                            }
                        }
                        else
                        {
                           
                        }
                        break;
                    case "frmBaseForm":

                        if (type.GetConstructors().Length > 0)
                        {
                            argsType = CreateParamsByType(type.GetConstructors()[0].GetParameters());
                            argsData = CreateParams(type.GetConstructors()[0].GetParameters());
                        }
                        ConstructorInfo ctorFrmbase = type.GetConstructor(argsType.ToArray());
                        if (ctorFrmbase != null)
                        {
                            try
                            {
                                frmBaseForm frmBase = (frmBaseForm)ctorFrmbase.Invoke(argsData.ToArray());
                                this.GetPropertiesBaseForm(frmBase);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        else
                        {

                        }
                        break;
                    case "RibbonForm":
                        if (type.GetConstructors().Length > 0)
                        {
                            argsType = CreateParamsByType(type.GetConstructors()[0].GetParameters());
                            argsData = CreateParams(type.GetConstructors()[0].GetParameters());
                        }
                        ConstructorInfo ctorFrmRibbon = type.GetConstructor(argsType.ToArray());
                        if (ctorFrmRibbon != null)
                        {
                            try
                            {
                                frmRibbon = (DevExpress.XtraBars.Ribbon.RibbonForm)ctorFrmRibbon.Invoke(argsData.ToArray());
                                this.GetPropertiesRibbonForm(frmRibbon);
                            }
                            catch (Exception ex)
                            {
                             
                            }

                        }
                        else
                        {

                        }
                        break;
                    case "UserControl":
                        if (type.GetConstructors().Length > 0)
                        {
                            argsType = CreateParamsByType(type.GetConstructors()[0].GetParameters());
                            argsData = CreateParams(type.GetConstructors()[0].GetParameters());
                        }
                        ConstructorInfo ctorUrc = type.GetConstructor(argsType.ToArray());
                        if (ctorUrc != null)
                        {
                            try
                            {
                                urc = (UserControl)ctorUrc.Invoke(argsData.ToArray());
                                foreach (Control item in urc.Controls[0].Controls)
                                {
                                    appInfo = new ActioAppInfo();
                                    appInfo.FunctionName = urc.Name;
                                    appInfo.FunctionTitle = urc.Text;
                                    this.GetActionName(item, appInfo);
                                    actioAppInfos.Add(appInfo);
                                }

                                if (urc.Controls.Count > 1)
                                {
                                    foreach (Control item in urc.Controls[1].Controls)
                                    {
                                        appInfo = new ActioAppInfo();
                                        appInfo.FunctionName = urc.Name;
                                        appInfo.FunctionTitle = urc.Text;
                                        this.GetActionName(item, appInfo);
                                        actioAppInfos.Add(appInfo);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                        }
                        else
                        {

                            Console.WriteLine("=========> Singleton object=[{0}]", type.Name);
                        }
                        break;
                    default:
                        break;
                }
            }
            this.gridControl1.DataSource = actioAppInfos;
        }

        private IList<Type> CreateParamsByType(ParameterInfo[] parameterInfos)
        {
            IList<Type> paraData = new List<Type>();
            foreach (var item in parameterInfos)
            {
                paraData.Add(item.ParameterType);
            }
            return paraData;
        }
        private IList<object> CreateParams(ParameterInfo[] parameterInfos)
        {
            IList<object> paraData = new List<object>();
            foreach (var item in parameterInfos)
            {
                switch (item.ParameterType.Name)
                {
                    case "Int32": paraData.Add(0); break;
                    case "String": paraData.Add("   "); break;
                    case "DateTime": paraData.Add(DateTime.Now); break;
                    case "Guid": paraData.Add(Guid.Empty); break;
                    case "List`1": paraData.Add(null); break;
                    case "Boolean": paraData.Add(false); break;
                    case "Decimal": paraData.Add(0.0m); break;
                    case "IList`1": paraData.Add(null); break;
                    case "DispatchingProducts": paraData.Add(null); break;
                    case "Object": paraData.Add(null); break;
                    case "Byte": paraData.Add(Convert.ToByte(0)); break;
                    case "Nullable`1": paraData.Add(null); break;
                    case "frm_S_AO_TrainingDefinitionGroup": paraData.Add(null); break;
                    case "STGate_EmployeeInOutIncorrect_Result": paraData.Add(null); break;
                    case "DataTable": paraData.Add(null); break;
                    case "Aisles": paraData.Add(null); break;
                    case "Image": paraData.Add(null); break;
                }
            }
            return paraData;

        }
        private void GetActionName(Control control, ActioAppInfo appInfo)
        {
            switch (control.GetType().Name)
            {
                case "SimpleButton":
                    var btn = (DevExpress.XtraEditors.SimpleButton)control;
                    appInfo.ActionName = btn.Name;
                    appInfo.ActionTitle = btn.Text;
                    break;
                case "BarButtonItem":
                    //var btnBar = (DevExpress.XtraBars.BarButtonItem)control;
                    //appInfo.ActionName = btnBar.Name;
                    //appInfo.ActionTitle = btnBar.Caption;
                    break;
                case "RepositoryItemCheckEdit":
                    break;
                //case "CheckEdit":
                //    var chk = (DevExpress.XtraEditors.CheckEdit)control;
                //    appInfo.ActionName = chk.Name;
                //    appInfo.ActionTitle = chk.Text;
                //    break;
                case "Button":
                    break;
                //case "CheckBox":
                //    break;
                default:
                    break;
            }
        }

        private void GetActionNameRibbon(BarItem control, ActioAppInfo appInfo)
        {
            switch (control.GetType().Name)
            {
                case "BarButtonItem":
                    appInfo.ActionName = control.Name;
                    appInfo.ActionTitle = control.Caption;
                    break;
                default:
                    break;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string path = "FunctionListWMS.xlsx";
            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }
    }
    public class ActioAppInfo
    {
        public string FunctionName { get; set; }
        public string FunctionTitle { get; set; }
        public string ActionName { get; set; }
        public string ActionTitle { get; set; }
    }
}
