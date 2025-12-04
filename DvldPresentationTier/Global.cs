using DvldBusinessTier;
using System;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DvldProject
{
    internal class Global
    {

        struct sFileInfo
        {
            public string FileName;
            public string FolderPath;
            public string FilePath;
        }

        static sFileInfo FileInformation;

        static private void fillStructFileInfo()
        {
            FileInformation.FileName = "loginInfo.txt";
            FileInformation.FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); 
            FileInformation.FilePath = Path.Combine(FileInformation.FolderPath, FileInformation.FileName) ;
        }

        static public Users USER = new Users();

        static public void setCredential( string Text )
        {
            fillStructFileInfo();
            File.WriteAllText(FileInformation.FilePath, Text);
        }

        static public void DeleteFile()
        {
            if(File.Exists(FileInformation.FilePath))
                File.Delete(FileInformation.FilePath);
        }

        static public bool getCredential(ref string username , ref string password)
        {
            fillStructFileInfo();

            if (File.Exists(FileInformation.FilePath))
            {

                string savedText = File.ReadAllText(FileInformation.FilePath);

                string[] parts = savedText.Split(new string[] { "#//#" }, StringSplitOptions.None);

                if (parts.Length >= 2)
                {
                    username = parts[0];
                    password = parts[1];
                }

                return true;

            }
            username = "";
            password = "";
            return false;
        }

    }
}
