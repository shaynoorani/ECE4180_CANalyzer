namespace WindowsAppCanalyzer
{
    partial class Form1
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
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxBaudRates = new System.Windows.Forms.ComboBox();
            this.dbcButton = new System.Windows.Forms.Button();
            this.Serial = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(580, 40);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(160, 28);
            this.comboBoxCOMPorts.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(413, 433);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(311, 26);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "MESSAGE";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(236, 433);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(85, 26);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "CAN ID";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(873, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 46);
            this.button1.TabIndex = 4;
            this.button1.Text = "SEND";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxBaudRates
            // 
            this.comboBoxBaudRates.FormattingEnabled = true;
            this.comboBoxBaudRates.Location = new System.Drawing.Point(774, 40);
            this.comboBoxBaudRates.Name = "comboBoxBaudRates";
            this.comboBoxBaudRates.Size = new System.Drawing.Size(121, 28);
            this.comboBoxBaudRates.TabIndex = 5;
            // 
            // dbcButton
            // 
            this.dbcButton.Location = new System.Drawing.Point(31, 25);
            this.dbcButton.Name = "dbcButton";
            this.dbcButton.Size = new System.Drawing.Size(107, 56);
            this.dbcButton.TabIndex = 6;
            this.dbcButton.Text = "DBC FILE";
            this.dbcButton.UseVisualStyleBackColor = true;
            this.dbcButton.Click += new System.EventHandler(this.dbcButton_Click);
            // 
            // Serial
            // 
            this.Serial.Location = new System.Drawing.Point(910, 34);
            this.Serial.Name = "Serial";
            this.Serial.Size = new System.Drawing.Size(100, 39);
            this.Serial.TabIndex = 7;
            this.Serial.Text = "Connect";
            this.Serial.UseVisualStyleBackColor = true;
            this.Serial.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(611, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "COM PORT";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(790, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Baud Rate";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(189, 37);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(368, 31);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(325, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "CAN Load";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Load  0%";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1028, 490);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Serial);
            this.Controls.Add(this.dbcButton);
            this.Controls.Add(this.comboBoxBaudRates);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBoxCOMPorts);
            this.Name = "Form1";
            this.Text = "CANalyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxBaudRates;
        private System.Windows.Forms.Button dbcButton;
        private System.Windows.Forms.Button Serial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

