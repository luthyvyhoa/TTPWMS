using Common.Controls;
using DA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common.Data;
using log4net;
using System.Data.Entity.Core.Objects;
using Common.Process;
using System.Windows.Forms;
using AutoMapper;

namespace UI.Helper
{
    public static class AppSetting
    {
        private static UserAccount userAccount = null;
        private static int storeID = 1;
        private static string storeName = string.Empty;
        private static DataProcess<Products> productDA = new DataProcess<Products>();
        private static DataProcess<Customers> customerDA = new DataProcess<Customers>();
        private static DataProcess<Employees> employeeDA = new DataProcess<Employees>();
        private static DataProcess<Locations> locationDA = new DataProcess<Locations>();
        private static Employees currentEmployee;
        private static string printerBarcodeName = string.Empty;
        private static string printerDefaultName = string.Empty;
        private static string pathLogoReport = string.Empty;
        private static string pathSignature = string.Empty;
        private static string pathEmployeePicture = string.Empty;
        private static string pathEmailAttach = string.Empty;
        private static int currentOperationMonthID = 0;
        private static string currentOperationMonthDescription = string.Empty;
        private static int lastOperationMonthID = 0;
        private static string lastOperationMonthDescription = string.Empty;
        private static Form parentFrm;

        // Declare log
        private static readonly ILog log = LogManager.GetLogger(typeof(AppSetting));

        /// <summary>
        /// Set the folder string path to read and write XML
        /// </summary>
        private static readonly string FilePath = Environment.CurrentDirectory + "\\";

        /// <summary>
        /// Refresh local data
        /// </summary>
        /// <returns></returns>
        public static async Task RefreshLocalData()
        {
            DataProcess<UserAccount> refreshCurrentUser = new DataProcess<UserAccount>();
            CurrentUser = refreshCurrentUser.Select(u => u.LoginName == CurrentUser.LoginName).FirstOrDefault();

            var storeData = FileProcess.LoadTable(" select top 1 StoreVietnam from Stores where storeID=" + StoreID);
            if (storeData != null && storeData.Rows.Count > 0)
            {
                storeName = Convert.ToString(storeData.Rows[0]["StoreVietnam"]);
            }
        }

        /// <summary>
        /// Load all data
        /// </summary>
        public static async Task LoadAllData(Form frm)
        {
            parentFrm = frm;
            log.Info("==> Begin load all local data");

            var storeData = FileProcess.LoadTable(" select top 1 StoreVietnam from Stores where storeID=" + StoreID);
            if (storeData != null && storeData.Rows.Count > 0)
            {
                storeName = Convert.ToString(storeData.Rows[0]["StoreVietnam"]);
            }
            //Load month value
            GetOperationMonth();

            // Get config file
            log.Info("==> Begin load all path config");
            log.InfoFormat("PrinterBarcodeName:[{0}]", ConfigurationManager.AppSettings["PrinterBarcodeName"]);
            log.InfoFormat("PrinterDefaultName:[{0}]", ConfigurationManager.AppSettings["PrinterDefaultName"]);
            log.InfoFormat("PathLogoReport:[{0}]", ConfigurationManager.AppSettings["PathLogoReport"]);
            log.InfoFormat("PathSignature:[{0}]", ConfigurationManager.AppSettings["PathSignature"]);
            log.InfoFormat("PathEmployeePicture:[{0}]", ConfigurationManager.AppSettings["PathEmployeePicture"]);
            log.InfoFormat("PathEmailAttach:[{0}]", ConfigurationManager.AppSettings["PathEmailAttach"]);
            log.InfoFormat("ContractTemplateFolder:[{0}]", ConfigurationManager.AppSettings["ContractTemplateFolder"]);
            log.InfoFormat("ContractDocumentFolder:[{0}]", ConfigurationManager.AppSettings["ContractDocumentFolder"]);


            printerBarcodeName = ConfigurationManager.AppSettings["PrinterBarcodeName"];
            printerDefaultName = ConfigurationManager.AppSettings["PrinterDefaultName"];
            pathLogoReport = ConfigurationManager.AppSettings["PathLogoReport"];
            pathSignature = ConfigurationManager.AppSettings["PathSignature"];
            pathEmployeePicture = ConfigurationManager.AppSettings["PathEmployeePicture"];
            pathEmailAttach = ConfigurationManager.AppSettings["PathEmailAttach"];
            if (storeID > 1)
            {
                pathEmailAttach = ConfigurationManager.AppSettings["PathEmailAttachBN"];
            }
            log.Info("End load all path config <== ");
            log.Info("<== End load all local data");
        }

        /// <summary>
        /// Get current Operation MonthID
        /// </summary>
        public static int CurrentOperationMonthID
        {
            get
            {
                return currentOperationMonthID;
            }
        }

        /// <summary>
        /// Get last Operation MonthID
        /// </summary>
        public static int LastOperationMonthID
        {
            get
            {
                return lastOperationMonthID;
            }
        }

        /// <summary>
        /// Get current Operation Description
        /// </summary>
        public static string CurrentOperationMonthDescription
        {
            get
            {
                return currentOperationMonthDescription;
            }
        }

        /// <summary>
        /// Get last Operation Description
        /// </summary>
        public static string LastOperationMonthDescription
        {
            get
            {
                return lastOperationMonthDescription;
            }
        }

        /// <summary>
        /// Get or Set current User login in system
        /// </summary>
        public static UserAccount CurrentUser
        {
            get
            {
                return userAccount;
            }
            set
            {
                userAccount = value;
                DataProcess<Employees> dataProcess = new DataProcess<Employees>();
                currentEmployee = dataProcess.Select(em => em.EmployeeID == userAccount.EmployeeID).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get current store ID selected
        /// </summary>
        public static int StoreID
        {
            get
            {
                return CurrentUser.StoreID;
            }
            private set
            {
                storeID = value;
            }
        }

        /// <summary>
        /// Get store name
        /// </summary>
        public static string StoreName
        {
            get
            {
                return storeName;
            }
        }

        /// <summary>
        /// Get all products
        /// </summary>
        public static IEnumerable<Products> ProductList
        {
            get
            {
                return productDA.Select();
            }
        }

        /// <summary>
        /// Get all location
        /// </summary>
        public static IEnumerable<Locations> LocationList
        {
            get
            {
                return locationDA.Select(l => l.StoreID == StoreID);
            }
        }

        /// <summary>
        /// Get all employee
        /// </summary>
        public static IEnumerable<Employees> EmployessList
        {
            get
            {
                return employeeDA.Select(e => e.StoreID == StoreID);
            }
        }

        /// <summary>
        /// Get current employee info
        /// </summary>
        public static Employees CurrentEmployee
        {
            get
            {
                return currentEmployee;
            }
        }

        /// <summary>
        /// Get printer device name to print barcode data
        /// </summary>
        public static string PrinterBarcodeName
        {
            get
            {
                return printerBarcodeName;
            }
        }

        /// <summary>
        /// Get printer device name to print report
        /// </summary>
        public static string PrinterDefaultName
        {
            get
            {
                return printerDefaultName;
            }
        }

        /// <summary>
        /// Get Logo report folder string path
        /// </summary>
        public static string PathLogoReport
        {
            get
            {
                return pathLogoReport;
            }
        }

        /// <summary>
        /// Get Signature report folder string path
        /// </summary>
        public static string PathSignature
        {
            get
            {
                return pathSignature;
            }
        }

        /// <summary>
        /// Get current email attach folder string path
        /// </summary>
        public static string PathEmailAttach
        {
            get
            {
                return pathEmailAttach;
            }
        }


        /// <summary>
        /// Get employee picture folder string path
        /// </summary>
        public static string PathEmployeePicture
        {
            get
            {
                return pathEmployeePicture;
            }
        }

        /// <summary>
        /// Get all customer by current Store
        /// </summary>
        public static IEnumerable<Customers> CustomerList
        {
            get
            {
                return customerDA.Select(c => c.StoreID == StoreID && c.CustomerDiscontinued == false);
            }
        }

        /// <summary>
        /// Get all customer
        /// </summary>
        public static IEnumerable<Customers> CustomerListAll
        {
            get
            {
                return customerDA.Select(c => c.CustomerDiscontinued == false).OrderBy(c => c.CustomerNumber);
            }
        }

        /// <summary>
        /// Get all Time Slots
        /// </summary>
        public static System.Data.DataTable TimeSlots
        {
            get
            {
                return FileProcess.LoadTable("Select * from CustomerBookingTimeSlots");
            }
        }

        /// <summary>
        /// Get all Dock Doors
        /// </summary>
        public static System.Data.DataTable DockDoors
        {
            get
            {
                return FileProcess.LoadTable("Select * from DockDoors");
            }
        }

        /// <summary>
        /// Get gender data
        /// </summary>
        /// <returns></returns>
        public static System.Data.DataTable GetGender()
        {
            using (var source = new System.Data.DataTable())
            {
                // Create column
                source.Columns.Add("ID", typeof(bool));
                source.Columns.Add("Sex", typeof(string));

                // Create row
                var rowMale = source.NewRow();
                var rowFemale = source.NewRow();

                // Set data
                rowMale["ID"] = 0;
                rowMale["Sex"] = "Male";

                rowFemale["ID"] = 1;
                rowFemale["Sex"] = "Female";

                // Add row
                source.Rows.Add(rowMale);
                source.Rows.Add(rowFemale);
                return source;
            }
        }

        // <summary>
        //  Get Insurance Unit
        // </summary>
        // <return></return>
        public static List<string> GetInsuranceUnit()
        {
            var source = new List<string>();

            source.Add("Carton");
            source.Add("Kg");

            return source;
        }

        // <summary>
        //  Get Billing Cycle
        // </summary>
        // <return></return>
        public static System.Data.DataTable GetBillingCycle()
        {
            using (var source = new System.Data.DataTable())
            {
                // Create column
                source.Columns.Add("ID", typeof(int));
                source.Columns.Add("Name", typeof(string));

                // Create row
                var row1 = source.NewRow();
                var row2 = source.NewRow();

                // Set data
                row1["ID"] = 1;
                row1["Name"] = "Monthly";

                row2["ID"] = 2;
                row2["Name"] = "Other";

                // Add row
                source.Rows.Add(row1);
                source.Rows.Add(row2);

                return source;
            }
        }

        /// <summary>
        /// Get operation month
        /// </summary>
        private static void GetOperationMonth()
        {
            int lastDayAdd = -1;
            int currentDayAdd = 0;
            int currentDay = DateTime.Now.Date.Day;
            if (currentDay < 15) { lastDayAdd = -2; currentDayAdd = -1; }
            DateTime lastMonthFilter = DateTime.Now.AddMonths(lastDayAdd);
            DateTime currentMonthFilter = DateTime.Now.AddMonths(currentDayAdd);
            DataProcess<OperatingCostMonths> dataProcess = new DataProcess<OperatingCostMonths>();
            var currentMonth = dataProcess.Select(m => m.FromDate <= currentMonthFilter && currentMonthFilter <= m.Todate).FirstOrDefault();
            var lastMonth = dataProcess.Select(m => m.FromDate <= lastMonthFilter && lastMonthFilter <= m.Todate).FirstOrDefault();
            if (currentMonth != null)
            {
                currentOperationMonthID = currentMonth.OperatingCostMonthlyID;
                currentOperationMonthDescription = currentMonth.MonthDescription;
            }
            if (lastMonth != null)
            {
                lastOperationMonthID = lastMonth.OperatingCostMonthlyID;
                lastOperationMonthDescription = lastMonth.MonthDescription;
            }
        }

    }
}
