using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MissionPlanner
{
    class TargetPosSocket
    {

        Socket TargetPosSock;
        public IPEndPoint RemoteIPEndPoint;
        public int RemotePort = 3155;

        public int Updating = 0;
        public int HasNewPos = 0;
        public int TargetPosX=0;
        public int TargetPosY=0;

        
        public TargetPosSocket()
        {


        }




        public void Run(Object obj)
        {
            if (IsRun)
            { 
                Debug.WriteLine("重複執行 TargetPosSocket");
                return;
            }
            IsRun = true;


            //將IP位址和Port宣告為服務的連接點(所有網路介面卡 IP, Port)
            IPEndPoint ipont = new IPEndPoint(IPAddress.Any, 3156);

            //IPv4協定 通訊類型 通訊協定
            TargetPosSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //完全接收失敗嘗試接收次數記錄
            int TryCount = 0;

            #region 嘗試連向伺服端，連接埠有無重疊
            try
            {
                //建立本機連線
                TargetPosSock.Connect(RemoteIPEndPoint);
            }
            catch
            {
                msg += "Port重複使用\n";
                Close();
                return;
            }
            #endregion


            #region 標頭與資料內容


            byte[] data_PosX = new byte[4] { 0, 0, 0, 0 };
            byte[] data_PosY = new byte[4] { 0, 0, 0, 0 };
            byte[] requestPost = new byte[] { 5 };

            #endregion


            //循環接收資料
            while (IsRun)
            {
                int dataLen = 0;
                try
                {
                    //請求送出目標資訊
                    TargetPosSock.Send(requestPost);


                    dataLen = TargetPosSock.Receive(data_PosY);
                    dataLen += TargetPosSock.Receive(data_PosX);
                    int PosX = data_PosX[0] << 24 | data_PosX[1] << 16 | data_PosX[2] << 8 | data_PosX[3];
                    int PosY = data_PosY[0] << 24 | data_PosY[1] << 16 | data_PosY[2] << 8 | data_PosY[3];


                    //update TargetPos
                    Updating = 1;
                    TargetPosX = PosX;
                    TargetPosY = PosY;
                    HasNewPos = 1;
                    Updating = 0;
                }
                catch (Exception e)
                {
                    msg += "Client斷線(" + e.Message;
                    Debug.WriteLine("ErrorDetect: Client斷線:" + e.Message);

                    Close();
                    return;
                }


                #region 當客戶端主動關閉時，收不到資訊
                if (dataLen == 0)
                {
                    msg += "Server斷線";
                    Close();
                    return;
                }
                #endregion

                //Thread.Sleep(100);
            }
        }

        public void Close()
        {
            IsRun = false;

            if (TargetPosSock != null)
            {
                TargetPosSock.Close();
                TargetPosSock = null;
            }


            if (msg != "")
            {
                //MessageBox.Show(msg);
                Debug.WriteLine(msg);
                msg = "";
            }
        }

        internal int SetIpEndPoint(string IP, string Port)
        {
            try
            {
                //設定目標IP
                byte[] ipAddr;// = new byte[4];
                String RemoteIP = IP;
                ipAddr = RemoteIP.Split('.').Select<String, byte>(x => byte.Parse(x)).ToArray<byte>();
                this.RemotePort = int.Parse(Port);
                this.RemoteIPEndPoint = new IPEndPoint(new IPAddress(ipAddr), RemotePort);
                return 0;
            }
            catch (Exception)
            {
                Debug.WriteLine("IP或Port無效");
                return 1;
            }
        }
        public string msg { get; set; }

        public bool IsRun { get; set; }
    }
}
