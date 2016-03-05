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
        const float rad2deg = (float)(180 / Math.PI);
        const float deg2rad = (float)(1.0 / rad2deg);

        //中心區域資訊
        float insideRate = 0.1f;
        float outsideRate = 0.2f;
        int CBB_Width = 320;
        int CBB_Height = 240;
        Rectangle CenterBoundingbox_outside;
        Rectangle CenterBoundingbox_inside;

        public Thread targetPosThread;
        TargetPosSocket targetPosSocket = new TargetPosSocket();
        public TargetPosSocketForm()
        {
            InitializeComponent();
            CenterBoundingbox_outside = new Rectangle((int)(-CBB_Width / 2 * outsideRate), (int)(-CBB_Height / 2 * outsideRate), (int)(CBB_Width * outsideRate), (int)(CBB_Height * outsideRate));
            CenterBoundingbox_inside = new Rectangle((int)(-CBB_Width / 2 * insideRate), (int)(-CBB_Height / 2 * insideRate), (int)(CBB_Width * insideRate), (int)(CBB_Height * insideRate));
        }

        public void DebugLog(String str1)
        {
            textBox_Debug.Text += str1 + "\r\n";
            Debug.WriteLine(str1);
        }

        private void TargetPosSocketForm_Load(object sender, EventArgs e)
        {
            timer1.Interval = 250;
            timer1.Enabled = true;
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            //建立執行緒
            socketThreadStart();
            button_Connect.Text = button_Connect.Text == "connect" ? "disconnect" : "connect";
        }

        private void socketThreadStart()
        {
            if (targetPosThread ==null)
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
            else
            {
                targetPosThread.Abort();
                targetPosThread = null;
            }

            
        }

        public int TargetPosX, TargetPosY, Updating;
        //Update MAV info
        private void timer1_Tick(object sender, EventArgs e)
        {

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

                            //判斷目標是否在中心區域內
                            bool tmp = targetPosSocket.TargetIsInside;
                            if (tmp)
                            {
                                targetPosSocket.TargetIsInside = IntersectsWith(ref CenterBoundingbox_outside);
                            }
                            else
                            {
                                targetPosSocket.TargetIsInside = IntersectsWith(ref CenterBoundingbox_inside);
                            }
                            if (tmp != targetPosSocket.TargetIsInside)
                            {
                                textBox_Debug.Text += "目標" + (targetPosSocket.TargetIsInside ? "進入" : "偏離") + "中心區域\r\n";
                            }

                            textBox_Debug.SelectionStart = textBox_Debug.Text.Length - 1;
                            textBox_Debug.ScrollToCaret();
                        }
                        this.Updating = 0;

                        //若為允許導航狀態 則更新座標
                        if (checkBox_AllowMoveMAV.Checked)
                        {
                            //計算目標距離
                            //MainV2.comPort.MAV.
                            //計算目標GPS

                            //設定拍攝點

                            //設定航點


                        }
                    }




                }


            }
        }

        private bool IntersectsWith(ref Rectangle CenterBoundingbox_inside)
        {
            return CenterBoundingbox_inside.Left < TargetPosX && TargetPosX < CenterBoundingbox_inside.Right &&
                CenterBoundingbox_inside.Top < TargetPosY && TargetPosY < CenterBoundingbox_inside.Bottom;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
