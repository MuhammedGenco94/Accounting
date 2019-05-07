using Accounting.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.Al_Sat
{
    public partial class frmStokListesi : Form
    {
        AccountingDBDataContext _db = new AccountingDBDataContext();
        public bool Secim = false;
        public int alID = -1;
        int _secimId = -1;

        public frmStokListesi()
        {
            InitializeComponent();
        }

        private void frmStokListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = (from s in _db.tblStoks
                       where s.tblProduct.Name.Contains(txtUrunBul.Text)
                       select new
                       {
                           p = s.ProductID,
                           ls = s.LotSerial,
                           q = s.Quantity,
                           u = s.UnitPrice
                       }).Distinct().OrderByDescending(x => x.ls).OrderBy(y => y.p);


            foreach (var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.p;
                Liste.Rows[i].Cells[1].Value = _db.tblProducts.First(x => x.ID == k.p).Name;
                Liste.Rows[i].Cells[2].Value = k.ls;
                Liste.Rows[i].Cells[3].Value = k.q;  //Eğer Sol tarafta Object var ise, sağda ne olursa olsun sıkıntı olmaz
                Liste.Rows[i].Cells[4].Value = k.u;
                i++;
            }
            Liste.AllowUserToAddRows = false;
            Liste.ReadOnly = true;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
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

        private void txtUrunBul_TextChanged(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
