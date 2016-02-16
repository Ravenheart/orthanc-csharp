using Orthanc.CSharp.PluginsCore.Enums;
using Orthanc.CSharp.PluginsCore.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp.PluginsCore
{
    public class OrthancCPlugin
    {
        #region Constants
        public const int ORTHANC_PLUGINS_MINIMAL_MAJOR_NUMBER = 1;
        public const int ORTHANC_PLUGINS_MINIMAL_MINOR_NUMBER = 0;
        public const int ORTHANC_PLUGINS_MINIMAL_REVISION_NUMBER = 0;
        #endregion

        public static void OrthancPluginSetDescription(ref OrthancPluginContext context, string description)
        {
            _OrthancPluginSetPluginProperty pr = new _OrthancPluginSetPluginProperty();
            pr.plugin = TestPlugin.OrthancPluginGetName();
            pr.property = _OrthancPluginProperty._OrthancPluginProperty_Description;
            pr.value = description;

            int size = Marshal.SizeOf(typeof(_OrthancPluginSetPluginProperty));
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(pr, ptr, true);

            try
            {
                context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_SetPluginProperty, ptr);
            }
            catch (Exception ex)
            {
                OrthancPluginLogError(ref context, ex.ToString());
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public static int OrthancPluginCheckVersion(ref OrthancPluginContext context)
        {
            int major, minor, revision;

            string ver = Marshal.PtrToStringAnsi(context.orthancVersion);
            if (ver != "mainline")
                return 1;

            string[] split = ver.Split('.');
            if (split.Length != 3)
                return 0;

            major = Convert.ToInt32(split[0]);
            minor = Convert.ToInt32(split[1]);
            revision = Convert.ToInt32(split[2]);

            if (major > ORTHANC_PLUGINS_MINIMAL_MAJOR_NUMBER)
                return 0;

            if (minor > ORTHANC_PLUGINS_MINIMAL_MINOR_NUMBER)
                return 1;

            if (minor < ORTHANC_PLUGINS_MINIMAL_MINOR_NUMBER)
                return 0;

            if (revision >= ORTHANC_PLUGINS_MINIMAL_REVISION_NUMBER)
                return 1;

            return 0;
        }

        public static void OrthancPluginFreeMemoryBuffer(ref OrthancPluginContext context, IntPtr buffer)
        {
            context.Free(buffer);
        }

        public static void OrthancPluginFreeString(ref OrthancPluginContext context, IntPtr str)
        {
            if (str != IntPtr.Zero)
            {
                context.Free(str);
            }
        }


        public static void OrthancPluginLogError(ref OrthancPluginContext context, string message)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.StringToHGlobalAnsi(message);
                OrthancCPlugin.OrthancPluginLogError(ref context, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
        public static void OrthancPluginLogError(ref OrthancPluginContext context, IntPtr message)
        {
            context.InvokeService(ref context, PluginsCore.Enums._OrthancPluginService._OrthancPluginService_LogError, message);
        }

        public static void OrthancPluginLogWarning(ref OrthancPluginContext context, string message)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.StringToHGlobalAnsi(message);
                OrthancCPlugin.OrthancPluginLogWarning(ref context, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
        public static void OrthancPluginLogWarning(ref OrthancPluginContext context, IntPtr message)
        {
            context.InvokeService(ref context, PluginsCore.Enums._OrthancPluginService._OrthancPluginService_LogWarning, message);
        }

        public static void OrthancPluginLogInfo(ref OrthancPluginContext context, string message)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.StringToHGlobalAnsi(message);
                OrthancCPlugin.OrthancPluginLogInfo(ref context, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
        public static void OrthancPluginLogInfo(ref OrthancPluginContext context, IntPtr message)
        {
            context.InvokeService(ref context, PluginsCore.Enums._OrthancPluginService._OrthancPluginService_LogInfo, message);
        }

        /// <summary>
        /// Register a REST callback.
        /// </summary>
        /// <param name="context">OrthancPluginContext*</param>
        /// <param name="pathRegularExpression">const char*</param>
        /// <param name="callback">OrthancPluginRestCallback</param>
        public static void OrthancPluginRegisterRestCallback(ref OrthancPluginContext context, IntPtr pathRegularExpression, Callbacks.OrthancPluginRestCallback callback)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginRestCallback pr = new _OrthancPluginRestCallback();
                pr.pathRegularExpression = pathRegularExpression;
                pr.callback = callback;

                int size = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(pr, ptr, true);
                context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_RegisterRestCallback, ptr);
            }
            catch (Exception ex)
            {
                OrthancPluginLogError(ref context, ex.ToString());
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Register a REST callback, without locking.
        /// </summary>
        /// <param name="context">OrthancPluginContext*</param>
        /// <param name="pathRegularExpression">const char*</param>
        /// <param name="callback">OrthancPluginRestCallback</param>
        public static void OrthancPluginRegisterRestCallbackNoLock(ref OrthancPluginContext context, IntPtr pathRegularExpression, Callbacks.OrthancPluginRestCallback callback)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginRestCallback pr = new _OrthancPluginRestCallback();
                pr.pathRegularExpression = pathRegularExpression;
                pr.callback = callback;

                int size = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(pr, ptr, true);
                context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_RegisterRestCallbackNoLock, ptr);
            }
            catch (Exception ex)
            {
                OrthancPluginLogError(ref context, ex.ToString());
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Retrieve the worklist query as a DICOM file.
        /// </summary>
        /// <param name="context">OrthancPluginContext* </param>
        /// <param name="target">OrthancPluginMemoryBuffer*</param>
        /// <param name="query">const OrthancPluginWorklistQuery*</param>
        /// <returns></returns>
        public static OrthancPluginErrorCode OrthancPluginWorklistGetDicomQuery(ref OrthancPluginContext context, IntPtr target, IntPtr query)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginWorklistQueryOperation pr = new _OrthancPluginWorklistQueryOperation();
                pr.query = query;
                pr.dicom = IntPtr.Zero;
                pr.size = 0;
                pr.isMatch = IntPtr.Zero;
                pr.target = target;

                int size = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(pr, ptr, true);

                return context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_WorklistGetDicomQuery, ptr);
            }
            catch (Exception ex)
            {
                OrthancPluginLogError(ref context, ex.ToString());
                return OrthancPluginErrorCode.OrthancPluginErrorCode_InternalError;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Test whether a worklist matches the query.
        /// </summary>
        /// <param name="context">OrthancPluginContext*</param>
        /// <param name="query">const OrthancPluginWorklistQuery*</param>
        /// <param name="dicom">const void*</param>
        /// <param name="size">uint32_t</param>
        /// <returns></returns>
        public static int OrthancPluginWorklistIsMatch(ref OrthancPluginContext context, IntPtr query, IntPtr dicom, uint size)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                int isMatch = 0;
                IntPtr ptrIsMatch = new IntPtr(isMatch);

                _OrthancPluginWorklistQueryOperation pr = new _OrthancPluginWorklistQueryOperation();
                pr.query = query;
                pr.dicom = dicom;
                pr.size = size;
                pr.isMatch = ptrIsMatch;
                pr.target = IntPtr.Zero;

                int ptrSize = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(ptrSize);
                Marshal.StructureToPtr(pr, ptr, true);

                if (context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_WorklistIsMatch, ptr) == OrthancPluginErrorCode.OrthancPluginErrorCode_Success)
                {
                    pr = (_OrthancPluginWorklistQueryOperation)Marshal.PtrToStructure(ptr, typeof(_OrthancPluginWorklistQueryOperation));
                    return pr.isMatch.ToInt32();
                }

                return 0;
            }
            catch (Exception ex)
            {
                OrthancPluginLogError(ref context, ex.ToString());
                return -1;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Mark the set of worklist answers as incomplete.
        /// </summary>
        /// <param name="context">OrthancPluginContext*</param>
        /// <param name="answers">OrthancPluginWorklistAnswers*</param>
        /// <returns></returns>
        public static OrthancPluginErrorCode OrthancPluginWorklistMarkIncomplete(ref OrthancPluginContext context, IntPtr answers)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginWorklistAnswersOperation pr = new _OrthancPluginWorklistAnswersOperation();
                pr.answers = answers;
                pr.query = IntPtr.Zero;
                pr.dicom = IntPtr.Zero;
                pr.size = 0;

                int size = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(pr, ptr, true);

                return context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_WorklistMarkIncomplete, ptr);
            }
            catch (Exception ex)
            {
                OrthancPluginLogError(ref context, ex.ToString());
                return OrthancPluginErrorCode.OrthancPluginErrorCode_InternalError;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Add one answer to some modality worklist request.
        /// </summary>
        /// <param name="context">OrthancPluginContext*</param>
        /// <param name="answers">OrthancPluginWorklistAnswers*</param>
        /// <param name="query">const OrthancPluginWorklistQuery*</param>
        /// <param name="dicom">const void*</param>
        /// <param name="size">uint32_t</param>
        /// <returns></returns>
        public static OrthancPluginErrorCode OrthancPluginWorklistAddAnswer(ref OrthancPluginContext context, IntPtr answers, IntPtr query, IntPtr dicom, uint size)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginWorklistAnswersOperation pr = new _OrthancPluginWorklistAnswersOperation();
                pr.answers = answers;
                pr.query = query;
                pr.dicom = dicom;
                pr.size = size;

                int ptrSize = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(ptrSize);
                Marshal.StructureToPtr(pr, ptr, true);

                return context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_WorklistAddAnswer, ptr);
            }
            catch (Exception ex)
            {
                OrthancPluginLogError(ref context, ex.ToString());
                return OrthancPluginErrorCode.OrthancPluginErrorCode_InternalError;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Register a callback to handle modality worklists requests.
        /// </summary>
        /// <param name="context">OrthancPluginContext*</param>
        /// <param name="callback">OrthancPluginWorklistCallback</param>
        /// <returns></returns>
        public static OrthancPluginErrorCode OrthancPluginRegisterWorklistCallback(ref OrthancPluginContext context, Callbacks.OrthancPluginWorklistCallback callback)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginWorklistCallback pr = new _OrthancPluginWorklistCallback();
                pr.callback = callback;

                int size = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(pr, ptr, true);

                return context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_RegisterWorklistCallback, ptr);
            }
            catch (Exception ex)
            {
                OrthancPluginLogError(ref context, ex.ToString());
                return OrthancPluginErrorCode.OrthancPluginErrorCode_InternalError;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
    }
}
