using CRentail.frmVehicles;
using CRentail.Vehicles;
using DvlcDataLayer;
using DVLCPresentation.Customers;
using DVLCPresentation.Drivers;
using DVLCPresentation.Payments;
using DVLCPresentation.People.Control;
using DVLCPresentation.Reservations;
using DVLCPresentation.Reservations.Reservation_List;
using DVLCPresentation.ReturnCar;
using DVLCPresentation.Statics;
using DVLCPresentation.Vehicles.Controls;
using DVLCPresentation.Vehicles.Maintence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmAddPerson());
            dtAccess.Connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            //Application.Run(new frmOverViewVehilces());

            //Application.Run(new frmVehicleList());
            //Application.Run(new frmVehicleList());
            //Application.Run(new frmFindVehicle ());
            //Application.Run(new frmDrivers());
            // Application.Run(new frmCustomersList());
            // Application.Run(new frmOverViewCustomers());
            // Application.Run(new frmAddReservation());
            Application.Run(new Login());
            //Application.Run(new frmShowReservationInfo(3));
            //  Application.Run(new frmOVerVeirwReservations());
            //Application.Run(new frmPaymentsList());
            //Application.Run(new frmExtendReservation (7));
            //Application.Run(new frmReturnCar());
            //Application.Run(new frmStatics());
            //Application.Run(new frmRepireMaintense(8));
            //Application.Run(new frmMaintanceList());
            //Application.Run(new StaticCustomers());
            //Application.Run(new frmReservationStatics());
            //Application.Run(new frmShowAllEarningForEacVehicle());
        }

    }
}
