using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PDFTemplate
{
    public partial class frmMain : Form
    {
        #region Private data

        TemplateForm _tfTemplate = new TemplateForm("template_pdf");
        
        TemplatePager _tpPager = null;

        #endregion

        #region Private methods

        private void AddMessage(string message)
        {
            ListViewItem _lviNewItem = new ListViewItem(DateTime.Now.ToShortTimeString());

            _lviNewItem.SubItems.Add(message);

            lvMessages.Items.Add(_lviNewItem);

            _lviNewItem.EnsureVisible();

            foreach (ColumnHeader _chHeader in lvMessages.Columns)
                _chHeader.Width = -2;
        }

        private void ImportFile(string form_file)
        {
            try 
            {
                _tfTemplate.FormFile = form_file;
                _tfTemplate.ImportFields();
                AddMessage("Form file set to: " + form_file);
            }
            catch(Exception ex)
            {
                AddMessage("EXCEPTION: " + ex.Message);
            }
        }

        #endregion

        #region Event handlers

        private void cmMessages_Opening(object sender, CancelEventArgs e)
        {
            miClear.Enabled = (lvMessages.Items.Count != 0);
        }        
        
        private void miClear_Click(object sender, EventArgs e)
        {
            lvMessages.Items.Clear();
        }

        private void btnAddElement_Click(object sender, EventArgs e)
        {
            string[] _rgcValues = txtElement.Text.Split(',');

            try
            {
                switch((TemplateFieldType)ddlType.SelectedValue)
                {
                    case TemplateFieldType.Checkbox:
                        if (_rgcValues.Length != 4)
                            return;
                        
                        if((_tpPager!=null) && cbPager.Checked)
                            _tpPager.Pages[_tpPager.CurrentPageIndex].AddCheckbox(_rgcValues[0], _rgcValues[1], _rgcValues[2], _rgcValues[3]);
                        else
                            _tfTemplate.AddCheckbox(_rgcValues[0], _rgcValues[1], _rgcValues[2], _rgcValues[3]);
                       
                            AddMessage("New checkbox:" + ddlType.SelectedValue.ToString() + ", " + _rgcValues[0] + ", " + _rgcValues[1] + ", " + _rgcValues[2] + ", " + _rgcValues[3]);
                        break;

                    case TemplateFieldType.Text:
                        if (_rgcValues.Length != 5)
                            return;

                        if ((_tpPager != null) && cbPager.Checked)
                            _tpPager.Pages[_tpPager.CurrentPageIndex].AddText(_rgcValues[0], _rgcValues[1], _rgcValues[2], bool.Parse(_rgcValues[3]), short.Parse(_rgcValues[4]));
                        else
                            _tfTemplate.AddText(_rgcValues[0], _rgcValues[1], _rgcValues[2], bool.Parse(_rgcValues[3]), short.Parse(_rgcValues[4]));
                        
                            AddMessage("New text field:" + ddlType.SelectedValue.ToString() + ", " + _rgcValues[0] + ", " + _rgcValues[1] + ", " + _rgcValues[2] + ", " + _rgcValues[3] + ", " + _rgcValues[4]);
                        break;

                    default: 
                        if (_rgcValues.Length != 2)
                            return;

                        if ((_tpPager != null) && cbPager.Checked)
                            _tpPager.Pages[_tpPager.CurrentPageIndex].AddField((TemplateFieldType)ddlType.SelectedValue, _rgcValues[0], _rgcValues[1]);
                        else
                            _tfTemplate.AddField((TemplateFieldType)ddlType.SelectedValue, _rgcValues[0], _rgcValues[1]);
                        
                            AddMessage("New field:" + ddlType.SelectedValue.ToString() + ", " + _rgcValues[0] + ", " + _rgcValues[1]);
                        break;
                }

                txtElement.Text = "";
            }
            catch(Exception ex)
            {
                AddMessage("EXCEPTION:" + ex.Message);
            }
        }

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            if (_tfTemplate == null)
            {
                AddMessage("Create a new template first");
                return;
            }

            if (System.IO.Path.GetExtension(dlgTemplate.FileName).ToLower() != ".xml")
                dlgTemplate.FileName = _tfTemplate.TemplateFile;

            dlgTemplate.Title = "Select XML template file";
            dlgTemplate.CheckFileExists = false;
            dlgTemplate.OverwritePrompt = true;
            dlgTemplate.FilterIndex = 2;

            DialogResult _drResult = dlgTemplate.ShowDialog();
            
            if(_drResult!=DialogResult.OK)
                return;

            try
            {
                XmlSerializer _xsSerializer = new XmlSerializer(typeof(TemplateForm));

                using (StreamWriter _swWriter = new StreamWriter(dlgTemplate.FileName))
                {
                    _xsSerializer.Serialize(_swWriter, _tfTemplate);
                }

                AddMessage("Saving template to: " + dlgTemplate.FileName);

                txtTemplatePath.Text = dlgTemplate.FileName;
            }
            catch (Exception ex)
            {
                AddMessage("EXCEPTION: " + ex.Message);
            }
        }

        private void btnSearchForm_Click(object sender, EventArgs e)
        {
            if (System.IO.Path.GetExtension(dlgSearchForm.FileName).ToLower() != ".pdf")
                dlgSearchForm.FileName = "";

            dlgSearchForm.Title = "Select PDF form file";
            dlgSearchForm.FilterIndex = 1;
            dlgSearchForm.CheckFileExists = true;

            if (dlgSearchForm.ShowDialog() != DialogResult.OK)
                return;

            txtFormPath.Text = dlgSearchForm.FileName;

            ImportFile(dlgSearchForm.FileName);
        }

        private void btnSearchTemplate_Click(object sender, EventArgs e)
        {
            if (System.IO.Path.GetExtension(dlgTemplate.FileName).ToLower() != ".xml")
                dlgTemplate.FileName = "";

            dlgTemplate.Title = "Select XML template file";
            dlgTemplate.CheckFileExists = true;
            dlgTemplate.OverwritePrompt = false;
            dlgTemplate.FilterIndex = 2;

            DialogResult _drResult = dlgTemplate.ShowDialog();

            if (_drResult != DialogResult.OK)
                return;

            if (!File.Exists(dlgTemplate.FileName))
                return;

            try
            {
                AddMessage("Loading template: " + dlgTemplate.FileName);

                txtTemplatePath.Text = dlgTemplate.FileName;
                _tfTemplate = TemplateForm.Read(dlgTemplate.FileName);
                txtFormPath.Text = _tfTemplate.FormPath;
                
                foreach (TemplateFieldsGroup group in _tfTemplate.Groups)
                    cbGroupIdx.Items.Add(group.Name);

                if (cbGroupIdx.Items.Count!=0)
                    cbGroupIdx.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                AddMessage("EXCEPTION:" + ex.Message);
                AddMessage("STACKTRACE:" + ex.StackTrace);
            }
        }

        private void btnDump_Click(object sender, EventArgs e)
        {
            AddMessage("Field(s) dump:");

            foreach (TemplateField _field in _tfTemplate.Fields)
            {
                AddMessage("Field:" + _field.Name + " [" + _field.Type.ToString() + "] value: " + _field.Value);
                
                if(_field.Type == TemplateFieldType.Checkbox)
                {
                    AddMessage("OnValue: " + _field.OnValue);  
                    AddMessage("OffValue: " + _field.OffValue);
                }

            }
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            PDFTemplate.frmProperties _frmProperties = new PDFTemplate.frmProperties();

            if( _tpPager!=null )
                _frmProperties.CurrentObject = _tpPager;
            else
                _frmProperties.CurrentObject = _tfTemplate;

            _frmProperties.ShowDialog();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            try
            {
                dlgTemplate.FileName = "";
                dlgTemplate.FilterIndex = 1;
                dlgTemplate.Title = "Select the destination PDF file (form will be flatten)";
                dlgTemplate.CheckFileExists = false;
                dlgTemplate.OverwritePrompt = true;

                if (dlgTemplate.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtDestination.Text = dlgTemplate.FileName;

                    AddMessage("Creating " + dlgTemplate.FileName + " flat file");

                    if( cbAutoFill.Checked )
                    {
                        if (cbPager.Checked)
                            AddMessage("Cannot perform autofill on pager (by now)");
                        else
                        {
                            foreach (TemplateField _field in _tfTemplate.Fields)
                            {
                                if (_field.Type == TemplateFieldType.Checkbox)
                                    _field.Value = _field.OnValue;
                                else
                                    _field.Value = _field.Name;
                            }
                        }
                    }

                    if ((cbPager.Checked) && (_tpPager != null))
                        _tpPager.FillForm(dlgTemplate.FileName);
                    else
                        _tfTemplate.FillForm(dlgTemplate.FileName);
                }
            }
            catch (Exception ex)
            {
                AddMessage("EXCEPTION:" + ex.Message);
            }

        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            dlgGroup _dlgGroupEditor = new dlgGroup(_tfTemplate.Fields);

            if (_dlgGroupEditor.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            if (_dlgGroupEditor.Fields.Count == 0)
                return;

            AddMessage("Group creation:");

            foreach (string _sField in _dlgGroupEditor.Fields)
                AddMessage("Field: " + _sField);

            _tfTemplate.AddGroup(
                _dlgGroupEditor.GroupName,
                _dlgGroupEditor.LowIndex, 
                _dlgGroupEditor.HighIndex,
                _dlgGroupEditor.Fields.ToArray()
            );
        }

        private void btnFieldsSetFill_Click(object sender, EventArgs e)
        {
            string[] _rgsValues = txtSetValues.Text.Split(',');


            if(cbPager.Checked )
            {
                if(_tpPager==null)
                    _tpPager = new TemplatePager(_tfTemplate);

                _tpPager.FillSet(cbGroupIdx.Text,true, _rgsValues);
                
                return;
            }

            _tfTemplate.FillSet(cbGroupIdx.Text, true,_rgsValues);

        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            _tfTemplate.Clear();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ddlType.DataSource = Enum.GetValues(typeof(TemplateFieldType));
        }

        #endregion

        #region Public methods

        #endregion

        public frmMain()
        {
            InitializeComponent();
        }
   }
}
