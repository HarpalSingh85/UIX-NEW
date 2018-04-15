using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace UIX
{
    public partial class Form1 : Form
    {
        #region Properties & Fields

        int interval = 10;
        int _i = 20;
        private int _limit = 3;
        float _tmpstatVal, _tmpwidthVal = 0.00f;

        Point _lastPoint;

        TimeSpan ts = new TimeSpan(1, 0, 0);
        Timer TP = new Timer();

                
        public int hh { get; set; }
        public int StatVal { get; set; }
        public int mm { get; set; }
        public int ss { get; set; }
        public int _count { get; set; }

        #endregion

        #region MainFrom
        public Form1()
        {
            InitializeComponent();
            panel1.Height = btnRestart.Height;
            panel1.Top = btnRestart.Top;

            timer1.Interval = interval;
            timer1.Start();

            hh = ts.Hours;
            mm = ts.Minutes;
            ss = ts.Seconds;        
           
            StatVal = 0;
                    

            TP.Interval = (60 * interval) /6;
            TP.Start();

            TP.Tick += TP_Tick;
                                 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _countClick();
            lblDisplay.Text = String.Format("{0}:{1}:{2}",0.ToString().PadLeft(2,'0'), 0.ToString().PadLeft(2, '0'), 0.ToString().PadLeft(2, '0'));
            panel1.Visible = false;
            lblTopBar.Text = "PULSE  SECURE  5.3  INSTALLER  NOTIFICATION";
            lblDisplayContent.Text = "Pulse Secure have been installed in your computer.\r\nPlease restart the computer.";
                        
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            DragMove( sender, e);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            DragLocation(e);
        }

        #endregion

        #region Timers

        private void TP_Tick(object sender, EventArgs e)
        {
            UpdateProgess();
        }
        
        private void Timer1_Tick(object sender, EventArgs e)
        {
                                   
            ss = ss - 1;

            if (ss == -1)
            {
                mm = mm - 1;
                ss = 59;

            }

            if (mm == -1)
            {
                hh = hh - 1;
                mm = 59;
            
                           
            }


            //Invoke Before 15 mins remaining

            if (hh == 0 && mm == 15 && ss == 0)
            {
                Show();

                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Focus();
                    this.BringToFront();
                    trayNt.Visible = false;
                }


            }

            //Invoke Before 5 mins remaining

            if (hh == 0 && mm == 5 && ss == 0)
            {
                Show();

                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Focus();
                    this.BringToFront();
                    trayNt.Visible = false;
                }


            }

            //Invoke Before 1 min remaining

            if (hh == 0 && mm == 1 && ss == 0)
            {
                Show();

                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Focus();
                    this.BringToFront();
                    trayNt.Visible = false;
                }

            }


            lblDisplay.Text = String.Format("{0}:{1}:{2}", hh.ToString().PadLeft(2, '0'), mm.ToString().PadLeft(2, '0'), ss.ToString().PadLeft(2, '0'));

            
            if (hh == 0 && mm == 0 && ss == 0)
            {
                timer1.Stop();
                TP.Stop();
            }
                                            

        }
                
        private void UpdateProgess()
        {
            if (panel3.Width != panel2.Width)
            {

                panel3.Width++;
                _tmpstatVal = StatVal;
                _tmpwidthVal = panel2.Width;
                StatVal++;
                
            }
        }

        #endregion


        #region Effects & Movements


        private void btnRestart_MouseHover(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Left = btnRestart.Location.X;
            panel1.Height = 3;
        }

        private void btnPostpone_MouseHover(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Left = btnPostpone.Location.X;
            panel1.Height = 3;
        }

        private void btnCancel_MouseHover(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Left = btnCancel.Location.X;
            panel1.Height = 3;
        }

        private void btnRestart_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void btnPostpone_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void lblDisplayContent_MouseDown(object sender, MouseEventArgs e)
        {
            DragLocation(e);
        }

        private void lblDisplayContent_MouseMove(object sender, MouseEventArgs e)
        {
            DragMove( sender,  e);
        }

        private void DragLocation( MouseEventArgs e)
        {
            _lastPoint = new Point(e.X, e.Y);
        }

        private void DragMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _lastPoint.X;
                this.Top += e.Y - _lastPoint.Y;
            }
        }

    

        private void dockTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            DragLocation(e);
        }

        private void dockTopBar_MouseMove(object sender, MouseEventArgs e)
        {
            DragMove(sender, e);
        }

        private void dockMain_MouseMove(object sender, MouseEventArgs e)
        {
            DragMove(sender, e);
        }

        private void dockMain_MouseDown(object sender, MouseEventArgs e)
        {
            DragLocation(e);
        }

       
      

        private void lblTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            DragLocation(e);
        }

        private void lblTopBar_MouseMove(object sender, MouseEventArgs e)
        {
            DragMove(sender, e);
        }


        #endregion


        #region Tray Notification

        private void trayNt_BalloonTipClicked(object sender, EventArgs e)
        {
            Show();
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Focus();
                this.BringToFront();
            }

            trayNt.Visible = false;
            trayNt.Icon = null;
        }

        

        private void trayNt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Focus();
                this.BringToFront();
            }

            trayNt.Visible = false;
            trayNt.Icon = null;
        }

        private void _trayNotify(string _headertext, string _subject)
        {

            trayNt.Icon = Properties.Resources.Tray;
            trayNt.Visible = true;
            trayNt.ShowBalloonTip(_i, _headertext, _subject, ToolTipIcon.Warning);
        }

        #endregion

        #region Button Events

        private void btnRestart_Click(object sender, EventArgs e)
        {
            //restart();
        }

        private void btnPostpone_Click(object sender, EventArgs e)
        {
            _countClick();
            panel3.Width = 5;
            timer1.Stop();
            hh = 1;
            mm = 0;
            ss = 0;
            timer1.Start();
            UpdateProgess();
            _trayNotify("Restart Posponded", "Computer restart have been postponded for next 60 minutes");
            this.Hide();
            
        }
        
        private void btnX_Click(object sender, EventArgs e)
        {
            this.Hide();
            _trayNotify("Restart Computer", "Restart your computer to complete installation");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            _trayNotify("Restart Computer", "Restart your computer to complete installation");
        }

        #endregion

        #region Methods

        private void restart()
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = "cmd";
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Arguments = "/C shutdown /r /f /t 000 ";
            Process.Start(proc);
        }

        private void _countClick()
        {

            label1.Text = "Reschedule Attempts Left : " + (_limit - _count).ToString();
            label2.Text = "Please ensure you save any documents you are currently working on before you select restart or postpone. Failure to do so could result in your documents being lost.";
            if (_count > 2)
            {
                btnPostpone.Enabled = false;
                label2.Text = "Please ensure you save any documents you are currently working on before you select restart. Failure to do so could result in your documents being lost.";
            }
            else
            {

                btnPostpone.Enabled = true;
            }
            _count++;
        }



        #endregion
    }
}
