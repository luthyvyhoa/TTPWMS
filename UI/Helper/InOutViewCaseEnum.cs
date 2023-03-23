
namespace UI.Helper
{
    /// <summary>
    /// Definition state to load data in InOutView form
    /// </summary>
    public enum InOutViewCaseEnum
    {
        /// <summary>
        /// Load All data
        /// </summary>
        All = 0,

        /// <summary>
        /// Load data by User
        /// </summary>
        Me = 1,

        /// <summary>
        /// Load data by Customer
        /// </summary>
        Customer = 2,

        /// <summary>
        /// Load data by Main
        /// </summary>
        Main = 3,

        /// <summary>
        /// Load data with case =WareHouseID
        /// </summary>
        WareHouse = 4,

        /// <summary>
        /// Load data by Room
        /// </summary>
        Room = 5,

        /// <summary>
        /// Load data by UnFinish
        /// </summary>
        UnFinish = 6,

        /// <summary>
        /// Load data or current user login is not yet confirm
        /// </summary>
        Me0 = 7,

        /// <summary>
        /// Load summary data of all Customers
        /// </summary>
        Summary = 8,
    }
}
