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

namespace Lib.ControlPublic
{
    public partial class ctrlShareScreen : UserControl
    {
        public ctrlShareScreen()
        {
            InitializeComponent();
        }

        public void LoadTitleInfo(string title)
        {
            lbTitle.Text = title;
            lbDate.Text = DateTime.Now.ToShortDateString();
            timer1.Start();
        }
        
        public void ShowTitle(string Title)
        {
            timer1.Stop();
            lbTitle.Text = Title;
            clsControls.UnVisableControl(lbDate, lbTime);
        }
        private void ctrlShareScreen_Load(object sender, EventArgs e)
        {

           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
