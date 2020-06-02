using System.Windows.Forms;

namespace PDFTemplate
{
    public partial class frmProperties : Form
    {
        #region Properties

        public object CurrentObject {
            set
            {
                pgProperties.SelectedObject = value;
            }
        }

        #endregion

        public frmProperties()
        {
            InitializeComponent();
        }
    }
}
