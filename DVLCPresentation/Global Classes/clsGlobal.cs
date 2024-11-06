
using System.Data;
using System.Runtime.Remoting.Messaging;
using clsPeople;
using System.IO;
using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Text;
namespace Clobal
{
    public class clsGlobal
    {
        static public DateTime VaildityLength = clsSettings.VaildityLength;
        static public clsUser CurrentUser;

        
        static public bool DeleteRegister()
        {
            string UserName = "Username";
            string KeyPath = @"SOFTWARE\LoginDVLD";
            try
            {
                using (RegistryKey Keybase = 
                    RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey Key = Keybase.OpenSubKey(KeyPath,true))
                    {
                       
                        if (Key.GetValue(UserName)!=null)
                        {
                            Key.DeleteValue(UserName);
                            return true ;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Delete Register"+ex);
                return false;
            }
        }
        public static void RemmberMe(string Username)
        {
            // Specify the Registry key and path

            //string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\LoginDVLD";
             string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\LoginDVLD";

            string valueName = "Username";
            string valueData = Username;

            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, valueName, valueData, RegistryValueKind.String);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        static public bool _ReadDataFromRegistry(ref string Username)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\LoginDVLD";
            string ValueName1 = "Username";
            try
            {
                string value1 = Registry.GetValue(keyPath, ValueName1, null) as string;
                if (value1 != null)
                {
                    Username = value1;
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An Error Occured: {ex.Message}");
            }
            return false;
        }

        public static string EncryptMessageByHashing(StringBuilder str)
        {
            using (SHA256 sh256 = SHA256.Create())
            {
                byte[] bits = sh256.ComputeHash(Encoding.UTF8.GetBytes(str.ToString()));
                return BitConverter.ToString(bits).Replace("-", "").ToLower();
            }
        }
        public static string EncryptDataByHashing(string data)
        {
            using (SHA256 hash = SHA256.Create())
            {
                byte[] dt = hash.ComputeHash(Encoding.UTF8.GetBytes(data));
                return BitConverter.ToString(dt).Replace("-", "");
            }

        }
        

    }
} 


