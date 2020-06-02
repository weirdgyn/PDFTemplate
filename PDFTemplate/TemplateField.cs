using System;
using System.Xml;
using System.Xml.Serialization;

namespace PDFTemplate
{
    [Serializable]
    [XmlRoot("field")]
    public class TemplateField
    {
        #region Private data

        private TemplateFieldType _tftType;
        private string _sName;
        private string _sValue;
        private string _sOffValue;
        private string _sOnValue;
        
        #endregion

        #region Properties

        [XmlAttribute("type")]
        public TemplateFieldType Type
        {
            get { return _tftType; }
            set {
                if (_tftType != value)
                    _tftType = value;
            }
        }

        [XmlAttribute("id")]
        public string Name
        {
            get { return _sName; }
            set
            {
                if (_sName != value)
                    _sName = value;
            }
        }

        [XmlAttribute("on_value")]
        public string OnValue
        {
            get { return _sOnValue; }
            set
            {
                if (_sOnValue != value)
                    _sOnValue = value;
            }
        }

        [XmlAttribute("OffValue")]
        public string OffValue
        {
            get { return _sOffValue; }
            set
            {
                if (_sOffValue != value)
                    _sOffValue = value;
            }
        }

        [XmlText]
        public string Value
        {
            get { return _sValue; }
            set
            {
                if (_sValue != value)
                {
                    if (_tftType == TemplateFieldType.Checkbox)
                        if ((value != _sOffValue) && (value != _sOnValue))
                            return;
                    
                    _sValue = value;
                }
            }
        }

        #endregion

        #region Constructors

        public TemplateField()
        {
            _tftType = TemplateFieldType.Text;
            _sName = "field_name";
            _sValue = "";
        }

        public TemplateField(string name_value)
        {
            _tftType = TemplateFieldType.Text;
            _sName = name_value;
            _sValue = "";
        }

        public TemplateField(string name_value,TemplateFieldType type_value)
        {
            _tftType = type_value;
            _sName = name_value;
            _sValue = "";
        }

        public TemplateField(string name_value, TemplateFieldType type_value,string field_value)
        {
            _tftType = type_value;
            _sName = name_value;
            _sValue = field_value;
        }

        #endregion
    }
}
