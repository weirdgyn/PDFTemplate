using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PDFTemplate
{
    /// <summary>
    /// Split type
    /// </summary>
    [Serializable]
    [XmlRoot("split_type")]
    public enum SplitType
    {
        /// <summary>
        /// By size.
        /// </summary>
        [XmlEnum("BySize")]
        BySize,
        /// <summary>
        /// By char.
        /// </summary>
        [XmlEnum("ByChar")]
        ByChar,
        /// <summary>
        /// None.
        /// </summary>
        [XmlEnum("None")]
        None
    }
}
