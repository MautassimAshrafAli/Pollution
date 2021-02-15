using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using SpeechLib;



namespace pollution_VS_AI
{
    public partial class pollutionW : Form
    {

        public static void SetDoubleBuffering(System.Windows.Forms.Control control, bool value)
        {
            System.Reflection.PropertyInfo controlProperty = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", (System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance));
            controlProperty.SetValue(control, value, null);
        }

      public  SpVoice voice = new SpVoice();

        public pollutionW()
        {
            InitializeComponent();


            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);

            this.CenterToScreen();

            SetDoubleBuffering(panel1, true);
            SetDoubleBuffering(panel2, true);
            SetDoubleBuffering(panel3, true);
            SetDoubleBuffering(panel4, true);
            SetDoubleBuffering(panel5, true);
            SetDoubleBuffering(panel6, true);
            SetDoubleBuffering(gunaShadowPanel1, true);

            Thread time_clock_ = new Thread(time_clock);
            time_clock_.Start();


            name_.Text = SystemInformation.UserName;

            label62.Text = char.ConvertFromUtf32(0xEE93);
            label64.Text = char.ConvertFromUtf32(0xF158);

            TimeZone zone = TimeZone.CurrentTimeZone;

            string standard = zone.StandardName;
            string s_standard = standard.Replace("Standard Time", "");
            loc_.Text = "Location in " + s_standard;

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

            voice.Pause();

            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public Label the_d = new Label();

        private void pollutionW_Load(object sender, EventArgs e)
        {

            
   
            for (int x = 0; x <= 10; x++)
            {

                voice.Speak("leave this place immediately because it is dangerous for you you have " +pollutionS.the_d+ ". choose a place from the map to go to a safe place.", SpeechVoiceSpeakFlags.SVSFlagsAsync);


            }

          
        
            

        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            p1.Visible = true;
            p2.Visible = false;
            p3.Visible = false;
        }
        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            p2.Visible = true;
            p1.Visible = false;
            p3.Visible = false;
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            p3.Visible = true;
            p1.Visible = false;
            p2.Visible = false;
        }
        private void pollutionW_MouseEnter(object sender, EventArgs e)
        {
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;

            label6.Visible = false;

        }

        private void time_clock()
        {

            while (true)
            {

                String hoursText = DateTime.Now.ToString("hh");
                String minutesText = DateTime.Now.ToString("mmm");
                String secondsText = DateTime.Now.ToString("ss");


                time_.Text = hoursText + ":" + minutesText + ":" + secondsText + " " + DateTime.Now.ToString("tt");
                date_.Text = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;


                Thread.Sleep(1000);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

            string data_op_hospitals = "data=!4m4!2m3!5m2!2e1!10e2";

            string the_map = string.Format("https://www.google.com.eg/maps/search/Hospitals/@29.9851798,30.9387049/{0}", data_op_hospitals);


            System.Diagnostics.Process.Start("chrome.exe", the_map);


        }

        private void panel3_Click(object sender, EventArgs e)
        {

            string data_op_Restaurants = "data=!4m4!2m3!5m2!2e1!10e2";

            string the_map = string.Format("https://www.google.com/maps/search/Restaurants/@29.9851798,30.9387049/{0}", data_op_Restaurants);


            System.Diagnostics.Process.Start("chrome.exe", the_map);

        }

        private void panel5_Click(object sender, EventArgs e)
        {

            string data_op_Hotels = "data=!4m4!2m3!5m2!2e1!10e2";

            string the_map = string.Format("https://www.google.com/maps/search/Hotels/@29.9851798,30.9387049/{0}", data_op_Hotels);


            System.Diagnostics.Process.Start("chrome.exe", the_map);

        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {

            label6.Visible = true;

            using (StreamWriter writer = new StreamWriter(@"C:\Users\"+SystemInformation.UserDomainName+@"\Desktop\Pollution_Data.txt", true))
            {
                writer.WriteLine(name_.Text + "|" + disease_.Text + "|" + loc_.Text + "|" + co_v.Text + "|" + time_.Text + "|" + date_.Text);
            }

        }
        int n = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            n += 1;

            if (n == 2) {


                panel6.Visible = true;

                timer1.Stop();

            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
           // this.Close();
           // voice.Pause();
        }
    }
}
