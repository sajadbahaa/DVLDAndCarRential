using clsPeople;
using DVLCPresentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
   
    public partial class ctrlPersonDetails : UserControl
    {
        private int _ID =-1;
        clsPerson _clsPerson;
        public int PersonID
        {
            get
            {
                return _ID;
            }
        }
        public ctrlPersonDetails()
        {
            InitializeComponent();
        }
        private void _LoadImage()
        {
            if (_clsPerson.Gendor == 0)
                pb.Image = Resources.male;
            else
                pb.Image = Resources.female;
            string ImagePath = _clsPerson.ImagePath;

            if (_clsPerson.ImagePath!="")
                if (File.Exists(ImagePath))                
                    pb.ImageLocation = ImagePath;
        }
        private void _FillInfoPerson()
        {
            _ID = _clsPerson.PersonID;
            lbName.Text = _clsPerson.FullName();
            lbCountry.Text = _clsPerson.CountryID.ToString();
            lbBirth.Text = _clsPerson.Birth.ToString();
            lbGendor.Text = (_clsPerson.Gendor==0?"Male":"Female");
            lbNationalNo.Text = _clsPerson.NationalNo.ToString();
            lbPhone.Text = _clsPerson.Phone.ToString();
             lbPersonID.Text = _clsPerson.PersonID.ToString();
            LEditPerson.Enabled = true;
            lbEmail.Text = _clsPerson.Email;
            lbAddress.Text = _clsPerson.Address;
            //Load Image
            _LoadImage();
        }
        public void LoadPersonDetailsByPersonID(int PersonID)
        {
            _clsPerson = clsPerson.FindByPersonID(PersonID);
            if (_clsPerson==null)
            {
                _RestInfo();
                MessageBox.Show($"this PersonID does exist {PersonID}");
                return;
            }
            _FillInfoPerson();
        }
         private  string GenderIs(byte Gendor)
        {
            if (Gendor==0)
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
        }
        public void _RestInfo() 
        {
            lbPersonID.Text = "????";
            lbAddress.Text  = "????";
            lbBirth.Text    = "????";                                                                                                                                                                                
            lbCountry.Text  = "????";
            lbEmail.Text    = "????";
            lbGendor.Text = "????";
            lbName.Text = "????";
            lbNationalNo.Text = "????";
            lbPhone.Text = "????";
            LEditPerson.Enabled = false;
            pb.Image = Resources.male;
        }
         public void LoadPersonDetailsByNationalNumber(string NationalNo)
         {
            _clsPerson = clsPerson.FindByNationalNo(NationalNo);
            if (_clsPerson==null)
            {
                _RestInfo();
                MessageBox.Show($"this National No [{NationalNo}] does not exist");
                return;
            }
            _FillInfoPerson();
         
         } 
        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void ctrlPersonDetails_Load(object sender, EventArgs e)
        {
            LEditPerson.Enabled = false;
        }
        
        
        private void UpdatePerson(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddPerson fUpdatePerson;

            fUpdatePerson = new frmAddPerson(_ID);
            fUpdatePerson.ShowDialog();
            LoadPersonDetailsByPersonID(_ID);

        }
        private void SaveImage(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lbNationalNo_Click(object sender, EventArgs e)
        {

        }

        private void pb_Click(object sender, EventArgs e)
        {

        }

        private void EditPerson(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddPerson frm = new frmAddPerson(PersonID);
            frm.ShowDialog();
            LoadPersonDetailsByPersonID(_ID); 
        }
    }
}
