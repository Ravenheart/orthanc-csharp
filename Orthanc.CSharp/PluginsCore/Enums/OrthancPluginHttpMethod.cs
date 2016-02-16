using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp.PluginsCore.Enums
{
    public enum OrthancPluginHttpMethod
    {
        OrthancPluginHttpMethod_Get = 1,    /*!< GET request */
        OrthancPluginHttpMethod_Post = 2,   /*!< POST request */
        OrthancPluginHttpMethod_Put = 3,    /*!< PUT request */
        OrthancPluginHttpMethod_Delete = 4, /*!< DELETE request */

        _OrthancPluginHttpMethod_INTERNAL = 0x7fffffff
    }
}
