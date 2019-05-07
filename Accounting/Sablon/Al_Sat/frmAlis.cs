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
using System.Runtime.InteropServices;
using Accounting.Properties;
using Accounting.PrintIslemleri;

namespace Accounting.Al_Sat
{
    public partial class frmAlis : Form
    {
        AccountingDBDataContext _db = new AccountingDBDataContext();
        Numaralar _n = new Numaralar();
        Formlar _f = new Formlar();
        Mesajlar _m = new Mesajlar();                   //CTRL + K + D  ==> Kodu düzenler..

        bool edit = false;
        int _acid = -1;
        int _firmaId = -1;
        int _perId = -1;
        public string[] MyArray { get; set; }

        public frmAlis()
        {
            InitializeComponent();
        }                           //CTRL + K + D  ==> Kodu düzenler..

        private void frmAlis_Load(object sender, EventArgs e)
        {
            Combo();
            Temizle();
        }

        void Temizle()
        {
            
            txtAlisNo.Text = _n.AlisNo();
            Liste.Rows.Clear();
            txtFirma.Text = "";
            txtPersonel.Text = "";
            dtpTarih.Text = DateTime.Now.ToShortDateString();
        }

        void Combo()
        {
            urncmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection veri = new AutoCompleteStringCollection();
            var lst = _db.tblProducts.Select(s => s.Name).Distinct();
            foreach (string urn in lst)
            {
                veri.Add(urn);
                urncmb.Items.Add(urn);
            }
            urncmb.AutoCompleteCustomSource = veri;

            int dgv;    // Data Grid View 
            dgv = urncmb.Items.Count;
            MyArray = new string[dgv];
            for (int p = 0; p < dgv; p++)
            {
                MyArray[p] = urncmb.Items[p].ToString();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            var btnaNo = new Button();
            txtAlisNo.Controls.Add(btnaNo);
            btnaNo.Size = new Size(25, txtAlisNo.ClientSize.Height + 2);
            btnaNo.Location = new Point(txtAlisNo.ClientSize.Width - btnaNo.Width, -1);
            btnaNo.Cursor = Cursors.Default;
            btnaNo.Image = Resources.arrow1;
            SendMessage(txtAlisNo.Handle, 0xd3, (IntPtr)2, (IntPtr)(btnaNo.Width << 16));
            btnaNo.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            var btnFir = new Button();
            txtFirma.Controls.Add(btnFir);
            btnFir.Size = new Size(25, txtFirma.ClientSize.Height + 2);
            btnFir.Location = new Point(txtFirma.ClientSize.Width - btnFir.Width, -1);
            btnFir.Cursor = Cursors.Default;
            btnFir.Image = Image.FromFile(@"C:\Users\Muhammed\source\repos\Accounting\Sablon\Resources\arrow2.png");
            btnFir.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            var btnPer = new Button();
            txtPersonel.Controls.Add(btnPer);
            btnPer.Size = new Size(25, txtPersonel.ClientSize.Height + 2);
            btnPer.Location = new Point(txtPersonel.ClientSize.Width - btnPer.Width, -1);
            btnPer.Cursor = Cursors.Default;
            btnPer.Image = Image.FromFile(@"C:\Users\Muhammed\source\repos\Accounting\Sablon\Resources\arrow2.png");
            btnPer.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            base.OnLoad(e);

            btnaNo.Click += btnaNo_Click;
            btnFir.Click += btnFir_Click;
            btnPer.Click += btnPer_Click;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr w, uint m, IntPtr p1, IntPtr p2);

        private void btnaNo_Click(object sender, EventArgs e)
        {
            int id = _f.AlisList(true);
            if (id > 0)
            {
                Ac(id);
            }
            frmAnaSayfa.Aktarma = -1;
        }

        private void btnFir_Click(object sender, EventArgs e)
        {
            int id = _f.FirmaList(true);
            if (id > 0)
            {
                FirmaAc(id);
            }
            frmAnaSayfa.Aktarma = -1;
        }

        private void btnPer_Click(object sender, EventArgs e)
        {
            int id = _f.Employee(true);
            if (id > 0)
            {
                PerAc(id);
            }
            frmAnaSayfa.Aktarma = -1;
        }

        public void Ac(int id)
        {
            try
            {
                Liste.Rows.Clear();
                edit = true;
                _acid = id;
                tblPurchasing pur = _db.tblPurchasings.First(x => x.PurNo == _acid);
                txtAlisNo.Text = pur.PurNo.ToString().PadLeft(7, '0');
                txtFirma.Text = pur.tblCompany.Name;
                txtPersonel.Text = pur.tblEmployee.Name;

                int i = 0;
                var srg = from s in _db.tblPurchasings
                          where s.PurNo == _acid
                          select s;
                foreach (tblPurchasing k in srg)
                {
                    Liste.Rows.Add();
                    Liste.Rows[i].Cells[0].Value = k.ProductID;
                    Liste.Rows[i].Cells[1].Value = k.tblProduct.Name;
                    Liste.Rows[i].Cells[2].Value = k.LotSerial;
                    Liste.Rows[i].Cells[3].Value = k.PurchasingPrice;
                    Liste.Rows[i].Cells[4].Value = k.Quantity;
                    Liste.Rows[i].Cells[5].Value = k.PurNo;

                    i++;
                }
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        public void FirmaAc(int id)
        {
            _firmaId = id;
            txtFirma.Text = _db.tblCompanies.First(x => x.ID == _firmaId).Name;
        }

        public void PerAc(int id)
        {
            _perId = id;
            txtPersonel.Text = _db.tblEmployees.First(x => x.ID == _perId).Name;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            YeniKaydet();
        }

        void YeniKaydet()                               //  CTRL + K + D  ==> Kodu düzenler..
        {
            Liste.AllowUserToAddRows = false;
            try
            {
                tblPurchasing[] purArray = new tblPurchasing[Liste.RowCount];
                tblStok[] stkArray = new tblStok[Liste.RowCount];
                float unitPriceHesap = 0;                                                                               /**YENİ**/
                for (int i = 0; i < Liste.RowCount; i++)
                {
                    int pid = int.Parse(Liste.Rows[i].Cells[0].Value.ToString());
                    string lot = Liste.Rows[i].Cells[2].Value.ToString();
                    purArray[i] = new tblPurchasing();
                    purArray[i].PurNo = int.Parse(txtAlisNo.Text);
                    purArray[i].CompanyID = _db.tblCompanies.First(x => x.Name == txtFirma.Text).ID;
                    purArray[i].ProductID = pid;
                    purArray[i].LotSerial = lot;
                    purArray[i].Date = DateTime.Parse(dtpTarih.Text);
                    purArray[i].PurchasingPrice = decimal.Parse(Liste.Rows[i].Cells[3].Value.ToString());
                    purArray[i].Quantity = int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                    purArray[i].EmployeeID = _db.tblEmployees.First(x => x.Name == txtPersonel.Text).ID;
                    _db.tblPurchasings.InsertOnSubmit(purArray[i]);

                    unitPriceHesap = float.Parse((purArray[i].PurchasingPrice / purArray[i].Quantity).ToString());      /**YENİ**/

                    AccountingDBDataContext _gb = new AccountingDBDataContext();
                    stkArray[i] = new tblStok();
                    var srg = (from s in _gb.tblStoks
                               where s.ProductID == pid && s.LotSerial == lot
                               select s).ToList();
                    if (srg.Count == 0)
                    {
                        stkArray[i].ProductID = pid;
                        stkArray[i].LotSerial = lot;
                        stkArray[i].Quantity = int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                        stkArray[i].UnitPrice = _db.tblProducts.First(x => x.ID == purArray[i].ProductID).UnitPrice;  /**YENİ**/
                        //stkArray[i].UnitPrice = decimal.Parse(unitPriceHesap.ToString());                               /**YENİ**/
                        _gb.tblStoks.InsertOnSubmit(stkArray[i]);
                    }
                    else
                    {
                        tblStok st = _gb.tblStoks.First(x => x.ProductID == pid && x.LotSerial == lot);
                        st.Quantity += int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                    }
                    _gb.SubmitChanges();
                }
                _db.SubmitChanges();                //CTRL + K + D  ==> Kodu düzenler..
                _m.YeniKayit("Yeni Kayıt Başarılı...");
            }
            catch (Exception kk)
            {
                _m.Hata(kk);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil();
            Temizle();
        }
        void Sil()
        {
            Liste.AllowUserToAddRows = false;
            try
            {
                for (int i = 0; i < Liste.RowCount; i++)
                {
                    int pid = int.Parse(Liste.Rows[i].Cells[0].Value.ToString());
                    string lot = Liste.Rows[i].Cells[2].Value.ToString();

                    tblStok st = _db.tblStoks.First(x => x.ProductID == pid && x.LotSerial == lot);
                    st.Quantity -= int.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                }

                var srg = (from s in _db.tblPurchasings
                           where s.PurNo == int.Parse(txtAlisNo.Text)
                           select s).ToList();

                _db.tblPurchasings.DeleteAllOnSubmit(srg);
                _db.SubmitChanges();
                _m.YeniKayit("Kayıt başarıyla silindi.");
            }
            catch (Exception n)
            {
                _m.Hata(n);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Yaz();
        }

        void Yaz()
        {
            frmPrint pri = new frmPrint();
            pri.HangiListe = "Alis";
            pri.Show();
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed == true)
            {
                splitContainer1.Panel2Collapsed = false;
                btnCollapse.Text = "Gizle";
            }
            else if (splitContainer1.Panel2Collapsed == false)
            {
                splitContainer1.Panel2Collapsed = true;
                btnCollapse.Text = "Göster";
            }
        }

        private void Liste_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = e.Control as TextBox;
            if (Liste.CurrentCell.ColumnIndex == 1 && txt != null)
            {
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt.AutoCompleteCustomSource.AddRange(MyArray);
            }
            else if (Liste.CurrentCell.ColumnIndex != 1 && txt != null)
            {
                txt.AutoCompleteMode = AutoCompleteMode.None;
            }
        }

        private void Liste_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    Liste.CurrentRow.Cells[0].Value = _db.tblProducts.First(x => x.Name == Liste.CurrentRow.Cells[1].Value.ToString()).ID;
                }
                if (e.ColumnIndex == 2)
                {
                    Liste.CurrentRow.Cells[6].Value = Liste.CurrentRow.Cells[1].Value + "/" + Liste.CurrentRow.Cells[2].Value;

                    string a = Liste.CurrentRow.Cells[6].Value.ToString();
                    for (int i = 0; i < Liste.RowCount - 1; i++)
                    {
                        int b = Liste.CurrentRow.Index;
                        if (Liste.Rows[i].Cells[6].Value.ToString() == a && i != b)
                        {
                            MessageBox.Show("Bu kayıt var, Kontrol Et..");
                            Liste.Rows[b].Cells[2].Value = "";
                            break;
                        }

                    }
                }
            }
            catch (Exception f)
            {
                _m.Hata(f);
            }
        }

    }
}
