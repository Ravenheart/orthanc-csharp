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
    public struct OrthancPluginContext
    {
        public IntPtr pluginsManager;
        public IntPtr orthancVersion;
        public OrthancPluginFree Free;
        public InvokeService InvokeService;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void OrthancPluginFree(IntPtr buffer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate OrthancPluginErrorCode InvokeService(ref OrthancPluginContext context, _OrthancPluginService service, IntPtr @params);
}
