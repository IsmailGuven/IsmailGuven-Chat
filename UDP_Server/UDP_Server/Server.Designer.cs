namespace UDP_Server
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
            this.Console = new System.Windows.Forms.RichTextBox();
            this.TextMessage = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Console
            // 
            this.Console.Location = new System.Drawing.Point(12, 12);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(399, 263);
            this.Console.TabIndex = 0;
            this.Console.Text = "";
            // 
            // TextMessage
            // 
            this.TextMessage.Location = new System.Drawing.Point(12, 281);
            this.TextMessage.Name = "TextMessage";
            this.TextMessage.Size = new System.Drawing.Size(318, 20);
            this.TextMessage.TabIndex = 1;
            this.TextMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextMessage_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(336, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 304);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextMessage);
            this.Controls.Add(this.Console);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Console;
        private System.Windows.Forms.TextBox TextMessage;
        private System.Windows.Forms.Button button1;
    }
}

