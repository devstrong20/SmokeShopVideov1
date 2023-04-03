using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Reflection;
using Newtonsoft.Json;
using static SmokeShopVideo.VSVshopHelper;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Net.Http;
using AxWMPLib;
using WMPLib;
using System.Data.Common;
using System.Threading;
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications;

namespace SmokeShopVideo
{
    public partial class Form1 : Form
    {
        List <string> FilteredVideos = new List<string>();
        FolderBrowserDialog br = new FolderBrowserDialog();
        public static int count = 0;
        public static string videofilename = "";
        private readonly pubsEntities2 pubsEntities = new pubsEntities2();
        public static string userid = "";
        public static int AccountId = 0;
        public static string logFilePath = ConfigurationManager.AppSettings["LogPath2"];
        public static string Products = ConfigurationManager.AppSettings["Products"];
      //  public static string Logo = ConfigurationManager.AppSettings["Logo"];
        public static string IO = ConfigurationManager.AppSettings["IntroOutro"];
        public static string MusicV = ConfigurationManager.AppSettings["MusicV"];
        public static DateTime StartTime = DateTime.Now;
        public static DateTime EndTime = DateTime.Now;
        public static DateTime Day = DateTime.Today;
        public static string[] folderNames = { MusicV, IO, Products };
        public static List<string> existingFolders = new List<string>();

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;   
            MediaPlayer.uiMode = "full";
            MediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(PlayStateChange);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string FilePath = ConfigurationManager.AppSettings["LogPath"];
            //string fileName = @"C:\Temp\SmSpVimeo\Vimeo\dontDelete3.txt";
            
            var uid = "";
            uid = File.ReadAllText(FilePath);
            char[] separators = new char[] { ' ', '$' };

            string[] subs = uid.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            userid = subs[0];
            var accid = subs[1].ToString();
            accid = accid.Substring(0, accid.Length - 2);
            AccountId = Int16.Parse(accid);
            timer1.Start();
        }

        public string getStartTime()
        {
            DayOfWeek wk = DateTime.Today.DayOfWeek;
            var starttime = "";
            switch (wk)
            {
                case DayOfWeek.Monday:
                    starttime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.MonStart).FirstOrDefault();
                    break;
                case DayOfWeek.Tuesday:
                    starttime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.TueStart).FirstOrDefault();
                    break;
                case DayOfWeek.Wednesday:
                    starttime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.WedStart).FirstOrDefault();
                    break;
                case DayOfWeek.Thursday:
                    starttime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.ThurStart).FirstOrDefault();
                    break;
                case DayOfWeek.Friday:
                    starttime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.FriStart).FirstOrDefault();
                    break;
                case DayOfWeek.Saturday:
                    starttime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.SatStart).FirstOrDefault();
                    break;
                case DayOfWeek.Sunday:
                    starttime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.SunStart).FirstOrDefault();
                    break;
            }
            return starttime;
        }
        public string getEndTime()
        {
            DayOfWeek wk = DateTime.Today.DayOfWeek;
            var stoptime = "";
            switch (wk)
            {
                case DayOfWeek.Monday:
                    stoptime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.MonStop).FirstOrDefault();
                    break;
                case DayOfWeek.Tuesday:
                    stoptime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.TueStop).FirstOrDefault();
                    break;
                case DayOfWeek.Wednesday:
                    stoptime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.WedStop).FirstOrDefault();
                    break;
                case DayOfWeek.Thursday:
                    stoptime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.ThurStop).FirstOrDefault();
                    break;
                case DayOfWeek.Friday:
                    stoptime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.FriStop).FirstOrDefault();
                    break;
                case DayOfWeek.Saturday:
                    stoptime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.SatStop).FirstOrDefault();
                    break;
                case DayOfWeek.Sunday:
                    stoptime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.SunStop).FirstOrDefault();
                    break;
            }
            return stoptime;
        }







        private void PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            DateTime now = DateTime.UtcNow;

            if (e.newState == 3)
            {
              //  MediaPlayer.fullScreen = true;
                string fileName = Path.GetFileName(MediaPlayer.currentMedia.sourceURL);
                string path = Path.GetDirectoryName(MediaPlayer.currentMedia.sourceURL);
                string[] parts = fileName.Split('.');
                videofilename = parts[0];
                if (now >= StartTime && now <= EndTime && videofilename != "Logo" && path != MusicV && path != IO)
                {
                    SavePlaysVideos(videofilename);
                }
                try
                {

                    using (var pubsEntities = new pubsEntities2())
                    {
                        var stime = getStartTime();
                        var etime = getEndTime();
                        StartTime = DateTimeOffset.Parse(stime).UtcDateTime;
                        EndTime = DateTimeOffset.Parse(etime).UtcDateTime;
                    }
                }
                catch(Exception ex) 
                {
                    LogException(ex);
                }
            }

            else if(e.newState == 8)
            {
                if (now > StartTime && now < EndTime && videofilename == "Logo")
                {
                    new ToastContentBuilder().AddArgument("action", "viewConversation")
                            .AddText("Wake Up Time")
                            .AddText("Please Wait, We are Connecting!")
                            .Show();
                    MediaPlayer.settings.setMode("loop", false);
                    timer1.Start();
                }
            }

            else if(e.newState == 10)
            {
                timer1.Start();
            }
        }

        private void LoadNewPlaylist()
        {
            count = 0;
            //functionCalled = true;
            FilteredVideos.Clear();
            MediaPlayer.currentPlaylist.clear();
            FilteredVideos = GetEntertainmentVideos();
            var playlist = MediaPlayer.playlistCollection.newPlaylist("New Playlist"); // Create a new playlist
            foreach (string videoPath in FilteredVideos) // Add each video to the playlist in the desired order
            {
                var media = MediaPlayer.newMedia(videoPath);
                playlist.appendItem(media);
            }
            MediaPlayer.currentPlaylist = playlist; // Set the current playlist to the new playlist
            //MediaPlayer.Ctlcontrols.play();
        }

        public void LoadLogo()
        {
            MediaPlayer.currentPlaylist.clear();
            MediaPlayer.settings.setMode("loop",true);
            var playlist = MediaPlayer.playlistCollection.newPlaylist("New Playlist");
            string imagePath = Path.Combine(Application.StartupPath, "Logo.jpeg");
            playlist.appendItem(MediaPlayer.newMedia(imagePath));
            MediaPlayer.currentPlaylist = playlist;
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            
            foreach (string folderName in folderNames)
            {

                if (Directory.Exists(folderName))
                {
                    existingFolders.Add(folderName);
                }
            }
            if (existingFolders.Count > 2)
            {
                if (existingFolders.Count == 3)
                {
                    new ToastContentBuilder()
                    .AddArgument("action", "viewConversation")
                    .AddText("Directories Found")
                    .AddText("Please Wait, While we Connect :).")
                    .Show();

                }
                try
                {

                    using (var pubsEntities = new pubsEntities2())
                    {
                        var stime = getStartTime();
                        var etime = getEndTime();

                        StartTime = DateTimeOffset.Parse(stime).UtcDateTime;
                        EndTime = DateTimeOffset.Parse(etime).UtcDateTime;
                        DateTime now = DateTime.UtcNow;
                        if (now > StartTime && now < EndTime)
                        {
                            MediaPlayer.settings.setMode("loop", false);
                            LoadNewPlaylist();
                        }
                        else if (now < StartTime || now > EndTime && videofilename != "Logo")
                        {
                            LoadLogo();
                            new ToastContentBuilder().AddArgument("action", "viewConversation")
                            .AddText("Sleep Mode")
                            .AddText("App is Sleeping :).")
                            .Show();
                        }
                        timer1.Stop();
                        MediaPlayer.Ctlcontrols.play();
                        successEx();
                    }
                }

                catch (Exception es)
                {
                    timer1.Stop();
                    LogException(es);
                    LoadNewPlaylist();
                    MediaPlayer.Ctlcontrols.play();
                }
            }
            else
            {
                timer1.Stop();
                existingFolders.Clear();
                DialogResult dr = MessageBox.Show("Directories not Found, Kindly check folders name or directory!\n\nThe PATHS should be as follow:\n\n" + "1.Music Videos Folder: " + MusicV + "\n2.Intro / Outro Folder: " + IO + "\n3.Products Videos Folder: " + Products + "\n\nTo Restart press 'Retry' and to Exit press 'Cancel'", "Directory Not Found", MessageBoxButtons.RetryCancel);
                if (dr == DialogResult.Retry)
                {
                    timer1.Start();
                }
                else
                {
                    Application.Exit();
                }
            }
            
        }
        public string SavePlaysVideos(string VideoID)
        {
            try
            {
                if (AccountId != 0)
                {
                    var vsvPlayObj = new VSVPlay
                    {
                        VSVAccountID = AccountId,
                        VidID = Int16.Parse(VideoID),
                        PlayTimeStamp = DateTime.Now,
                        VSVLocationID = 0,
                    };
                    pubsEntities.VSVPlays.Add(vsvPlayObj);
                    pubsEntities.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                LogException(ex);
                return "";
            }
            return "";
        }
        public List<string> GetEntertainmentVideos() 
        {
            var VideosList = new List<String>();
            int accountId = AccountId;
            try
            {
                using (var pubsEntities = new pubsEntities2()) 
                {
                    var Account = pubsEntities.VSVAccounts.FirstOrDefault(x => x.VSVAccountID == accountId);
                    var Music = Account.MusicVideoCount.ToString();
                    var Intros = Account.VideoCount.ToString();
                    var countProdvideo = pubsEntities.VSVaccountprodvideos.Where(x => x.VSVAccountID == accountId).Count();
                    var Outros = Account.VideoCount.ToString();
                    // VsvShop Entertainment video //

                    if (Music != "")
                    {
                        var countMusic = Int16.Parse(Music);
                        try
                        {
                            var respRandomNumMusic = GetRandomNumber(1, countMusic).ToString();
                            string[] files = Directory.GetFiles(MusicV)
                                     .Where(file => file.ToLower().EndsWith("mp4") && Path.GetFileNameWithoutExtension(file) == respRandomNumMusic)
                                        .ToArray();
                            string firstFile = files.FirstOrDefault();
                            if (!string.IsNullOrEmpty(firstFile) && File.Exists(firstFile))
                            {
                                VideosList.Add(firstFile);
                            }
                            else
                            {
                                LogException2(respRandomNumMusic , MusicV);
                            }
                        }
                        catch (Exception ex)
                        {
                            LogException(ex);
                        }
                    }
                    else
                    {
                        try
                        {
                            var respRandomNumMusic = GetRandomNumber(1, 170).ToString();
                            string[] files = Directory.GetFiles(MusicV)
                                     .Where(file => file.ToLower().EndsWith("mp4") && Path.GetFileNameWithoutExtension(file) == respRandomNumMusic)
                                        .ToArray();
                            string firstFile = files.FirstOrDefault();
                            if (!string.IsNullOrEmpty(firstFile) && File.Exists(firstFile))
                            {
                                VideosList.Add(firstFile);
                            }
                            else
                            {
                                LogException2(respRandomNumMusic, MusicV);
                            }
                        }
                        catch (Exception ex)
                        {
                            LogException(ex);
                            return null;
                        }   
                        

                    }

                    // VsvShop Intro video //

                    if (Intros != "")
                    {
                        var countIntros = Int16.Parse(Intros);
                        try
                        {
                            var respRandomNumIntro = GetRandomNumber(1, countIntros).ToString();
                            string[] files = Directory.GetFiles(IO)
                                   .Where(file => file.ToLower().EndsWith("mp4") && Path.GetFileNameWithoutExtension(file) == respRandomNumIntro)
                                     .ToArray();
                            string firstFile = files.FirstOrDefault();
                            if (!string.IsNullOrEmpty(firstFile) && File.Exists(firstFile))
                            {
                                VideosList.Add(firstFile);
                            }
                            else
                            {
                                LogException2(respRandomNumIntro, IO);
                            }
                        }
                        catch (Exception ex)
                        {
                            LogException(ex);
                            return null;
                        }

                    }
                    else
                    {
                        try 
                        {
                            var respRandomNumIntro = GetRandomNumber(1, 38).ToString();
                            string[] files = Directory.GetFiles(IO)
                                   .Where(file => file.ToLower().EndsWith("mp4") && Path.GetFileNameWithoutExtension(file) == respRandomNumIntro)
                                     .ToArray();
                            string firstFile = files.FirstOrDefault();
                            if (!string.IsNullOrEmpty(firstFile) && File.Exists(firstFile))
                            {
                                VideosList.Add(firstFile);
                            }
                            else
                            {
                                LogException2(respRandomNumIntro, IO);
                            }
                        }
                        catch (Exception ex)
                        {
                            LogException(ex);
                            return null;
                        }
                        

                    }


                    // VsvShop prod video //

                    if (countProdvideo > 0)
                    {
                        int respRandomNumProdFirst = GetRandomNumber(1, countProdvideo / 3);
                        var prodVideo1 = pubsEntities.VSVaccountprodvideos.Where(x => x.VSVAccountID == accountId).ToList().ElementAt(respRandomNumProdFirst);
                        if (prodVideo1 != null)
                        {
                            try
                            {
                                var pd1 = prodVideo1.VidID.ToString();
                                string[] files = Directory.GetFiles(Products)
                                     .Where(file => file.ToLower().EndsWith("mp4") && Path.GetFileNameWithoutExtension(file) == pd1)
                                     .ToArray();
                                string firstFile = files.FirstOrDefault();
                                if (!string.IsNullOrEmpty(firstFile) && File.Exists(firstFile))
                                {
                                    VideosList.Add(firstFile);
                                }
                                else
                                {
                                    LogException2(pd1, Products);
                                }
                            }
                            catch(Exception ex)
                            {
                                LogException(ex);
                                return null;
                            }

                        }

                        int respRandomNumProdSecond = GetRandomNumber((countProdvideo / 3) + 1, countProdvideo / 2);
                        var prodVideo2 = pubsEntities.VSVaccountprodvideos.Where(x => x.VSVAccountID == accountId).ToList().ElementAt(respRandomNumProdSecond);
                        if (prodVideo2 != null)
                        {
                            try 
                            {
                                var pd2 = prodVideo2.VidID.ToString();
                                string[] files = Directory.GetFiles(Products)
                                     .Where(file => file.ToLower().EndsWith("mp4") && Path.GetFileNameWithoutExtension(file) == pd2)
                                     .ToArray();
                                string firstFile = files.FirstOrDefault();
                                if (!string.IsNullOrEmpty(firstFile) && File.Exists(firstFile))
                                {
                                    VideosList.Add(firstFile);
                                }
                                else
                                {
                                    LogException2(pd2, Products);
                                }
                            }
                            catch(Exception ex)
                            {
                                LogException(ex);
                                return null;
                            }

                        }

                        int respRandomNumProdThird = GetRandomNumber((countProdvideo / 2) + 1, countProdvideo);
                        var prodVideo3 = pubsEntities.VSVaccountprodvideos.Where(x => x.VSVAccountID == accountId).ToList().ElementAt(respRandomNumProdThird);
                        if (prodVideo3 != null)
                        {
                            try
                            {
                                var pd3 = prodVideo3.VidID.ToString();
                                string[] files = Directory.GetFiles(Products)
                                      .Where(file => file.ToLower().EndsWith("mp4") && Path.GetFileNameWithoutExtension(file) == pd3)
                                      .ToArray();
                                string firstFile = files.FirstOrDefault();
                                if (!string.IsNullOrEmpty(firstFile) && File.Exists(firstFile))
                                {
                                    VideosList.Add(firstFile);
                                }
                                else
                                {
                                    LogException2(pd3, Products);
                                }

                            }
                            catch(Exception ex) 
                            {
                                LogException(ex);
                                return null;
                            }
                        }

                    }
                    // VsvShop outro video //

                    if (Outros != "")
                    {
                        var countOutros = Int16.Parse(Outros);
                        try
                        {
                            var respRandomNumOutro = GetRandomNumber(1, countOutros).ToString();
                            string[] files = Directory.GetFiles(IO)
                                     .Where(file => file.ToLower().EndsWith("mp4") && Path.GetFileNameWithoutExtension(file) == respRandomNumOutro)
                                     .ToArray();
                            string firstFile = files.FirstOrDefault();
                            if (!string.IsNullOrEmpty(firstFile) && File.Exists(firstFile))
                            {
                                VideosList.Add(firstFile);
                            }
                            else
                            {
                                LogException2(respRandomNumOutro, IO);
                            }
                        }
                        catch (Exception ex)
                        {
                            LogException(ex);
                            return null;
                        }

                    }
                    else
                    {
                        try
                        {
                            var respRandomNumOutro = GetRandomNumber(1, 38).ToString();
                            string[] files = Directory.GetFiles(IO)
                                     .Where(file => file.ToLower().EndsWith("mp4") && Path.GetFileNameWithoutExtension(file) == respRandomNumOutro)
                                     .ToArray();
                            string firstFile = files.FirstOrDefault();
                            if (!string.IsNullOrEmpty(firstFile) && File.Exists(firstFile))
                            {
                                VideosList.Add(firstFile);
                            }
                            else
                            {
                                LogException2(respRandomNumOutro, IO);
                            }
                        }
                        catch  (Exception ex)
                        {
                            LogException(ex);
                            return null;
                        }
                        
                    }
                    return VideosList;
                    

                }
 
            }

            catch (Exception ex)
            {
                LogException(ex);
                return GetEntertainmentVideos2();
            }
        }

        private void successEx()
        {
            if (!File.Exists(logFilePath))
            {
                using (StreamWriter sw = File.CreateText(logFilePath))
                {
                    sw.WriteLine("Log file created at " + DateTime.Now);
                    sw.WriteLine("DB Connection Successful!");
                    sw.WriteLine($"Timestamp: {DateTime.Now}");
                    sw.WriteLine(new string('-', 50));
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine("DB Connection Successful!");
                    sw.WriteLine($"Timestamp: {DateTime.Now}");
                    sw.WriteLine(new string('-', 50));
                }
            }
        }

        private void LogException2(string  i, string dir)
        {
            if (!File.Exists(logFilePath))
            {
                using (StreamWriter sw = File.CreateText(logFilePath))
                {
                    sw.WriteLine("Log file created at " + DateTime.Now);
                    
                    sw.WriteLine("Exception: Video File Does not Exists! ");
                    sw.WriteLine("Video ID:" + i);
                    sw.WriteLine("Video Directory:" + dir);
                    sw.WriteLine($"Timestamp: {DateTime.Now}");
                    sw.WriteLine(new string('-', 50));
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine("Exception: Video File Does not Exists! ");
                    sw.WriteLine("Video ID:" + i);
                    sw.WriteLine("Video Directory:" + dir);
                    sw.WriteLine($"Timestamp: {DateTime.Now}");
                    sw.WriteLine(new string('-', 50));
                }
            }
        }
        private void LogException(Exception ex)
        {
            try
            {
                if (!File.Exists(logFilePath))
                {
                    using (StreamWriter sw = File.CreateText(logFilePath))
                    {
                        sw.WriteLine("Log file created at " + DateTime.Now);
                        sw.WriteLine($"Exception: {ex.Message}");
                        sw.WriteLine($"StackTrace: {ex.StackTrace}");
                        sw.WriteLine($"Timestamp: {DateTime.Now}");
                        sw.WriteLine(new string('-', 50));
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(logFilePath, true))
                    {
                        sw.WriteLine($"Exception: {ex.Message}");
                        sw.WriteLine($"StackTrace: {ex.StackTrace}");
                        sw.WriteLine($"Timestamp: {DateTime.Now}");
                        sw.WriteLine(new string('-', 50));
                    }
                }
            }
            catch (Exception)
            {
                // Do nothing if the logging fails
            }
        }

        public List<string> GetEntertainmentVideos2()
        {
            try
            {
                var VideosList = new List<String>();
                var respRandomNumMusic = GetRandomNumber(1, 173).ToString();
                string[] file1 = Directory.GetFiles(MusicV)
                         .Where(file => file.ToLower().EndsWith("mp4") && Path.GetFileNameWithoutExtension(file) == respRandomNumMusic)
                            .ToArray();
                VideosList.Add(file1[0]);

                var respRandomNumIntro = GetRandomNumber(1, 38).ToString();
                string[] file2 = Directory.GetFiles(IO)
                        .Where(file => file.ToLower().EndsWith("mp4") && Path.GetFileNameWithoutExtension(file) == respRandomNumIntro)
                         .ToArray();
                VideosList.Add(file2[0]);

                var respRandomNumOutro = GetRandomNumber(1, 38).ToString();
                string[] files = Directory.GetFiles(IO)
                         .Where(file => file.ToLower().EndsWith("mp4") && Path.GetFileNameWithoutExtension(file) == respRandomNumOutro)
                         .ToArray();
                VideosList.Add(files[0]);
                return VideosList;
            }
            catch(Exception es)
            {
                LogException(es);
                return GetEntertainmentVideos();
            }
        }



        private void Exit(object sender, EventArgs e)
        {
            MediaPlayer.Ctlcontrols.stop(); 
            Application.Exit();

        }
       


       



        public int GetRandomNumber(int maxLength)
        {
            Random rnd = new Random();
            int random = rnd.Next(maxLength - 1);
            return random;
        }
        public int GetRandomNumber(int minValue, int maxLength)
        {
            Random rnd = new Random();
            int random = rnd.Next(minValue, maxLength - 1);
            return random;
        }

        private void APPEXIT(object sender, FormClosingEventArgs e)
        {
            MediaPlayer.Ctlcontrols.stop();
        }

        private void DefaultFolders(object sender, EventArgs e)
        {
           MessageBox.Show("1.Music Videos Folder : " + MusicV + "\n2.Intro/Outro Folder : " + IO + "\n3.Products Videos Folder : "+ Products,"Folders Directory",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void AboutUs(object sender, EventArgs e)
        {
            MessageBox.Show("420 Friendly Smoke Shop", "Smoke Shop Video", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
