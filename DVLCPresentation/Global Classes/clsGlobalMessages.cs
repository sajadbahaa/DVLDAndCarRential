using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRentail.Public_Classes
{
    public class clsGlobalMessages
    {
    static  public void Close(Form f)
        {
            f.Close();
        }

    static public void MessageNotImmplementedYet()
        {
            MessageBox.Show("Not Immplemented Yet");
        }
    static public void UpdateMessage()
        {
            MessageBox.Show("Updated Successfully");
        }
    static public void DeleteMessage()
        {
            MessageBox.Show("Deleted Successfully");
        }
    static public void AddMessage()
        {
            MessageBox.Show("Added Successfully");
        }
    static public void ErrorMessageAdded()
        {
            MessageBox.Show("Failed Adding Data");
            return;
        }
    static public void ErrorMessageUpdate()
        {
            MessageBox.Show("Failed Update Data");
            return;
        }
    static public void ErrorMessageFindByID()
        {
            MessageBox.Show("this ID not Found");
            return;
        }
        static public void Messages(string msg)
        {
            MessageBox.Show(msg);
            return;
        }

        static public void ErrorMessageIDExist()
        {
            MessageBox.Show("this ID not Exist");
        }
    

    static public bool  MessageDoyouWantDelete(Form frm)
        {

            if ((frm.DialogResult = MessageBox.Show("Do you want Delete ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
                return false ;

            return true;
        }
    static public void ErrorDeleteMessage()
        {
            MessageBox.Show("Failed Delete Record");
            return;
        }
        
    }
}
