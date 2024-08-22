namespace evieplus.Forms
{
    partial class PaymentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentForm));
            this.buttonBack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelBoxAygazTypePrice = new System.Windows.Forms.Label();
            this.labelBoxAygazTypeName = new System.Windows.Forms.Label();
            this.pictureBoxAygazTypeImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxAygazType = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelDurationLeft = new System.Windows.Forms.Label();
            this.timerDurationLeft = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazTypeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.White;
            this.buttonBack.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonBack.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonBack.Location = new System.Drawing.Point(12, 12);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(146, 100);
            this.buttonBack.TabIndex = 33;
            this.buttonBack.Text = "◄ GERİ";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Visible = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(531, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 59);
            this.label2.TabIndex = 34;
            this.label2.Text = "ÖDEME";
            // 
            // labelBoxAygazTypePrice
            // 
            this.labelBoxAygazTypePrice.BackColor = System.Drawing.Color.White;
            this.labelBoxAygazTypePrice.Font = new System.Drawing.Font("Montserrat ExtraBold", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBoxAygazTypePrice.Location = new System.Drawing.Point(434, 454);
            this.labelBoxAygazTypePrice.Name = "labelBoxAygazTypePrice";
            this.labelBoxAygazTypePrice.Size = new System.Drawing.Size(410, 90);
            this.labelBoxAygazTypePrice.TabIndex = 38;
            this.labelBoxAygazTypePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBoxAygazTypeName
            // 
            this.labelBoxAygazTypeName.BackColor = System.Drawing.Color.White;
            this.labelBoxAygazTypeName.Font = new System.Drawing.Font("Montserrat ExtraBold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBoxAygazTypeName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelBoxAygazTypeName.Location = new System.Drawing.Point(434, 316);
            this.labelBoxAygazTypeName.Name = "labelBoxAygazTypeName";
            this.labelBoxAygazTypeName.Size = new System.Drawing.Size(410, 138);
            this.labelBoxAygazTypeName.TabIndex = 37;
            this.labelBoxAygazTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxAygazTypeImage
            // 
            this.pictureBoxAygazTypeImage.BackColor = System.Drawing.Color.White;
            this.pictureBoxAygazTypeImage.Location = new System.Drawing.Point(543, 113);
            this.pictureBoxAygazTypeImage.Name = "pictureBoxAygazTypeImage";
            this.pictureBoxAygazTypeImage.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxAygazTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAygazTypeImage.TabIndex = 36;
            this.pictureBoxAygazTypeImage.TabStop = false;
            // 
            // pictureBoxAygazType
            // 
            this.pictureBoxAygazType.BackColor = System.Drawing.Color.White;
            this.pictureBoxAygazType.InitialImage = null;
            this.pictureBoxAygazType.Location = new System.Drawing.Point(424, 104);
            this.pictureBoxAygazType.Name = "pictureBoxAygazType";
            this.pictureBoxAygazType.Size = new System.Drawing.Size(432, 452);
            this.pictureBoxAygazType.TabIndex = 35;
            this.pictureBoxAygazType.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(197, 583);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(886, 205);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // labelDurationLeft
            // 
            this.labelDurationLeft.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelDurationLeft.ForeColor = System.Drawing.Color.White;
            this.labelDurationLeft.Location = new System.Drawing.Point(1110, 9);
            this.labelDurationLeft.Name = "labelDurationLeft";
            this.labelDurationLeft.Size = new System.Drawing.Size(158, 59);
            this.labelDurationLeft.TabIndex = 40;
            this.labelDurationLeft.Text = "300 sn";
            this.labelDurationLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDurationLeft.Visible = false;
            // 
            // timerDurationLeft
            // 
            this.timerDurationLeft.Interval = 1000;
            this.timerDurationLeft.Tick += new System.EventHandler(this.timerDurationLeft_Tick);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.labelDurationLeft);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelBoxAygazTypePrice);
            this.Controls.Add(this.labelBoxAygazTypeName);
            this.Controls.Add(this.pictureBoxAygazTypeImage);
            this.Controls.Add(this.pictureBoxAygazType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PaymentForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaymentForm";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.Shown += new System.EventHandler(this.PaymentForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazTypeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelBoxAygazTypePrice;
        private System.Windows.Forms.Label labelBoxAygazTypeName;
        private System.Windows.Forms.PictureBox pictureBoxAygazTypeImage;
        private System.Windows.Forms.PictureBox pictureBoxAygazType;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelDurationLeft;
        private System.Windows.Forms.Timer timerDurationLeft;
    }
}