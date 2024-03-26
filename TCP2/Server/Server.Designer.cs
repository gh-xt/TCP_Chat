namespace Server
{
    partial class Server
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
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.receivedMessages = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(593, 98);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(117, 26);
            this.tbPort.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(531, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port";
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(189, 91);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(281, 26);
            this.tbIPAddress.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Address";
            // 
            // receivedMessages
            // 
            this.receivedMessages.Location = new System.Drawing.Point(95, 183);
            this.receivedMessages.Name = "receivedMessages";
            this.receivedMessages.Size = new System.Drawing.Size(615, 190);
            this.receivedMessages.TabIndex = 8;
            this.receivedMessages.Text = "";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.receivedMessages);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbIPAddress);
            this.Controls.Add(this.label1);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox receivedMessages;
    }
}

