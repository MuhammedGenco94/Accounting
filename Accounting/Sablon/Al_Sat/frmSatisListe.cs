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
    public partial class frmSatisListe : Form
    {
        AccountingDBDataContext _db = new AccountingDBDataContext();
        public bool Secim;
        public int satId = -1;

        public frmSatisListe()
        {
            InitializeComponent();
        }

        private void frmSatisListe_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();

            int i = 0;
            var lst = (from s in _db.tblSalesUps
                       select new
                       {
                           s = s.SalesID,
                           n = s.tblCompany.Name,
                           d = s.Date
                       }).Distinct().OrderByDescending(x => x.d).OrderBy(y => y.n);

            foreach (var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.s;
                Liste.Rows[i].Cells[1].Value = k.n;
                Liste.Rows[i].Cells[2].Value = k.d;
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
            if (Secim && satId > 0)
            {
                frmAnaSayfa.Aktarma = satId;
                Close();
            }
        }

        void Sec()
        {
            try
            {
                satId = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());

            }
            catch (Exception)
            {
                satId = -1;
            }
        }
    }
}
