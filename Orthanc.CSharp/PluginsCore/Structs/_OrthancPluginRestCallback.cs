using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp.PluginsCore.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct _OrthancPluginRestCallback
    {
        /// <summary>
        /// const char*
        /// </summary>
        public IntPtr pathRegularExpression;
        public Orthanc.CSharp.PluginsCore.Callbacks.OrthancPluginRestCallback callback;
    }
}
