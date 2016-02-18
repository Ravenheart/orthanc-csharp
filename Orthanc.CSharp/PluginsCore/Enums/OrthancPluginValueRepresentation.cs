using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp.PluginsCore.Enums
{
    /// <summary>
    /// The value representations present in the DICOM standard (version 2013).
    /// </summary>
    public enum OrthancPluginValueRepresentation
    {
        OrthancPluginValueRepresentation_AE = 1,   /*!< Application Entity */
        OrthancPluginValueRepresentation_AS = 2,   /*!< Age String */
        OrthancPluginValueRepresentation_AT = 3,   /*!< Attribute Tag */
        OrthancPluginValueRepresentation_CS = 4,   /*!< Code String */
        OrthancPluginValueRepresentation_DA = 5,   /*!< Date */
        OrthancPluginValueRepresentation_DS = 6,   /*!< Decimal String */
        OrthancPluginValueRepresentation_DT = 7,   /*!< Date Time */
        OrthancPluginValueRepresentation_FD = 8,   /*!< Floating Point Double */
        OrthancPluginValueRepresentation_FL = 9,   /*!< Floating Point Single */
        OrthancPluginValueRepresentation_IS = 10,  /*!< Integer String */
        OrthancPluginValueRepresentation_LO = 11,  /*!< Long String */
        OrthancPluginValueRepresentation_LT = 12,  /*!< Long Text */
        OrthancPluginValueRepresentation_OB = 13,  /*!< Other Byte String */
        OrthancPluginValueRepresentation_OF = 14,  /*!< Other Float String */
        OrthancPluginValueRepresentation_OW = 15,  /*!< Other Word String */
        OrthancPluginValueRepresentation_PN = 16,  /*!< Person Name */
        OrthancPluginValueRepresentation_SH = 17,  /*!< Short String */
        OrthancPluginValueRepresentation_SL = 18,  /*!< Signed Long */
        OrthancPluginValueRepresentation_SQ = 19,  /*!< Sequence of Items */
        OrthancPluginValueRepresentation_SS = 20,  /*!< Signed Short */
        OrthancPluginValueRepresentation_ST = 21,  /*!< Short Text */
        OrthancPluginValueRepresentation_TM = 22,  /*!< Time */
        OrthancPluginValueRepresentation_UI = 23,  /*!< Unique Identifier (UID) */
        OrthancPluginValueRepresentation_UL = 24,  /*!< Unsigned Long */
        OrthancPluginValueRepresentation_UN = 25,  /*!< Unknown */
        OrthancPluginValueRepresentation_US = 26,  /*!< Unsigned Short */
        OrthancPluginValueRepresentation_UT = 27,  /*!< Unlimited Text */

        _OrthancPluginValueRepresentation_INTERNAL = 0x7fffffff
    }
}
