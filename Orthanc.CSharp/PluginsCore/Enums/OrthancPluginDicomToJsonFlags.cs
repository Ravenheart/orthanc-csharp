using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp.PluginsCore.Enums
{
    /// <summary>
    /// Flags to customize a DICOM-to-JSON conversion. By default, binary tags are formatted using Data URI scheme.
    /// </summary>
    [Flags]
    public enum OrthancPluginDicomToJsonFlags
    {
        OrthancPluginDicomToJsonFlags_IncludeBinary = (1 << 0),  /*!< Include the binary tags */
        OrthancPluginDicomToJsonFlags_IncludePrivateTags = (1 << 1),  /*!< Include the private tags */
        OrthancPluginDicomToJsonFlags_IncludeUnknownTags = (1 << 2),  /*!< Include the tags unknown by the dictionary */
        OrthancPluginDicomToJsonFlags_IncludePixelData = (1 << 3),  /*!< Include the pixel data */
        OrthancPluginDicomToJsonFlags_ConvertBinaryToAscii = (1 << 4),  /*!< Output binary tags as-is, dropping non-ASCII */
        OrthancPluginDicomToJsonFlags_ConvertBinaryToNull = (1 << 5),  /*!< Signal binary tags as null values */

        _OrthancPluginDicomToJsonFlags_INTERNAL = 0x7fffffff
    }
}
