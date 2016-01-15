using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MissionPlanner
{
    class TargetPosSocket
    {

        Socket TargetPosSock;
        IPEndPoint RemoteIPEndPoint;
        public TargetPosSocket()
        {


        }




        internal void Run(object obj)
        {
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
            byte[] data = new byte[0];

            byte[] data_Len = new byte[4] { 0, 0, 0, 0 };

            int len = 0;
            #endregion


            //循環接收資料
            while (isRun)
            {

                try
                {
                    #region 嘗試從客戶端接收資料，要是從伺服端強制關閉客戶端會造成以下物件錯誤
                    TryCount = 0;
                    TargetPosSock.Receive(data_Len);

                    len = data_Len[0] << 24 | data_Len[1] << 16 | data_Len[2] << 8 | data_Len[3];
                    if (len > 10485760 || len < 0) //if  > 10MB 
                    {
                        Console.WriteLine("ErrorDetect: len=" + len);
                        Close();
                        return;
                    }
                    data = new byte[len];

                    int get = TargetPosSock.Receive(data);

                    //如果接收不完全
                    if (get != len)
                    {
                        int StartIndex = get;
                        int EndIndex = len - get;
                        //不斷等待進行接收
                        while (StartIndex != len)
                        {
                            byte[] tmpAcceptData = new byte[EndIndex];
                            get = TargetPosSock.Receive(tmpAcceptData);
                            Array.ConstrainedCopy(tmpAcceptData, 0, data, StartIndex, get);
                            StartIndex += get;
                            EndIndex -= get;
                            if (get == 0)
                            {
                                ++TryCount;
                                if (TryCount > 100)
                                {
                                    msg += "Client斷線，或接收逾時";
                                    Close();
                                    return;
                                }
                            }
                        }
                    }


                    //回傳接收完成的訊息
                    //client.Send(new byte[1] { 0 });
                    TargetPosSock.Send(new byte[1] { 3 });
                }
                catch (Exception e)
                {
                    msg += "Client斷線(" + e.Message;
                    Console.WriteLine("ErrorDetect: Client斷線:" + e.Message);

                    Close();
                    return;
                }

                    #endregion

                #region 當客戶端主動關閉時，收不到資訊
                if (data.Length == 0)
                {
                    msg += "Server斷線";
                    Close();
                    return;
                }
                #endregion

                //座標與時間接收完畢  將資訊存入公共變數
            }
        }

        public void Close()
        {
            isRun = false;

            if (TargetPosSock != null)
            {
                TargetPosSock.Close();
                TargetPosSock = null;
            }


            if (msg != "")
            {
                //MessageBox.Show(msg);
                Console.WriteLine(msg);
                msg = "";
            }
        }

        internal void SetIpEndPoint(string p1, string p2)
        {
            throw new NotImplementedException();
        }
        public bool isRun { get; set; }

        public string msg { get; set; }
    }
}
