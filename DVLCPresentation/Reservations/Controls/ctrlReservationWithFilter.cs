using clsPeople;
using DVLCPresentation.Global_Classes;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLCPresentation.Reservations.Controls
{
    public partial class ctrlReservationWithFilter : UserControl
    {
        public ctrlReservationWithFilter()
        {
            InitializeComponent();
        }
        public event EventHandler<clsReservations> OnReservationSelected;
        protected virtual void InvokeEventOnReservation(clsReservations e)
        {
            OnReservationSelected?.Invoke(this, e);
        }
        public int ReservationID
        {
            get
            {
                return ctrlOverViewReservation1.ReservationID;
            }
        }

        public clsReservations ReservationInfo
        {
            get
            {
                return ctrlOverViewReservation1.ReservationInfo;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
                int Reservation = int.Parse(txtFilter.Text);
                txtFilter.Text = "".Trim();
                txtFilter.Text = Reservation.ToString();
            }
            clsVaildation.UserControlKeyPressHandlerNumber(sender, e);

        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            clsVaildation.ValidatingEmpty(sender,e,txtFilter,errorProvider1);
        }

        private void ctrlReservationWithFilter_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            clsFilters.FilterFocuse(txtFilter);
        }
        public void LoadReservationInfo(int ReservationID)
        {
            txtFilter.Text = clsFormat.ConverGenericToString(ReservationID);
            FindNow();
        }
        private bool _FilterEnabel = true;
        public bool FilterEnabel
        {
            get
            {
                return _FilterEnabel;
            }
        }

        private void FindNow()
        {
            switch (cbFilter.Text)
            {
                case "ReservationID":
                    ctrlOverViewReservation1.LoadReservationInfo(int.Parse(txtFilter.Text));
                    break;
            }
            if (FilterEnabel && OnReservationSelected != null)
            {
                InvokeEventOnReservation(ReservationInfo);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!clsVaildation.VaildationFieldsRequired(this))
                return;
            
            FindNow();
        }
    }
}
