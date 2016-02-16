using Orthanc.CSharp.PluginsCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp.PluginsCore
{
    public class Callbacks
    {
        /// <summary>
        /// Signature of a callback function that answers to a REST request.
        /// </summary>
        /// <param name="output">OrthancPluginRestOutput*</param>
        /// <param name="url">const char*</param>
        /// <param name="request">OrthancPluginHttpRequest*</param>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate OrthancPluginErrorCode OrthancPluginRestCallback(IntPtr output, IntPtr url, IntPtr request);

        /// <summary>
        /// Signature of a callback function that is triggered when Orthanc receives a DICOM instance.
        /// </summary>
        /// <param name="instance">OrthancPluginDicomInstance*</param>
        /// <param name="instanceId">const char*</param>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate OrthancPluginErrorCode OrthancPluginOnStoredInstanceCallback(IntPtr instance, IntPtr instanceId);

        /// <summary>
        /// Callback to handle the C-Find SCP requests received by Orthanc.
        /// </summary>
        /// <param name="answers">OrthancPluginWorklistAnswers*</param>
        /// <param name="query">const OrthancPluginWorklistQuery*</param>
        /// <param name="remoteAet">const char*</param>
        /// <param name="calledAet">const char*</param>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate OrthancPluginErrorCode OrthancPluginWorklistCallback(IntPtr answers, IntPtr query, IntPtr remoteAet, IntPtr calledAet);
    }
}
