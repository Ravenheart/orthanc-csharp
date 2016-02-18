using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp.PluginsCore.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct _OrthancPluginRegisterErrorCode
    {
        /// <summary>
        /// OrthancPluginErrorCode*
        /// </summary>
        public IntPtr target;
        /// <summary>
        /// int32_t
        /// </summary>
        public Int32 code;
        /// <summary>
        /// uint16_t
        /// </summary>
        public UInt16 httpStatus;
        /// <summary>
        /// const char*
        /// </summary>
        public IntPtr message;
    }
}
