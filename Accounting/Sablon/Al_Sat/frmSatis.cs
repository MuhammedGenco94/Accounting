using Accounting.Modal;
using Accounting.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.Al_Sat
{
    public partial class frmSatis : Form
    {
        public static int SecilenProID;
        public static string SecilenLotSeri;
        public static int SecilenAdet;

        AccountingDBDataContext _db = new AccountingDBDataContext();
        Mesajlar _m = new Mesajlar();
        Numaralar _n = new Numaralar();
        Formlar _f = new Formlar();

        bool edit = false;
        int _firmaId = -1;
        int _cityid = -1;
        int _perId = -1;
        int _shipid = -1;
        int _satisid = -1;

        public string[] MyArray { get; set; }

        public frmSatis()
        {
            InitializeComponent();
        }

        private void frmSatis_Load(object sender, EventArgs e)
        {
            Combox();
            Temizle();
        }

        void Combox()
        {
            cbUrun.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection veri = new AutoCompleteStringCollection();
            var lst = _db.tblProducts.Select(s => s.Name).Distinct();
            foreach (string urn in lst)
            {
                veri.Add(urn);
                cbUrun.Items.Add(urn);
            }
            cbUrun.AutoCompleteCustomSource = veri;

            int dgv;
            dgv = cbUrun.Items.Count;
            MyArray = new string[dgv];
            for (int p = 0; p < dgv; p++)
            {
                MyArray[p] = cbUrun.Items[p].ToString();
            }
        }

        void Temizle()
        {
            txtSatisNo.Text = _n.SatisNo();
            Liste.Rows.Clear();
            txtFirma.Text = "";
            txtPersonel.Text = "";
            txtSehir.Text = "";
            txtShip.Text = "";
            dtpTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            YeniKaydet();
        }

        void YeniKaydet()
        {
            Liste.AllowUserToAddRows = false;
            try
            {
                tblSalesDown[] sld = new tblSalesDown[Liste.RowCount];
                tblSalesUp[] slu = new tblSalesUp[Liste.RowCount];
                tblStok[] stk = new tblStok[Liste.RowCount];

                for (int i = 0; i < Liste.RowCount; i++)
                {
                    int pid = int.Parse(Liste.Rows[i].Cells[0].Value.ToString());
                    string lot = Liste.Rows[i].Cells[3].Value.ToString();

                    sld[i] = new tblSalesDown();
                    sld[i].SalesID = int.Parse(txtSatisNo.Text);
                    sld[i].ProductID = int.Parse(Liste.Rows[i].Cells[0].Value.ToString());
                    sld[i].LotSerial = Liste.Rows[i].Cells[3].Value.ToString();
                    sld[i].SalesPrice = decimal.Parse(Liste.Rows[i].Cells[4].Value.ToString());
                    sld[i].Quantity = int.Parse(Liste.Rows[i].Cells[5].Value.ToString());

                    slu[i] = new tblSalesUp();
                    slu[i].SalesID = int.Parse(txtSatisNo.Text);
                    slu[i].CompanyID = _db.tblCompanies.First(x => x.Name == txtFirma.Text).ID;
                    slu[i].Date = DateTime.Parse(dtpTarih.Text);
                    slu[i].CityID = _db.tblCities.First(x => x.City == txtSehir.Text).ID;
                    slu[i].EmployeeID = _db.tblEmployees.First(x => x.Name == txtPersonel.Text).ID;
                    slu[i].ShipperID = _db.tblShippers.First(x => x.Name == txtShip.Text).ID;

                    _db.tblSalesDowns.InsertOnSubmit(sld[i]);
                    _db.tblSalesUps.InsertOnSubmit(slu[i]);


                    stk[i] = new tblStok();

                    var srg = (from s in _db.tblStoks
                               where s.ProductID == int.Parse(Liste.Rows[i].Cells[0].Value.ToString())
                               && s.LotSerial == Liste.Rows[i].Cells[3].Value.ToString()
                               select s).ToList();
                    if (srg.Count > 0)
                    {
                        tblStok st = _db.tblStoks.First(x => x.ProductID == pid && x.LotSerial == lot);
                        if (st.Quantity < 0 || st.Quantity < int.Parse(Liste.Rows[i].Cells[5].Value.ToString()))
                        {
                            MessageBox.Show("Stokta ürün Kalmamış!!. Satış yapamazsınız.");

                            for (int k = 0; k < Liste.Columns.Count; k++)
                            {
                                for (int j = 0; j < Liste.Rows.Count; j++)
                                {
                                    Liste.Rows[j].Cells[k].Value = DBNull.Value;
                                }
                            }
                            goto Start;
                        }
                        else if (st.Quantity >= int.Parse(Liste.Rows[i].Cells[5].Value.ToString()))
                        {
                            st.Quantity -= int.Parse(Liste.Rows[i].Cells[5].Value.ToString());
                        }
                        _db.SubmitChanges();
                    }
                    else
                    {
                        MessageBox.Show("Stokta ürün yok. Satış yapamazsınız.");
                        for (int k = 0; k < Liste.Columns.Count; k++)
                        {
                            for (int j = 0; j < Liste.Rows.Count; j++)
                            {
                                Liste.Rows[j].Cells[k].Value = DBNull.Value;
                            }
                        }
                        goto Start;
                    }
                    //_db.SubmitChanges();
                }
                _db.SubmitChanges();
                _m.YeniKayit("Yeni Satış Başarılı...");
            Start:
                return;
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            var btnsno = new Button();
            btnsno.Size = new Size(25, txtSatisNo.ClientSize.Height + 2);
            btnsno.Location = new Point(txtSatisNo.ClientSize.Width - btnsno.Width, -1);
            btnsno.Cursor = Cursors.Default;
            btnsno.Image = Resources.arrow1;
            txtSatisNo.Controls.Add(btnsno);
            SendMessage(txtSatisNo.Handle, 0xd3, (IntPtr)2, (IntPtr)(btnsno.Width << 16));
            btnsno.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            var btnfir = new Button();
            btnfir.Size = new Size(25, txtFirma.ClientSize.Height + 2);
            btnfir.Location = new Point(txtFirma.ClientSize.Width - btnfir.Width, -1);
            btnfir.Cursor = Cursors.Default;
            btnfir.Image = Resources.arrow1;
            txtFirma.Controls.Add(btnfir);
            SendMessage(txtFirma.Handle, 0xd3, (IntPtr)2, (IntPtr)(btnfir.Width << 16));
            btnfir.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            var btnper = new Button();
            btnper.Size = new Size(25, txtPersonel.ClientSize.Height + 2);
            btnper.Location = new Point(txtPersonel.ClientSize.Width - btnper.Width, -1);
            btnper.Cursor = Cursors.Default;
            btnper.Image = Resources.arrow1;
            txtPersonel.Controls.Add(btnper);
            SendMessage(txtPersonel.Handle, 0xd3, (IntPtr)2, (IntPtr)(btnper.Width << 16));
            btnper.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            var btnshp = new Button();
            btnshp.Size = new Size(25, txtShip.ClientSize.Height + 2);
            btnshp.Location = new Point(txtShip.ClientSize.Width - btnshp.Width, -1);
            btnshp.Cursor = Cursors.Default;
            btnshp.Image = Resources.arrow1;
            txtShip.Controls.Add(btnshp);
            SendMessage(txtShip.Handle, 0xd3, (IntPtr)2, (IntPtr)(btnshp.Width << 16));
            btnshp.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            var btncty = new Button();
            btncty.Size = new Size(25, txtSehir.ClientSize.Height + 2);
            btncty.Location = new Point(txtSehir.ClientSize.Width - btncty.Width, -1);
            btncty.Cursor = Cursors.Default;
            btncty.Image = Resources.arrow1;
            txtSehir.Controls.Add(btncty);
            SendMessage(txtSehir.Handle, 0xd3, (IntPtr)2, (IntPtr)(btncty.Width << 16));
            btncty.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            base.OnLoad(e);

            btnsno.Click += btnano_Click;
            btnfir.Click += btnfir_Click;
            btnper.Click += btnper_Click;
            btnshp.Click += btnshp_Click;
            btncty.Click += btncty_Click;

        }
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private void btnano_Click(object sender, EventArgs e)
        {
            int id = _f.SatisList(true);
            if (id > 0)
            {
                Ac(id);
            }
            frmAnaSayfa.Aktarma = -1;
        }
        private void btnfir_Click(object sender, EventArgs e)
        {
            int id = _f.FirmaList(true);
            if (id > 0)
            {
                FirmaAc(id);
            }
            frmAnaSayfa.Aktarma = -1;
        }
        private void btnper_Click(object sender, EventArgs e)
        {
            int id = _f.Employee(true);
            if (id > 0)
            {
                PerAc(id);
            }
            frmAnaSayfa.Aktarma = -1;
        }
        private void btnshp_Click(object sender, EventArgs e)
        {
            int id = _f.Shipper(true);
            if (id > 0)
            {
                ShipperAc(id);
            }
            frmAnaSayfa.Aktarma = -1;
        }
        private void btncty_Click(object sender, EventArgs e)
        {
            int id = _f.CityList(true);
            if (id > 0)
            {
                CityAc(id);
            }
            frmAnaSayfa.Aktarma = -1;
        }
        public void Ac(int id)
        {
            try
            {
                Liste.Rows.Clear();
                _satisid = id;
                tblSalesUp slu = _db.tblSalesUps.First(x => x.SalesID == id);
                txtSatisNo.Text = slu.SalesID.ToString().PadLeft(7, '0');
                txtFirma.Text = slu.tblCompany.Name;
                txtPersonel.Text = slu.tblEmployee.Name;
                txtSehir.Text = slu.tblCity.City;
                txtShip.Text = slu.tblShipper.Name;

                int i = 0;
                var srg = from s in _db.tblSalesDowns where s.SalesID == id select s;

                foreach (tblSalesDown k in srg)
                {
                    Liste.Rows.Add();
                    Liste.Rows[i].Cells[0].Value = k.ProductID;
                    Liste.Rows[i].Cells[1].Value = k.tblProduct.Name;
                    Liste.Rows[i].Cells[3].Value = k.LotSerial;
                    Liste.Rows[i].Cells[4].Value = k.SalesPrice;
                    Liste.Rows[i].Cells[5].Value = k.Quantity;
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
        public void ShipperAc(int id)
        {
            _shipid = id;
            txtShip.Text = _db.tblShippers.First(x => x.ID == _shipid).Name;
        }
        public void CityAc(int id)
        {
            _cityid = id;
            txtSehir.Text = _db.tblCities.First(x => x.ID == _cityid).City;
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed == true)
            {
                splitContainer1.Panel2Collapsed = false;
                btnCollapse.Text = "GİZLE";
            }
            else if (splitContainer1.Panel2Collapsed == false)
            {
                splitContainer1.Panel2Collapsed = true;
                btnCollapse.Text = "GÖSTER";
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil();
        }

        void Sil()
        {
            Liste.AllowUserToAddRows = false;
            try
            {
                for (int i = 0; i < Liste.RowCount; i++)
                {
                    int pid = int.Parse(Liste.Rows[i].Cells[0].Value.ToString());
                    string lot = Liste.Rows[i].Cells[3].Value.ToString();
                    tblStok st = _db.tblStoks.First(x => x.ProductID == pid && x.LotSerial == lot);
                    st.Quantity -= int.Parse(Liste.Rows[i].Cells[5].Value.ToString());
                    _db.SubmitChanges();
                }
                var srgUp = (from s in _db.tblSalesUps
                           where s.SalesID == int.Parse(txtSatisNo.Text)
                           select s).ToList();
                var srgDown = (from s in _db.tblSalesDowns
                               where s.SalesID == int.Parse(txtSatisNo.Text)
                               select s).ToList();

                _db.tblSalesUps.DeleteAllOnSubmit(srgUp);
                _db.tblSalesDowns.DeleteAllOnSubmit(srgDown); /*****Denemeden Ekledim*****/
                _db.SubmitChanges();
                _m.YeniKayit("Kayıt başarıyla silindi.");
                Temizle();
            }
            catch (Exception e)
            {
                _m.Hata(e);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Yaz();
        }

        void Yaz()
        {
            PrintIslemleri.frmPrint pri = new PrintIslemleri.frmPrint();
            pri.HangiListe = "Satis";
            pri.Show();
        }

        private void Liste_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    Liste.CurrentRow.Cells[0].Value = _db.tblProducts.First(x => x.Name == Liste.CurrentRow.Cells[1].Value.ToString()).ID;
                    SecilenProID = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());
                }
                if (e.ColumnIndex == 5)
                {
                    if (int.Parse(Liste.CurrentCell.Value.ToString()) > int.Parse(Liste.Rows[Liste.CurrentRow.Index].Cells[7].Value.ToString()))
                    {
                        MessageBox.Show("Satılacak ürünün adedi soktan daha fazladır !!");
                        Liste.CurrentCell.Value = "";
                    }
                }
            }
            catch (Exception f)
            {
                _m.Hata(f);
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

        private void Liste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int ProdID = _f.LotSeri(true);
                if (ProdID > 0)
                {
                    AcLotSeri(ProdID);
                }
                frmAnaSayfa.Aktarma = -1;
            }

            try
            {
                if (Liste.Rows[Liste.CurrentRow.Index].Cells[3].Value != null)
                {
                    Liste.CurrentRow.Cells[6].Value = Liste.CurrentRow.Cells[1].Value + "/" + Liste.CurrentRow.Cells[3].Value;

                    string a = Liste.CurrentRow.Cells[6].Value.ToString();
                    for (int i = 0; i < Liste.RowCount - 1; i++)
                    {
                        int b = Liste.CurrentRow.Index;
                        if (Liste.Rows[i].Cells[6].Value.ToString() == a && i != b)
                        {
                            MessageBox.Show("Bu kayıt var, Kontrol Et..");
                            Liste.Rows[b].Cells[3].Value = "";
                            break;
                        }
                    }
                }
            }
            catch (Exception gg)
            {
                _m.Hata(gg);
            }

        }

        void AcLotSeri(int ProdID)
        {
            _satisid = ProdID;

            for (int i = Liste.CurrentRow.Index; i < Liste.Rows.Count - 1; i++)
            {
                Liste.Rows[i].Cells[3].Value = SecilenLotSeri;
                Liste.Rows[i].Cells[7].Value = SecilenAdet;

            }
        }
    }
}
