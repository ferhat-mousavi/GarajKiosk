namespace evieplus.Forms
{
    partial class TransactionCompleteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionCompleteForm));
            this.labelBoxAygazTypePrice = new System.Windows.Forms.Label();
            this.labelBoxAygazTypeName = new System.Windows.Forms.Label();
            this.pictureBoxAygazTypeImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxAygazType = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazTypeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBoxAygazTypePrice
            // 
            this.labelBoxAygazTypePrice.BackColor = System.Drawing.Color.White;
            this.labelBoxAygazTypePrice.Font = new System.Drawing.Font("Montserrat ExtraBold", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBoxAygazTypePrice.Location = new System.Drawing.Point(733, 445);
            this.labelBoxAygazTypePrice.Name = "labelBoxAygazTypePrice";
            this.labelBoxAygazTypePrice.Size = new System.Drawing.Size(410, 90);
            this.labelBoxAygazTypePrice.TabIndex = 44;
            this.labelBoxAygazTypePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBoxAygazTypeName
            // 
            this.labelBoxAygazTypeName.BackColor = System.Drawing.Color.White;
            this.labelBoxAygazTypeName.Font = new System.Drawing.Font("Montserrat ExtraBold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBoxAygazTypeName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelBoxAygazTypeName.Location = new System.Drawing.Point(733, 307);
            this.labelBoxAygazTypeName.Name = "labelBoxAygazTypeName";
            this.labelBoxAygazTypeName.Size = new System.Drawing.Size(410, 138);
            this.labelBoxAygazTypeName.TabIndex = 43;
            this.labelBoxAygazTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxAygazTypeImage
            // 
            this.pictureBoxAygazTypeImage.BackColor = System.Drawing.Color.White;
            this.pictureBoxAygazTypeImage.Location = new System.Drawing.Point(842, 104);
            this.pictureBoxAygazTypeImage.Name = "pictureBoxAygazTypeImage";
            this.pictureBoxAygazTypeImage.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxAygazTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAygazTypeImage.TabIndex = 42;
            this.pictureBoxAygazTypeImage.TabStop = false;
            // 
            // pictureBoxAygazType
            // 
            this.pictureBoxAygazType.BackColor = System.Drawing.Color.White;
            this.pictureBoxAygazType.InitialImage = null;
            this.pictureBoxAygazType.Location = new System.Drawing.Point(723, 95);
            this.pictureBoxAygazType.Name = "pictureBoxAygazType";
            this.pictureBoxAygazType.Size = new System.Drawing.Size(432, 452);
            this.pictureBoxAygazType.TabIndex = 41;
            this.pictureBoxAygazType.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(381, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(519, 59);
            this.label2.TabIndex = 40;
            this.label2.Text = "ÖDEME BAŞARILI!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(109, 573);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1063, 188);
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // labelMessage
            // 
            this.labelMessage.Font = new System.Drawing.Font("Montserrat ExtraBold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMessage.ForeColor = System.Drawing.Color.White;
            this.labelMessage.Location = new System.Drawing.Point(125, 95);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(447, 452);
            this.labelMessage.TabIndex = 46;
            this.labelMessage.Text = "Ürününüzü dolaptan xxxxxxxx şifresi ile alabilirsiniz. ";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TransactionCompleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelBoxAygazTypePrice);
            this.Controls.Add(this.labelBoxAygazTypeName);
            this.Controls.Add(this.pictureBoxAygazTypeImage);
            this.Controls.Add(this.pictureBoxAygazType);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TransactionCompleteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TransactionCompleteForm";
            this.Load += new System.EventHandler(this.TransactionCompleteForm_Load);
            this.Shown += new System.EventHandler(this.TransactionCompleteForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazTypeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAygazType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBoxAygazTypePrice;
        private System.Windows.Forms.Label labelBoxAygazTypeName;
        private System.Windows.Forms.PictureBox pictureBoxAygazTypeImage;
        private System.Windows.Forms.PictureBox pictureBoxAygazType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelMessage;
    }
}