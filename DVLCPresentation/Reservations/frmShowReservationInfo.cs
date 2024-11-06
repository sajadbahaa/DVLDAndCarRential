using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Reservations
{
    public partial class frmShowReservationInfo : Form
    {
        public frmShowReservationInfo(int ReservationID)
        {
            InitializeComponent();
            ctrlOverViewReservation1.LoadReservationInfo(ReservationID);
        }

        private void frmShowReservationInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
