using System;
using System.Xml.Serialization;

namespace PDFTemplate
{
    [Serializable]
    [XmlRoot("type")]
    public enum TemplateFieldType
    {
        [XmlEnum("Text")]
        Text = 4,
        [XmlEnum("Checkbox")]
        Checkbox = 2
    }
}
