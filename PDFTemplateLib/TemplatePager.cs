using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace PDFTemplate
{
    /// <summary>
    /// Template pager.
    /// Helper class to provide multipage support.
    /// </summary>
    public class TemplatePager
    {
        #region Private data

        private TemplateForm _tfMasterForm = null;
        private List<TemplateForm> _lstPageForms = null;
        private int _nCurrentPageIndex = 0;
        
        #endregion

        #region Public properties

        /// <summary>
        /// Master form
        /// </summary>
        public TemplateForm MasterForm 
        {
            get { return _tfMasterForm; }
        }

        /// <summary>
        /// Page set
        /// </summary>
        public List<TemplateForm> Pages 
        {
            get { return _lstPageForms; }
        }

        /// <summary>
        /// Current page index
        /// </summary>
        public int CurrentPageIndex 
        { 
            get { return _nCurrentPageIndex; } 
        }

        /// <summary>
        /// Base directory for flat pdf generation.
        /// Master form and pages forms BaseDir (if any) will be replaced.
        /// </summary>
        public string BaseDir 
        {
            get { return _tfMasterForm.BaseDir; }
            set {
                if( _tfMasterForm!=null)
                    _tfMasterForm.BaseDir = value;
                
                foreach (TemplateForm _page in _lstPageForms)
                    _page.BaseDir = value;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Add new page to internal page set copying it from master form
        /// </summary>
        public TemplateForm AddPage()
        {
            if (_tfMasterForm == null)
                throw new Exception("Master page not initialized");
            
            TemplateForm _newForm = new TemplateForm(_tfMasterForm);
            
            _lstPageForms.Add(_newForm);

            _nCurrentPageIndex = _lstPageForms.Count-1;

            return _newForm;
        }

        /// <summary>
        /// Fill form merging all pages and storing it to the output_file provided
        /// </summary>
        /// <param name="output_file">Destination file</param>
        /// <returns>Output filename</returns>
        public string FillForm(string output_file)
        {
            string[] _rgFiles = new string[_lstPageForms.Count];

            int _i = 0;

            foreach (TemplateForm form in _lstPageForms)
                _rgFiles[_i++] = form.FillForm();

            merge_files(_rgFiles, output_file);

            remove_files(_rgFiles);

            return output_file;
        }

        /// <summary>
        /// Fill set of grouped fields
        /// </summary>
        /// <param name="group_name">Group name/id</param>
        /// <param name="values">Values</param>
        /// <seealso cref="FieldsExpansion"/>
        /// <returns>True if new page have been created false otherwise</returns>
        public bool FillSet(string group_name, bool format, params object[] values)
        {
            TemplateForm _tfCurrentPage = _lstPageForms[_nCurrentPageIndex];

            if (_tfCurrentPage == null)
                throw (new KeyNotFoundException("Page not found"));

            bool _result = _tfCurrentPage.FillSet(group_name, format, values);

            // If the FillSet require a new page we add new page and reiterate the FillSet
            if (_result)
            {
                _tfCurrentPage = AddPage();
                _result = _tfCurrentPage.FillSet(group_name, format, values);
                
                return true;
            }

            return false;
        }

        /// <summary>
        /// Set all the fields with same id in pages to the same value
        /// </summary>
        /// <param name="field_id">Id/name of field</param>
        /// <param name="values">Values set</param>
        public void SetField(string field_id, params object[] values)
        {
            foreach(TemplateForm _form in _lstPageForms)
                _form[field_id].Set(values);
        }

        /// <summary>
        /// Pager static creator
        /// </summary>
        /// <param name="template_file">Master form template file</param>
        /// <returns>Pager object</returns>
        public static TemplatePager Create(string template_file)
        {
            TemplatePager _tpNewPager = new TemplatePager(template_file);

            return _tpNewPager;
        }

        #endregion

        #region Private methods

        private void remove_files(string[] files)
        {
            foreach (string filename in files)
                System.IO.File.Delete(filename);
        }

        private void merge_files(string[] files, string output_file)
        {
            Document document = new Document();
            PdfCopy writer = new PdfCopy(document, new FileStream(output_file, FileMode.Create));
            
            if (writer == null)
            {
                return;
            }

            document.Open();

            foreach (string fileName in files)
            {
                PdfReader reader = new PdfReader(fileName);
                reader.ConsolidateNamedDestinations();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    PdfImportedPage page = writer.GetImportedPage(reader, i);
                    writer.AddPage(page);
                }

                reader.Close();
            }

            writer.Close();
            document.Close();
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Base constructor
        /// </summary>
        public TemplatePager()
        {
            _lstPageForms = new List<TemplateForm>();
        }

        /// <summary>
        /// Constructor file based.
        /// </summary>
        /// <param name="template_file">Master form file</param>
        public TemplatePager(string template_file)
            : this()
        {
            _tfMasterForm = TemplateForm.Read(template_file);

            // Add the first page
            AddPage();
        }

        /// <summary>
        /// Form based costructor
        /// </summary>
        /// <param name="form">Form reference</param>
        public TemplatePager(TemplateForm form)
            : this()
        {
            _tfMasterForm = form;

            // Add the first page
            AddPage();
        }

        #endregion
    }
}
