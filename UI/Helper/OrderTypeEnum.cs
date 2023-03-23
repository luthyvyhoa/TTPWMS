using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Helper
{
    /// <summary>
    /// Definition order type in project
    /// </summary>
    public enum OrderTypeEnum
    {
        /// <summary>
        /// Receiving order
        /// </summary>
        RO = 0,

        /// <summary>
        /// Dispatching order
        /// </summary>
        DO = 1,

        /// <summary>
        /// Trip order
        /// </summary>
        TW = 2,

       /// <summary>
       /// Customer Service
       /// </summary>
        CS = 3,

        /// <summary>
        /// Product CHecking
        /// </summary>
        PC = 4,
        /// <summary>
        /// BigC trip
        /// </summary>
        TB = 5
    }
}
