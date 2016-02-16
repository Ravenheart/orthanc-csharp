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
    public struct OrthancPluginHttpRequest
    {
        public OrthancPluginHttpMethod method;
        public uint groupsCount;
        public IntPtr groups;
        public uint getCount;
        public IntPtr getKeys;
        public IntPtr getValues;
        public IntPtr body;
        public uint bodySize;
        public uint headersCount;
        public IntPtr headersKeys;
        public IntPtr headersValues;
    }
}