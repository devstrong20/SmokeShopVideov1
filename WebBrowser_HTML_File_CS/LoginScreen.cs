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
using System.Web;
using System.Windows.Forms;

namespace SmokeShopVideo
{
    public partial class LoginScreen : Form
    {
        private readonly pubsEntities2 pubsEntities =  new pubsEntities2();
        public LoginScreen()
        {
            InitializeComponent();
           
        }
        public static string vimeoUserId = "";
        private void button1_Click(object sender, EventArgs e)//("insert into tblUser values('" + textBox1.Text + "', '" + textBox2.Text + "')"
        {
            Form1 vimeohome = new Form1();
            LoginScreen vimeologin = new LoginScreen();
            NewDateScreen dateScreen = new NewDateScreen();
           
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty)
            {

                
                var data1 = pubsEntities.VSVAccounts.Where(x => x.UserID == textBox1.Text && x.Password == textBox2.Text).Select(x => x.VSVAccountID).FirstOrDefault();

                if (data1.ToString()!=null&& data1>0)
                {
                    var data = pubsEntities.VSVAccounts.Where(x => x.UserID == textBox1.Text && x.Password ==  textBox2.Text ).Select(x => x.VSVAccountID).FirstOrDefault();
                    
                    string root = @"C:\Temp";
                    string subdir = @"C:\Temp\SmSpVimeo\Vimeo\";
                    // If directory does not exist, create it. 
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    if (!Directory.Exists(subdir))
                    {
                        Directory.CreateDirectory(subdir);
                    }
                    //dr.Close();
                    //if (File.Exists(@"C:\Temp\SmSpVimeo\Vimeo\dontDelete.txt"))
                    //{
                    //    File.Delete(@"C:\Temp\SmSpVimeo\Vimeo\dontDelete.txt");
                    //}
                    //string fileName = @"C:\Temp\SmSpVimeo\Vimeo\dontDelete3.txt";
                    string FilePath = ConfigurationManager.AppSettings["LogPath"];
                    FileInfo fi = new FileInfo(FilePath);
                    var writestring = textBox1.Text + "$" + data;
                    using (StreamWriter sw = fi.CreateText())
                    {
                        sw.WriteLine(writestring);

                    }
                    File.SetAttributes(FilePath, FileAttributes.ReadOnly | FileAttributes.Hidden);
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.Show();
                }
                else
                {
                    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
