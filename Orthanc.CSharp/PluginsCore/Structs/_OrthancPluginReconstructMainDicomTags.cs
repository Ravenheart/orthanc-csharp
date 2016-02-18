using Orthanc.CSharp.PluginsCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp.PluginsCore.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct _OrthancPluginReconstructMainDicomTags
    {
        /// <summary>
        /// OrthancPluginStorageArea*
        /// </summary>
        public IntPtr storageArea;
        /// <summary>
        /// OrthancPluginResourceType
        /// </summary>
        public OrthancPluginResourceType level;
    }
}
