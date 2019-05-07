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
    public partial class frmLotSeri : Form
    {
        AccountingDBDataContext _db = new AccountingDBDataContext();
        public bool Secim;
        public int satId = -1;

        public frmLotSeri()
        {
            InitializeComponent();
        }

        private void frmLotSeri_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = (from s in _db.tblStoks
                       where s.ProductID == frmSatis.SecilenProID
                       && s.Quantity != 0
                       select new
                       {
                           p = s.ProductID,
                           ls = s.LotSerial,
                           q = s.Quantity
                           //d = s.da
                       }).Distinct().OrderByDescending(x => x.p).OrderBy(y => y.ls);

            foreach (var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.p;
                Liste.Rows[i].Cells[1].Value = k.ls;
                Liste.Rows[i].Cells[2].Value = k.q;
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
                frmSatis.SecilenLotSeri = Liste.CurrentRow.Cells[1].Value.ToString();
                frmSatis.SecilenAdet = int.Parse(Liste.CurrentRow.Cells[2].Value.ToString());
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
