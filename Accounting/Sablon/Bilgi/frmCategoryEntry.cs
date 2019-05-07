using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.Modal;

namespace Accounting.Bilgi
{
    public partial class frmCategoryEntry : Form
    {
        AccountingDBDataContext _db = new AccountingDBDataContext();
        Mesajlar _m = new Mesajlar();
        bool _edit = false;
        int _secimId = -1;

        public bool Secim = false;  //Yeni kendim Ekledim************

        public frmCategoryEntry()
        {
            InitializeComponent();
        }

        private void frmCategoryEntry_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        void Temizle()
        {
            txtCName.Text = "";
            _edit = false;
            _secimId = -1;
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            //var lst = (from s in _db.tblCategories select s).ToList();    //Bu başka bir yöntem
            var lst = _db.tblCategories.ToList();
            foreach (var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.ID;
                Liste.Rows[i].Cells[1].Value = k.CategoryName;
                i++;
            }
            Liste.AllowUserToAddRows = false;
        }

        void YeniKaydet()
        {
            try
            {
                tblCategory cat = new tblCategory();
                cat.CategoryName = txtCName.Text;

                _db.tblCategories.InsertOnSubmit(cat);
                _db.SubmitChanges();
                _m.YeniKayit("Kayıt tamamlandı.");
                Temizle();
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        void Sec()
        {
            try
            {
                _edit = true;
                _secimId = -1;
                _secimId = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());
            
                txtCName.Text = Liste.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                _edit = false;
                _secimId = -1;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_edit && _secimId>0 && _m.Guncelle()==DialogResult.Yes)
            {
                Guncelle();
            }
            else if (!_edit)
            {
                YeniKaydet();
            }
        }
        void Guncelle()
        {
            tblCategory cat = _db.tblCategories.First(x => x.ID == _secimId);
            cat.CategoryName = txtCName.Text;
            _db.SubmitChanges();
            _m.Guncelle(true);
            Temizle();
        }

        private void Liste_Click(object sender, EventArgs e)
        {
            Sec();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_edit && _secimId >0 && _m.Sil()==DialogResult.Yes)
            {
                Sil();
            }
            
        }

        void Sil()
        {
            try
            {
                _db.tblCategories.DeleteOnSubmit(_db.tblCategories.First(s => s.ID == int.Parse(Liste.CurrentRow.Cells[0].Value.ToString())));
                _db.SubmitChanges();
                Temizle();
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        private void txtCName_TextChanged(object sender, EventArgs e)
        {
            
            if (txtCName.Text == "" && _db.tblCategories.First(x => x.CategoryName!=txtCName.Text).ID>0)
            {
                Temizle();
            }
            
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Sec2();
            if (Secim && _secimId > 0)
            {
                frmAnaSayfa.Aktarma = _secimId;
                Close();
            }
        }   //Yeni kendim Ekledim************

        void Sec2()
        {
            try
            {
                _secimId = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                _secimId = -1;
            }
        }   //Yeni kendim Ekledim************
    }
}
