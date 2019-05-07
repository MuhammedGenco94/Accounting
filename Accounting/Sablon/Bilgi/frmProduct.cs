using Accounting.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.Properties;

namespace Accounting.Bilgi
{
    public partial class frmProduct : Form
    {
        AccountingDBDataContext _db = new AccountingDBDataContext();
        Mesajlar _m = new Mesajlar();
        Formlar _f = new Formlar();
        Numaralar _n = new Numaralar();

        bool edit = false;
        int _urunId = -1;
        int _kategoriId = -1;

        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        void Temizle()
        {
            foreach (Control _control in splitContainer1.Panel1.Controls)
            {
                if (_control is TextBox)
                {
                    _control.Text = "";
                }
                txtUrunNo.Text = _n.UrunNo();
                edit = false;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (edit && _m.Guncelle() == DialogResult.Yes)
            {
                Guncelle();
            }
            else if (!edit)
            {
                YeniKaydet();
            }
        }

        void YeniKaydet()
        {
            try
            {
                tblProduct pro = new tblProduct();
                pro.ProNo = int.Parse(txtUrunNo.Text);
                pro.Name = txtUrunAdi.Text;
                //pro.CategoryID = _db.tblCategories.First(x => x.CategoryName == (txtCategoryId.Text)).ID;
                pro.CategoryID = int.Parse(txtCategoryId.Text);
                pro.Note = txtNot.Text;
                pro.UnitPrice = decimal.Parse(txtBirimFiyat.Text);


                _db.tblProducts.InsertOnSubmit(pro);
                _db.SubmitChanges();
                _m.YeniKayit("Kayıt başarıyla gerçekleşti.");
                Temizle();
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        void Guncelle()
        {
            try
            {
                tblProduct pro = _db.tblProducts.First(x => x.ID == _urunId);
                pro.ProNo = int.Parse(txtUrunNo.Text);
                pro.Name = txtUrunAdi.Text;
                pro.CategoryID = int.Parse(txtCategoryId.Text);
                pro.Note = txtNot.Text;
                pro.UnitPrice = decimal.Parse(txtBirimFiyat.Text);

                _db.SubmitChanges();
                _m.Guncelle(true);
                Temizle();
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            var btnUrunNo = new Button();
            btnUrunNo.Size = new Size(25, txtUrunNo.ClientSize.Height + 2);
            btnUrunNo.Location = new Point(txtUrunNo.ClientSize.Width - btnUrunNo.Width, -1);
            btnUrunNo.Cursor = Cursors.Default;
            btnUrunNo.Image = Resources.arrow1;
            txtUrunNo.Controls.Add(btnUrunNo);
            SendMessage(txtUrunNo.Handle, 0xd3, (IntPtr)2, (IntPtr)(btnUrunNo.Width << 16));
            btnUrunNo.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            var btnKategoriNo = new Button();
            btnKategoriNo.Size = new Size(25, txtCategoryId.ClientSize.Height + 2);
            btnKategoriNo.Location = new Point(txtCategoryId.ClientSize.Width - btnKategoriNo.Width, -1);
            btnKategoriNo.Cursor = Cursors.Default;
            btnKategoriNo.Image = Image.FromFile(@"C:\Users\Muhammed\source\repos\Accounting\Sablon\Resources\arrow2.png");
            txtCategoryId.Controls.Add(btnKategoriNo);
            btnKategoriNo.Anchor = (AnchorStyles.Top | AnchorStyles.Right);


            base.OnLoad(e);

            btnUrunNo.Click += btnUrunNo_Click;
            btnKategoriNo.Click += btnKategoriNo_Click;
        }
        
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr w, uint m, IntPtr p1, IntPtr p2);


        private void btnUrunNo_Click(object sender, EventArgs e)
        {
            int Aktarma_Id = _f.UrunList(true);
            if (Aktarma_Id > 0)
            {
                product_Ac(Aktarma_Id);
            }
            frmAnaSayfa.Aktarma = -1;
        }

        void product_Ac(int Aktarma_Id)
        {
            try
            {
                edit = true;
                _urunId = Aktarma_Id;
                tblProduct Pro = _db.tblProducts.First(s => s.ID == _urunId);
                txtUrunNo.Text = Pro.ProNo.ToString().PadLeft(7, '0');
                txtUrunAdi.Text = Pro.Name;
                txtCategoryId.Text = Pro.CategoryID.ToString();
                txtNot.Text = Pro.Note;
                txtBirimFiyat.Text = Pro.UnitPrice.ToString();
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        private void btnKategoriNo_Click(object sender, EventArgs e)
        {
            int Aktarma_Id = _f.Kategori(true);
            if (Aktarma_Id > 0)
            {
                category_Ac(Aktarma_Id);
            }
            frmAnaSayfa.Aktarma = -1;
        }

        void category_Ac(int Aktarma_Id)
        {
            try
            {
                //edit = true;    // Kodu bozuyor, true iken Yeni Kaydet işlemine giremiyor, 
                                  //               false iken Guncelle işlemine giremiyor.
                _kategoriId = Aktarma_Id;
                tblCategory cat = _db.tblCategories.First(s => s.ID == _kategoriId);
                txtCategoryId.Text = cat.ID.ToString();
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        void Sil()
        {
            _db.tblProducts.DeleteOnSubmit(_db.tblProducts.First(x => x.ID == _urunId));
            _db.SubmitChanges();
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (edit && _m.Sil() == DialogResult.Yes && _urunId>0)
            {
                Sil();
            }
        }

        private void txtUrunAdi_TextChanged(object sender, EventArgs e)
        {
            if (txtUrunAdi.Text == "" && _db.tblProducts.First(x => x.Name != txtUrunAdi.Text).ID > 0)
            {
                Temizle();
            }
        }
    }
}
