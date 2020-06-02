using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace PDFTemplate
{
    /// <summary>
    /// Template fields group.
    /// </summary>
    [Serializable]
    [XmlRoot("group")]
    public class TemplateFieldsGroup
    {
        #region Private data
        
        private List<string> _lstFieldIds;
        private string _sName;
        private int _nCurrentIndex = 0;
        private int _nLowIndex = 0;
        private int _nHighIndex = 0;
        private TemplateGroupType _tgtType = TemplateGroupType.Persistent;
        
        #endregion

        #region Public properties

        /// <summary>
        /// Field ids composing the group
        /// </summary>
        [XmlArray("fields_ids"), XmlArrayItem(typeof(string), ElementName = "field_name")]
        public List<string> FieldIds 
        {
            get { return _lstFieldIds; }
            set
            {
                if (_lstFieldIds != value)
                    _lstFieldIds = value;
            }
        }

        /// <summary>
        /// Set low index
        /// </summary>
        [XmlAttribute("low_index")]
        public int LowIndex
        {
            get { return _nLowIndex; }
            set
            {
                if (_nLowIndex != value)
                    _nLowIndex = value;
            }
        }

        /// <summary>
        /// Set high index
        /// </summary>
        [XmlAttribute("high_index")]
        public int HighIndex
        {
            get { return _nHighIndex; }
            set
            {
                if (_nHighIndex != value)
                    _nHighIndex = value;
            }
        }

        /// <summary>
        /// Group id/name
        /// </summary>
        [XmlAttribute("name")]
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
        /// Group type
        /// </summary>
        [XmlAttribute("group_type")]
        public TemplateGroupType Type
        {
            get { return _tgtType; }
            set
            {
                if (_tgtType != value)
                    _tgtType = value;
            }
        }

        /// <summary>
        /// Current index
        /// </summary>
        [XmlIgnore]
        public int CurrentIndex
        {
            get { return _nCurrentIndex; }
            set
            {
                if (_nCurrentIndex != value )
                {
                    if ((value <= _nHighIndex) || (value >= _nLowIndex))
                        _nCurrentIndex = value;
                    else
                        throw new IndexOutOfRangeException("Set index out of range");
                }
            }
        }

        #endregion

        #region Public methods

        //TODO: use IEnumrable return type and 'yeld return'

        /// <summary>
        /// Enumerate group of fields
        /// </summary>
        /// <returns>Fully enumerated fields set</returns>
        public string[] Enumerate()
        {
            if (_lstFieldIds == null)
                return null;

            if ((_nLowIndex == 0) && (_nHighIndex == 0))
                return _lstFieldIds.ToArray();

            List<string> _lstIds = new List<string>();

            foreach (string _sId in _lstFieldIds)
                for (int _i = _nLowIndex; _i <= _nHighIndex; _i++)
                    try
                    {
                        _lstIds.Add(String.Format(_sId, _i));
                    }
                    catch (FormatException) { }

            return _lstIds.ToArray();
        }

        /// <summary>
        /// Create group.
        /// </summary>
        /// <param name="low_index">Low set index</param>
        /// <param name="high_index">High set index</param>
        /// <param name="field_ids">Fields ids</param>
        /// <returns>Group</returns>
        public TemplateFieldsGroup Create(string name, int low_index, int high_index, string[] field_ids)
        {
            TemplateFieldsGroup _tfgNewGroup = new TemplateFieldsGroup(name, low_index, high_index, field_ids);

            return _tfgNewGroup;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Base constructor
        /// </summary>
        public TemplateFieldsGroup()
        {
            _lstFieldIds = new List<string>();
        }

        /// <summary>
        /// Name/id based constructor
        /// <param name="name">Groudp id/name</param>
        /// </summary>
        public TemplateFieldsGroup(string name)
            : this()
        {
            _sName = name;
        }

        /// <summary>
        /// Index based constructor
        /// </summary>
        /// <param name="name">Groudp id/name</param>
        /// <param name="low_index">Low set index</param>
        /// <param name="high_index">High set index</param>
        public TemplateFieldsGroup(string name, int low_index, int high_index)
            : this(name)
        {
            _nHighIndex = high_index;
            _nLowIndex = low_index;
        }

        /// <summary>
        /// Ids based constructor
        /// </summary>
        /// <param name="name">Groudp id/name</param>
        /// <param name="low_index">Low set index</param>
        /// <param name="high_index">High set index</param>
        /// <param name="field_ids">Fields ids</param>
        public TemplateFieldsGroup(string name, int low_index, int high_index, params string[] field_ids)
            : this(name, low_index, high_index)
        {
            foreach (string fieldname in field_ids)
                _lstFieldIds.Add(fieldname);
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="group">Source group reference</param>
        public TemplateFieldsGroup(TemplateFieldsGroup group)
            : this()
        {
            this._nCurrentIndex = group._nCurrentIndex;
            this._nHighIndex = group._nHighIndex;
            this._nLowIndex = group._nLowIndex;
            this._sName = group._sName;

            foreach (string field_id in group._lstFieldIds)
                this._lstFieldIds.Add(new string(field_id.ToCharArray()));
        }

        #endregion
    }
}
