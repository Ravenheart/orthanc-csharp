using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp.PluginsCore.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct _OrthancPluginRestApiGet2
    {
        /// <summary>
        /// OrthancPluginMemoryBuffer*
        /// </summary>
        public IntPtr target;
        /// <summary>
        /// const char* 
        /// </summary>
        public IntPtr uri;
        /// <summary>
        /// uint32_t
        /// </summary>
        public uint headersCount;
        /// <summary>
        /// const char* const*
        /// </summary>
        public IntPtr headersKeys;
        /// <summary>
        /// const char* const* 
        /// </summary>
        public IntPtr headersValues;
        /// <summary>
        /// int32_t
        /// </summary>
        public int afterPlugins;
    }
}
