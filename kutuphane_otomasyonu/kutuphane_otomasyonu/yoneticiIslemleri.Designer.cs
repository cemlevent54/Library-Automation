using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace kutuphane_otomasyonu
{
    partial class yoneticiIslemleri
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_ekle = new System.Windows.Forms.Button();
            this.btn_sil = new System.Windows.Forms.Button();
            this.btn_goruntule = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_kitapSil = new System.Windows.Forms.Button();
            this.btn_KitapGoruntule = new System.Windows.Forms.Button();
            this.btn_odunKitapArsivi = new System.Windows.Forms.Button();
            this.btn_kitapEkle = new System.Windows.Forms.Button();
            this.btn_odunc = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_ekle);
            this.panel1.Controls.Add(this.btn_sil);
            this.panel1.Controls.Add(this.btn_goruntule);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 675);
            this.panel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 599);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 59);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kullanıcı Görüntüle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 426);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "Kullanıcı Silme";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Kullanıcı Ekleme";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kutuphane_otomasyonu.Properties.Resources.kutuphane;
            this.pictureBox1.Location = new System.Drawing.Point(25, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btn_ekle
            // 
            this.btn_ekle.BackgroundImage = global::kutuphane_otomasyonu.Properties.Resources.useradd11;
            this.btn_ekle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ekle.Location = new System.Drawing.Point(39, 142);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(110, 105);
            this.btn_ekle.TabIndex = 4;
            this.btn_ekle.UseVisualStyleBackColor = true;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // btn_sil
            // 
            this.btn_sil.BackgroundImage = global::kutuphane_otomasyonu.Properties.Resources.userdelete1;
            this.btn_sil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_sil.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sil.Location = new System.Drawing.Point(39, 315);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(110, 108);
            this.btn_sil.TabIndex = 5;
            this.btn_sil.UseVisualStyleBackColor = true;
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // btn_goruntule
            // 
            this.btn_goruntule.BackgroundImage = global::kutuphane_otomasyonu.Properties.Resources.viewusers1;
            this.btn_goruntule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_goruntule.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_goruntule.Location = new System.Drawing.Point(39, 490);
            this.btn_goruntule.Name = "btn_goruntule";
            this.btn_goruntule.Size = new System.Drawing.Size(110, 106);
            this.btn_goruntule.TabIndex = 0;
            this.btn_goruntule.UseVisualStyleBackColor = true;
            this.btn_goruntule.Click += new System.EventHandler(this.btn_goruntule_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btn_kitapSil);
            this.panel2.Controls.Add(this.btn_KitapGoruntule);
            this.panel2.Controls.Add(this.btn_odunKitapArsivi);
            this.panel2.Controls.Add(this.btn_kitapEkle);
            this.panel2.Controls.Add(this.btn_odunc);
            this.panel2.Location = new System.Drawing.Point(180, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1057, 134);
            this.panel2.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(821, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 22);
            this.label8.TabIndex = 17;
            this.label8.Text = "Ödünç Kitaplar Arşivi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(619, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 22);
            this.label7.TabIndex = 16;
            this.label7.Text = "Ödünç Kitap Takibi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(413, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 22);
            this.label6.TabIndex = 15;
            this.label6.Text = "Kitapları Görüntüle";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(250, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 22);
            this.label5.TabIndex = 14;
            this.label5.Text = "Kitap Sil";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 22);
            this.label4.TabIndex = 13;
            this.label4.Text = "Kitap Ekleme";
            // 
            // btn_kitapSil
            // 
            this.btn_kitapSil.BackgroundImage = global::kutuphane_otomasyonu.Properties.Resources.deletebook1;
            this.btn_kitapSil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_kitapSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_kitapSil.Location = new System.Drawing.Point(237, 3);
            this.btn_kitapSil.Name = "btn_kitapSil";
            this.btn_kitapSil.Size = new System.Drawing.Size(107, 84);
            this.btn_kitapSil.TabIndex = 6;
            this.btn_kitapSil.UseVisualStyleBackColor = true;
            this.btn_kitapSil.Click += new System.EventHandler(this.btn_kitapSil_Click);
            // 
            // btn_KitapGoruntule
            // 
            this.btn_KitapGoruntule.BackgroundImage = global::kutuphane_otomasyonu.Properties.Resources.booksearch21;
            this.btn_KitapGoruntule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_KitapGoruntule.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_KitapGoruntule.Location = new System.Drawing.Point(443, 3);
            this.btn_KitapGoruntule.Name = "btn_KitapGoruntule";
            this.btn_KitapGoruntule.Size = new System.Drawing.Size(100, 84);
            this.btn_KitapGoruntule.TabIndex = 2;
            this.btn_KitapGoruntule.UseVisualStyleBackColor = true;
            this.btn_KitapGoruntule.Click += new System.EventHandler(this.btn_KitapGoruntule_Click);
            // 
            // btn_odunKitapArsivi
            // 
            this.btn_odunKitapArsivi.BackgroundImage = global::kutuphane_otomasyonu.Properties.Resources.bookarchive11;
            this.btn_odunKitapArsivi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_odunKitapArsivi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_odunKitapArsivi.Location = new System.Drawing.Point(859, 3);
            this.btn_odunKitapArsivi.Name = "btn_odunKitapArsivi";
            this.btn_odunKitapArsivi.Size = new System.Drawing.Size(100, 84);
            this.btn_odunKitapArsivi.TabIndex = 7;
            this.btn_odunKitapArsivi.UseVisualStyleBackColor = true;
            this.btn_odunKitapArsivi.Click += new System.EventHandler(this.btn_odunKitapArsivi_Click);
            // 
            // btn_kitapEkle
            // 
            this.btn_kitapEkle.BackgroundImage = global::kutuphane_otomasyonu.Properties.Resources.addbook1;
            this.btn_kitapEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_kitapEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_kitapEkle.Location = new System.Drawing.Point(41, 3);
            this.btn_kitapEkle.Name = "btn_kitapEkle";
            this.btn_kitapEkle.Size = new System.Drawing.Size(100, 84);
            this.btn_kitapEkle.TabIndex = 1;
            this.btn_kitapEkle.UseVisualStyleBackColor = true;
            this.btn_kitapEkle.Click += new System.EventHandler(this.btn_kitapEkle_Click);
            // 
            // btn_odunc
            // 
            this.btn_odunc.BackgroundImage = global::kutuphane_otomasyonu.Properties.Resources.iconbook;
            this.btn_odunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_odunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_odunc.Location = new System.Drawing.Point(650, 3);
            this.btn_odunc.Name = "btn_odunc";
            this.btn_odunc.Size = new System.Drawing.Size(100, 84);
            this.btn_odunc.TabIndex = 3;
            this.btn_odunc.UseVisualStyleBackColor = true;
            this.btn_odunc.Click += new System.EventHandler(this.btn_odunc_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(179, 133);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1058, 543);
            this.panel3.TabIndex = 10;
            // 
            // yoneticiIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1241, 679);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "yoneticiIslemleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "yoneticiSayfasi";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_goruntule;
        private Button btn_kitapEkle;
        private Button btn_KitapGoruntule;
        private Button btn_odunc;
        private Button btn_ekle;
        private Button btn_sil;
        private Button btn_kitapSil;
        private Button btn_odunKitapArsivi;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Panel panel3;
    }
}