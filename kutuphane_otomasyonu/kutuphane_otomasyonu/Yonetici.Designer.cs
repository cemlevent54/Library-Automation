namespace kutuphane_otomasyonu
{
    partial class Yonetici
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_yoneticiSignUp = new System.Windows.Forms.Button();
            this.btn_yoneticilogin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btn_yoneticiSignUp);
            this.panel3.Controls.Add(this.btn_yoneticilogin);
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(237, 595);
            this.panel3.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kutuphane_otomasyonu.Properties.Resources.kutuphane;
            this.pictureBox1.Location = new System.Drawing.Point(44, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 500);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 25);
            this.label5.TabIndex = 33;
            this.label5.Text = "Yönetici Ekle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Yönetici Giriş";
            // 
            // btn_yoneticiSignUp
            // 
            this.btn_yoneticiSignUp.BackgroundImage = global::kutuphane_otomasyonu.Properties.Resources.useradd12;
            this.btn_yoneticiSignUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_yoneticiSignUp.Location = new System.Drawing.Point(44, 370);
            this.btn_yoneticiSignUp.Name = "btn_yoneticiSignUp";
            this.btn_yoneticiSignUp.Size = new System.Drawing.Size(155, 127);
            this.btn_yoneticiSignUp.TabIndex = 6;
            this.btn_yoneticiSignUp.UseVisualStyleBackColor = true;
            this.btn_yoneticiSignUp.Click += new System.EventHandler(this.btn_yoneticiSignUp_Click);
            // 
            // btn_yoneticilogin
            // 
            this.btn_yoneticilogin.BackgroundImage = global::kutuphane_otomasyonu.Properties.Resources.admin;
            this.btn_yoneticilogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_yoneticilogin.Location = new System.Drawing.Point(44, 186);
            this.btn_yoneticilogin.Name = "btn_yoneticilogin";
            this.btn_yoneticilogin.Size = new System.Drawing.Size(155, 127);
            this.btn_yoneticilogin.TabIndex = 5;
            this.btn_yoneticilogin.UseVisualStyleBackColor = true;
            this.btn_yoneticilogin.Click += new System.EventHandler(this.btn_yoneticilogin_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(243, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 595);
            this.panel1.TabIndex = 5;
            // 
            // Yonetici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 602);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Yonetici";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yonetici";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_yoneticiSignUp;
        private System.Windows.Forms.Button btn_yoneticilogin;
        private System.Windows.Forms.Panel panel1;
    }
}