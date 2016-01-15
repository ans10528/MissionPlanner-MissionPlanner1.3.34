using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void TargetPosSocketForm_Load(object sender, EventArgs e)
        {

        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            targetPosSocket.SetIpEndPoint(textBox_RemoteIP.Text, textBox_RemotePort.Text);
            targetPosThread = new Thread(targetPosSocket.Run);
            targetPosThread.IsBackground = true;
            targetPosThread.Start();
        }
    }
}
