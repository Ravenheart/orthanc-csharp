using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp.PluginsCore.Enums
{
    public enum OrthancPluginResourceType
    {
        OrthancPluginResourceType_Patient = 0,     /*!< Patient */
        OrthancPluginResourceType_Study = 1,       /*!< Study */
        OrthancPluginResourceType_Series = 2,      /*!< Series */
        OrthancPluginResourceType_Instance = 3,    /*!< Instance */
        OrthancPluginResourceType_None = 4,        /*!< Unavailable resource type */

        _OrthancPluginResourceType_INTERNAL = 0x7fffffff
    }
}
