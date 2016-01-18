using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MissionPlanner
{
    public partial class TargetPosSocketForm : Form
    {
        public Thread targetPosThread;
        TargetPosSocket targetPosSocket = new TargetPosSocket();
        public TargetPosSocketForm()
        {
            InitializeComponent();
        }

        public void DebugLog(String str1)
        {
            textBox_Debug.Text += str1 + "\r\n";
            Debug.WriteLine(str1);
        }

        private void TargetPosSocketForm_Load(object sender, EventArgs e)
        {
            timer1.Interval = 200;
            timer1.Enabled = true;
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {

            //建立執行緒
            socketThreadStart();
        }

        private void socketThreadStart()
        {
            DebugLog("targetPosThread 建立執行緒");
            DebugLog("IP/Port" + textBox_RemoteIP.Text + ':' + textBox_RemotePort.Text);
            if (targetPosSocket.SetIpEndPoint(textBox_RemoteIP.Text, textBox_RemotePort.Text) == 0)
            {
                targetPosThread = new Thread(targetPosSocket.Run);
                targetPosThread.IsBackground = true;
                targetPosThread.Start();
            }
            
        }

        public int TargetPosX, TargetPosY, Updating;
        //Update MAV info
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (!targetPosSocket.IsRun)
            //{
            //    Console.WriteLine("TargetPosSocket AutoReStart");
            //    targetPosSocket.Run();
            //}


            if (targetPosSocket.IsRun)
            {
                //更新資訊

                //資訊是否接收中(鎖定中)
                if (targetPosSocket.Updating == 0)
                {
                    //有新座標
                    if (targetPosSocket.HasNewPos == 1)
                    {
                        this.Updating = 1;
                        if (this.TargetPosX != targetPosSocket.TargetPosX || this.TargetPosY != targetPosSocket.TargetPosY)
                        {
                            this.TargetPosX = targetPosSocket.TargetPosX;
                            this.TargetPosY = targetPosSocket.TargetPosY;

                            textBox_Debug.Text += this.TargetPosX + "," + this.TargetPosY + "\r\n";
                            textBox_Debug.SelectionStart = textBox_Debug.Text.Length - 1;
                            textBox_Debug.ScrollToCaret();
                        }
                        this.Updating = 0;
                    }
                }


            }

            //picView.Image = NetImageSource.VedioBuffer.ReadBitmap();
            //this.Text = "FPS = " + NetImageSource.VedioBuffer.FPS + ", delay = " + NetImageSource.VedioBuffer.Delay_Net + ", data = " + NetImageSource.VedioBuffer.DataSize;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
