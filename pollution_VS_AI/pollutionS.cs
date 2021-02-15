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

namespace pollution_VS_AI
{
    public partial class pollutionS : Form
    {

        public static void SetDoubleBuffering(System.Windows.Forms.Control control, bool value)
        {
            System.Reflection.PropertyInfo controlProperty = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", (System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance));
            controlProperty.SetValue(control, value, null);
        }



        public pollutionS()
        {
            InitializeComponent();

            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);

            this.CenterToScreen();

            SetDoubleBuffering(panel1, true);
            SetDoubleBuffering(panel2, true);
            SetDoubleBuffering(panel4, true);
            SetDoubleBuffering(gunaElipsePanel1, true);
            SetDoubleBuffering(gunaElipsePanel2, true);
            SetDoubleBuffering(gunaElipsePanel3, true);
            SetDoubleBuffering(gunaElipsePanel4, true);
            SetDoubleBuffering(gunaElipsePanel5, true);
            SetDoubleBuffering(gunaElipsePanel6, true);
            SetDoubleBuffering(gunaElipsePanel7, true);

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

        private void pollutionS_Load(object sender, EventArgs e)
        {

        }

        private void gunaElipsePanel1_MouseEnter(object sender, EventArgs e)
        {
            g1.Visible = true;
            g2.Visible = false;
            g3.Visible = false;
            g4.Visible = false;
            g5.Visible = false;
            g6.Visible = false;
            g7.Visible = false;
          
        }

        private void gunaElipsePanel2_MouseEnter(object sender, EventArgs e)
        {
            g2.Visible = true;
            g1.Visible = false;
            g3.Visible = false;
            g4.Visible = false;
            g5.Visible = false;
            g6.Visible = false;
            g7.Visible = false;
        }

        private void gunaElipsePanel4_MouseEnter(object sender, EventArgs e)
        {
            g3.Visible = true;
            g2.Visible = false;
            g1.Visible = false;
            g4.Visible = false;
            g5.Visible = false;
            g6.Visible = false;
            g7.Visible = false;
        }

        private void gunaElipsePanel3_MouseEnter(object sender, EventArgs e)
        {
            g4.Visible = true;
            g2.Visible = false;
            g3.Visible = false;
            g1.Visible = false;
            g5.Visible = false;
            g6.Visible = false;
            g7.Visible = false;
        }

        private void gunaElipsePanel5_MouseEnter(object sender, EventArgs e)
        {
            g5.Visible = true;
            g2.Visible = false;
            g3.Visible = false;
            g4.Visible = false;
            g1.Visible = false;
            g6.Visible = false;
            g7.Visible = false;
        }

        private void gunaElipsePanel7_MouseEnter(object sender, EventArgs e)
        {
            g6.Visible = true;
            g2.Visible = false;
            g3.Visible = false;
            g4.Visible = false;
            g5.Visible = false;
            g1.Visible = false;
            g7.Visible = false;
        }

        private void gunaElipsePanel6_MouseEnter(object sender, EventArgs e)
        {
            g7.Visible = true;
            g2.Visible = false;
            g3.Visible = false;
            g4.Visible = false;
            g5.Visible = false;
            g6.Visible = false;
            g1.Visible = false;
        }

        private void pollutionS_MouseEnter(object sender, EventArgs e)
        {
            g1.Visible = false;
            g2.Visible = false;
            g3.Visible = false;
            g4.Visible = false;
            g5.Visible = false;
            g6.Visible = false;
            g7.Visible = false;
        }



        public static string the_d;
        public static Image the_img_d;

        private void gunaElipsePanel1_Click(object sender, EventArgs e)
        {
            label7.Text = "Ischaemic Heart Disease";
            the_d = "Ischaemic Heart Disease";
            the_img_d = Properties.Resources.icons8_heart_with_pulse_40px_1;


            Form1 pd = new Form1();
            pd.Show();
            pd.BringToFront();
           // pd.label7.Text = label7.Text;
           // pd.pic1.Image = Properties.Resources.icons8_heart_with_pulse_40px_1;

        }

        private void gunaElipsePanel2_Click(object sender, EventArgs e)
        {
            label7.Text = "Stroke";
            the_d = "Stroke";
            the_img_d = Properties.Resources.icons8_brain_40px;

            Form1 pd = new Form1();
            pd.Show();
            pd.BringToFront();
            //pd.serialPort1.Open();
          //  pd.label7.Text = label7.Text;
          //  pd.pic1.Image = Properties.Resources.icons8_brain_40px;

        }

        private void label10_Click(object sender, EventArgs e)
        {
            label7.Text = "Lung Cancer";
            the_d = "Lung Cancer";
            the_img_d = Properties.Resources.icons8_lungs_40px_1;

            Form1 pd = new Form1();
            pd.Show();
            pd.BringToFront();
         //   pd.label7.Text = label7.Text;
           // pd.pic1.Image = Properties.Resources.icons8_lungs_40px_1;

        }

        private void label8_Click(object sender, EventArgs e)
        {
            label7.Text = "Chronic Obstructive Pulmonary Disease";
            the_d = "Chronic Obstructive Pulmonary Disease";
            the_img_d = Properties.Resources.icons8_lungs_40px;

            Form1 pd = new Form1();
            pd.Show();
            pd.BringToFront();
           // pd.label7.Text = label7.Text;
           // pd.pic1.Image = Properties.Resources.icons8_lungs_40px;

        }

        private void gunaElipsePanel5_Click(object sender, EventArgs e)
        {
            label7.Text = "Acute Lower Respiratory";
            the_d = "Acute Lower Respiratory";
            the_img_d = Properties.Resources.icons8_spleen_40px;

            Form1 pd = new Form1();
            pd.Show();
            pd.BringToFront();
           // pd.label7.Text = label7.Text;
            //pd.pic1.Image = Properties.Resources.icons8_spleen_40px;
        }

        private void gunaElipsePanel7_Click(object sender, EventArgs e)
        {
            label7.Text = "Asthma";
            the_d = "Asthma";
          the_img_d  = Properties.Resources.icons8_asthma_40px;

            Form1 pd = new Form1();
            pd.Show();
            pd.BringToFront();
           // pd.label7.Text = label7.Text;
           // pd.pic1.Image = Properties.Resources.icons8_asthma_40px;

        }

        private void gunaElipsePanel6_Click(object sender, EventArgs e)
        {
            label7.Text = "Cardiovascular Problems";
            the_d = "Cardiovascular Problems";
            the_img_d = Properties.Resources.icons8_drop_of_blood_40px;

            Form1 pd = new Form1();
            pd.Show();
            pd.BringToFront();
           // pd.label7.Text = label7.Text;
           // pd.pic1.Image = Properties.Resources.icons8_drop_of_blood_40px;

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        int n = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            n += 1;

            if (n == 2)
            {


                panel2.Visible = true;

                timer1.Stop();

            }
        }
    }
}
