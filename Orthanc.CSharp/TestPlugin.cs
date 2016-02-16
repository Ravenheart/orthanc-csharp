using Orthanc.CSharp.PluginsCore;
using Orthanc.CSharp.PluginsCore.Structs;
using RGiesecke.DllExport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Orthanc.CSharp.PluginsCore;
using Orthanc.CSharp.PluginsCore.Enums;

namespace Orthanc.CSharp
{
    public class TestPlugin
    {
        public static OrthancPluginContext Context;

        [DllExport("OrthancPluginInitialize", CallingConvention = CallingConvention.Cdecl)]
        public static int OrthancPluginInitialize(ref OrthancPluginContext c)
        {
            TestPlugin.Context = c;
            IntPtr ptrPathApi = IntPtr.Zero;
            try
            {
                ptrPathApi = Marshal.StringToHGlobalAnsi("/hello");
                Callbacks.OrthancPluginRestCallback callback = new PluginsCore.Callbacks.OrthancPluginRestCallback(Callback_OrthancPluginRestCallback);

                OrthancCPlugin.OrthancPluginRegisterRestCallback(ref TestPlugin.Context, ptrPathApi, callback);
                return 0;
            }
            catch (Exception ex)
            {
                Log.Message(ex.ToString());
                OrthancCPlugin.OrthancPluginLogError(ref c, ex.ToString());
                return -1;
            }
            finally
            {
                Marshal.FreeHGlobal(ptrPathApi);
            }
        }

        [DllExport("OrthancPluginFinalize", CallingConvention = CallingConvention.Cdecl)]
        public static void OrthancPluginFinalize()
        {
        }

        [DllExport("OrthancPluginGetName", CallingConvention = CallingConvention.Cdecl)]
        public static string OrthancPluginGetName()
        {
            return "Orthanc C# Test Plugin";
        }

        [DllExport("OrthancPluginGetVersion", CallingConvention = CallingConvention.Cdecl)]
        public static string OrthancPluginGetVersion()
        {
            return "1.0.0.0";
        }





        private static OrthancPluginErrorCode Callback_OrthancPluginRestCallback(IntPtr output, IntPtr url, IntPtr request)
        {
            // output = OrthancPluginRestOutput*
            // url = const char*
            // request = OrthancPluginHttpRequest*


            try
            {
                string pUrl = Marshal.PtrToStringAnsi(url);
                OrthancPluginHttpRequest pRequest = (OrthancPluginHttpRequest)Marshal.PtrToStructure(request, typeof(OrthancPluginHttpRequest));

                Log.Message(pUrl);

                return OrthancPluginErrorCode.OrthancPluginErrorCode_Success;
            }
            catch (Exception ex)
            {
                Log.Message(ex.ToString());
                OrthancCPlugin.OrthancPluginLogError(ref TestPlugin.Context, ex.ToString());

                return OrthancPluginErrorCode.OrthancPluginErrorCode_InternalError;
            }
            finally
            {
            }


        }
    }
}
