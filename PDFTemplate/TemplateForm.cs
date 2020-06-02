using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PDFTemplate
{
    [Serializable]
    [XmlRoot("templateform")]
    public class TemplateForm
    {
        #region Private data
        
        private string _sId;
        private string _sFormFile;
        private List<TemplateField> _lstFields;
        private bool _bAutoImportFields = false;
        
        #endregion

        #region Properties

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

        [XmlAttribute("form_file")]
        public string FormFile
        {
            get { return _sFormFile; }
            set
            {
                if (_sFormFile != value)
                {
                    _sFormFile = value;
                    
                    if (!_bAutoImportFields)
                        return;
                    else
                        import_fields();
                }
            }
        }

        [XmlArray("fields"), XmlArrayItem(typeof(TemplateField), ElementName = "field")]
        public List<TemplateField> Fields
        {
            get { return _lstFields; }
            set { 
                if (_lstFields != value)
                    _lstFields = value; 
            }
        }
        
        #endregion

        #region Private methods

        private void import_fields()
        {
            using(PdfReader _pdfReader = new PdfReader(_sFormFile))
            {
                AcroFields _Fields = _pdfReader.AcroFields;

                foreach (var _field in _pdfReader.AcroFields.Fields)
                {
                    int _nType = _pdfReader.AcroFields.GetFieldType(_field.Key);
                    TemplateFieldType _ftType = (TemplateFieldType)(_nType);
                    TemplateField _ffNewField = new TemplateField(_field.Key, _ftType);

                    if (_ftType == TemplateFieldType.Checkbox)
                    {
                        string[] _rgsStates = _pdfReader.AcroFields.GetAppearanceStates(_field.Key);
                        _ffNewField.OnValue = _rgsStates[1];
                        _ffNewField.OffValue = _rgsStates[0];
                    }

                    _lstFields.Add(_ffNewField);
                }

            }
        }

        #endregion

        #region Public methods

        public void Save(string filename)
        {
            XmlSerializer _xsSerializer = new XmlSerializer(typeof(TemplateForm));

            using (StreamWriter _swWriter = new StreamWriter(filename))
            {
                try { _xsSerializer.Serialize(_swWriter,this); }
                catch (Exception ex) { throw ex; }
            }
        }

        public void AddField(TemplateFieldType type_value, string name_value, string field_value)
        {
            TemplateField _tfNewField = new TemplateField();
            _tfNewField.Type = type_value;
            _tfNewField.Value = field_value;
            _tfNewField.Name = name_value;

            _lstFields.Add(_tfNewField);
        }

        public void ImportFields()
        {
            import_fields();
        }

        public static TemplateForm Create(string name_value, string form_path)
        {
            if (!File.Exists(form_path))
                return null;

            TemplateForm _tfNewTemplate = new TemplateForm(name_value);

            _tfNewTemplate._sFormFile = form_path;

            if (_tfNewTemplate._bAutoImportFields)
                _tfNewTemplate.import_fields();

            return _tfNewTemplate;
        }

        public static TemplateForm Read(string template_path)
        {
            if (!File.Exists(template_path))
                return null;

            XmlSerializer _xsSerializer = new XmlSerializer(typeof(TemplateForm));
            
            TemplateForm _tfNewTemplate = null;
            
            using (FileStream _srReader = new FileStream(template_path, FileMode.Open))
            {
                _tfNewTemplate = (TemplateForm)_xsSerializer.Deserialize(_srReader);
            }

            return _tfNewTemplate;
        }

        #endregion

        #region Constructors
        
        public TemplateForm()
        {
            _sId = "template";
            _lstFields = new List<TemplateField>();
        } 

        public TemplateForm(string name_value)
        {
            _sId = name_value;
            _lstFields = new List<TemplateField>();
        }

        public TemplateForm(string name_value, string form_path)
        {
            _sId = name_value;
            _sFormFile = form_path;
            _lstFields = new List<TemplateField>();

            if (_bAutoImportFields)
                import_fields();

        }
        
        #endregion
    }
}
