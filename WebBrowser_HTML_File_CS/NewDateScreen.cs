using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmokeShopVideo
{
    public partial class NewDateScreen : Form
    {
        public NewDateScreen()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void NewDateScreen_Load(object sender, EventArgs e)
        {
            label6.Text = "Today is : ";
            DayOfWeek wk = DateTime.Today.DayOfWeek;
            label6.Text += wk;

        }
        public string getStartTime(string stime)
        {
            char[] delimiterChars = { ' ', ':' };
            string text = stime;
            string[] words = text.Split(delimiterChars);
            var hourr = words[0];
            int hour = int.Parse(hourr);
            var min = words[1];
            var aaaa = words[2];
            if (aaaa == "PM")
            {
                hour += 12;
            }
            string hourrr = hour.ToString();
            if (aaaa == "AM" && hour < 10)
            {
                hourrr = "0" + hourrr;
            }
            string startTime = hourrr + ":" + min;
            return startTime;

        }
        public string getEndTime(string etime)
        {
            char[] delimiterChars = { ' ', ':' };
            string textt = etime;
            string[] wordss = textt.Split(delimiterChars);
            var stophourr = wordss[0];
            int shour = int.Parse(stophourr);
            var minn = wordss[1];
            var pppp = wordss[2];
            if (pppp == "PM")
            {
                shour += 12;
            }
            string hourrrr = shour.ToString();
            string stopTime = hourrrr + ":" + minn;
            return stopTime;
        }


            private void button1_Click(object sender, EventArgs e)
        {
            //var userid = LoginScreen.vimeoUserId;
            string fileName = @"C:\Temp\SmSpVimeo\Vimeo\dontDelete3.txt";
            FileInfo fi = new FileInfo(fileName);
            var uid = "";
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";

                while ((s = sr.ReadLine()) != null)
                {
                    uid = s;
                }
            }
            char[] separators = new char[] { ' ', '$' };

            string[] subs = uid.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var userid = subs[0];
            var mstarttime = monStartDTP.Value.ToShortTimeString();//2:49 PM
            var mendtime = monEndDTP.Value.ToShortTimeString();
            var monStartTime = getStartTime(mstarttime);
            var monEndTime = getEndTime(mendtime);
            var tustarttime = tueStartDTP.Value.ToShortTimeString();//2:49 PM
            var tuendtime = tueEndDTP.Value.ToShortTimeString();
            var tueStartTime = getStartTime(tustarttime);
            var tueEndTime = getEndTime(tuendtime);
            var westarttime = wedStartDTP.Value.ToShortTimeString();//2:49 PM
            var weendtime = wedEndDTP.Value.ToShortTimeString();
            var wedStartTime = getStartTime(westarttime);
            var wedEndTime = getEndTime(weendtime);
            var thstarttime = thuStartDTP.Value.ToShortTimeString();//2:49 PM
            var thendtime = thuEndDTP.Value.ToShortTimeString();
            var thuStartTime = getStartTime(thstarttime);
            var thuEndTime = getEndTime(thendtime);
            var frstarttime = friStartDTP.Value.ToShortTimeString();//2:49 PM
            var frendtime = friEndDTP.Value.ToShortTimeString();
            var friStartTime = getStartTime(frstarttime);
            var friEndTime = getEndTime(frendtime);
            var sastarttime = satStartDTP.Value.ToShortTimeString();//2:49 PM
            var saendtime = satEndDTP.Value.ToShortTimeString();
            var satStartTime = getStartTime(sastarttime);
            var satEndTime = getEndTime(saendtime);
            var sustarttime = sunStartDTP.Value.ToShortTimeString();//2:49 PM
            var suendtime = sunEndDTP.Value.ToShortTimeString();
            var sunStartTime = getStartTime(sustarttime);
            var sunEndTime = getEndTime(suendtime);
            Form1 vimeohome = new Form1();
            var constring = ConfigurationManager.ConnectionStrings["vimeocs"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            SqlCommand selectvideoids = new SqlCommand();
            string query = "";
            query = "UPDATE VSVAccount SET MonStart ='" + monStartTime + "', MonStop ='" + monEndTime + "' ,TueStart ='" + tueStartTime + "', TueStop ='" + tueEndTime + "' , WedStart ='" + wedStartTime + "' , WedStop ='" + wedEndTime + "' , ThurStart ='" + thuStartTime + "' , ThurStop ='" + thuEndTime + "',FriStart ='" + friStartTime + "', FriStop ='" + friEndTime + "' ,SatStart ='" + satStartTime + "', SatStop ='" + satEndTime + "' , SunStart ='" + sunStartTime + "', SunStop ='" + sunEndTime + "' WHERE UserID ='" + userid + "';";
            selectvideoids = new SqlCommand(query, con);
            con.Open();
            int i = selectvideoids.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                this.Hide();
                vimeohome.Show();
            }
            else
            {
                MessageBox.Show("Error While Adding The Start and Ending Time. Kindly Contact Administrator");
            }

        }
    }
}
