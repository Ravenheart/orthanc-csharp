using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp.PluginsCore.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct _OrthancPluginAnswerBuffer
    {
        /// <summary>
        /// OrthancPluginRestOutput*
        /// </summary>
        public IntPtr output;
        /// <summary>
        /// const char* 
        /// </summary>
        public IntPtr answer;
        /// <summary>
        /// uint32_t
        /// </summary>
        public uint answerSize;
        /// <summary>
        /// const char*
        /// </summary>
        public IntPtr mimeType;
    }
}
