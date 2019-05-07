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
    public partial class frmEmployee : Form
    {
        AccountingDBDataContext _db = new AccountingDBDataContext();
        Mesajlar _m = new Mesajlar();

        public bool Secim = false;
        bool _edit = false;
        int _secimId = -1;

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();
            int j = 0;
            //var lst = (from s in _db.tblCategories select s).ToList();    //Bu başka bir yöntem
            var lst = _db.tblEmployees.ToList();
            foreach (var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[j].Cells[0].Value = k.ID;
                Liste.Rows[j].Cells[1].Value = k.Name;
                Liste.Rows[j].Cells[2].Value = k.Title;
                Liste.Rows[j].Cells[3].Value = k.HireDate;
                Liste.Rows[j].Cells[4].Value = k.Phone;
                j++;
            }
            Liste.AllowUserToAddRows = false;
        }

        void YeniKaydet()
        {
            try
            {
                tblEmployee emp = new tblEmployee();
                emp.Name = txtUName.Text;
                emp.Title = txtUtTitle.Text;
                emp.HireDate = DateTime.Parse(dtpUHiredDate.Text);
                //emp.HireDate = dtpUHiredDate.Value;
                emp.Phone = txtUPhone.Text;
                _db.tblEmployees.InsertOnSubmit(emp);
                _db.SubmitChanges();
                _m.YeniKayit("Kayıt tamamlandı.");
                Temizle();
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        void Temizle()
        {
            txtUName.Text = "";
            txtUtTitle.Text = "";
            dtpUHiredDate.Text = DateTime.Now.ToShortDateString();
            txtUPhone.Text = "";
            _edit = false;
            _secimId = -1;
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_edit && _secimId > 0 && _m.Guncelle() == DialogResult.Yes)
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
            tblEmployee emp = _db.tblEmployees.First(x => x.ID == _secimId);
            emp.Name = txtUName.Text;
            emp.Title = txtUtTitle.Text;
            emp.HireDate = DateTime.Parse(dtpUHiredDate.Text);
            //emp.HireDate = dtpUHiredDate.Value;
            emp.Phone = txtUPhone.Text;

            _db.SubmitChanges();
            _m.Guncelle(true);
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_edit && _secimId > 0 && _m.Sil() == DialogResult.Yes)
            {
                Sil();
            }
        }

        void Sil()
        {
            try
            {
                _db.tblEmployees.DeleteOnSubmit(_db.tblEmployees.First(s => s.ID == int.Parse(Liste.CurrentRow.Cells[0].Value.ToString())));
                _db.SubmitChanges();
                Temizle();
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUName_TextChanged(object sender, EventArgs e)
        {
            if (txtUName.Text == "")
            {
                Temizle();
            }
        }

        private void txtUtTitle_TextChanged(object sender, EventArgs e)
        {
            if (txtUtTitle.Text == "")
            {
                Temizle();
            }
        }

        private void Liste_Click(object sender, EventArgs e)
        {
            Sec();
        }

        void Sec()
        {
            try
            {
                _edit = true;
                _secimId = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());
                txtUName.Text = Liste.CurrentRow.Cells[1].Value.ToString();
                txtUtTitle.Text = Liste.CurrentRow.Cells[2].Value.ToString();
                dtpUHiredDate.Text = Liste.CurrentRow.Cells[3].Value.ToString();
                txtUPhone.Text = Liste.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception)
            {
                _edit = false;
                _secimId = -1;
            }
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if (Secim && _secimId>0)
            {
                frmAnaSayfa.Aktarma = _secimId;
                Close();
            }
        }

    }
}
