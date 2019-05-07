﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.Modal;

namespace Accounting.Al_Sat
{
    public partial class frmAlisListe : Form
    {
        AccountingDBDataContext _db = new AccountingDBDataContext();
        public bool Secim = false;
        public int alID = -1;
        int _secimId = -1;

        public frmAlisListe()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAlisListe_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = (from s in _db.tblPurchasings
                       select new
                       {
                           p =s.PurNo,
                           n =s.tblCompany.Name,
                           d =s.Date
                           //,id=s.ID
                       }).Distinct().OrderByDescending(x=>x.d).OrderBy(y=>y.n);


            foreach (var k in lst)
            {
                Liste.Rows.Add();
                //Liste.Rows[i].Cells[0].Value = k.id;
                Liste.Rows[i].Cells[0].Value = k.p;
                Liste.Rows[i].Cells[1].Value = k.n;
                Liste.Rows[i].Cells[2].Value = k.d;  //Sol taraftaki Object ise, sağdaki ne olursa olsun sıkıntı olmaz
                i++;
            }
            Liste.AllowUserToAddRows = false;
            Liste.ReadOnly = true;
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
                //_secimId = _db.tblPurchasings.First(x=>x.CompanyID == _db.tblCompanies).ID
                _secimId = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                _secimId = -1;
            }
        }

        
    }
}
