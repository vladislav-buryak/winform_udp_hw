namespace WinFormsApp5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtGuess = new TextBox();
            btnSend = new Button();
            txtLog = new TextBox();
            btnConnect = new Button();
            SuspendLayout();
            // 
            // txtGuess
            // 
            txtGuess.Location = new Point(193, 30);
            txtGuess.Name = "txtGuess";
            txtGuess.Size = new Size(100, 23);
            txtGuess.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(193, 71);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 1;
            btnSend.Text = "button1";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(193, 111);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.Size = new Size(100, 23);
            txtLog.TabIndex = 2;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(193, 179);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "button2";
            btnConnect.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConnect);
            Controls.Add(txtLog);
            Controls.Add(btnSend);
            Controls.Add(txtGuess);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtGuess;
        private Button btnSend;
        private TextBox txtLog;
        private Button btnConnect;
    }
}
