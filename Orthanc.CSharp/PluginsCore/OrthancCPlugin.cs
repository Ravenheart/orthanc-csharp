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
        /// Register a callback for received instances.
        /// This function registers a callback function that is called
        /// whenever a new DICOM instance is stored into the Orthanc core.
        /// </summary>
        /// <param name="context">OrthancPluginContext* - The Orthanc plugin context, as received by OrthancPluginInitialize().</param>
        /// <param name="callback">OrthancPluginOnStoredInstanceCallback - The callback function.</param>
        public static void OrthancPluginRegisterOnStoredInstanceCallback(ref OrthancPluginContext context, Orthanc.CSharp.PluginsCore.Callbacks.OrthancPluginOnStoredInstanceCallback callback)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginOnStoredInstanceCallback pr = new _OrthancPluginOnStoredInstanceCallback();
                pr.callback = callback;

                int size = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(pr, ptr, true);

                context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_RegisterOnStoredInstanceCallback, ptr);
            }
            catch (Exception ex)
            {
                Log.Message(ex.ToString());
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

        /// <summary>
        /// Answer to a REST request. This function answers to a REST request with the content of a memory buffer.
        /// </summary>
        /// <param name="context">OrthancPluginContext* - The Orthanc plugin context, as received by OrthancPluginInitialize().</param>
        /// <param name="output">OrthancPluginRestOutput* - The HTTP connection to the client application.</param>
        /// <param name="answer">const char* - Pointer to the memory buffer containing the answer.</param>
        /// <param name="answerSize">uint32_t - Number of bytes of the answer.</param>
        /// <param name="mimeType">const char* - The MIME type of the answer.</param>
        public static void OrthancPluginAnswerBuffer(ref OrthancPluginContext context, IntPtr output, IntPtr answer, uint answerSize, IntPtr mimeType)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginAnswerBuffer pr = new _OrthancPluginAnswerBuffer();
                pr.output = output;
                pr.answer = answer;
                pr.answerSize = answerSize;
                pr.mimeType = mimeType;

                int size = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(pr, ptr, true);

                context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_AnswerBuffer, ptr);
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
        /// Make a GET call to the Orthanc REST API, with custom HTTP headers. 
        /// Make a GET call to the Orthanc REST API with extended parameters. 
        /// The result to the query is stored into a newly allocated memory buffer.
        /// </summary>
        /// <param name="context">OrthancPluginContext* - The Orthanc plugin context, as received by OrthancPluginInitialize().</param>
        /// <param name="target">OrthancPluginMemoryBuffer* - The target memory buffer. It must be freed with OrthancPluginFreeMemoryBuffer().</param>
        /// <param name="uri">const char* - The URI in the built-in Orthanc API.</param>
        /// <param name="headersCount">uint32_t - The number of HTTP headers.</param>
        /// <param name="headersKeys">const char* const* - Array containing the keys of the HTTP headers.</param>
        /// <param name="headersValues">const char* const* - Array containing the values of the HTTP headers.</param>
        /// <param name="afterPlugins">int32_t - If 0, the built-in API of Orthanc is used. If 1, the API is tainted by the plugins.</param>
        /// <returns>0 if success, or the error code if failure.</returns>
        public static OrthancPluginErrorCode OrthancPluginRestApiGet2(ref OrthancPluginContext context, IntPtr target, IntPtr uri, uint headersCount, IntPtr headersKeys, IntPtr headersValues, int afterPlugins)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginRestApiGet2 pr = new _OrthancPluginRestApiGet2();
                pr.target = target;
                pr.uri = uri;
                pr.headersCount = headersCount;
                pr.headersKeys = headersKeys;
                pr.headersValues = headersValues;
                pr.afterPlugins = afterPlugins;

                int size = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(pr, ptr, true);

                return context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_RestApiGet2, ptr);
            }
            catch (Exception ex)
            {
                Log.Message(ex.ToString());
                OrthancPluginLogError(ref context, ex.ToString());
                return OrthancPluginErrorCode.OrthancPluginErrorCode_InternalError;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Format a DICOM instance as a JSON string.
        /// This function formats a DICOM instance that is stored in Orthanc,
        /// and outputs a JSON string representing the tags of this DICOM instance.
        /// </summary>
        /// <param name="context">OrthancPluginContext* - The Orthanc plugin context, as received by OrthancPluginInitialize().</param>
        /// <param name="instanceId">const char* - The Orthanc identifier of the instance.</param>
        /// <param name="format">OrthancPluginDicomToJsonFormat - The output format.</param>
        /// <param name="flags">OrthancPluginDicomToJsonFlags - Flags governing the output.</param>
        /// <param name="maxStringLength">uint32_t - The maximum length of a field. Too long fields will be output as "null". The 0 value means no maximum length.</param>
        /// <returns>char* - The NULL value if the case of an error, or the JSON string. This string must be freed by OrthancPluginFreeString().</returns>
        public static IntPtr OrthancPluginDicomInstanceToJson(ref OrthancPluginContext context, IntPtr instanceId, OrthancPluginDicomToJsonFormat format, OrthancPluginDicomToJsonFlags flags, uint maxStringLength)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginDicomToJson pr = new _OrthancPluginDicomToJson();
                pr.instanceId = instanceId;
                pr.format = format;
                pr.flags = flags;
                pr.maxStringLength = maxStringLength;

                int size = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(pr, ptr, true);

                if (context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_DicomInstanceToJson, ptr) != OrthancPluginErrorCode.OrthancPluginErrorCode_Success)
                {
                    return IntPtr.Zero;
                }
                else
                {
                    pr = (_OrthancPluginDicomToJson)Marshal.PtrToStructure(ptr, typeof(_OrthancPluginDicomToJson));
                    return pr.result;
                }
            }
            catch (Exception ex)
            {
                Log.Message(ex.ToString());
                OrthancPluginLogError(ref context, ex.ToString());
                return IntPtr.Zero;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Format a DICOM memory buffer as a JSON string.
        /// This function takes as input a memory buffer containing a DICOM file,
        /// and outputs a JSON string representing the tags of this DICOM file.
        /// </summary>
        /// <param name="context">OrthancPluginContext* - The Orthanc plugin context, as received by OrthancPluginInitialize().</param>
        /// <param name="buffer">const void* - The memory buffer containing the DICOM file.</param>
        /// <param name="size">uint32_t - The size of the memory buffer.</param>
        /// <param name="format">OrthancPluginDicomToJsonFormat - The output format.</param>
        /// <param name="flags">OrthancPluginDicomToJsonFlags - Flags governing the output.</param>
        /// <param name="maxStringLength">uint32_t - The maximum length of a field. Too long fields will be output as "null". The 0 value means no maximum length.</param>
        /// <returns>char* - The NULL value if the case of an error, or the JSON string. This string must be freed by OrthancPluginFreeString().</returns>
        public static IntPtr OrthancPluginDicomBufferToJson(ref OrthancPluginContext context, IntPtr buffer, uint size, OrthancPluginDicomToJsonFormat format, OrthancPluginDicomToJsonFlags flags, uint maxStringLength)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginDicomToJson pr = new _OrthancPluginDicomToJson();
                pr.buffer = buffer;
                pr.size = size;
                pr.format = format;
                pr.flags = flags;
                pr.maxStringLength = maxStringLength;

                int ptrSize = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(ptrSize);
                Marshal.StructureToPtr(pr, ptr, true);

                if (context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_DicomBufferToJson, ptr) != OrthancPluginErrorCode.OrthancPluginErrorCode_Success)
                {
                    return IntPtr.Zero;
                }
                else
                {
                    pr = (_OrthancPluginDicomToJson)Marshal.PtrToStructure(ptr, typeof(_OrthancPluginDicomToJson));
                    return pr.result;
                }
            }
            catch (Exception ex)
            {
                Log.Message(ex.ToString());
                OrthancPluginLogError(ref context, ex.ToString());
                return IntPtr.Zero;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Reconstruct the main DICOM tags.
        /// This function requests the Orthanc core to reconstruct the main DICOM tags of all the resources of the given type.
        /// This function can only be used as a part of the upgrade of a custom database back-end.
        /// (cf. OrthancPlugins::IDatabaseBackend::UpgradeDatabase).
        /// A database transaction will be automatically setup.
        /// </summary>
        /// <param name="context">OrthancPluginContext* - The Orthanc plugin context, as received by OrthancPluginInitialize().</param>
        /// <param name="storageArea">OrthancPluginStorageArea* - The storage area.</param>
        /// <param name="level">OrthancPluginResourceType - The type of the resources of interest.</param>
        /// <returns>0 if success, other value if error.</returns>
        public static OrthancPluginErrorCode OrthancPluginReconstructMainDicomTags(ref OrthancPluginContext context, IntPtr storageArea, OrthancPluginResourceType level)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginReconstructMainDicomTags pr = new _OrthancPluginReconstructMainDicomTags();
                pr.level = level;
                pr.storageArea = storageArea;

                int size = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(pr, ptr, true);

                return context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_ReconstructMainDicomTags, ptr);
            }
            catch (Exception ex)
            {
                Log.Message(ex.ToString());
                OrthancPluginLogError(ref context, ex.ToString());
                return OrthancPluginErrorCode.OrthancPluginErrorCode_InternalError;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Register a new tag into the DICOM dictionary.
        /// This function declares a new tag in the dictionary of DICOM tags
        /// that are known to Orthanc. This function should be used in the
        /// OrthancPluginInitialize() callback.
        /// </summary>
        /// <param name="context">OrthancPluginContext* - The Orthanc plugin context, as received by OrthancPluginInitialize().</param>
        /// <param name="group">uint16_t - The group of the tag.</param>
        /// <param name="element">uint16_t - The element of the tag.</param>
        /// <param name="vr">OrthancPluginValueRepresentation - The value representation of the tag.</param>
        /// <param name="name">const char* - The nickname of the tag.</param>
        /// <param name="minMultiplicity">uint32_t - The minimum multiplicity of the tag (must be above 0).</param>
        /// <param name="maxMultiplicity">uint32_t - The maximum multiplicity of the tag. A value of 0 means an arbitrary multiplicity ("<tt>n</tt>").</param>
        /// <returns>0 if success, other value if error.</returns>
        public static OrthancPluginErrorCode OrthancPluginRegisterDictionaryTag(ref OrthancPluginContext context, UInt16 group, UInt16 element, OrthancPluginValueRepresentation vr, IntPtr name, UInt32 minMultiplicity, UInt32 maxMultiplicity)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginRegisterDictionaryTag pr = new _OrthancPluginRegisterDictionaryTag();
                pr.group = group;
                pr.element = element;
                pr.vr = vr;
                pr.name = name;
                pr.minMultiplicity = minMultiplicity;
                pr.maxMultiplicity = maxMultiplicity;

                int size = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(pr, ptr, true);

                return context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_RegisterDictionaryTag, ptr);
            }
            catch (Exception ex)
            {
                Log.Message(ex.ToString());
                OrthancPluginLogError(ref context, ex.ToString());
                return OrthancPluginErrorCode.OrthancPluginErrorCode_InternalError;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Declare a custom error code for this plugin.
        /// This function declares a custom error code that can be generated
        /// by this plugin. This declaration is used to enrich the body of
        /// the HTTP answer in the case of an error, and to set the proper HTTP status code.
        /// </summary>
        /// <param name="context">OrthancPluginContext* - The Orthanc plugin context, as received by OrthancPluginInitialize().</param>
        /// <param name="code">int32_t - The error code that is internal to this plugin.</param>
        /// <param name="httpStatus">uint16_t - The HTTP status corresponding to this error.</param>
        /// <param name="message">const char* - The description of the error.</param>
        /// <returns>The error code that has been assigned inside the Orthanc core.</returns>
        public static OrthancPluginErrorCode OrthancPluginRegisterErrorCode(ref OrthancPluginContext context, Int32 code, UInt16 httpStatus, IntPtr message)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginRegisterErrorCode pr = new _OrthancPluginRegisterErrorCode();
                pr.code = code;
                pr.httpStatus = httpStatus;
                pr.message = message;

                int size = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(pr, ptr, true);

                if (context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_RegisterErrorCode, ptr) == OrthancPluginErrorCode.OrthancPluginErrorCode_Success)
                {
                    pr = (_OrthancPluginRegisterErrorCode)Marshal.PtrToStructure(ptr, typeof(_OrthancPluginRegisterErrorCode));
                    Int32 newCode = Marshal.ReadInt32(pr.target);
                    return (OrthancPluginErrorCode)newCode;
                }
                else
                {
                    return OrthancPluginErrorCode.OrthancPluginErrorCode_Plugin;
                }
            }
            catch (Exception ex)
            {
                Log.Message(ex.ToString());
                OrthancPluginLogError(ref context, ex.ToString());
                return OrthancPluginErrorCode.OrthancPluginErrorCode_Plugin;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Remove a file from the storage area.
        /// This function removes a given file from the storage area that is currently used by Orthanc.
        /// </summary>
        /// <param name="context">OrthancPluginContext* - The Orthanc plugin context, as received by OrthancPluginInitialize().</param>
        /// <param name="storageArea">OrthancPluginStorageArea* - The storage area.</param>
        /// <param name="uuid">const char* - The identifier of the file to be removed.</param>
        /// <param name="type">OrthancPluginContentType - The type of the file content.</param>
        /// <returns>0 if success, other value if error.</returns>
        public static OrthancPluginErrorCode OrthancPluginStorageAreaRemove(ref OrthancPluginContext context, IntPtr storageArea, IntPtr uuid, OrthancPluginContentType type)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginStorageAreaRemove pr = new _OrthancPluginStorageAreaRemove();
                pr.storageArea = storageArea;
                pr.uuid = uuid;
                pr.type = type;

                int size = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(pr, ptr, true);

                return context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_StorageAreaRemove, ptr);
            }
            catch (Exception ex)
            {
                Log.Message(ex.ToString());
                OrthancPluginLogError(ref context, ex.ToString());
                return OrthancPluginErrorCode.OrthancPluginErrorCode_InternalError;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Read a file from the storage area.
        /// This function reads the content of a given file from the storage area that is currently used by Orthanc.
        /// </summary>
        /// <param name="context">The Orthanc plugin context, as received by OrthancPluginInitialize().</param>
        /// <param name="target">The target memory buffer. It must be freed with OrthancPluginFreeMemoryBuffer().</param>
        /// <param name="storageArea">The storage area.</param>
        /// <param name="uuid">The identifier of the file to be read.</param>
        /// <param name="type">The type of the file content.</param>
        /// <returns>0 if success, other value if error.</returns>
        public static OrthancPluginErrorCode OrthancPluginStorageAreaRead(ref OrthancPluginContext context, IntPtr target, IntPtr storageArea, IntPtr uuid, OrthancPluginContentType type)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                _OrthancPluginStorageAreaRead pr = new _OrthancPluginStorageAreaRead();
                pr.target = target;
                pr.storageArea = storageArea;
                pr.uuid = uuid;
                pr.type = type;

                int size = Marshal.SizeOf(pr);
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(pr, ptr, true);

                return context.InvokeService(ref context, _OrthancPluginService._OrthancPluginService_StorageAreaRead, ptr);
            }
            catch (Exception ex)
            {
                Log.Message(ex.ToString());
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