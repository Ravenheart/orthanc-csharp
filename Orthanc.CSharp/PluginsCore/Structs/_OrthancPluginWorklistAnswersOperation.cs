using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp.PluginsCore.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct _OrthancPluginWorklistAnswersOperation
    {
        /// <summary>
        /// OrthancPluginWorklistAnswers*
        /// </summary>
        public IntPtr answers;
        /// <summary>
        /// const OrthancPluginWorklistQuery*
        /// </summary>
        public IntPtr query;
        /// <summary>
        /// const void*
        /// </summary>
        public IntPtr dicom;
        /// <summary>
        /// uint32_t
        /// </summary>
        public uint size;
    }
}
