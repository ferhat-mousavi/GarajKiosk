namespace GarajKiosk
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBoxAygazType1 = new System.Windows.Forms.PictureBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSettings4 = new System.Windows.Forms.Button();
            this.pictureBoxAygazTypeImage1 = new System.Windows.Forms.PictureBox();
            this.labelBoxAygazTypeName1 = new System.Windows.Forms.Label();
            this.labelBoxAygazTypePrice1 = new System.Windows.Forms.Label();
            this.labelBoxAygazTypePrice2 = new System.Windows.Forms.Label();
            this.labelBoxAygazTypeName2 = new System.Windows.Forms.Label();
            this.pictureBoxAygazTypeImage2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxAygazType2 = new System.Windows.Forms.PictureBox();
            this.timerLoadForm = new System.Windows.Forms.Timer(this.components);
            this.buttonSettings3 = new System.Windows.Forms.Button();
            this.buttonSettings1 = new System.Windows.Forms.Button();
            this.buttonSettings2 = new System.Windows.Forms.Button();
            this.timerFirebase = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazType1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazTypeImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazTypeImage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazType2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxAygazType1
            // 
            this.pictureBoxAygazType1.BackColor = System.Drawing.Color.White;
            this.pictureBoxAygazType1.InitialImage = null;
            this.pictureBoxAygazType1.Location = new System.Drawing.Point(195, 273);
            this.pictureBoxAygazType1.Name = "pictureBoxAygazType1";
            this.pictureBoxAygazType1.Size = new System.Drawing.Size(432, 452);
            this.pictureBoxAygazType1.TabIndex = 0;
            this.pictureBoxAygazType1.TabStop = false;
            this.pictureBoxAygazType1.Click += new System.EventHandler(this.pictureBoxAygazType1_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMessage.ForeColor = System.Drawing.Color.White;
            this.labelMessage.Location = new System.Drawing.Point(12, 126);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(1256, 144);
            this.labelMessage.TabIndex = 2;
            this.labelMessage.Text = "Lütfen almak istediğiniz ürünü seçin";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(441, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(398, 59);
            this.label2.TabIndex = 3;
            this.label2.Text = "ÜRÜN SEÇİMİ";
            // 
            // buttonSettings4
            // 
            this.buttonSettings4.FlatAppearance.BorderSize = 0;
            this.buttonSettings4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonSettings4.Location = new System.Drawing.Point(1180, 700);
            this.buttonSettings4.Name = "buttonSettings4";
            this.buttonSettings4.Size = new System.Drawing.Size(100, 100);
            this.buttonSettings4.TabIndex = 4;
            this.buttonSettings4.UseVisualStyleBackColor = true;
            this.buttonSettings4.Click += new System.EventHandler(this.buttonSettings4_Click);
            // 
            // pictureBoxAygazTypeImage1
            // 
            this.pictureBoxAygazTypeImage1.BackColor = System.Drawing.Color.White;
            this.pictureBoxAygazTypeImage1.Location = new System.Drawing.Point(314, 282);
            this.pictureBoxAygazTypeImage1.Name = "pictureBoxAygazTypeImage1";
            this.pictureBoxAygazTypeImage1.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxAygazTypeImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAygazTypeImage1.TabIndex = 5;
            this.pictureBoxAygazTypeImage1.TabStop = false;
            this.pictureBoxAygazTypeImage1.Click += new System.EventHandler(this.pictureBoxAygazType1_Click);
            // 
            // labelBoxAygazTypeName1
            // 
            this.labelBoxAygazTypeName1.BackColor = System.Drawing.Color.White;
            this.labelBoxAygazTypeName1.Font = new System.Drawing.Font("Montserrat ExtraBold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBoxAygazTypeName1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelBoxAygazTypeName1.Location = new System.Drawing.Point(205, 485);
            this.labelBoxAygazTypeName1.Name = "labelBoxAygazTypeName1";
            this.labelBoxAygazTypeName1.Size = new System.Drawing.Size(410, 138);
            this.labelBoxAygazTypeName1.TabIndex = 6;
            this.labelBoxAygazTypeName1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelBoxAygazTypeName1.Click += new System.EventHandler(this.pictureBoxAygazType1_Click);
            // 
            // labelBoxAygazTypePrice1
            // 
            this.labelBoxAygazTypePrice1.BackColor = System.Drawing.Color.White;
            this.labelBoxAygazTypePrice1.Font = new System.Drawing.Font("Montserrat ExtraBold", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBoxAygazTypePrice1.Location = new System.Drawing.Point(205, 623);
            this.labelBoxAygazTypePrice1.Name = "labelBoxAygazTypePrice1";
            this.labelBoxAygazTypePrice1.Size = new System.Drawing.Size(410, 90);
            this.labelBoxAygazTypePrice1.TabIndex = 7;
            this.labelBoxAygazTypePrice1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelBoxAygazTypePrice1.Click += new System.EventHandler(this.pictureBoxAygazType1_Click);
            // 
            // labelBoxAygazTypePrice2
            // 
            this.labelBoxAygazTypePrice2.BackColor = System.Drawing.Color.White;
            this.labelBoxAygazTypePrice2.Font = new System.Drawing.Font("Montserrat ExtraBold", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBoxAygazTypePrice2.Location = new System.Drawing.Point(665, 623);
            this.labelBoxAygazTypePrice2.Name = "labelBoxAygazTypePrice2";
            this.labelBoxAygazTypePrice2.Size = new System.Drawing.Size(410, 90);
            this.labelBoxAygazTypePrice2.TabIndex = 11;
            this.labelBoxAygazTypePrice2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelBoxAygazTypePrice2.Click += new System.EventHandler(this.pictureBoxAygazType2_Click);
            // 
            // labelBoxAygazTypeName2
            // 
            this.labelBoxAygazTypeName2.BackColor = System.Drawing.Color.White;
            this.labelBoxAygazTypeName2.Font = new System.Drawing.Font("Montserrat ExtraBold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBoxAygazTypeName2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelBoxAygazTypeName2.Location = new System.Drawing.Point(665, 485);
            this.labelBoxAygazTypeName2.Name = "labelBoxAygazTypeName2";
            this.labelBoxAygazTypeName2.Size = new System.Drawing.Size(410, 138);
            this.labelBoxAygazTypeName2.TabIndex = 10;
            this.labelBoxAygazTypeName2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelBoxAygazTypeName2.Click += new System.EventHandler(this.pictureBoxAygazType2_Click);
            // 
            // pictureBoxAygazTypeImage2
            // 
            this.pictureBoxAygazTypeImage2.BackColor = System.Drawing.Color.White;
            this.pictureBoxAygazTypeImage2.Location = new System.Drawing.Point(774, 282);
            this.pictureBoxAygazTypeImage2.Name = "pictureBoxAygazTypeImage2";
            this.pictureBoxAygazTypeImage2.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxAygazTypeImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAygazTypeImage2.TabIndex = 9;
            this.pictureBoxAygazTypeImage2.TabStop = false;
            this.pictureBoxAygazTypeImage2.Click += new System.EventHandler(this.pictureBoxAygazType2_Click);
            // 
            // pictureBoxAygazType2
            // 
            this.pictureBoxAygazType2.BackColor = System.Drawing.Color.White;
            this.pictureBoxAygazType2.InitialImage = null;
            this.pictureBoxAygazType2.Location = new System.Drawing.Point(655, 273);
            this.pictureBoxAygazType2.Name = "pictureBoxAygazType2";
            this.pictureBoxAygazType2.Size = new System.Drawing.Size(432, 452);
            this.pictureBoxAygazType2.TabIndex = 8;
            this.pictureBoxAygazType2.TabStop = false;
            this.pictureBoxAygazType2.Click += new System.EventHandler(this.pictureBoxAygazType2_Click);
            // 
            // timerLoadForm
            // 
            this.timerLoadForm.Enabled = true;
            this.timerLoadForm.Interval = 600000;
            this.timerLoadForm.Tick += new System.EventHandler(this.timerLoadForm_Tick);
            // 
            // buttonSettings3
            // 
            this.buttonSettings3.FlatAppearance.BorderSize = 0;
            this.buttonSettings3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonSettings3.Location = new System.Drawing.Point(-1, 700);
            this.buttonSettings3.Name = "buttonSettings3";
            this.buttonSettings3.Size = new System.Drawing.Size(100, 100);
            this.buttonSettings3.TabIndex = 12;
            this.buttonSettings3.UseVisualStyleBackColor = true;
            this.buttonSettings3.Click += new System.EventHandler(this.buttonSettings3_Click);
            // 
            // buttonSettings1
            // 
            this.buttonSettings1.FlatAppearance.BorderSize = 0;
            this.buttonSettings1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonSettings1.Location = new System.Drawing.Point(-1, 0);
            this.buttonSettings1.Name = "buttonSettings1";
            this.buttonSettings1.Size = new System.Drawing.Size(100, 100);
            this.buttonSettings1.TabIndex = 13;
            this.buttonSettings1.UseVisualStyleBackColor = true;
            this.buttonSettings1.Click += new System.EventHandler(this.buttonSettings1_Click);
            // 
            // buttonSettings2
            // 
            this.buttonSettings2.FlatAppearance.BorderSize = 0;
            this.buttonSettings2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonSettings2.Location = new System.Drawing.Point(1180, 0);
            this.buttonSettings2.Name = "buttonSettings2";
            this.buttonSettings2.Size = new System.Drawing.Size(100, 100);
            this.buttonSettings2.TabIndex = 14;
            this.buttonSettings2.UseVisualStyleBackColor = true;
            this.buttonSettings2.Click += new System.EventHandler(this.buttonSettings2_Click);
            // 
            // timerFirebase
            // 
            this.timerFirebase.Enabled = true;
            this.timerFirebase.Interval = 7200000;
            this.timerFirebase.Tick += new System.EventHandler(this.timerFirebase_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.buttonSettings2);
            this.Controls.Add(this.buttonSettings1);
            this.Controls.Add(this.buttonSettings3);
            this.Controls.Add(this.labelBoxAygazTypePrice2);
            this.Controls.Add(this.labelBoxAygazTypeName2);
            this.Controls.Add(this.pictureBoxAygazTypeImage2);
            this.Controls.Add(this.pictureBoxAygazType2);
            this.Controls.Add(this.labelBoxAygazTypePrice1);
            this.Controls.Add(this.labelBoxAygazTypeName1);
            this.Controls.Add(this.pictureBoxAygazTypeImage1);
            this.Controls.Add(this.buttonSettings4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.pictureBoxAygazType1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Garaj Kiosk";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazType1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazTypeImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazTypeImage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazType2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAygazType1;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSettings4;
        private System.Windows.Forms.PictureBox pictureBoxAygazTypeImage1;
        private System.Windows.Forms.Label labelBoxAygazTypeName1;
        private System.Windows.Forms.Label labelBoxAygazTypePrice1;
        private System.Windows.Forms.Label labelBoxAygazTypePrice2;
        private System.Windows.Forms.Label labelBoxAygazTypeName2;
        private System.Windows.Forms.PictureBox pictureBoxAygazTypeImage2;
        private System.Windows.Forms.PictureBox pictureBoxAygazType2;
        private System.Windows.Forms.Timer timerLoadForm;
        private System.Windows.Forms.Button buttonSettings3;
        private System.Windows.Forms.Button buttonSettings1;
        private System.Windows.Forms.Button buttonSettings2;
        private System.Windows.Forms.Timer timerFirebase;
    }
}

