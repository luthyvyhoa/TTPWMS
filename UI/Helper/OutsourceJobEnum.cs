
namespace UI.Helper
{
    /// <summary>
    /// Define state oursourcec job
    /// </summary>
    public enum OutsourceJobEnum
    {
        /// <summary>
        /// Load all oursource job
        /// </summary>
        All,

        /// <summary>
        /// Load oursource job by user login and has confirmed
        /// </summary>
        Me,

        /// <summary>
        /// Load oursource job by user login and has been not yet confirmed
        /// </summary>
        Me_0,

        /// <summary>
        /// Load all oursource job has been not yet confirmed
        /// </summary>
        All_Not_Confirm,

        /// <summary>
        /// Load all oursource job is reject
        /// </summary>
        Reject,

        /// <summary>
        /// Find oursource job follow workID input
        /// </summary>
        WorkID,

        /// <summary>
        /// Find oursource job by employeeID
        /// </summary>
        EmployeeID,

        /// <summary>
        /// Find oursource job by CustomerID
        /// </summary>
        Customer
    }
}
