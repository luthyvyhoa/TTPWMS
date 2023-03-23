
namespace UI.Helper
{
    public enum DataStateEnum
    {
        /// <summary>
        /// No modified data
        /// </summary>
        None = 0,

        /// <summary>
        /// Data has modified
        /// </summary>
        Update = 1,

        /// <summary>
        /// Data has add new
        /// </summary>
        Insert = 2,

        /// <summary>
        /// Data has deleted
        /// </summary>
        Delete = 3
    }
}
