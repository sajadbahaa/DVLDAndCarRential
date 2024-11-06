using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Global_Classes
{
    public class clsUtilize
    {
        //D:\Projects\DvlcWindows
        public static string GenrateGuid()
        {
            Guid newGuid = Guid.NewGuid();
            return newGuid.ToString();
}
        public static string ReplaceFileNameWithGuid(string SourceFile)
        {
            // File name is path of photo that you selected 
            string FileName = SourceFile;
            // we will define File info to get extension 
            FileInfo fi = new FileInfo(FileName);
            string extn = fi.Extension;
            return GenrateGuid() + extn;
        }
        public static bool CreateFolderifDoesnotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (IOException iox)
                {
                    MessageBox.Show("Error"+iox.Message);
                    return false; 
                }
            }
            return true;
        }
        public static bool CopyImagetoProjectImagesFolder(ref string SourceFile)
        {
            string DestinationFolder = @"D:\Projects\ProjectDrivingLicense\DvlcWindows\Images\";
            if (!CreateFolderifDoesnotExist(DestinationFolder))
            {
                return false;
            }
            string DestinationFile = DestinationFolder + ReplaceFileNameWithGuid(SourceFile);
            try
            {
                File.Copy(SourceFile,DestinationFile,true);
            }
            catch (IOException iox)
            {
                MessageBox.Show("Error"+iox.Message);
                return false;
            }
            SourceFile = DestinationFile;
            return true;
        }
public static bool HandelImage(ref string Image,PictureBox pb)
        {
            if (Image!=pb.ImageLocation)
            {
                if (Image!=null)
                {
                    File.Delete(Image);
                    Image = null;
                }
                if (pb.ImageLocation!=null)
                {
                    string ImagePath = pb.ImageLocation;
                    if (CopyImagetoProjectImagesFolder(ref ImagePath))
                    {
                        pb.ImageLocation = ImagePath;
                        Image = pb.ImageLocation;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
