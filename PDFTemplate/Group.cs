using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace PDFTemplate
{
    public partial class dlgGroup : Form
    {
        #region Private data

        List<string> _lstFields = new List<string>();

        #endregion

        #region Public properties

        public List<string> Fields 
        {
            get { return _lstFields; }
        }

        public int HighIndex { get { return (int)nudHighIndex.Value; } }
        public int LowIndex { get { return (int)nudLowIndex.Value; } }
        public string GroupName { get { return txtGroupName.Text; } }
        
        #endregion

        #region Event handlers

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string _sFieldName = String.Format(cbFieldId.Text, (int)nudLowIndex.Value);
            
            if (!cbFieldId.Items.Contains(_sFieldName))
                return;

            _lstFields.Add(cbFieldId.Text);
            lvFields.VirtualListSize = _lstFields.Count;
            cbFieldId.SelectedText = "";
        }

        private void lvFields_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = new ListViewItem(e.ItemIndex.ToString());
            e.Item.SubItems.Add(_lstFields[e.ItemIndex]);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void miClear_Click(object sender, EventArgs e)
        {
            _lstFields.Clear();
            lvFields.VirtualListSize = _lstFields.Count;
        }

        private void cmdFields_Opening(object sender, CancelEventArgs e)
        {
            miRemoveField.Enabled = (_lstFields.Count != 0);
            miClear.Enabled = (_lstFields.Count != 0);
        }

        private void miRemoveField_Click(object sender, EventArgs e)
        {
            foreach (int _i in lvFields.SelectedIndices)
                _lstFields.RemoveAt(_i);

            lvFields.VirtualListSize = _lstFields.Count;
        }

        private void dlgGroup_Load(object sender, EventArgs e)
        {
        }

        #endregion

        public dlgGroup()
        {
            InitializeComponent();
        }

        public dlgGroup(List<TemplateField> fields) 
            : this()
        {
            foreach (TemplateField _field in fields)
                cbFieldId.Items.Add(_field.Name);
        }
    }
}
