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
    public struct OrthancPluginDictionaryEntry
    {
        public ushort group;            /*!< The group of the tag */
        public ushort element;          /*!< The element of the tag */
        public OrthancPluginValueRepresentation vr;               /*!< The value representation of the tag */
        public uint minMultiplicity;  /*!< The minimum multiplicity of the tag */
        public uint maxMultiplicity;  /*!< The maximum multiplicity of the tag (0 means arbitrary) */
    }
}
