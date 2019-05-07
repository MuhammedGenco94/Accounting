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
    public partial class frmProductList : Form
    {
        AccountingDBDataContext _db = new AccountingDBDataContext();
        public bool Secim = false;
        int _secimId = -1;

        public frmProductList()
        {
            InitializeComponent();
        }

        private void frmProductList_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var _list = (from s in _db.tblProducts
                         where s.Name.Contains(txtFirmaBul.Text)
                         select s).OrderBy(x => x.ID);
            foreach (var item in _list)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = item.ID;
                Liste.Rows[i].Cells[1].Value = item.ProNo;
                Liste.Rows[i].Cells[2].Value = item.Name;
                Liste.Rows[i].Cells[3].Value = _db.tblCategories.First(x => x.ID == item.CategoryID).CategoryName;
                //Liste.Rows[i].Cells[3].Value = item.CategoryID;
                Liste.Rows[i].Cells[4].Value = item.Note;
                Liste.Rows[i].Cells[5].Value = item.UnitPrice;
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

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void txtFirmaBul_TextChanged(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
