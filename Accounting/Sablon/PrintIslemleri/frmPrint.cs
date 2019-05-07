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
using Accounting.Al_Sat;

namespace Accounting.PrintIslemleri
{
    public partial class frmPrint : Form
    {
        AccountingDBDataContext _db = new AccountingDBDataContext();

        public string HangiListe;

        public frmPrint()
        {
            InitializeComponent();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            switch (HangiListe)
            {
                case "Alis":
                    Alis();
                    break;
                case "Satis":
                    Satis();
                    break;
            }
        }

        private void Alis()
        {
            Al_Sat.frmAlis als =  Application.OpenForms["frmAlis"] as Al_Sat.frmAlis; //Form.ActiveForm();
            pAlis cr = new pAlis();
            var srg = (from s in _db.vwAlis
                       where s.PurNo == int.Parse(als.txtAlisNo.Text)
                       select s).ToList();
            printYardim ch = new printYardim();
            DataTable dt = ch.ConvertTo(srg);
            cr.SetDataSource(dt);
            crvPrint.ReportSource = cr;

        }

        private void Satis()
        {
            frmSatis als = Application.OpenForms["frmSatis"] as frmSatis;
            pSatis cr = new pSatis();
            var srg = (from s in _db.vwSatis
                       where s.SatisID == int.Parse(als.txtSatisNo.Text)
                       select s).ToList();  
            printYardim ch = new printYardim();
            DataTable dt = ch.ConvertTo(srg);
            cr.SetDataSource(dt);
            crvPrint.ReportSource = cr;
        }
    }
}
