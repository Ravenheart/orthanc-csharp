using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp.PluginsCore.Enums
{
    /// <summary>
    /// The content types that are supported by Orthanc plugins.
    /// </summary>
    public enum OrthancPluginContentType
    {
        OrthancPluginContentType_Unknown = 0,      /*!< Unknown content type */
        OrthancPluginContentType_Dicom = 1,        /*!< DICOM */
        OrthancPluginContentType_DicomAsJson = 2,  /*!< JSON summary of a DICOM file */

        _OrthancPluginContentType_INTERNAL = 0x7fffffff
    }
}
