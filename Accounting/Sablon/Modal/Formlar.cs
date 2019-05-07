using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.Bilgi;
using Accounting.Al_Sat;

namespace Accounting.Modal
{
    class Formlar
    {
        #region InformationEntry
        public void Category()
        {
            frmCategoryEntry frm = new frmCategoryEntry();
            frm.ShowDialog();
        }

        public int Shipper(bool secim = false)
        {
            frmShippers frm = new frmShippers();
            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.ShowDialog();
            }
            return frmAnaSayfa.Aktarma;
        }

        public int Employee(bool secim=false)
        {
            frmEmployee frm = new frmEmployee();
            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.ShowDialog();
            }
            return frmAnaSayfa.Aktarma;
        }

        public void Company()
        {
            frmCompany frm = new frmCompany();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

        }

        public int FirmaList(bool secim = false)
        {
            frmCompanyList frm = new frmCompanyList();
            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            return frmAnaSayfa.Aktarma;
        }

        public void Product()
        {
            frmProduct frm = new frmProduct();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        public int UrunList(bool secim = false)
        {
            frmProductList frm = new frmProductList();
            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            return frmAnaSayfa.Aktarma;
        }

        public int Kategori(bool secim = false)
        {
            frmCategoryEntry frm = new frmCategoryEntry();
            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            return frmAnaSayfa.Aktarma;
        }
        #endregion


        #region SalesEntry
        public void Alis()
        {
            frmAlis frm = new frmAlis();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        public int AlisList(bool secim = false)
        {
            frmAlisListe frm = new frmAlisListe();
            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            return frmAnaSayfa.Aktarma;
        }
        public void Satis()
        {
            frmSatis frm = new frmSatis();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        public int SatisList(bool secim = false)
        {
            frmSatisListe frm = new frmSatisListe();
            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            return frmAnaSayfa.Aktarma;
        }
        public int CityList(bool secim = false)
        {
            frmCity frm = new frmCity();
            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.ShowDialog();
            }
            return frmAnaSayfa.Aktarma;
        }
        #endregion


        #region StockProcess
        public int StokList(bool secim = false)
        {
            frmStokListesi frm = new frmStokListesi();
            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            return frmAnaSayfa.Aktarma;
        }
        public int LotSeri(bool secim = false)
        {
            frmLotSeri frm = new frmLotSeri();
            if (secim)
            {
                frm.Secim = true;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = Form.ActiveForm;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            return frmAnaSayfa.Aktarma;
        }
        #endregion
    }
}
