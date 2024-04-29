using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Windows_Activator_Application.Process_Windows;

namespace Windows_Activator_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        string inforWindowsActivationText = "OS Name: {0}\nWindows Version: {1}\nVersion: {2}\nIs 64 Bit Operating System: {3}\n" +
            "Is 64 Bit Process: {4}\nActivation Status: {5}";


        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            cButton1.Location = new Point(this.Width - 34, 2);
            cButton2.Location = new Point(this.Width - cButton1.Width - 34, 2);
        }

        string OSName, Windows_Version, Version, Is64BitOperatingSystem, Is64BitProcess, ActivationStatus;

        private void Form1_Load(object sender, EventArgs e)
        {
           PB_Icon.Image=Icon.ToBitmap();
      
           LB_Form_Text.Text = Text;
            var osVersion = Environment.OSVersion;
            ActivationStatus = "Checking...";
            richTextBox1.Text = "Loading...";
            thread = new Thread(new ThreadStart(delegate
            {
                loadInfomation();
                richTextBox1.Text = string.Format(inforWindowsActivationText, OSName, Windows_Version, Version, Is64BitOperatingSystem,
                Is64BitProcess, ActivationStatus);
            }));
            thread.IsBackground= true;
            thread.Start();

        }

        void loadInfomation()
        {
            OSName = Process_Windows.GetOSName();
            Windows_Version = Environment.OSVersion.Platform.ToString();
            Version = Environment.OSVersion.Version + $" ({Environment.OSVersion.VersionString})";
            Is64BitOperatingSystem = Environment.Is64BitOperatingSystem.ToString();
            Is64BitProcess = Environment.Is64BitProcess.ToString();
            ActivationStatus = Process_Windows.CheckActivation().ToString() ;
        }

        Thread thread=null;

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.DodgerBlue),1), 0, 0, this.Width - 1, this.Height - 1);
            base.OnPaint(e);
        }

        private void cButton2_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void cButton1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Close();
            }
        }

        private void cButton4_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left )
            {
                if(MessageBox.Show("Do you want to close the program?", ProductName+ " - Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                    Close();
                }
            }    
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            float i = 0; float.TryParse( Process_Windows.GetOSName(), out i);
            Process_Windows.Activation_Windows(i==10? WindowsVersion.Windows10: i>=8 && i<=8.1? WindowsVersion.Windows8_1: WindowsVersion.Windows7);
            ActivationStatus = "Activating...";
            loadInfomation();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadInfomation();
            richTextBox1.Text = string.Format(inforWindowsActivationText, OSName, Windows_Version, Version, Is64BitOperatingSystem,
                 Is64BitProcess, ActivationStatus);
        }

        private void cButton3_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button== MouseButtons.Left)
            {
               if(MessageBox.Show("Do you want to activate Windows?", ProductName + " - Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (!backgroundWorker1.IsBusy)
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }
               }
            }    
        }
    }
}
