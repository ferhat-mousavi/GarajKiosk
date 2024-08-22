namespace evieplus.Forms
{
    partial class OutOfServiceForm
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
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonSettings2 = new System.Windows.Forms.Button();
            this.buttonSettings1 = new System.Windows.Forms.Button();
            this.buttonSettings3 = new System.Windows.Forms.Button();
            this.buttonSettings4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMessage.ForeColor = System.Drawing.Color.White;
            this.labelMessage.Location = new System.Drawing.Point(12, 176);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(1256, 296);
            this.labelMessage.TabIndex = 14;
            this.labelMessage.Text = "Maalesef Şu Anda Hizmet Veremiyoruz.";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSettings2
            // 
            this.buttonSettings2.FlatAppearance.BorderSize = 0;
            this.buttonSettings2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonSettings2.Location = new System.Drawing.Point(1181, 0);
            this.buttonSettings2.Name = "buttonSettings2";
            this.buttonSettings2.Size = new System.Drawing.Size(100, 100);
            this.buttonSettings2.TabIndex = 18;
            this.buttonSettings2.UseVisualStyleBackColor = true;
            this.buttonSettings2.Click += new System.EventHandler(this.buttonSettings2_Click);
            // 
            // buttonSettings1
            // 
            this.buttonSettings1.FlatAppearance.BorderSize = 0;
            this.buttonSettings1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonSettings1.Location = new System.Drawing.Point(0, 0);
            this.buttonSettings1.Name = "buttonSettings1";
            this.buttonSettings1.Size = new System.Drawing.Size(100, 100);
            this.buttonSettings1.TabIndex = 17;
            this.buttonSettings1.UseVisualStyleBackColor = true;
            this.buttonSettings1.Click += new System.EventHandler(this.buttonSettings1_Click);
            // 
            // buttonSettings3
            // 
            this.buttonSettings3.FlatAppearance.BorderSize = 0;
            this.buttonSettings3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonSettings3.Location = new System.Drawing.Point(0, 700);
            this.buttonSettings3.Name = "buttonSettings3";
            this.buttonSettings3.Size = new System.Drawing.Size(100, 100);
            this.buttonSettings3.TabIndex = 16;
            this.buttonSettings3.UseVisualStyleBackColor = true;
            this.buttonSettings3.Click += new System.EventHandler(this.buttonSettings3_Click);
            // 
            // buttonSettings4
            // 
            this.buttonSettings4.FlatAppearance.BorderSize = 0;
            this.buttonSettings4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonSettings4.Location = new System.Drawing.Point(1181, 700);
            this.buttonSettings4.Name = "buttonSettings4";
            this.buttonSettings4.Size = new System.Drawing.Size(100, 100);
            this.buttonSettings4.TabIndex = 15;
            this.buttonSettings4.UseVisualStyleBackColor = true;
            this.buttonSettings4.Click += new System.EventHandler(this.buttonSettings4_Click);
            // 
            // OutOfServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.buttonSettings2);
            this.Controls.Add(this.buttonSettings1);
            this.Controls.Add(this.buttonSettings3);
            this.Controls.Add(this.buttonSettings4);
            this.Controls.Add(this.labelMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OutOfServiceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OutOfServiceForm";
            this.Shown += new System.EventHandler(this.OutOfServiceForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonSettings2;
        private System.Windows.Forms.Button buttonSettings1;
        private System.Windows.Forms.Button buttonSettings3;
        private System.Windows.Forms.Button buttonSettings4;
    }
}