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
    public struct _OrthancPluginDicomToJson
    {
        public IntPtr result;
        public IntPtr instanceId;
        public IntPtr buffer;
        public uint size;
        public OrthancPluginDicomToJsonFormat format;
        public OrthancPluginDicomToJsonFlags flags;
        public uint maxStringLength;
    }
}
