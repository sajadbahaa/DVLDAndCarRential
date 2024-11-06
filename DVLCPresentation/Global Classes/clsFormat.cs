using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Global_Classes
{
    public class clsFormat
    {
    public static string DateToShortString(DateTime d1)
        {
            return d1.ToString("dd/MMM/yyyyy");
        }
        public static string ConverGenericToString<T>(T text)
        {
            return text.ToString();
        }

        public static T ConvetStringToDataType<T>(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return default(T);
            }
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException($"Cannot convert '{value}' to type {typeof(T).Name}");
            }
            catch (FormatException)
            {
                throw new FormatException($"Invalid format for converting '{value}' to type {typeof(T).Name}");
            }
            catch (Exception ex)
            {

                 throw new Exception($"An error occurred while converting '{value}' to type {typeof(T).Name}: {ex.Message}"); ;
            }


        }
        public static string FormatString(string Format= "???")
        {
            return Format;
        }
    }
}
