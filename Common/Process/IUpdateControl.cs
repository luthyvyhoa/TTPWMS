
using System.Windows.Forms;
namespace Common.Process
{
    /// <summary>
    /// Update data form control by other thread
    /// </summary>
    public interface IUpdateControl
    {
        /// <summary>
        /// Set control need update data
        /// </summary>
        /// <param name="controlUpdate">Control</param>
        void UpdateControl(Control controlUpdate);

        /// <summary>
        /// Set data for control update
        /// </summary>
        void UpdateMethod();
    }
}
