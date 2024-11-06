using DVLCPresentation.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class PersonCardWithFilter : UserControl
    {
        public int PersonSelect
        {
            get
            {
                return ctrlPersonDetails1.PersonID;
            }
        }
        public int PersonID
        {
            get
            {
                return ctrlPersonDetails1.PersonID;
            }
        }
        public event Action<int> OnPersonSeleced;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> Handler = OnPersonSeleced;
            if (Handler!=null)
            {
                Handler(PersonID);
            }
        }
       
        public PersonCardWithFilter()
        {
            InitializeComponent();
        }
        private bool _FilterEnable = true;
        public bool FilterEnable
        {
            get { return _FilterEnable; }
            set
            {
                _FilterEnable = value;
                gbFilter.Enabled = _FilterEnable;
            }
        }
        


        public ctrlPersonDetails ctrlLoadPerson
        {
            get
            {
                return ctrlPersonDetails1;
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
     {


            if (cbFilter.Text == "PersonID")
            {
                if (e.KeyChar==(char)13)
                {
                    int ID = clsFormat.ConvetStringToDataType<int>(txtFilter.Text);
                    btnFind.PerformClick();
                    txtFilter.Text = "".Trim();
                    txtFilter.Text = clsFormat.ConverGenericToString(ID);
                }

                if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        
       public  void LoadPersonInfo(int PersonID)
        {
            cbFilter.SelectedIndex = 1;
            txtFilter.Text = PersonID.ToString();
            Find();
        }
        
        private void Find()
        {
            switch (cbFilter.Text)
            {
                case "PersonID":
ctrlPersonDetails1.LoadPersonDetailsByPersonID(int.Parse(txtFilter.Text));
                    break;
                case "NationalNo":
ctrlPersonDetails1.LoadPersonDetailsByNationalNumber(txtFilter.Text);
                    break;
                default:
                    break;
            }
            // if i need Data the event will fire
            if (OnPersonSeleced != null&&FilterEnable)
                OnPersonSeleced(ctrlPersonDetails1.PersonID);

        }
        public void FilterFocuse()
        {
            txtFilter.Focus();
        }
        private void DataBackEvent(object sender, int PersonID)
        {
            cbFilter.SelectedIndex = 1;
            txtFilter.Text = PersonID.ToString();
            ctrlPersonDetails1.LoadPersonDetailsByPersonID(int.Parse(txtFilter.Text));
        }
        private void AddPerson(object sender, EventArgs e)
        {
            frmAddPerson frmAdd = new frmAddPerson();
            frmAdd._DataBack += DataBackEvent;
            frmAdd.ShowDialog();
        }
    
        //to there i stopped.
        private void ctrlFilterBy_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FindPersonInfo(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) { 
                MessageBox.Show("Some Fields are not complete");
                return;
            }
            Find();
        }

        private void txtFilter_Validating(object sender, CancelEventArgs e)
        {

        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (e.KeyChar==(char)13)
            {
             btnFind.PerformClick();
            }
            if (cbFilter.Text == "PersonID")
                e.Handled = (!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar));  
   
        }
    }
}
