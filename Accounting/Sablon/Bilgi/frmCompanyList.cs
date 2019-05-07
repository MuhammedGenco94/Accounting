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
    public partial class frmCompanyList : Form
    {
        AccountingDBDataContext _db = new AccountingDBDataContext();

        public bool Secim = false;

        int _secimId = -1;

        public frmCompanyList()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCompanyList_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = (from s in _db.tblCompanies
                       where s.Name.Contains(txtFirmaBul.Text) || s.Phone.Contains(txtFirmaBul.Text)
                       select s).OrderBy(x => x.ID).ToList();
            
            foreach (var k in lst)
            {
                Liste.Rows.Add();   //Boş satır ekliyor
                Liste.Rows[i].Cells[0].Value = k.ID;
                Liste.Rows[i].Cells[1].Value = k.Name;
                Liste.Rows[i].Cells[2].Value = k.Authorized;
                Liste.Rows[i].Cells[3].Value = k.Phone;
                i++;
            }
            Liste.AllowUserToAddRows = false;
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if (Secim && _secimId > 0)
            {
                frmAnaSayfa.Aktarma = _secimId;
                Close();
            }
        }

        void Sec()
        {
            try
            {
                _secimId = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                _secimId = -1;
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void txtFirmaBul_TextChanged(object sender, EventArgs e)
        //Bu yöntem "TextChanged" Database'i çok yoruyor, Bul Tuşu tanımlıyken Kullanmaya gerek yok.
        {
            Listele();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Liste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
