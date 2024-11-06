using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRentail.Public_Controls
{
    public partial class ctrlRecored : UserControl
    {
        public ctrlRecored()
        {
            InitializeComponent();
        }
        public void LoadDataRecord(string NumberOfRecord)
        {
            lbRecord.Text = NumberOfRecord.Trim();
        }
        private void ctrlRecored_Load(object sender, EventArgs e)
        {

        }
    }
}
