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
    public struct _OrthancPluginRegisterDictionaryTag
    {
        /// <summary>
        /// uint16_t
        /// </summary>
        public UInt16 group;
        /// <summary>
        /// uint16_t
        /// </summary>
        public UInt16 element;
        /// <summary>
        /// OrthancPluginValueRepresentation
        /// </summary>
        public OrthancPluginValueRepresentation vr;
        /// <summary>
        /// const char*
        /// </summary>
        public IntPtr name;
        /// <summary>
        /// uint32_t
        /// </summary>
        public UInt32 minMultiplicity;
        /// <summary>
        /// uint32_t
        /// </summary>
        public UInt32 maxMultiplicity;
    }
}
