namespace evieplus.Forms
{
    partial class NotAvailableForm
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
            this.labelBoxAygazTypePrice = new System.Windows.Forms.Label();
            this.labelBoxAygazTypeName = new System.Windows.Forms.Label();
            this.pictureBoxAygazTypeImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.pictureBoxAygazType = new System.Windows.Forms.PictureBox();
            this.buttonBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazTypeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazType)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBoxAygazTypePrice
            // 
            this.labelBoxAygazTypePrice.BackColor = System.Drawing.Color.White;
            this.labelBoxAygazTypePrice.Font = new System.Drawing.Font("Montserrat ExtraBold", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBoxAygazTypePrice.Location = new System.Drawing.Point(434, 648);
            this.labelBoxAygazTypePrice.Name = "labelBoxAygazTypePrice";
            this.labelBoxAygazTypePrice.Size = new System.Drawing.Size(410, 90);
            this.labelBoxAygazTypePrice.TabIndex = 17;
            this.labelBoxAygazTypePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBoxAygazTypeName
            // 
            this.labelBoxAygazTypeName.BackColor = System.Drawing.Color.White;
            this.labelBoxAygazTypeName.Font = new System.Drawing.Font("Montserrat ExtraBold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBoxAygazTypeName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelBoxAygazTypeName.Location = new System.Drawing.Point(434, 510);
            this.labelBoxAygazTypeName.Name = "labelBoxAygazTypeName";
            this.labelBoxAygazTypeName.Size = new System.Drawing.Size(410, 138);
            this.labelBoxAygazTypeName.TabIndex = 16;
            this.labelBoxAygazTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxAygazTypeImage
            // 
            this.pictureBoxAygazTypeImage.BackColor = System.Drawing.Color.White;
            this.pictureBoxAygazTypeImage.Location = new System.Drawing.Point(543, 307);
            this.pictureBoxAygazTypeImage.Name = "pictureBoxAygazTypeImage";
            this.pictureBoxAygazTypeImage.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxAygazTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAygazTypeImage.TabIndex = 15;
            this.pictureBoxAygazTypeImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(441, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(398, 59);
            this.label2.TabIndex = 14;
            this.label2.Text = "ÜRÜN SEÇİMİ";
            // 
            // labelMessage
            // 
            this.labelMessage.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMessage.ForeColor = System.Drawing.Color.White;
            this.labelMessage.Location = new System.Drawing.Point(12, 151);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(1256, 144);
            this.labelMessage.TabIndex = 13;
            this.labelMessage.Text = "Maalesef bu ürün şu an dolapta bulunmamaktadır.";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxAygazType
            // 
            this.pictureBoxAygazType.BackColor = System.Drawing.Color.White;
            this.pictureBoxAygazType.InitialImage = null;
            this.pictureBoxAygazType.Location = new System.Drawing.Point(424, 298);
            this.pictureBoxAygazType.Name = "pictureBoxAygazType";
            this.pictureBoxAygazType.Size = new System.Drawing.Size(432, 452);
            this.pictureBoxAygazType.TabIndex = 12;
            this.pictureBoxAygazType.TabStop = false;
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
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // NotAvailableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelBoxAygazTypePrice);
            this.Controls.Add(this.labelBoxAygazTypeName);
            this.Controls.Add(this.pictureBoxAygazTypeImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.pictureBoxAygazType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NotAvailableForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NotAvailableForm";
            this.Load += new System.EventHandler(this.NotAvailableForm_Load);
            this.Shown += new System.EventHandler(this.NotAvailableForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazTypeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBoxAygazTypePrice;
        private System.Windows.Forms.Label labelBoxAygazTypeName;
        private System.Windows.Forms.PictureBox pictureBoxAygazTypeImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.PictureBox pictureBoxAygazType;
        private System.Windows.Forms.Button buttonBack;
    }
}