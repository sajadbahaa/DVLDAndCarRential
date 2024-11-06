using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.People.Control
{
    public partial class frmFindPerson : Form
    {
        private int _PersonID;
        private delegate void DataBackHadling(object sender,int PersonID);
        private DataBackHadling _DataBack = null;
        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void frmFindPerson_Load(object sender, EventArgs e)
        {

        }

    private void GetDataBack(object sender, int PersonID)
        {
            _PersonID = PersonID;
            MessageBox.Show(_PersonID.ToString());
        }

        private void Close(object sender, EventArgs e)
        {
            _DataBack?.Invoke(this, ctrlFilterBy1.PersonID);
        }
    
    }
}
