
using System;
using System.Windows.Forms;
namespace Common.Process
{
    public static class RefreshData
    {

        /// <summary>
        /// Refresh value on control by order thread
        /// </summary>
        /// <param name="controlUpdate">Control</param>
        /// <param name="method">Action</param>
        public static void Refresh(Control controlUpdate, Action method)
        {
            controlUpdate.Invoke(method);
        }

        /// <summary>
        /// Reload data event 
        /// </summary>
        public static event EventHandler ReloadDataEvent = null;

        /// <summary>
        /// Raise Reload event when Reload Data event has subscribe
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        public static void OnReloadData(object sender, EventArgs e)
        {
            if (ReloadDataEvent != null)
            {
                ReloadDataEvent(sender, e);
            }
        }
    }
}
