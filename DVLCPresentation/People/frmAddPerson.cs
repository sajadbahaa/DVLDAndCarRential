using clsPeople;
using DVLCPresentation.Global_Classes;
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
    public partial class frmAddPerson : Form
    {
        enum enMode { add=1,Update = 2}
        enum enGendor { male = 0,female =1}

        
        private enMode _Mode;
       
        private clsPerson _person;
        
        private int _personID;
        
        public frmAddPerson()
        {
            InitializeComponent();
            _Mode = enMode.add;
        
        }
        private void _FillCountriesInComboBox()
        {
            DataTable dt = clsCountries.GetAllCountries();
            foreach (DataRow row in dt.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }
        public frmAddPerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _personID = PersonID;
        }
        public delegate void DataBackHandler(object sender, int PersonID);
        public event DataBackHandler _DataBack;
     
        private void _RestDefaultValues()
        {
            _FillCountriesInComboBox();
            if (_Mode==enMode.add)
            {
                lblTitle.Text = "Add Person";
                _person = new clsPerson();
            }
            else
            {
                lblTitle.Text = "Update Person";
            }

            txtAddress.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true;
            
            if (rbMale.Checked)
                pbPersonImage.Image = Resources.male;
            else
            pbPersonImage.Image = Resources.female;    

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value =  dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            txtPhone.Text = "";
            cbCountry.SelectedIndex = cbCountry.FindString("Iraq");
            llRemoveImage.Visible = (pbPersonImage.ImageLocation !=null);
        
        } 
        private void _LoadData()
        {
            _person = clsPerson.FindByPersonID(_personID);
            if (_person==null)
            {
                MessageBox.Show($"this {_personID} not found");
                return;
            }
            
            lblPersonID.Text = _personID.ToString();
            lblTitle.Text = "Update Person";
            txtAddress.Text = _person.Address;
            txtEmail.Text = _person.Email;
            txtPhone.Text = _person.Phone;
            txtNationalNo.Text = _person.NationalNo;
            txtFirstName.Text = _person.FirstName;
            txtSecondName.Text = _person.SecondName;
            txtThirdName.Text = _person.ThirdName;
            txtLastName.Text = _person.LastName;

            if (_person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
            
            if (_person.ImagePath!=null)
            {
                pbPersonImage.ImageLocation = _person.ImagePath;
                llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);
            }
        }
        private void frmAddPerson_Load(object sender, EventArgs e)
        {
            _RestDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void Close(object sender, EventArgs e)
        {

        }
         private bool _HandelPersonImage()
         {
             //_person.image is an old image
            // pbImagePerson if it does not like _person.image its new
           //we check if _perons.image doest like pbImagePerson
            if (_person.ImagePath !=pbPersonImage.ImageLocation)
            {
                if (_person.ImagePath!=null)
                {
                    try
                    {
                        File.Delete(_person.ImagePath);
                    }
                    catch (IOException iox)
                    {
                        MessageBox.Show("Error"+iox.Message);
                    }
                }
                if (pbPersonImage.ImageLocation != null)
                {
                    string ImagePath = pbPersonImage.ImageLocation.ToString();
                    if (clsUtilize.CopyImagetoProjectImagesFolder(ref ImagePath))
                    {
                        pbPersonImage.ImageLocation = ImagePath;

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Copying Image is Error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }



            }
            return true;     

        }
        private void Save(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
  MessageBox.Show("some fields are not complete , " +
 "put mouse on the red icon to see the problem", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandelPersonImage())
                return;

            _person.Email = txtEmail.Text;
            _person.FirstName = txtFirstName.Text;
            _person.SecondName = txtSecondName.Text;
            _person.LastName = txtLastName.Text;
            _person.ThirdName = txtThirdName.Text;
            _person.Birth = dtpDateOfBirth.Value;
            _person.Address = txtAddress.Text;
            _person.CountryID = clsCountries.FindByCountryName(cbCountry.Text).CountryID;
            if (rbMale.Checked)
                _person.Gendor = (byte)enGendor.male;
            else
                _person.Gendor = (byte)enGendor.female;

            if (pbPersonImage.ImageLocation!="")
            {
                _person.ImagePath = pbPersonImage.ImageLocation;
            }
            _person.Phone = txtPhone.Text;
            _person.NationalNo = txtNationalNo.Text;
            if (_person.Save())
            {
                MessageBox.Show("Saved Successfully","Saved",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                lblPersonID.Text = _person.PersonID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update Person";
                _DataBack?.Invoke(this,_person.PersonID);
            }
            else
            {
                MessageBox.Show("Check thers is error","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void ChangeGendor(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pbPersonImage.Image = Resources.male;
            }
            else
            {
                pbPersonImage.Image = Resources.female;
            }

        }

        private void VaildateEmptyOrNot(object sender, CancelEventArgs e)
        {
        TextBox text = (TextBox)sender;
            if (string.IsNullOrEmpty(text.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(text,"value is empty");
            }
            else
            {
                errorProvider1.SetError(text,null);
            }
        }

        private void VaildateEmail(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim()=="")
            {
                return;
            }
            if (!clsVaildation.VaildateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail,"Eamil Address Is not Vaild");
            }
            else
            {
                errorProvider1.SetError(txtEmail,null);
            }
        }

        private void VaildateNationalNo(object sender, CancelEventArgs e)
        {
            if (txtNationalNo.Text.Trim()!=_person.NationalNo&&clsPerson.IsNationalNoExist(txtNationalNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo,"National No is used by another user");
            }
            else
            {
                errorProvider1.SetError(txtNationalNo,null);
            }
        }

        private void SaveImage(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //"Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string ImagePath = openFileDialog1.FileName;
                pbPersonImage.ImageLocation = ImagePath;
                pbPersonImage.Load(ImagePath);
                llRemoveImage.Visible = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            if (rbMale.Checked)
                pbPersonImage.Image = Resources.male;
            else
                pbPersonImage.Image = Resources.female;
            
            llRemoveImage.Visible = false;
       
        }
    }
}
