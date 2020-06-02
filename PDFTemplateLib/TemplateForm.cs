using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PDFTemplate
{
    /// <summary>
    /// Template form.
    /// </summary>
    [Serializable]
    [XmlRoot("templateform")]
    public class TemplateForm
    {
        #region Private data

        private string _sId;
        private string _sFormFile;
        private string _sTemplateFile;
        private string _sBaseDir;
        private string _sBaseFilename;
        private List<TemplateField> _lstFields;
        private List<TemplateFieldsGroup> _lstGroups;

        #endregion

        #region Public properties

        /// <summary>
        /// Template id/name
        /// </summary>
        [XmlAttribute("template_id")]
        public string Id
        {
            get { return _sId; }
            set
            {
                if (_sId != value)
                    _sId = value;
            }
        }

        /// <summary>
        /// Base directory used in creating flat PDF file
        /// </summary>
        [XmlAttribute("basedir")]
        public string BaseDir
        {
            get { return _sBaseDir; }
            set
            {
                if (_sBaseDir != value)
                    _sBaseDir = value;
            }
        }

        /// <summary>
        /// Base filename used in creating flat PDF file
        /// </summary>
        [XmlAttribute("basename")]
        public string BaseFilename 
        {
            get { return _sBaseFilename; }
            set
            {
                if (_sBaseFilename != value)
                    _sBaseFilename = value;
            }
        }

        /// <summary>
        /// PDF form filename. 
        /// The file must reside in the same directory of the template file (once serialized).
        /// </summary>
        [XmlAttribute("form_file")]
        public string FormFile
        {
            get { return _sFormFile; }
            set
            {
                if (_sFormFile != value)
                {
                    if (String.IsNullOrWhiteSpace(_sTemplateFile))
                        _sTemplateFile = Path.Combine( System.IO.Path.GetDirectoryName(value), System.IO.Path.GetFileNameWithoutExtension(value) + PDFTemplate.Properties.Resources.TemplateExt);

                    _sFormFile = System.IO.Path.GetFileName(value);
                }
            }
        }

        /// <summary>
        /// Fields
        /// </summary>
        [XmlArray("fields"), XmlArrayItem(typeof(TemplateField), ElementName = "field")]
        public List<TemplateField> Fields
        {
            get { return _lstFields; }
            set
            {
                if (_lstFields != value)
                    _lstFields = value;
            }
        }

        /// <summary>
        /// Groups of fields
        /// </summary>
        [XmlArray("groups"), XmlArrayItem(typeof(TemplateFieldsGroup), ElementName = "group")]
        public List<TemplateFieldsGroup> Groups
        {
            get { return _lstGroups; }
            set
            {
                if (_lstGroups != value)
                    _lstGroups = value;
            }
        }

        /// <summary>
        /// PDF form file full path.
        /// </summary>
        [XmlIgnore]
        public string FormPath
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(_sTemplateFile))
                    return Path.Combine( System.IO.Path.GetDirectoryName(_sTemplateFile), _sFormFile );
                else
                    return _sFormFile;
            }
        }

        /// <summary>
        /// Template filename.
        /// </summary>
        [XmlIgnore]
        public string TemplateFile
        {
            get { return _sTemplateFile; }
        }
        
        /// <summary>
        /// Simple indexer just returns or sets the matching element from the internal field list.
        /// </summary>
        /// <param name="index">Field index</param>
        /// <returns>Field</returns>
        [XmlIgnore]
        public TemplateField this[int index]
        {
            get
            {
                return _lstFields[index];
            }
        }

        /// <summary>
        /// Id based indexer. 
        /// Returns or sets the matching element from the internal field list.
        /// </summary>
        /// <param name="id">Field id</param>
        /// <returns>Field</returns>
        [XmlIgnore]
        public TemplateField this[string id]
        {
            get
            {
                return _lstFields.Find(x => x.Name.Equals(id));
            }
        }

        #endregion

        #region Private methods

        private int import_fields()
        {
            int _nFields = 0;

            using (PdfReader _pdfReader = new PdfReader(FormPath))
            {
                AcroFields _Fields = _pdfReader.AcroFields;

                _lstFields.Clear();

                foreach (KeyValuePair<String, iTextSharp.text.pdf.AcroFields.Item> _field in _Fields.Fields)
                {
                    TemplateField _ffNewField = new TemplateField(_Fields, _field);
                    _lstFields.Add(_ffNewField);
                    _nFields++;
                }
            }

            return _nFields;
        }

        private string fill_form(string output_file)
        {
            using (PdfReader _pdfReader = new PdfReader(FormPath))
            {
                using (PdfStamper _pdfStamper = new PdfStamper(_pdfReader, new FileStream(output_file, FileMode.Create)))
                {
                    _pdfStamper.AcroFields.GenerateAppearances = true;

                    foreach (var _field in _pdfStamper.AcroFields.Fields)
                        foreach (TemplateField _spField in _lstFields)
                        {
                            if (_field.Key.Equals(_spField.Name))
                            {
                                switch (_spField.Type )
                                {
                                    case TemplateFieldType.Text:
                                        _pdfStamper.AcroFields.SetField(_field.Key, _spField.Value);
                                        break;

                                    case TemplateFieldType.Checkbox:
                                        //TODO: check Value field cannot be set != OnValue, Offvalue
                                        if (_spField.Value == _spField.OnValue)
                                            _pdfStamper.AcroFields.SetField(_field.Key, _spField.OnValue);
                                        else
                                            _pdfStamper.AcroFields.SetField(_field.Key, _spField.OffValue);
                                        break;
                                }
                            }
                        }

                    _pdfStamper.FormFlattening = true;
                }
            }

            return output_file;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Save/serialize the template on the provided path
        /// </summary>
        /// <param name="filename">Path where to serialize template</param>
        public void Save(string filename)
        {
            XmlSerializer _xsSerializer = new XmlSerializer(typeof(TemplateForm));

            using (StreamWriter _swWriter = new StreamWriter(filename))
            {
                try 
                { 
                    _xsSerializer.Serialize(_swWriter, this);
                    _sTemplateFile = filename;
                }
                catch (Exception ex) 
                { 
                    throw ex; 
                }
            }
        }

        /// <summary>
        /// Add a field
        /// </summary>
        /// <param name="type_value">Type of field</param>
        /// <param name="name_value">Name of field</param>
        /// <param name="field_value">Value of field</param>
        public void AddField(TemplateFieldType type_value, string name_value, string field_value)
        {
            TemplateField _tfNewField = null;

            switch (type_value)
            {
                case TemplateFieldType.Text:
                    _tfNewField = TemplateField.CreateText(name_value, field_value,"",false,16);
                    break;

                case TemplateFieldType.Checkbox:
                    _tfNewField = TemplateField.CreateCheckBox(
                        name_value, 
                        field_value, 
                        PDFTemplate.Properties.Resources.DefCheckBoxOnValue,
                        PDFTemplate.Properties.Resources.DefCheckBoxOffValue
                    );
                    break;
            }

            _lstFields.Add(_tfNewField);
        }

        /// <summary>
        /// Add a text field
        /// </summary>
        /// <param name="name_value">Name of field</param>
        /// <param name="field_value">Value of field</param>
        /// <param name="format_value">Format of field</param>
        /// <param name="padding_value">Padding flag</param>
        /// <param name="size_value">Size of field</param>
        public void AddText(string name_value, string field_value, string format_value, bool padding_value, int size_value)
        {
            TemplateField _tfNewField = TemplateField.CreateText(name_value, field_value, format_value, padding_value, size_value);

            _lstFields.Add(_tfNewField);
        }

        /// <summary>
        /// Add a checkbox field
        /// </summary>
        /// <param name="name_value">Name of field</param>
        /// <param name="field_value">Value of field</param>
        /// <param name="on_value">On value (checked)</param>
        /// <param name="off_value">Off value (uncheked)</param>
        public void AddCheckbox(string name_value, string field_value, string on_value, string off_value)
        {
            TemplateField _tfNewField = TemplateField.CreateCheckBox(name_value, field_value, on_value, off_value);

            _lstFields.Add(_tfNewField);
        }

        /// <summary>
        /// Import fields from the PDF form bind to the template.
        /// The previous set of field (if any) will be cleared.
        /// </summary>
        /// <returns>Number of fields imported</returns>
        public int ImportFields()
        {
            return import_fields();
        }

        /// <summary>
        /// Create a template from a provided PDF form path.
        /// The new template will be automatically bind to the 'generating' form.
        /// Fields will be imported accordingly to the settings auto_import_fields parameter.
        /// </summary>
        /// <param name="name_value">Id of the new template</param>
        /// <param name="form_path">PDF form path</param>
        /// <param name="auto_import_fields">Auto import fields from pdf form (default true)</param>
        /// <returns>New template</returns>
        public static TemplateForm Create(string name_value, string form_path, bool auto_import_fields = true)
        {
            if (!File.Exists(form_path))
                return null;

            TemplateForm _tfNewTemplate = new TemplateForm(name_value);

            _tfNewTemplate._sFormFile = System.IO.Path.GetFileName(form_path);

            if (auto_import_fields)
                _tfNewTemplate.import_fields();

            return _tfNewTemplate;
        }

        /// <summary>
        /// Create a template unserializing it from a serialized copy in the provided path
        /// </summary>
        /// <param name="template_path">Path to serialized template</param>
        /// <returns>>New template from serialized copy</returns>
        public static TemplateForm Read(string template_path)
        {
            if (!File.Exists(template_path))
                return null;

            XmlSerializer _xsSerializer = new XmlSerializer(typeof(TemplateForm));

            TemplateForm _tfNewTemplate = null;

            using (FileStream _srReader = new FileStream(template_path, FileMode.Open))
            {
                _tfNewTemplate = (TemplateForm)_xsSerializer.Deserialize(_srReader);
                _tfNewTemplate._sTemplateFile = template_path;
            }

            return _tfNewTemplate;
        }

        /// <summary>
        /// Set PDF FormFile value.
        /// The ImportFields method will be invoked only if auto_import_fields parameter is true.
        /// </summary>
        /// <param name="form_path">Path to form file</param>
        /// <param name="auto_import_fields">If true enable the automatic import of fields into template (default false)</param>
        public void SetForm(string form_path, bool auto_import_fields = false)
        {
            if (String.IsNullOrWhiteSpace(_sTemplateFile))
                _sTemplateFile = Path.Combine( System.IO.Path.GetDirectoryName(_sFormFile), System.IO.Path.GetFileNameWithoutExtension(_sFormFile) + PDFTemplate.Properties.Resources.TemplateExt);

            _sFormFile = System.IO.Path.GetFileName(form_path);

            if (auto_import_fields)
                import_fields();
        }

        /// <summary>
        /// Fill the form in the template and store it to a flat pdf file into provided path
        /// </summary>
        /// <param name="output_file">Path to destination PDF flatten file</param>
        /// <returns>Filename</returns>
        public string FillForm(string output_file)
        {
            return fill_form(output_file);
        }

        /// <summary>
        /// Fill the form bound to template with field values and store it to a flat PDF file.
        /// Filename of flat PDF file is generated trough BaseFile and BaseDir properties and timestamp.
        /// </summary>
        /// <seealso cref="BaseFilename"/>
        /// <seealso cref="BaseDir"/>
        /// <returns>Filename</returns>
        public string FillForm()
        {
            string _sPath = Path.Combine(_sBaseDir, _sBaseFilename + "_" + System.IO.Path.GetRandomFileName() + PDFTemplate.Properties.Resources.FlatfileExt);
            
            return fill_form(_sPath );
        }

        /// <summary>
        /// Fill set of grouped fields
        /// </summary>
        /// <param name="group_index">Index of group</param>
        /// <param name="values">Values</param>
        /// <seealso cref="FieldsExpansion"/>
        /// <returns>True if new page is needed false otherwise</returns>
        public bool FillSet(int group_index, bool format, params object[] values)
        {
            if ((group_index >= _lstGroups.Count) || (group_index < 0))
                throw new IndexOutOfRangeException("Group index out of range");

            TemplateFieldsGroup _tfgGroup = _lstGroups[group_index];

            int _values_idx = 0;
            int _nStep = 0;
            int _nElements = 0;

            foreach (string _sFieldNamePattern in _tfgGroup.FieldIds)
            {
                string _sFieldName;

                _sFieldName = String.Format(_sFieldNamePattern, _tfgGroup.CurrentIndex);

                TemplateField _tfField = null;

                _tfField = this[_sFieldName];

                if (_tfField != null)
                {
                    if ((_tfField.Expansion == TemplateFieldExpansion.Vertical) && (_tfField.Type == TemplateFieldType.Text) && (values[_values_idx] is string) &&
                        ((_tfField.SplitPolicy == SplitType.ByChar) || ((_tfField.SplitPolicy == SplitType.BySize) && (_tfField.Size < ((string)values[_values_idx]).Length))))
                    {
                        // Overflow on row
                        string[] _sValues = null;
                        
                        switch( _tfField.SplitPolicy)
                        {
                            case SplitType.BySize:
                                _sValues = ((string)values[_values_idx]).Split(_tfField.Size);
                                break;
                            
                            case SplitType.ByChar:
                                _sValues = ((string)values[_values_idx]).Split(_tfField.SplitChar);
                                break;

                            default:
                                throw new ArgumentException("SplitType "+ _tfField.SplitPolicy + " not managed");
                        }

                        if ((_tfgGroup.HighIndex - _tfgGroup.LowIndex) < _sValues.Length)
                            throw new SetTooHighException("Set will not fit in this page");

                        if (_tfgGroup.CurrentIndex + _sValues.Length > _tfgGroup.HighIndex)
                            return true;

                        _nElements = 0;

                        foreach (string _sValue in _sValues)
                        {
                            string _sFieldId;

                            _sFieldId = String.Format(_sFieldNamePattern, _tfgGroup.CurrentIndex + _nElements);

                            if (format && !String.IsNullOrWhiteSpace(this[_sFieldId].Format))
                                this[_sFieldId].Set(_sValue);
                            else
                                this[_sFieldId].Value = _sValue;

                            _nElements++;
                        }

                        //_nElements--;
                    }
                    else
                    {
                        if (_tfgGroup.CurrentIndex + 1 > _tfgGroup.HighIndex)
                            return true;

                        if (format && !String.IsNullOrWhiteSpace(_tfField.Format))
                            _tfField.Set(values[_values_idx]);
                        else if (values[_values_idx] is string)
                            _tfField.Value = (string)values[_values_idx];
                        else
                            _tfField.Value = values[_values_idx].ToString();

                        _nElements = 1;
                    }
                }
                else
                    throw new ArgumentException("Field identifier unknown");

                _values_idx++;

                if (_nElements > _nStep)
                    _nStep = _nElements;
            }

            _tfgGroup.CurrentIndex += _nStep;

            return false;
        }

        /// <summary>
        /// Fill set of grouped fields
        /// </summary>
        /// <param name="group_name">Group name/id</param>
        /// <param name="values">Values</param>
        /// <seealso cref="FieldsExpansion"/>
        /// <returns>True if new page is needed false otherwise</returns>
        public bool FillSet(string group_name, bool format, params object[] values)
        {
            TemplateFieldsGroup _tfgGroup = _lstGroups.Find(x => x.Name.Equals(group_name));

            if (_tfgGroup == null)
                throw (new KeyNotFoundException());

            int _index = _lstGroups.IndexOf(_tfgGroup);

            return FillSet(_index, format, values);
        }

        /// <summary>
        /// Add new group
        /// <param name="fields_ids">Parameters</param>
        /// </summary>
        public void AddGroup(string name, int low_index, int high_index, params string[] fields_ids)
        {
            TemplateFieldsGroup _tfgNewGroup = new TemplateFieldsGroup(name,low_index, high_index, fields_ids);
            _lstGroups.Add(_tfgNewGroup);
        }

        /// <summary>
        /// Copy fields values into matching dest_form fields
        /// </summary>
        /// <param name="dest_form">Destination form</param>
        /// <param name="field_ids">Fields set</param>
        public void CopyTo(TemplateForm dest_form, params string[] field_ids)
        {
            foreach (string field_id in field_ids)
                dest_form[field_id].Value = this[field_id].Value;
        }

        /// <summary>
        /// Clear values and groups index
        /// </summary>
        public void Clear()
        {
            foreach (TemplateField _tfField in this.Fields)
                _tfField.Value = "";

            foreach (TemplateFieldsGroup _tfgGroup in this.Groups)
                _tfgGroup.CurrentIndex = 0;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Basic constructor
        /// </summary>
        public TemplateForm()
        {
            _lstFields = new List<TemplateField>();
            _lstGroups = new List<TemplateFieldsGroup>();
        }

        /// <summary>
        /// ID based construtor.
        /// Create a template and assign its name
        /// </summary>
        /// <param name="name_value">Template name</param>
        public TemplateForm(string name_value) 
            : this()
        {
            _sId = name_value;
        }

        /// <summary>
        /// Form based constructor.
        /// Create a template from a PDF form.
        /// Using this constructor triggers automatically ImportFields methods.
        /// </summary>
        /// <seealso cref="ImportFields"/>
        /// <param name="name_value">Template name</param>
        /// <param name="form_path">PDF form path</param>
        public TemplateForm(string name_value, string form_path)
            : this(name_value)
        {
            _sFormFile = System.IO.Path.GetFileName(form_path);

            _sTemplateFile = Path.Combine( System.IO.Path.GetDirectoryName(_sFormFile), System.IO.Path.GetFileNameWithoutExtension(_sFormFile) + PDFTemplate.Properties.Resources.TemplateExt);

            import_fields();
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="form">Original template form</param>
        public TemplateForm(TemplateForm form)
            :this()
        {
            this._sBaseDir = form._sBaseDir;
            this._sBaseFilename = form._sBaseFilename;
            this._sFormFile = form._sFormFile;
            this._sId = form._sId;
            this._sTemplateFile = form._sTemplateFile;

            foreach (TemplateField field in form._lstFields)
                this._lstFields.Add(new TemplateField(field));

            foreach (TemplateFieldsGroup group in form._lstGroups)
                this._lstGroups.Add(new TemplateFieldsGroup(group));
        }

        #endregion
    }
}
