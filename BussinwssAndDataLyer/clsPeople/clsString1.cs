using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsString
{
    public class clsString1
    {
      

        static  public int FindCharacterPosition(char c, string s, ref int pos)
            {
                try
                {
                    if (c == s.ElementAt(s.IndexOf(c)))
                    {
                        pos = s.IndexOf(c);
                        return pos;
                    }


                }
                catch (Exception ex)
                {
                   
                }
                return -1;
            }
        static public void GetString(string str, char delim, ref string Word1, ref string Word2)
        {
            int pos = 0;

            string word = "";
            while ((pos = clsString1.FindCharacterPosition(delim, str, ref pos)) != -1)
            {
                //str = str.Substring(0, pos);
                word = str.Substring(0, pos);
                if (word != " ")
                {
                    Word1 = word;
                }
                str = str.Remove(0, pos + Convert.ToString(delim).Length);
                pos = -1;
            }
            if (str != "")
            {
                Word2 = str;
            }




        }
    }
}
