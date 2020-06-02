using System;
using System.Xml.Serialization;

namespace PDFTemplate
{
    /// <summary>
    /// Template field type
    /// </summary>
    [Serializable]
    [XmlRoot("type")]
    public enum TemplateFieldType
    {
        /// <summary>
        /// Text (match type 4 in acrobat forms)
        /// </summary>
        [XmlEnum("Text")]
        Text = 4,
        /// <summary>
        /// Checkbox (match type 2 in acrobat forms)
        /// </summary>
        [XmlEnum("Checkbox")]
        Checkbox = 2
    }
}
