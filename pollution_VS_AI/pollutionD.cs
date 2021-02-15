using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SpeechLib;
using System.IO.Ports;

namespace pollution_VS_AI
{
    public partial class Form1 : Form
    {

        public static void SetDoubleBuffering(System.Windows.Forms.Control control, bool value)
        {
            System.Reflection.PropertyInfo controlProperty = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", (System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance));
            controlProperty.SetValue(control, value, null);
        }


        public Form1()
        {
            InitializeComponent();


            SetDoubleBuffering(panel1, true);
            SetDoubleBuffering(panel2, true);
            SetDoubleBuffering(panel3, true);
            SetDoubleBuffering(panel4, true);
            SetDoubleBuffering(panel5, true);
            SetDoubleBuffering(panel6, true);
           

            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);

            this.CenterToScreen();

            Thread time_clock_ = new Thread(time_clock);
            time_clock_.Start();

            label46.Text = SystemInformation.UserName;

           

        }

        private void time_clock()
        {

            while (true)
            {

                String hoursText = DateTime.Now.ToString("hh");
                String minutesText = DateTime.Now.ToString("mmm");
                String secondsText = DateTime.Now.ToString("ss");


                label6.Text = hoursText + ":" + minutesText + ":" + secondsText + " " + DateTime.Now.ToString("tt");
                label9.Text = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;


                Thread.Sleep(1000);
            }

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

            timer2.Stop();

            voice.Pause();

            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void Form1_Load(object sender, EventArgs e)
        {}

        private void button1_Click_1(object sender, EventArgs e)
        {}

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            p1.Visible = true;
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            p1.Visible = false;
        }

        private void panel5_Click(object sender, EventArgs e)
        {
           
            System.Diagnostics.Process.Start("chrome.exe", "https://www.marinevesseltraffic.com/rain-and-lightning-tracker?full_screen=yes");
        }

        int n = 0;

        SerialPort port;

        private void timer1_Tick(object sender, EventArgs e)
        {
            n += 1;

            if (n == 2)
            {

                label7.Text=  pollutionS.the_d;   // take the name of d from the form of home.
                pic1.Image = pollutionS.the_img_d; // tale the image of d from the form oh home.


                panel6.Visible = true; // if the panel6 visible the show.
                timer2.Start(); // if the time2 is stop then start.
                //  serialPort1.Open(); // if you have the port the oprn it.
                using (port = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One))
                {
                    port.ReadTimeout = 500;

                    if (!port.IsOpen)
                    {

                        port.Open();
                        port.DataReceived += Port_DataReceived;

                    }
                }

                
                timer1.Stop(); // then time stop.

            }
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data_reade = port.ReadLine();
                listBox1.Items.Add(data_reade);


            }
            catch (Exception)
            {


            }
        }

        pollutionW pw = new pollutionW();
        SpVoice voice = new SpVoice();
        double p;
       

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {

                int data_reade_int = Convert.ToInt32(port.ReadLine());

                co_v.Text = listBox1.Items[listBox1.Items.Count - 1].ToString() + " ppm"; // take the data from listbox1 and but it in the laple named(co_v).

                p=Convert.ToDouble(listBox1.Items[listBox1.Items.Count - 1]);
                p = p / 10000;

                label10.Text = p.ToString() + " %";

         
              

                if (data_reade_int >= 500) {


                    pw = new pollutionW();
                    pw.Show();
                    pw.BringToFront();
                    pw.disease_.Text = label7.Text;
                    pw.co_v.Text = listBox1.Items[listBox1.Items.Count - 1].ToString() + " ppm";

                    pw.label2.Text = "leave this place immediately\r\nbecause it is dangerous for you\r\nyou have " + label7.Text +
                    "se.\r\nChoose a place from the map to go to a safe place.";

                    p = Convert.ToInt32(listBox1.Items[listBox1.Items.Count - 1]);
                    p = p / 10000;

                    pw.label7.Text = p.ToString() + " %";




                    string data_op_Restaurants = "data=!4m4!2m3!5m2!2e1!10e2";

                    string the_map = string.Format("https://www.google.com/maps/search/Restaurants/@29.9851798,30.9387049/{0}", data_op_Restaurants);


                    System.Diagnostics.Process.Start("chrome.exe", the_map);


                    timer3.Start();


                    co_v.ForeColor = Color.Red;
                    label10.ForeColor = Color.Red;



                    timer2.Stop();


                }

  
            }
            catch (Exception)
            {
            }

          
        }

        int x = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            x += 1;

            listBox1.Items.Add(x.ToString());

            if (x == 13) {

                x = 0;
            
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            int data_reade_int = Convert.ToInt32(port.ReadLine());

            co_v.Text = listBox1.Items[listBox1.Items.Count - 1].ToString() + " ppm";

            pw.co_v.Text = listBox1.Items[listBox1.Items.Count - 1].ToString() + " ppm";
            p = Convert.ToInt32(listBox1.Items[listBox1.Items.Count - 1]);
            p = p / 10000;

            pw.label7.Text = p.ToString() + " %";


            if (data_reade_int <= 500) {


                co_v.ForeColor = Color.Silver;
                label10.ForeColor = Color.Silver;

                voice.Pause();
                pw.voice.Pause();


                for (int i = 0; i < Application.OpenForms.Count; i++)
                {


                    Form n = Application.OpenForms[i];
                    if (n.Name == "pollutionW")
                    {

                        n.Close();


                    }
                }


            }

          

            if (data_reade_int >= 501)
            {

                timer2.Start();

            }





        }

        private void timer4_Tick(object sender, EventArgs e)
        {}


        
    }
}
