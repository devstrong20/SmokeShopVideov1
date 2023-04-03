//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.IO;

//using System.IO;
//using System.Reflection;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Runtime.InteropServices;
//using Microsoft.Win32;
//using System.Threading.Tasks;
//using System.Text.RegularExpressions;
//using System.Net.Http;
//using Newtonsoft.Json;
//using System.Diagnostics;
//using System.Web.Mvc;
//using static SmokeShopVideo.VSVshopHelper;
//using Windows.UI.Popups;
//using Windows.UI.Xaml.Controls;

//namespace SmokeShopVideo
//{

//    [ComVisibleAttribute(true)]

//    public partial class Form2 : Form
//    {
//        List<string> FilteredVideos = new List<string>();
//        FolderBrowserDialog br = new FolderBrowserDialog();
//        int CurrentFile = 0;
//        public Form2()
//        {
//            InitializeComponent();
//        }

//        private void LoadDirectory(object sender, EventArgs e)
//        {
//            MediaPlayer.Ctlcontrols.stop();
//            if (FilteredVideos.Count > 1)
//            {
//                FilteredVideos.Clear();
//                FilteredVideos = null;

//                ListOfVideos.Items.Clear();
//                CurrentFile = 0;
//            }

//            DialogResult result = br.ShowDialog();
//            if (result == DialogResult.OK)
//            {
//                FilteredVideos = Directory.GetFiles(br.SelectedPath, "*.*").Where(files => files.ToLower().EndsWith("mp4")).ToList();
//            }

//            LoadPlayList();

//        }

//        private void LoadNewPlaylist()
//        {
//            FilteredVideos = Directory.GetFiles("Directory").Where(files => files.ToLower().EndsWith("mp4")).ToList();
//            LoadPlayList();
//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {
//            LoadNewPlaylist();
//        }
//        private void LoadPlayList()
//        {
//            MediaPlayer.currentPlaylist = MediaPlayer.newPlaylist("Playlist", "");
//            playlistCollection.remove("myplaylist");  
//            foreach (string videos in FilteredVideos)
//            {
//                MediaPlayer.currentPlaylist.appendItem(MediaPlayer.newMedia(videos));
//                ListOfVideos.Items.Add(videos);
//            }


//        }

//        private void PlayFile(string url)
//        {
//            MediaPlayer.URL = url;
//        }

//        private void ShowLabel(Label name)
//        {
//            string file = Path.GetFileName(ListOfVideos.SelectedItem.ToString());
//            name.Text = "Current Playing: " + file;
//        }



//        private void StateChangeEvent(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
//        {
//            switch (e.newState)
//            {
//                case 0:    // Undefined
//                    duration.Text = "Undefined";
//                    break;

//                case 1:    // Stopped
//                    duration.Text = "Stopped";
//                    //MediaPlayer.fullScreen = true;
//                    break;

//                case 2:    // Paused
//                    duration.Text = "Paused";

//                    break;

//                case 3:    // Playing
//                    duration.Text = "Playing";
//                    MediaPlayer.fullScreen = true;
//                    break;

//                case 4:    // ScanForward
//                    duration.Text = "ScanForward";
//                    //MediaPlayer.fullScreen = true;
//                    break;

//                case 5:    // ScanReverse
//                    duration.Text = "ScanReverse";
//                    break;

//                case 6:    // Buffering
//                    duration.Text = "Buffering";
//                    break;

//                case 7:    // Waiting
//                    duration.Text = "Waiting";
//                    break;

//                case 8:    // MediaEnded
//                    duration.Text = "MediaEnded";
//                    if (CurrentFile >= FilteredVideos.Count - 1)
//                    {
//                        CurrentFile = 0;
//                    }
//                    else
//                    {
//                        CurrentFile += 1;
//                    }

//                    ListOfVideos.SelectedIndex = CurrentFile;
//                    ShowLabel(FileName);
//                    break;

//                case 9:    // Transitioning
//                    duration.Text = "Transitioning";
//                    break;

//                case 10:   // Ready
//                    duration.Text = "Ready";
//                    //MediaPlayer.fullScreen = true;
//                    timer1.Start();
//                    break;

//                case 11:   // Reconnecting
//                    duration.Text = "Reconnecting";
//                    break;

//                case 12:   // Last
//                    duration.Text = "Last";
//                    break;

//                default:
//                    duration.Text = ("Unknown State: " + e.newState.ToString());
//                    break;
//            }
//        }

//        private void MediaPlayer_Enter(object sender, EventArgs e)
//        {

//        }

//        private void PlayList(object sender, EventArgs e)
//        {
//            CurrentFile = ListOfVideos.SelectedIndex;
//            PlayFile(ListOfVideos.SelectedItem.ToString());
//            ShowLabel(FileName);
//        }



//        private void label1_Click(object sender, EventArgs e)
//        {

//        }

//        private void label1_Click_1(object sender, EventArgs e)
//        {

//        }

//        private void TimerEvent(object sender, EventArgs e)
//        {
//            MediaPlayer.Ctlcontrols.play();
//            timer1.Stop();
//        }

//        private void Exit(object sender, EventArgs e)
//        {
//            Application.Exit();
//        }



//    }
//    public partial class Form1 : Form
//    {

//        private readonly pubsEntities2 pubsEntities = new pubsEntities2();
//        HttpClient httpClient = new HttpClient();
//        Random rnd = new Random();
//        List<VSVshopHelper.VSVShopVideos> VideosList = new List<VSVshopHelper.VSVShopVideos>();

//        List<int> PlayedEntertaimentVideosList = new List<int>();
//        List<int> PlayedIntrosVideosList = new List<int>();

//        public Form1()
//        {
//            this.WindowState = FormWindowState.Maximized;
//            InitializeComponent();
//            //webView1.ScriptNotify += webView1_ScriptNotify;
//            //this.FormBorderStyle = FormBorderStyle.None;
//        }
//        public static string userid = "";
//        public static int AccountId = 0;
//        public void getFulscreen()
//        {
//            Form1 f = new Form1();
//            f.TopMost = true;
//            //f.FormBorderStyle = FormBorderStyle.None;
//            f.WindowState = FormWindowState.Maximized;

//        }
//        public void exitFulscreen()
//        {
//            Form1 ff = new Form1();
//            ff.TopMost = false;

//            ff.WindowState = FormWindowState.Normal;

//        }
//        private void Form1_Load(object sender, EventArgs e)
//        {
//            string FilePath = ConfigurationManager.AppSettings["LogPath"];
//            //string fileName = @"C:\Temp\SmSpVimeo\Vimeo\dontDelete3.txt";
//            var uid = "";
//            uid = File.ReadAllText(FilePath);
//            char[] separators = new char[] { ' ', '$' };

//            string[] subs = uid.Split(separators, StringSplitOptions.RemoveEmptyEntries);

//            userid = subs[0];
//            var accid = subs[1].ToString();
//            accid = accid.Substring(0, accid.Length - 2);
//            AccountId = Int16.Parse(accid);
//            Assembly assembly = Assembly.GetExecutingAssembly();
//            StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("SmokeShopVideo.HTML.htm"));
//            var data = reader.ReadToEnd();
//            webView1.NavigateToString(data);

//            webView1.ContainsFullScreenElementChanged += (obj, args) =>
//            {
//                this.FullScreen = webView1.ContainsFullScreenElement;
//            };
//        }

//        private bool fullScreen = false;
//        [DefaultValue(false)]
//        public bool FullScreen
//        {
//            get { return fullScreen; }
//            set
//            {
//                fullScreen = value;
//                if (value)
//                {
//                    this.WindowState = FormWindowState.Normal;
//                    FormBorderStyle = FormBorderStyle.None;
//                    WindowState = FormWindowState.Maximized;
//                }
//                else
//                {
//                    this.Activate();
//                    this.FormBorderStyle = FormBorderStyle.Sizable;
//                }
//            }
//        }


//        public int GetRandomNumber(int maxLength)
//        {
//            Random rnd = new Random();
//            int random = rnd.Next(maxLength - 1);
//            return random;
//        }
//        public int GetRandomNumber(int minValue, int maxLength)
//        {
//            Random rnd = new Random();
//            int random = rnd.Next(minValue, maxLength - 1);
//            return random;
//        }
//        public string GetVimeoVideoId(string url)
//        {
//            string vimeoVideoRegex = "(.*)(.com/)(.*)";
//            string resp = Regex.Replace(url, vimeoVideoRegex, "$3");
//            return resp.Replace("/", "?h=");
//            //return resp;
//        }

//        public string SavePlaysVideos(List<VSVShopVideos> VideosList)// public string SavePlaysVideos( [FromBody]List<VSVShopVideos> VideosList)
//        {
//            try
//            {
//                foreach (var resp in VideosList)
//                {
//                    if (resp.VSVAccountID != null)
//                    {
//                        var vsvPlayObj = new VSVPlay
//                        {
//                            VSVAccountID = (int)resp.VSVAccountID,
//                            VidID = (int)resp.VidId,
//                            PlayTimeStamp = resp.PlayTimeStamp,
//                            VSVLocationID = 0,
//                        };
//                        pubsEntities.VSVPlays.Add(vsvPlayObj);
//                        pubsEntities.SaveChanges();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            return "";
//        }

//        [HttpPost]
//        public string GetEntertainmentVideos(int loopIndex)
//        {
//            VideosList = new List<VSVShopVideos>();
//            int accountId = AccountId;
//            try
//            {
//                // VsvShop Entertainment video //
//                var countEntertainment = pubsEntities.VSVEntertainmentVideos.Count();
//                if (countEntertainment > 0)
//                {
//                    var VsventertainmentVideo = pubsEntities.VSVEntertainmentVideos.ToList().ElementAt(GetRandomNumber(countEntertainment));
//                    if (VsventertainmentVideo != null)
//                    {
//                        var VsventertainmentVideosObj = new VSVshopHelper.VSVShopVideos
//                        {
//                            Url = VsventertainmentVideo.URL,
//                            VideoId = GetVimeoVideoId(VsventertainmentVideo.URL)
//                        };
//                        VideosList.Add(VsventertainmentVideosObj);
//                    }
//                }
//                // VsvShop Intro video //
//                var countIntros = pubsEntities.VSVShopIntroes.Where(x => x.VSVAccountID == accountId).Count();
//                if (countIntros > 0)
//                {
//                    int respRandomNumIntro = GetRandomNumber(countIntros);
//                    var VsvshopIntro = pubsEntities.VSVShopIntroes.Where(x => x.VSVAccountID == accountId).ToList().ElementAt(respRandomNumIntro);
//                    if (VsvshopIntro != null)
//                    {
//                        var VsvshopIntrosvideoId = GetVimeoVideoId(VsvshopIntro.IntroURL);
//                        var VsvshopIntrosObj = new VSVshopHelper.VSVShopVideos
//                        {
//                            Url = VsvshopIntro.IntroURL,
//                            VideoId = VsvshopIntrosvideoId
//                        };
//                        VideosList.Add(VsvshopIntrosObj);
//                        PlayedIntrosVideosList.Add(respRandomNumIntro);
//                    }
//                }
//                // VsvShop prod video //
//                var countProdvideo = pubsEntities.VSVaccountprodvideos.Where(x => x.VSVAccountID == accountId).Count();
//                if (countProdvideo > 0)
//                {
//                    int respRandomNumProdFirst = GetRandomNumber(1, countProdvideo / 3);
//                    var prodVideo1 = GetProdVideos(accountId, respRandomNumProdFirst);
//                    if (prodVideo1 != null)
//                        VideosList.Add(prodVideo1);
//                    int respRandomNumProdSecond = GetRandomNumber((countProdvideo / 3) + 1, countProdvideo / 2);
//                    var prodVideo2 = GetProdVideos(accountId, respRandomNumProdSecond);
//                    if (prodVideo2 != null)
//                        VideosList.Add(prodVideo2);
//                    int respRandomNumProdThird = GetRandomNumber((countProdvideo / 2) + 1, countProdvideo);
//                    var prodVideo3 = GetProdVideos(accountId, respRandomNumProdThird);
//                    if (prodVideo3 != null)
//                        VideosList.Add(prodVideo3);
//                }
//                // VsvShop outro video //
//                var countOutros = pubsEntities.VSVShopOutroes.Where(x => x.VSVAccountID == accountId).Count();
//                if (countOutros > 0)
//                {
//                    int respRandomNumOutro = GetRandomNumber(countOutros);
//                    var VsvshopOutros = pubsEntities.VSVShopOutroes.Where(x => x.VSVAccountID == accountId).ToList().ElementAt(respRandomNumOutro);
//                    if (VsvshopOutros != null)
//                    {
//                        var VsvshopOutrosObj = new VSVshopHelper.VSVShopVideos
//                        {
//                            Url = VsvshopOutros.OutroURL,
//                            VideoId = GetVimeoVideoId(VsvshopOutros.OutroURL)
//                        };
//                        VideosList.Add(VsvshopOutrosObj);
//                    }
//                }
//                var objDTO = new VSVshopHelper.VSVShopVideosDTO
//                {
//                    VideosLists = VideosList,
//                    LoopEnded = false
//                };

//                return JsonConvert.SerializeObject(objDTO);
//            }
//            catch (Exception ex)
//            {
//                Debug.WriteLine(ex);
//                return null;
//            }
//        }
//        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
//        {

//        }
//        public VSVshopHelper.VSVShopVideos GetProdVideos(int accountIdd, int randomNum)
//        {

//            var Vsvaccountprodvideos = pubsEntities.VSVaccountprodvideos.Where(x => x.VSVAccountID == accountIdd).ToList().ElementAt(randomNum);
//            if (Vsvaccountprodvideos != null)
//            {
//                var VsvaccountprodvideosvideoId = GetVimeoVideoId(Vsvaccountprodvideos.URL);
//                var VsvaccountprodvideosObj = new VSVshopHelper.VSVShopVideos
//                {
//                    VidId = Vsvaccountprodvideos.VidID,
//                    VSVAccountID = Vsvaccountprodvideos.VSVAccountID,
//                    PlayTimeStamp = DateTime.Now,
//                    Url = Vsvaccountprodvideos.URL,
//                    VideoId = VsvaccountprodvideosvideoId
//                };
//                return VsvaccountprodvideosObj;
//            }
//            return null;
//        }
//        public string getVideoIds()
//        {
//            var countEntertainment = pubsEntities.VSVEntertainmentVideos.ToList();
//            //var constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbVimeo;User ID=sa;Password=sa";
//            var constring = ConfigurationManager.ConnectionStrings["vimeocs"].ConnectionString;
//            SqlConnection con = new SqlConnection(constring);
//            SqlCommand selectvideoids = new SqlCommand("Select URL from VSVProducts", con);
//            DataTable dt = new DataTable();
//            con.Open();
//            SqlDataReader selectedVids = selectvideoids.ExecuteReader();
//            dt.Load(selectedVids);
//            con.Close();
//            var ids = new List<string>();
//            //var ids = new object();
//            foreach (DataRow row in dt.Rows)
//            {
//                ids.Add(Convert.ToString(row["URL"]));
//            }
//            List<string> videoids = ids.ConvertAll<string>(x => x.ToString());
//            //String.Join(", ", videoids);
//            var idssss = String.Join(", ", videoids);
//            //Console.WriteLine(String.Join(", ", videoids));
//            //var videoids = dt.Rows;
//            //string[] videoids = new string[] { "590305554", "36319428", "95212995", "67423133", "131484417" };
//            //int[] videoids = { 590305554, 36319428, 95212995, 67423133, 131484417 };
//            //string test = "1323";
//            return idssss;
//        }

//        public string getStartTime()
//        {
//            DayOfWeek wk = DateTime.Today.DayOfWeek;
//            var starttime = "";
//            switch (wk)
//            {
//                case DayOfWeek.Monday:
//                    starttime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.MonStart).FirstOrDefault();
//                    break;
//                case DayOfWeek.Tuesday:
//                    starttime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.TueStart).FirstOrDefault();
//                    break;
//                case DayOfWeek.Wednesday:
//                    starttime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.WedStart).FirstOrDefault();
//                    break;
//                case DayOfWeek.Thursday:
//                    starttime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.ThurStart).FirstOrDefault();
//                    break;
//                case DayOfWeek.Friday:
//                    starttime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.FriStart).FirstOrDefault();
//                    break;
//                case DayOfWeek.Saturday:
//                    starttime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.SatStart).FirstOrDefault();
//                    break;
//                case DayOfWeek.Sunday:
//                    starttime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.SunStart).FirstOrDefault();
//                    break;
//            }
//            return starttime;
//        }
//        public string getEndTime()
//        {
//            DayOfWeek wk = DateTime.Today.DayOfWeek;
//            var stoptime = "";
//            switch (wk)
//            {
//                case DayOfWeek.Monday:
//                    stoptime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.MonStop).FirstOrDefault();
//                    break;
//                case DayOfWeek.Tuesday:
//                    stoptime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.TueStop).FirstOrDefault();
//                    break;
//                case DayOfWeek.Wednesday:
//                    stoptime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.WedStop).FirstOrDefault();
//                    break;
//                case DayOfWeek.Thursday:
//                    stoptime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.ThurStop).FirstOrDefault();
//                    break;
//                case DayOfWeek.Friday:
//                    stoptime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.FriStop).FirstOrDefault();
//                    break;
//                case DayOfWeek.Saturday:
//                    stoptime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.SatStop).FirstOrDefault();
//                    break;
//                case DayOfWeek.Sunday:
//                    stoptime = pubsEntities.VSVAccounts.Where(x => x.UserID == userid).Select(x => x.SunStop).FirstOrDefault();
//                    break;
//            }
//            return stoptime;
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            this.Close();
//            NewDateScreen newDateScreen = new NewDateScreen();
//            newDateScreen.Show();
//        }

//        private void button2_Click(object sender, EventArgs e)
//        {
//            Application.Exit();
//        }
//        public void Exit()
//        {
//            Application.Exit();
//        }
//        public async Task openDateScreen()
//        {
//            this.Close();
//            NewDateScreen newDateScreen = new NewDateScreen();
//            newDateScreen.Show();
//            //updated
//        }

//        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
//        {

//        }

//        private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
//        {

//        }

//        public string entVideoResponse = "";
//        private void webView1_DOMContentLoaded(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlDOMContentLoadedEventArgs e)
//        {
//            webView1.InvokeScript("getloopVideos", new string[] { "0" });
//        }

//        private void webView1_ScriptNotify(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlScriptNotifyEventArgs e)
//        {
//            string jsScriptValue = "";
//            if (e.Value.Contains("___"))
//            {
//                var key = e.Value.Split(new string[] { "___" }, StringSplitOptions.None)[0];
//                jsScriptValue = e.Value.Split(new string[] { "___" }, StringSplitOptions.None)[1];
//                if (key == "st")
//                {
//                    var st = getStartTime();
//                    webView1.InvokeScript("GetloopVideosReponse", new string[] { st });
//                }
//                else if (key == "et")
//                {

//                }
//                else if (key == "sp")
//                {
//                    List<VSVShopVideos> tmp = JsonConvert.DeserializeObject<List<VSVShopVideos>>(jsScriptValue);
//                    SavePlaysVideos(tmp);
//                    webView1.InvokeScript("GetloopVideosReponse", new string[] { jsScriptValue });
//                }
//            }
//            else
//            {
//                entVideoResponse = "-1";
//                var stime = getStartTime();
//                var etime = getEndTime();
//                var startTime = DateTimeOffset.Parse(stime).UtcDateTime;
//                var endTime = DateTimeOffset.Parse(etime).UtcDateTime;
//                //var startTime = DateTime.Parse(stime);
//                //var endTime = DateTime.Parse(etime);

//                if (DateTime.UtcNow >= startTime &&
//                    DateTime.UtcNow <= endTime)
//                {
//                    jsScriptValue = e.Value;
//                    entVideoResponse = GetEntertainmentVideos(Int16.Parse(jsScriptValue));
//                }
//                webView1.InvokeScript("GetloopVideosReponse", new string[] { entVideoResponse });

//            }


//        }

//        async void webView1_ScriptNotify(object sender, NotifyEventArgs e)
//        {
//            var jsScriptValue = e.Value;
//            MessageDialog msg = new MessageDialog(jsScriptValue);
//            var res = await msg.ShowAsync();

//        }

//        public void callme()
//        {
//            int a = 1;
//        }

//        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
//        {
//            webView1.Dispose();
//        }
//    }



//}
