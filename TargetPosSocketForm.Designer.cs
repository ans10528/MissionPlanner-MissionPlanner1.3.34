namespace MissionPlanner
{
    partial class TargetPosSocketForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_RemoteIP = new System.Windows.Forms.TextBox();
            this.textBox_RemotePort = new System.Windows.Forms.TextBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_CameraAngle = new System.Windows.Forms.TextBox();
            this.textBox_MavHeight = new System.Windows.Forms.TextBox();
            this.textBox_OutputDiffDistance = new System.Windows.Forms.TextBox();
            this.textBox_InputGroundDistance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_TargetDirectDistance = new System.Windows.Forms.TextBox();
            this.textBox_TargetGroundDistance = new System.Windows.Forms.TextBox();
            this.checkBox_AllowMoveMAV = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_RemoteIP
            // 
            this.textBox_RemoteIP.Location = new System.Drawing.Point(31, 32);
            this.textBox_RemoteIP.Name = "textBox_RemoteIP";
            this.textBox_RemoteIP.Size = new System.Drawing.Size(107, 22);
            this.textBox_RemoteIP.TabIndex = 0;
            this.textBox_RemoteIP.Text = "192.168.100.";
            // 
            // textBox_RemotePort
            // 
            this.textBox_RemotePort.Location = new System.Drawing.Point(144, 32);
            this.textBox_RemotePort.Name = "textBox_RemotePort";
            this.textBox_RemotePort.Size = new System.Drawing.Size(50, 22);
            this.textBox_RemotePort.TabIndex = 1;
            this.textBox_RemotePort.Text = "3155";
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(200, 32);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(116, 23);
            this.button_Connect.TabIndex = 2;
            this.button_Connect.Text = "connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Target Direct Distance";
            // 
            // textBox_CameraAngle
            // 
            this.textBox_CameraAngle.Location = new System.Drawing.Point(93, 136);
            this.textBox_CameraAngle.Name = "textBox_CameraAngle";
            this.textBox_CameraAngle.Size = new System.Drawing.Size(100, 22);
            this.textBox_CameraAngle.TabIndex = 4;
            this.textBox_CameraAngle.Text = "-45";
            // 
            // textBox_MavHeight
            // 
            this.textBox_MavHeight.Location = new System.Drawing.Point(93, 164);
            this.textBox_MavHeight.Name = "textBox_MavHeight";
            this.textBox_MavHeight.Size = new System.Drawing.Size(100, 22);
            this.textBox_MavHeight.TabIndex = 5;
            this.textBox_MavHeight.Text = "10";
            // 
            // textBox_OutputDiffDistance
            // 
            this.textBox_OutputDiffDistance.Location = new System.Drawing.Point(131, 288);
            this.textBox_OutputDiffDistance.Name = "textBox_OutputDiffDistance";
            this.textBox_OutputDiffDistance.Size = new System.Drawing.Size(94, 22);
            this.textBox_OutputDiffDistance.TabIndex = 6;
            // 
            // textBox_InputGroundDistance
            // 
            this.textBox_InputGroundDistance.Location = new System.Drawing.Point(131, 260);
            this.textBox_InputGroundDistance.Name = "textBox_InputGroundDistance";
            this.textBox_InputGroundDistance.Size = new System.Drawing.Size(94, 22);
            this.textBox_InputGroundDistance.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Target Ground Distance";
            // 
            // textBox_TargetDirectDistance
            // 
            this.textBox_TargetDirectDistance.Location = new System.Drawing.Point(156, 80);
            this.textBox_TargetDirectDistance.Name = "textBox_TargetDirectDistance";
            this.textBox_TargetDirectDistance.Size = new System.Drawing.Size(100, 22);
            this.textBox_TargetDirectDistance.TabIndex = 8;
            // 
            // textBox_TargetGroundDistance
            // 
            this.textBox_TargetGroundDistance.Location = new System.Drawing.Point(156, 108);
            this.textBox_TargetGroundDistance.Name = "textBox_TargetGroundDistance";
            this.textBox_TargetGroundDistance.Size = new System.Drawing.Size(100, 22);
            this.textBox_TargetGroundDistance.TabIndex = 8;
            // 
            // checkBox_AllowMoveMAV
            // 
            this.checkBox_AllowMoveMAV.AutoSize = true;
            this.checkBox_AllowMoveMAV.Location = new System.Drawing.Point(300, 325);
            this.checkBox_AllowMoveMAV.Name = "checkBox_AllowMoveMAV";
            this.checkBox_AllowMoveMAV.Size = new System.Drawing.Size(105, 16);
            this.checkBox_AllowMoveMAV.TabIndex = 9;
            this.checkBox_AllowMoveMAV.Text = "AllowMoveMAV";
            this.checkBox_AllowMoveMAV.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "攝影角度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "載具高度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "預計地面距離";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "輸出地面距離差";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(131, 323);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(94, 22);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "1000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 326);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "座標更新間隔";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(300, 288);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 26);
            this.button2.TabIndex = 13;
            this.button2.Text = "單次允許";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // TargetPosSocketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 387);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox_AllowMoveMAV);
            this.Controls.Add(this.textBox_TargetGroundDistance);
            this.Controls.Add(this.textBox_TargetDirectDistance);
            this.Controls.Add(this.textBox_InputGroundDistance);
            this.Controls.Add(this.textBox_OutputDiffDistance);
            this.Controls.Add(this.textBox_MavHeight);
            this.Controls.Add(this.textBox_CameraAngle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.textBox_RemotePort);
            this.Controls.Add(this.textBox_RemoteIP);
            this.Name = "TargetPosSocketForm";
            this.Text = "TargetPosSocketForm";
            this.Load += new System.EventHandler(this.TargetPosSocketForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_RemoteIP;
        private System.Windows.Forms.TextBox textBox_RemotePort;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_CameraAngle;
        private System.Windows.Forms.TextBox textBox_MavHeight;
        private System.Windows.Forms.TextBox textBox_OutputDiffDistance;
        private System.Windows.Forms.TextBox textBox_InputGroundDistance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_TargetDirectDistance;
        private System.Windows.Forms.TextBox textBox_TargetGroundDistance;
        private System.Windows.Forms.CheckBox checkBox_AllowMoveMAV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
    }
}