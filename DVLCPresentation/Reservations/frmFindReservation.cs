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
    public partial class frmFindReservation : Form
    {
        public frmFindReservation()
        {
            InitializeComponent();
        }

        private void ctrlReservationWithFilter1_OnReservationSelected(object sender, clsPeople.clsReservations e)
        {
            if (e.ReservationID==-1)
            {
                return;
            }

            if (e.ApplicationInfo.ApplicationStatus==clsPeople.clsApplication.enApplicationStatus.Cancel)
            {
                MessageBox.Show("this Reservation has been cancel");
                return;
            }
            if (e.ApplicationInfo.ApplicationStatus == clsPeople.clsApplication.enApplicationStatus.Complete)
            {
                MessageBox.Show("this Reservation has been completed");
                return;
            }

            MessageBox.Show(ctrlReservationWithFilter1.ReservationInfo.VehicleInfo.VehicleNamesInfo.VehicleName);
        }
    }
}
