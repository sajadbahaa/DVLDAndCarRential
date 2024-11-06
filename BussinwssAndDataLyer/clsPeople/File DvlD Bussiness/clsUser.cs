using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace clsPeople
{
    public class clsUser
    { 
        
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsPerson PersonInfo;
        enum enMode { add = 1,update =2}
        private enMode _Mode;
        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            Username = "";
            Password = "";
            IsActive = false;
            _Mode = enMode.add;
        }
        
    private clsUser(int UserID,int PersonID,string Username,string Password,bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;
            PersonInfo = clsPerson.FindByPersonID(this.PersonID);
            _Mode = enMode.update;
        }
        // public clsUser(int UserID, int PersonID, string Username, string Password, bool IsActive)
        //{
        //    this.UserID = UserID;
        //    this.PersonID = PersonID;
        //    this.Username = Username;
        //    this.Password = Password;
        //    this.IsActive = IsActive;
            
        //}
        public static clsUser FindByUsernameAndPassword(string Username,string  Password)
        {
            int UserID = -1,PersonID = -1;
            bool IsActive = false;
            if (dtUsers.Find(ref UserID, ref PersonID, Username, Password, ref IsActive))
            {
                return new clsUser(UserID,PersonID,Username,Password,IsActive);
            }
            else
            {
                return null;
            }
        }
        static public bool IsUserExist(string Username)
        {
            return (dtUsers.IsUserExist(Username));
        }
        public bool IsUserActive()
        {
            return this.IsActive;
        }
    public static clsUser FindByUserID(int UserID)
        {
            int PersonID = -1;
            string Username = "", Password = "";
            bool IsActive = false;
            if (dtUsers.Find(UserID, ref PersonID,ref Username,ref  Password,ref IsActive))
            {
                return new clsUser(UserID, PersonID, Username, Password,IsActive);
            }
            else
            {

                return null;
            }
        }
        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID  = -1;
            string Username = "", Password = "";
            bool IsActive = false;
            if (dtUsers.Find(ref UserID, PersonID, ref Username, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            }
            else
            {

                return null;
            }
        }
        private bool _Add()
        {
            this.UserID = dtUsers.Add(this.PersonID, this.Username, this.Password, this.IsActive);
            return this.UserID > -1;
                
        }
        private bool _Update()
        {
            return dtUsers.Update(this.UserID, this.PersonID, this.Username, this.Password, this.IsActive);
        }
        public static bool Delete(int UserID)
        {
            return (dtUsers.Delete(UserID));
        }
       public bool Save()
        {
            switch (_Mode) 
            {
                case enMode.add:
                    if (_Add())
                    {
                        _Mode = enMode.update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.update:
                    return _Update();
            }
            return false;

        }
        public static DataTable GetAllUsers()
        {
            return (dtUsers.GetAllUsers());
        }
       
        
        public static bool IsPersonIDFollowedForUser(int PersonID)
        {
            return (dtUsers.IsPersonIDExistInUsers(PersonID));
        }
        public bool ChangePassword(string Password)
        {
            bool UpdatePassord = dtUsers.ChangePassword(this.UserID,Password);
            if (!UpdatePassord)
                return false;
            // if it not false;
            else
                return true;
        }
    }
}
