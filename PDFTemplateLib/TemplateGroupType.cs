using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PDFTemplate
{
    /// <summary>
    /// Template field type
    /// </summary>
    [Serializable]
    [XmlRoot("group_type")]
    public enum TemplateGroupType
    {        
        /// <summary>
        /// First page only group.
        /// Will be shown only only on 'first page'.
        /// </summary>
        [XmlEnum("FirstPageOnly")]
        FirstPageOnly,
        /// <summary>
        /// Last page only group.
        /// Will be shown only only on 'last page'.
        /// </summary>
        [XmlEnum("LastPageOnly")]
        LastPageOnly,
        /// <summary>
        /// Persistent group.
        /// Will be shown on each page.
        /// </summary>
        [XmlEnum("Persistent")]
        Persistent,
        /// <summary>
        /// Odd page group.
        /// Will be shown on odd pages.
        /// </summary>
        [XmlEnum("OddPageOnly")]
        OddPageOnly,
        /// <summary>
        /// Even page group.
        /// Will be shown on even pages.
        /// </summary>
        [XmlEnum("EvenPageOnly")]
        EvenPageOnly
    }
}
