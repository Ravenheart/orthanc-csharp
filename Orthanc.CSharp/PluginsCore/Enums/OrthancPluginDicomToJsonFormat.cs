using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp.PluginsCore.Enums
{
    /// <summary>
    /// The possible output formats for a DICOM-to-JSON conversion.
    /// </summary>
    public enum OrthancPluginDicomToJsonFormat
    {
        OrthancPluginDicomToJsonFormat_Full = 1,    /*!< Full output, with most details */
        OrthancPluginDicomToJsonFormat_Short = 2,   /*!< Tags output as hexadecimal numbers */
        OrthancPluginDicomToJsonFormat_Human = 3,   /*!< Human-readable JSON */

        _OrthancPluginDicomToJsonFormat_INTERNAL = 0x7fffffff
    }
}
