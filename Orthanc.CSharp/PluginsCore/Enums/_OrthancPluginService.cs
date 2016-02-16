using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp.PluginsCore.Enums
{
    public enum _OrthancPluginService
    {
        /* Generic services */
        _OrthancPluginService_LogInfo = 1,
        _OrthancPluginService_LogWarning = 2,
        _OrthancPluginService_LogError = 3,
        _OrthancPluginService_GetOrthancPath = 4,
        _OrthancPluginService_GetOrthancDirectory = 5,
        _OrthancPluginService_GetConfigurationPath = 6,
        _OrthancPluginService_SetPluginProperty = 7,
        _OrthancPluginService_GetGlobalProperty = 8,
        _OrthancPluginService_SetGlobalProperty = 9,
        _OrthancPluginService_GetCommandLineArgumentsCount = 10,
        _OrthancPluginService_GetCommandLineArgument = 11,
        _OrthancPluginService_GetExpectedDatabaseVersion = 12,
        _OrthancPluginService_GetConfiguration = 13,
        _OrthancPluginService_BufferCompression = 14,
        _OrthancPluginService_ReadFile = 15,
        _OrthancPluginService_WriteFile = 16,
        _OrthancPluginService_GetErrorDescription = 17,
        _OrthancPluginService_CallHttpClient = 18,
        _OrthancPluginService_RegisterErrorCode = 19,
        _OrthancPluginService_RegisterDictionaryTag = 20,
        _OrthancPluginService_DicomBufferToJson = 21,
        _OrthancPluginService_DicomInstanceToJson = 22,
        _OrthancPluginService_CreateDicom = 23,
        _OrthancPluginService_ComputeMd5 = 24,
        _OrthancPluginService_ComputeSha1 = 25,
        _OrthancPluginService_LookupDictionary = 26,

        /* Registration of callbacks */
        _OrthancPluginService_RegisterRestCallback = 1000,
        _OrthancPluginService_RegisterOnStoredInstanceCallback = 1001,
        _OrthancPluginService_RegisterStorageArea = 1002,
        _OrthancPluginService_RegisterOnChangeCallback = 1003,
        _OrthancPluginService_RegisterRestCallbackNoLock = 1004,
        _OrthancPluginService_RegisterWorklistCallback = 1005,
        _OrthancPluginService_RegisterDecodeImageCallback = 1006,

        /* Sending answers to REST calls */
        _OrthancPluginService_AnswerBuffer = 2000,
        _OrthancPluginService_CompressAndAnswerPngImage = 2001,  /* Unused as of Orthanc 0.9.4 */
        _OrthancPluginService_Redirect = 2002,
        _OrthancPluginService_SendHttpStatusCode = 2003,
        _OrthancPluginService_SendUnauthorized = 2004,
        _OrthancPluginService_SendMethodNotAllowed = 2005,
        _OrthancPluginService_SetCookie = 2006,
        _OrthancPluginService_SetHttpHeader = 2007,
        _OrthancPluginService_StartMultipartAnswer = 2008,
        _OrthancPluginService_SendMultipartItem = 2009,
        _OrthancPluginService_SendHttpStatus = 2010,
        _OrthancPluginService_CompressAndAnswerImage = 2011,
        _OrthancPluginService_SendMultipartItem2 = 2012,

        /* Access to the Orthanc database and API */
        _OrthancPluginService_GetDicomForInstance = 3000,
        _OrthancPluginService_RestApiGet = 3001,
        _OrthancPluginService_RestApiPost = 3002,
        _OrthancPluginService_RestApiDelete = 3003,
        _OrthancPluginService_RestApiPut = 3004,
        _OrthancPluginService_LookupPatient = 3005,
        _OrthancPluginService_LookupStudy = 3006,
        _OrthancPluginService_LookupSeries = 3007,
        _OrthancPluginService_LookupInstance = 3008,
        _OrthancPluginService_LookupStudyWithAccessionNumber = 3009,
        _OrthancPluginService_RestApiGetAfterPlugins = 3010,
        _OrthancPluginService_RestApiPostAfterPlugins = 3011,
        _OrthancPluginService_RestApiDeleteAfterPlugins = 3012,
        _OrthancPluginService_RestApiPutAfterPlugins = 3013,
        _OrthancPluginService_ReconstructMainDicomTags = 3014,
        _OrthancPluginService_RestApiGet2 = 3015,

        /* Access to DICOM instances */
        _OrthancPluginService_GetInstanceRemoteAet = 4000,
        _OrthancPluginService_GetInstanceSize = 4001,
        _OrthancPluginService_GetInstanceData = 4002,
        _OrthancPluginService_GetInstanceJson = 4003,
        _OrthancPluginService_GetInstanceSimplifiedJson = 4004,
        _OrthancPluginService_HasInstanceMetadata = 4005,
        _OrthancPluginService_GetInstanceMetadata = 4006,
        _OrthancPluginService_GetInstanceOrigin = 4007,

        /* Services for plugins implementing a database back-end */
        _OrthancPluginService_RegisterDatabaseBackend = 5000,
        _OrthancPluginService_DatabaseAnswer = 5001,
        _OrthancPluginService_RegisterDatabaseBackendV2 = 5002,
        _OrthancPluginService_StorageAreaCreate = 5003,
        _OrthancPluginService_StorageAreaRead = 5004,
        _OrthancPluginService_StorageAreaRemove = 5005,

        /* Primitives for handling images */
        _OrthancPluginService_GetImagePixelFormat = 6000,
        _OrthancPluginService_GetImageWidth = 6001,
        _OrthancPluginService_GetImageHeight = 6002,
        _OrthancPluginService_GetImagePitch = 6003,
        _OrthancPluginService_GetImageBuffer = 6004,
        _OrthancPluginService_UncompressImage = 6005,
        _OrthancPluginService_FreeImage = 6006,
        _OrthancPluginService_CompressImage = 6007,
        _OrthancPluginService_ConvertPixelFormat = 6008,
        _OrthancPluginService_GetFontsCount = 6009,
        _OrthancPluginService_GetFontInfo = 6010,
        _OrthancPluginService_DrawText = 6011,
        _OrthancPluginService_CreateImage = 6012,
        _OrthancPluginService_CreateImageAccessor = 6013,
        _OrthancPluginService_DecodeDicomImage = 6014,

        /* Primitives for handling worklists */
        _OrthancPluginService_WorklistAddAnswer = 7000,
        _OrthancPluginService_WorklistMarkIncomplete = 7001,
        _OrthancPluginService_WorklistIsMatch = 7002,
        _OrthancPluginService_WorklistGetDicomQuery = 7003,

        _OrthancPluginService_INTERNAL = 0x7fffffff
    }
}
