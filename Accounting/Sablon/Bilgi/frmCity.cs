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

namespace Accounting.Bilgi
{
    public partial class frmCity : Form
    {
        AccountingDBDataContext _db = new AccountingDBDataContext();
        public bool Secim;
        public int cityID = -1;

        public frmCity()
        {
            InitializeComponent();
        }

        private void frmCity_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();

            int i = 0;
            var lst = (from s in _db.tblCities
                       select new
                       {
                           s = s.ID,
                           n = s.City

                       }).Distinct().OrderByDescending(x => x.s).OrderBy(y => y.n);

            foreach (var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.s;
                Liste.Rows[i].Cells[1].Value = k.n;

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
            if (Secim && cityID > 0)
            {
                frmAnaSayfa.Aktarma = cityID;
                Close();
            }
        }

        void Sec()
        {
            try
            {
                cityID = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());

            }
            catch (Exception)
            {
                cityID = -1;
            }
        }

    }
}
