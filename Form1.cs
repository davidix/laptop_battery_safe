using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Threading;

namespace laptop_battery_safe
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;
        }
        int limit = 95;
        PowerStatus power = SystemInformation.PowerStatus;


        private void Application_Idle(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckerTimer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblBatteryPercentage.Text = (power.BatteryLifePercent * 100).ToString();
            if (power.PowerLineStatus == PowerLineStatus.Online && power.BatteryLifePercent * 100 > limit)
            {
                msg();
            }
        }
        public void msg()
        {
            CheckerTimer.Stop();
            for (int i = 0; i < 5; i++)
                Console.Beep(1500, 100);
            for (int j = 0; j < 5; j++)
                Console.Beep(3000, 80);
            for (int k = 0; k < 5; k++)
                Console.Beep(500, 80);

            MessageBox.Show("Battery full;");
            Restarter.Start();
            Restarter.Interval = (60 * 1 * 500);
        }

        private void Restarter_Tick(object sender, EventArgs e)
        {
            CheckerTimer.Start();
            Restarter.Stop();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limit = Convert.ToInt32(textBox1.Text);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

    }
}
