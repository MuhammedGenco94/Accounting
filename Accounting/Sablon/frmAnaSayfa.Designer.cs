namespace Accounting
{
    partial class frmAnaSayfa
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
            this.pnlUst = new System.Windows.Forms.Panel();
            this.btnKapat = new System.Windows.Forms.Button();
            this.btnStok = new System.Windows.Forms.Button();
            this.btnBolum2 = new System.Windows.Forms.Button();
            this.btnSatis = new System.Windows.Forms.Button();
            this.grpLeft = new System.Windows.Forms.GroupBox();
            this.pnlLeft3 = new System.Windows.Forms.Panel();
            this.pnlLeft2 = new System.Windows.Forms.Panel();
            this.btnUrunListe = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnFirmaListe = new System.Windows.Forms.Button();
            this.btnCompany = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnKargo = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.pnlLeft1 = new System.Windows.Forms.Panel();
            this.btnStokListe = new System.Windows.Forms.Button();
            this.btnSatisFormu = new System.Windows.Forms.Button();
            this.btnAlisListe = new System.Windows.Forms.Button();
            this.btnAlis = new System.Windows.Forms.Button();
            this.btnSatisListe = new System.Windows.Forms.Button();
            this.pnlUst.SuspendLayout();
            this.grpLeft.SuspendLayout();
            this.pnlLeft2.SuspendLayout();
            this.pnlLeft1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUst
            // 
            this.pnlUst.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlUst.Controls.Add(this.btnKapat);
            this.pnlUst.Controls.Add(this.btnStok);
            this.pnlUst.Controls.Add(this.btnBolum2);
            this.pnlUst.Controls.Add(this.btnSatis);
            this.pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUst.Location = new System.Drawing.Point(0, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Size = new System.Drawing.Size(935, 99);
            this.pnlUst.TabIndex = 0;
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.BackColor = System.Drawing.Color.Red;
            this.btnKapat.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKapat.ForeColor = System.Drawing.Color.White;
            this.btnKapat.Location = new System.Drawing.Point(780, 12);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(143, 65);
            this.btnKapat.TabIndex = 0;
            this.btnKapat.Text = "KAPAT";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnStok
            // 
            this.btnStok.BackColor = System.Drawing.Color.Maroon;
            this.btnStok.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStok.ForeColor = System.Drawing.Color.White;
            this.btnStok.Location = new System.Drawing.Point(310, 12);
            this.btnStok.Name = "btnStok";
            this.btnStok.Size = new System.Drawing.Size(143, 65);
            this.btnStok.TabIndex = 0;
            this.btnStok.Text = "STOK İŞLEMLERİ";
            this.btnStok.UseVisualStyleBackColor = false;
            this.btnStok.Click += new System.EventHandler(this.btnBolum3_Click);
            // 
            // btnBolum2
            // 
            this.btnBolum2.BackColor = System.Drawing.Color.Olive;
            this.btnBolum2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBolum2.ForeColor = System.Drawing.Color.White;
            this.btnBolum2.Location = new System.Drawing.Point(161, 12);
            this.btnBolum2.Name = "btnBolum2";
            this.btnBolum2.Size = new System.Drawing.Size(143, 65);
            this.btnBolum2.TabIndex = 0;
            this.btnBolum2.Text = "BİLGİ GİRİŞ İŞLEMLERİ";
            this.btnBolum2.UseVisualStyleBackColor = false;
            this.btnBolum2.Click += new System.EventHandler(this.btnBolum2_Click);
            // 
            // btnSatis
            // 
            this.btnSatis.BackColor = System.Drawing.Color.Teal;
            this.btnSatis.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatis.ForeColor = System.Drawing.Color.White;
            this.btnSatis.Location = new System.Drawing.Point(12, 12);
            this.btnSatis.Name = "btnSatis";
            this.btnSatis.Size = new System.Drawing.Size(143, 65);
            this.btnSatis.TabIndex = 0;
            this.btnSatis.Text = "SATIŞ İŞLEMLERİ";
            this.btnSatis.UseVisualStyleBackColor = false;
            this.btnSatis.Click += new System.EventHandler(this.btnBolum1_Click);
            // 
            // grpLeft
            // 
            this.grpLeft.BackColor = System.Drawing.Color.White;
            this.grpLeft.Controls.Add(this.pnlLeft3);
            this.grpLeft.Controls.Add(this.pnlLeft2);
            this.grpLeft.Controls.Add(this.pnlLeft1);
            this.grpLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpLeft.Location = new System.Drawing.Point(0, 99);
            this.grpLeft.Name = "grpLeft";
            this.grpLeft.Size = new System.Drawing.Size(195, 392);
            this.grpLeft.TabIndex = 1;
            this.grpLeft.TabStop = false;
            this.grpLeft.Text = "groupBox1";
            // 
            // pnlLeft3
            // 
            this.pnlLeft3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlLeft3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft3.Location = new System.Drawing.Point(389, 16);
            this.pnlLeft3.Name = "pnlLeft3";
            this.pnlLeft3.Size = new System.Drawing.Size(193, 373);
            this.pnlLeft3.TabIndex = 2;
            this.pnlLeft3.Visible = false;
            // 
            // pnlLeft2
            // 
            this.pnlLeft2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlLeft2.Controls.Add(this.btnUrunListe);
            this.pnlLeft2.Controls.Add(this.btnProduct);
            this.pnlLeft2.Controls.Add(this.btnFirmaListe);
            this.pnlLeft2.Controls.Add(this.btnCompany);
            this.pnlLeft2.Controls.Add(this.btnEmployee);
            this.pnlLeft2.Controls.Add(this.btnKargo);
            this.pnlLeft2.Controls.Add(this.btnCategory);
            this.pnlLeft2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft2.Location = new System.Drawing.Point(196, 16);
            this.pnlLeft2.Name = "pnlLeft2";
            this.pnlLeft2.Size = new System.Drawing.Size(193, 373);
            this.pnlLeft2.TabIndex = 2;
            this.pnlLeft2.Visible = false;
            // 
            // btnUrunListe
            // 
            this.btnUrunListe.BackColor = System.Drawing.Color.Silver;
            this.btnUrunListe.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUrunListe.ForeColor = System.Drawing.Color.Black;
            this.btnUrunListe.Location = new System.Drawing.Point(3, 293);
            this.btnUrunListe.Name = "btnUrunListe";
            this.btnUrunListe.Size = new System.Drawing.Size(183, 33);
            this.btnUrunListe.TabIndex = 0;
            this.btnUrunListe.Text = "Ürün Listesi";
            this.btnUrunListe.UseVisualStyleBackColor = false;
            this.btnUrunListe.Click += new System.EventHandler(this.btnUrunListe_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.Silver;
            this.btnProduct.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.Color.Black;
            this.btnProduct.Location = new System.Drawing.Point(3, 254);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(183, 33);
            this.btnProduct.TabIndex = 0;
            this.btnProduct.Text = "Ürün Giriş";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnFirmaListe
            // 
            this.btnFirmaListe.BackColor = System.Drawing.Color.Silver;
            this.btnFirmaListe.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirmaListe.ForeColor = System.Drawing.Color.Black;
            this.btnFirmaListe.Location = new System.Drawing.Point(4, 187);
            this.btnFirmaListe.Name = "btnFirmaListe";
            this.btnFirmaListe.Size = new System.Drawing.Size(183, 33);
            this.btnFirmaListe.TabIndex = 0;
            this.btnFirmaListe.Text = "Firma Listesi";
            this.btnFirmaListe.UseVisualStyleBackColor = false;
            this.btnFirmaListe.Click += new System.EventHandler(this.btnFirmaListe_Click);
            // 
            // btnCompany
            // 
            this.btnCompany.BackColor = System.Drawing.Color.Silver;
            this.btnCompany.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompany.ForeColor = System.Drawing.Color.Black;
            this.btnCompany.Location = new System.Drawing.Point(4, 148);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Size = new System.Drawing.Size(183, 33);
            this.btnCompany.TabIndex = 0;
            this.btnCompany.Text = "Firma Giriş";
            this.btnCompany.UseVisualStyleBackColor = false;
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.Silver;
            this.btnEmployee.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.ForeColor = System.Drawing.Color.Black;
            this.btnEmployee.Location = new System.Drawing.Point(4, 81);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(183, 33);
            this.btnEmployee.TabIndex = 0;
            this.btnEmployee.Text = "Çalışan Giriş";
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnKargo
            // 
            this.btnKargo.BackColor = System.Drawing.Color.Silver;
            this.btnKargo.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKargo.ForeColor = System.Drawing.Color.Black;
            this.btnKargo.Location = new System.Drawing.Point(4, 42);
            this.btnKargo.Name = "btnKargo";
            this.btnKargo.Size = new System.Drawing.Size(183, 33);
            this.btnKargo.TabIndex = 0;
            this.btnKargo.Text = "Kargo Giriş";
            this.btnKargo.UseVisualStyleBackColor = false;
            this.btnKargo.Click += new System.EventHandler(this.btnKargo_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.BackColor = System.Drawing.Color.Silver;
            this.btnCategory.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.ForeColor = System.Drawing.Color.Black;
            this.btnCategory.Location = new System.Drawing.Point(3, 3);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(183, 33);
            this.btnCategory.TabIndex = 0;
            this.btnCategory.Text = "Kategori Giriş";
            this.btnCategory.UseVisualStyleBackColor = false;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // pnlLeft1
            // 
            this.pnlLeft1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlLeft1.Controls.Add(this.btnStokListe);
            this.pnlLeft1.Controls.Add(this.btnSatisListe);
            this.pnlLeft1.Controls.Add(this.btnSatisFormu);
            this.pnlLeft1.Controls.Add(this.btnAlisListe);
            this.pnlLeft1.Controls.Add(this.btnAlis);
            this.pnlLeft1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft1.Location = new System.Drawing.Point(3, 16);
            this.pnlLeft1.Name = "pnlLeft1";
            this.pnlLeft1.Size = new System.Drawing.Size(193, 373);
            this.pnlLeft1.TabIndex = 2;
            // 
            // btnStokListe
            // 
            this.btnStokListe.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnStokListe.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStokListe.ForeColor = System.Drawing.Color.Black;
            this.btnStokListe.Location = new System.Drawing.Point(3, 197);
            this.btnStokListe.Name = "btnStokListe";
            this.btnStokListe.Size = new System.Drawing.Size(183, 36);
            this.btnStokListe.TabIndex = 0;
            this.btnStokListe.Text = "Stok Listesi";
            this.btnStokListe.UseVisualStyleBackColor = false;
            this.btnStokListe.Click += new System.EventHandler(this.btnStokListe_Click);
            // 
            // btnSatisFormu
            // 
            this.btnSatisFormu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSatisFormu.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatisFormu.ForeColor = System.Drawing.Color.Black;
            this.btnSatisFormu.Location = new System.Drawing.Point(3, 97);
            this.btnSatisFormu.Name = "btnSatisFormu";
            this.btnSatisFormu.Size = new System.Drawing.Size(183, 36);
            this.btnSatisFormu.TabIndex = 0;
            this.btnSatisFormu.Text = "Satış Formu";
            this.btnSatisFormu.UseVisualStyleBackColor = false;
            this.btnSatisFormu.Click += new System.EventHandler(this.btnSatisFormu_Click);
            // 
            // btnAlisListe
            // 
            this.btnAlisListe.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAlisListe.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAlisListe.ForeColor = System.Drawing.Color.Black;
            this.btnAlisListe.Location = new System.Drawing.Point(4, 49);
            this.btnAlisListe.Name = "btnAlisListe";
            this.btnAlisListe.Size = new System.Drawing.Size(183, 36);
            this.btnAlisListe.TabIndex = 0;
            this.btnAlisListe.Text = "Alış Listesi";
            this.btnAlisListe.UseVisualStyleBackColor = false;
            this.btnAlisListe.Click += new System.EventHandler(this.btnAlisListe_Click);
            // 
            // btnAlis
            // 
            this.btnAlis.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAlis.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAlis.ForeColor = System.Drawing.Color.Black;
            this.btnAlis.Location = new System.Drawing.Point(3, 3);
            this.btnAlis.Name = "btnAlis";
            this.btnAlis.Size = new System.Drawing.Size(183, 36);
            this.btnAlis.TabIndex = 0;
            this.btnAlis.Text = "Alış Formu";
            this.btnAlis.UseVisualStyleBackColor = false;
            this.btnAlis.Click += new System.EventHandler(this.btnAlis_Click);
            // 
            // btnSatisListe
            // 
            this.btnSatisListe.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSatisListe.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatisListe.ForeColor = System.Drawing.Color.Black;
            this.btnSatisListe.Location = new System.Drawing.Point(3, 145);
            this.btnSatisListe.Name = "btnSatisListe";
            this.btnSatisListe.Size = new System.Drawing.Size(183, 36);
            this.btnSatisListe.TabIndex = 0;
            this.btnSatisListe.Text = "Satış Listesi";
            this.btnSatisListe.UseVisualStyleBackColor = false;
            this.btnSatisListe.Click += new System.EventHandler(this.btnSatisListe_Click);
            // 
            // frmAnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 491);
            this.Controls.Add(this.grpLeft);
            this.Controls.Add(this.pnlUst);
            this.IsMdiContainer = true;
            this.Name = "frmAnaSayfa";
            this.Text = "frmAnaSayfa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAnaSayfa_Load);
            this.pnlUst.ResumeLayout(false);
            this.grpLeft.ResumeLayout(false);
            this.pnlLeft2.ResumeLayout(false);
            this.pnlLeft1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUst;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btnStok;
        private System.Windows.Forms.Button btnBolum2;
        private System.Windows.Forms.Button btnSatis;
        private System.Windows.Forms.GroupBox grpLeft;
        private System.Windows.Forms.Panel pnlLeft2;
        private System.Windows.Forms.Panel pnlLeft1;
        private System.Windows.Forms.Panel pnlLeft3;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnKargo;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnCompany;
        private System.Windows.Forms.Button btnFirmaListe;
        private System.Windows.Forms.Button btnUrunListe;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnStokListe;
        private System.Windows.Forms.Button btnSatisFormu;
        private System.Windows.Forms.Button btnAlisListe;
        private System.Windows.Forms.Button btnAlis;
        private System.Windows.Forms.Button btnSatisListe;
    }
}