using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Accounting
{
    public partial class frmAnaSayfa : Form
    {
        Modal.AccountingDBDataContext _db = new Modal.AccountingDBDataContext();
        Modal.Formlar _f = new Modal.Formlar();

        public static int Aktarma;

        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            pnlLeft1.Visible = false;
            grpLeft.BackColor = Color.Teal;
            grpLeft.ForeColor = Color.White;
            grpLeft.Text = "Bölüm-1 Giriş İşlemleri";
            pnlLeft1.Visible = true;
        }

        private void btnBolum1_Click(object sender, EventArgs e)
        {
            pnlLeft1.Visible = true;
            pnlLeft2.Visible = false;
            pnlLeft3.Visible = false;
            grpLeft.Text = "Bölüm-1 Giriş İşlemleri";
            grpLeft.BackColor = Color.Teal;
            grpLeft.ForeColor = Color.White;
        }

        private void btnBolum2_Click(object sender, EventArgs e)
        {
            pnlLeft1.Visible = false;
            pnlLeft2.Visible = true;
            pnlLeft3.Visible = false;
            grpLeft.Text = "Bilgi Giriş İşlemleri";
            grpLeft.BackColor = Color.Olive;
            grpLeft.ForeColor = Color.White;
        }

        private void btnBolum3_Click(object sender, EventArgs e)
        {
            pnlLeft1.Visible = false;
            pnlLeft2.Visible = false;
            pnlLeft3.Visible = true;
            grpLeft.Text = "Bölüm-3 Giriş İşlemleri";
            grpLeft.BackColor = Color.Maroon;
            grpLeft.ForeColor = Color.White;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            _f.Category();
        }

        private void btnKargo_Click(object sender, EventArgs e)
        {
            _f.Shipper();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            _f.Employee();
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            _f.Company();
        }

        private void btnFirmaListe_Click(object sender, EventArgs e)
        {
            _f.FirmaList();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            _f.Product();
        }

        private void btnUrunListe_Click(object sender, EventArgs e)
        {
            _f.UrunList();
        }

        private void btnAlis_Click(object sender, EventArgs e)
        {
            _f.Alis();
            closeAllForms();
        }

        private void btnAlisListe_Click(object sender, EventArgs e)
        {
            _f.AlisList();
            closeAllForms();
        }

        private void btnSatisFormu_Click(object sender, EventArgs e)
        {
            _f.Satis();
            closeAllForms();
        }

        private void btnSatisListe_Click(object sender, EventArgs e)
        {
            _f.SatisList();
            closeAllForms();
        }

        private void btnStokListe_Click(object sender, EventArgs e)
        {
            _f.StokList();
            closeAllForms();
        }

        void closeAllForms()
        {
            for (int i = Application.OpenForms.Count - 2; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "frmAnaSayfa")
                    Application.OpenForms[i].Close();
            }
        }
    }
}
