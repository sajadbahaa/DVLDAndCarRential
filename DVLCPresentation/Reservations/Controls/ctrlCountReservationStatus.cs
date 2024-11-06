using clsPeople;
using CRentail.Public_Classes;
using DVLCPresentation.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Reservations.Controls
{
    public partial class ctrlCountReservationStatus : UserControl
    {
        public ctrlCountReservationStatus()
        {
            InitializeComponent();
        }
       
        private void ctrlCountReservationStatus_Load(object sender, EventArgs e)
        {

        }
        public void LoadReservationStatics()
        {
            short CountNew = 0, CountCompleted = 0, CountCancel = 0;
            bool IsFind = clsReservations.GetAllReservationsstatics<short>(ref CountNew, ref CountCompleted, ref CountCancel);
            if (IsFind)
            {
                lbCountCancel.Text = clsFormat.ConverGenericToString(CountCancel);
                lbCountCompleted.Text = clsFormat.ConverGenericToString(CountCompleted);
                lbCountNew.Text = clsFormat.ConverGenericToString(CountNew);
                return;
            }
            clsGlobalMessages.Messages("There is no Reservations Statics");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
