using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace PDFTemplate
{
    /// <summary>
    /// Template field
    /// </summary>
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
        private int _nSize;
        private string _sFormat;
        private bool _bPadding = false;
        private bool _bEllipsis = true;
        private bool _bFilter0 = false;
        private TemplateFieldExpansion _tfeExpansion = TemplateFieldExpansion.None;
        private char _cPaddingChar = '_';
        private char _cSplitChar = '|';
        private SplitType _stSplitPolicy = SplitType.BySize;

        #endregion

        #region Properties

        /// <summary>
        /// Type of field
        /// </summary>
        [XmlAttribute("type")]
        public TemplateFieldType Type
        {
            get { return _tftType; }
            set
            {
                if (_tftType != value)
                    _tftType = value;
            }
        }

        /// <summary>
        /// Field id
        /// </summary>
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

        /// <summary>
        /// On (checked) value of checkbox
        /// </summary>
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

        /// <summary>
        /// Off (unchecked) value of checkbox
        /// </summary>
        [XmlAttribute("off_value")]
        public string OffValue
        {
            get { return _sOffValue; }
            set
            {
                if (_sOffValue != value)
                    _sOffValue = value;
            }
        }

        /// <summary>
        /// Size of text values (number of chars)
        /// </summary>
        [XmlAttribute("size")]
        public int Size
        {
            get { return _nSize; }
            set
            {
                if (_nSize != value)
                    _nSize = value;
            }
        }

        /// <summary>
        /// Format for text values
        /// </summary>
        [XmlAttribute("format")]
        public string Format
        {
            get { return _sFormat; }
            set
            {
                if (_sFormat != value)
                    _sFormat = value;
            }
        }

        /// <summary>
        /// Padding flag.
        /// Default value is false.
        /// </summary>
        [XmlAttribute("padding")]
        public bool Padding
        {
            get { return _bPadding; }
            set
            {
                if (_bPadding != value)
                    _bPadding = value;
            }
        }

        /// <summary>
        /// Ellipsis flag.
        /// Default value is true.
        /// </summary>
        [XmlAttribute("ellipsis")]
        public bool Ellipsis
        {
            get { return _bEllipsis; }
            set
            {
                if (_bEllipsis != value)
                    _bEllipsis = value;
            }
        }

        /// <summary>
        /// Filter '0' values flag.
        /// Default value is false.
        /// </summary>
        [XmlAttribute("filter0")]
        public bool Filter0
        {
            get { return _bFilter0; }
            set
            {
                if (_bFilter0 != value)
                    _bFilter0 = value;
            }
        }

        /// <summary>
        /// Padding char.
        /// Default padding char is '_'.
        /// </summary>
        [XmlAttribute("padding_char")]
        public char PaddingChar
        {
            get { return _cPaddingChar; }
            set
            {
                if (_cPaddingChar != value)
                    _cPaddingChar = value;
            }
        }

        /// <summary>
        /// Split char.
        /// Default split char is '|'.
        /// </summary>
        [XmlAttribute("split_char")]
        public char SplitChar
        {
            get { return _cSplitChar; }
            set
            {
                if (_cSplitChar != value)
                    _cSplitChar = value;
            }
        }

        /// <summary>
        /// Fields expansion.
        /// </summary>
        [XmlAttribute("expansion")]
        public TemplateFieldExpansion Expansion
        {
            get { return _tfeExpansion; }
            set
            {
                if (_tfeExpansion != value)
                    _tfeExpansion = value;
            }
        }

        /// <summary>
        /// Field split.
        /// </summary>
        [XmlAttribute("split_policy")]
        public SplitType SplitPolicy
        {
            get { return _stSplitPolicy; }
            set
            {
                if (_stSplitPolicy != value)
                    _stSplitPolicy = value;
            }
        }

        /// <summary>
        /// Field value
        /// </summary>
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

        #region Public methods

        /// <summary>
        /// Create a text field.
        /// </summary>
        /// <param name="name_value">Name/id of field</param>
        /// <param name="field_value">Value of field</param>
        /// <param name="format_value">Format of field</param>
        /// <param name="padding_value">Padding flag</param>
        /// <param name="size_value">Size of field</param>
        /// <returns>Text field</returns>
        public static TemplateField CreateText(string name_value, string field_value, string format_value, bool padding_value, int size_value)
        {
            TemplateField _tfNewField = new TemplateField(name_value, TemplateFieldType.Text, field_value);

            _tfNewField._sFormat = format_value;
            _tfNewField._bPadding = padding_value;
            _tfNewField._nSize = size_value;
            _tfNewField._sOnValue = "";
            _tfNewField._sOffValue = "";

            return _tfNewField;
        }

        /// <summary>
        /// Create a checkbox field.
        /// </summary>
        /// <param name="name_value">Name/id of field</param>
        /// <param name="field_value">Value of field</param>
        /// <param name="on_value">On value</param>
        /// <param name="off_value">Off value</param>
        /// <returns>CheckBox field</returns>
        public static TemplateField CreateCheckBox(string name_value, string field_value, string on_value, string off_value)
        {
            TemplateField _tfNewField = new TemplateField(name_value, TemplateFieldType.Checkbox, field_value);

            _tfNewField.Format = "";
            _tfNewField._bPadding = false;
            _tfNewField._nSize = 1;
            _tfNewField._sOnValue = on_value;
            _tfNewField._sOffValue = off_value;

            return _tfNewField;
        }

        /// <summary>
        /// Set field Value from a list of parameters using Format property as string format descriptor (as per String.Format()).
        /// </summary>
        /// <seealso cref="Format"/>
        /// <seealso cref="String.Format()"/>
        /// <param name="parameters">Parameters as for String.Format()</param>
        public void Set(params object[] parameters)
        {
            if (parameters.Length == 1)
            {
                if (parameters[0] is string)
                {
                    this.Set((string)parameters[0]);
                    return;
                }
                else if (parameters[0] is bool)
                {
                    this.Set((bool)parameters[0]);
                    return;
                }
                else if (parameters[0] is int)
                {
                    this.Set((int)parameters[0]);
                    return;
                }
                else if (parameters[0] is double)
                {
                    this.Set((double)parameters[0]);
                    return;
                }
                else if (parameters[0] is decimal)
                {
                    this.Set((decimal)parameters[0]);
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(_sFormat))
                _sValue = String.Format(_sFormat, parameters);
            else
                throw new Exception("Format not set");
        }

        /// <summary>
        /// Set field from boolean value.
        /// If the field is checkbox the value true will match the checked/On state.
        /// </summary>
        /// <param name="value">Boolean value</param>
        public void Set(bool value)
        {
            if (_tftType == TemplateFieldType.Checkbox)
                _sValue = (value ? _sOnValue : _sOffValue);
            else
                _sValue = value.ToString();
        }

        /// <summary>
        /// Set field from int value.
        /// </summary>
        /// <param name="value">Integer value</param>
        public void Set(int value)
        {
            if (_bFilter0 && (value == 0))
                return;

            if (!string.IsNullOrWhiteSpace(_sFormat))
                _sValue = String.Format(this._sFormat, value);
            else
                _sValue = value.ToString();
        }

        /// <summary>
        /// Set field from double value.
        /// </summary>
        /// <param name="value">Double value</param>
        public void Set(double value)
        {
            if (_bFilter0 && (value == 0f))
                return;

            if (!string.IsNullOrWhiteSpace(_sFormat))
                _sValue = String.Format(this._sFormat, value);
            else
                _sValue = value.ToString();
        }

        /// <summary>
        /// Set field from decimal value.
        /// </summary>
        /// <param name="value">Decimal value</param>
        public void Set(decimal value)
        {
            if (_bFilter0 && (value == 0))
                return;

            if (!string.IsNullOrWhiteSpace(_sFormat))
                _sValue = String.Format(this._sFormat, value);
            else
                _sValue = value.ToString();
        }

        /// <summary>
        /// Set field from string value.
        /// </summary>
        /// <param name="value">String value</param>
        public void Set(string value)
        {
            string result;

            if (!string.IsNullOrWhiteSpace(this._sFormat))
                result = String.Format(this._sFormat, value);
            else
                result = value;

            if (result.Length > _nSize)
            {
                result = result.Substring(0, _nSize);
                
                if (_bEllipsis)
                    result += "...";
            }

            if (_bPadding && (result.Length < _nSize))
                result = result.PadRight(_nSize,_cPaddingChar);

            if (_sValue != result)
                _sValue = result;
        }

        /// <summary>
        /// Set field from DateTime value.
        /// </summary>
        /// <param name="value">DateTime value</param>
        public void Set(DateTime value)
        {
            if (!string.IsNullOrWhiteSpace(_sFormat))
                _sValue = String.Format(this._sFormat, value);
            else
                _sValue = value.ToString("dd/MM/yyyy");
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Base constructor.
        /// Create a Text field, name is set to 'field_name'.
        /// </summary>
        public TemplateField()
        {
            _tftType = TemplateFieldType.Text;
            _sName = PDFTemplate.Properties.Resources.DefFieldName;
            _sValue = "";
        }

        /// <summary>
        /// Constructor name based.
        /// Create a text field with provided name.
        /// </summary>
        /// <param name="name_value">Name/id of field</param>
        public TemplateField(string name_value) 
            : this()
        {
            _sName = name_value;
        }

        /// <summary>
        /// Constructor type based.
        /// Create a field of provided type and name.
        /// </summary>
        /// <param name="name_value">Name/id of field</param>
        /// <param name="type_value">Type of field</param>
        public TemplateField(string name_value, TemplateFieldType type_value) 
            : this(name_value)
        {
            _tftType = type_value;
        }

        /// <summary>
        /// Constructor value based.
        /// Create a field of provided type, name and value.
        /// </summary>
        /// <remarks>
        /// Value of checkbox field have to match OnValue or OffValue property.
        /// </remarks>
        /// <seealso cref="OffValue"/>
        /// <seealso cref="OnValue"/>
        /// <param name="name_value">Name/id of field</param>
        /// <param name="type_value">Type of field</param>
        /// <param name="field_value">Value of field</param>
        public TemplateField(string name_value, TemplateFieldType type_value, string field_value) 
            : this(name_value, type_value)
        {
            _sValue = field_value;
        }

        /// <summary>
        /// Constructor AcroField based.
        /// Create a field 'image' of the matching field in the PDF form.
        /// </summary>
        /// <param name="fields">Field hashset of PDF form</param>
        /// <param name="field">Field reference</param>
        public TemplateField(AcroFields fields, KeyValuePair<String, iTextSharp.text.pdf.AcroFields.Item> field)
        {
            int _nType = fields.GetFieldType(field.Key);
            TemplateFieldType _ftType = (TemplateFieldType)(_nType);
            this.Name = field.Key;
            this.Type = _ftType;

            if (_ftType == TemplateFieldType.Checkbox)
            {
                string[] _rgsStates = fields.GetAppearanceStates(field.Key);
                this.OnValue = _rgsStates[1];
                this.OffValue = _rgsStates[0];
            }
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="field">Source field reference</param>
        public TemplateField(TemplateField field)
        {
            this._tftType = field._tftType;
            this._sName = field._sName;
            this._sValue = field._sValue;
            this._sOffValue = field._sOffValue;
            this._sOnValue = field._sOnValue;
            this._nSize = field._nSize;
            this._sFormat = field._sFormat;
            this._bPadding = field._bPadding;
            this._bEllipsis = field._bEllipsis;
            this._bFilter0 = field._bFilter0;
            this._tfeExpansion = field._tfeExpansion;
            this._cPaddingChar = field._cPaddingChar;
            this._stSplitPolicy = field._stSplitPolicy;
            this._cSplitChar = field._cSplitChar;
        }

        #endregion
    }
}
