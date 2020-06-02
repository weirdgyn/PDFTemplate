using System;
using System.Xml.Serialization;

namespace PDFTemplate
{
    /// <summary>
    /// Template field expansion enum.
    /// </summary>
    [Serializable]
    [XmlRoot("expansion")]
    public enum TemplateFieldExpansion
    {
        /// <summary>
        /// Vertical expansion
        /// </summary>
        [XmlEnum("Vertical")]
        Vertical,
        /// <summary>
        /// No expansion allowed
        /// </summary>
        [XmlEnum("None")]
        None
    }
}
