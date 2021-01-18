using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YetkiliServisOtomasyonu.Forms.Raporlar
{
    public partial class KritikStokListe : Form
    {
        public KritikStokListe()
        {
            InitializeComponent();
        }

        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void kritikliste()
        {
            var liste = (from a in db.TblStok
                        where(a.StokMiktar==a.KritikStokDurum || a.KritikStokDurum>=a.StokMiktar)
                         select new
                         {
                             a.StokNo,
                             a.StokAdi,
                             a.StokMarka,
                             a.StokModel,
                             a.StokMiktar,
                             a.TblDepo.DepoAdi,
                             a.KritikStokDurum
                         }).ToList();
            gridControl1.DataSource = liste.ToList();
        }
        void DepoListe()
        {
            var liste = (from a in db.TblDepo
                         select new
                         {
                             a.Id,
                             Depo = a.DepoAdi
                         }).ToList();
            lookUpEdit1.Properties.DataSource = liste.ToList();

            lookUpEdit1.Properties.PopulateColumns();
            lookUpEdit1.Properties.Columns["Id"].Visible = false;
        }
        private void KritikStokListe_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.PopulateColumns();
            lookUpEdit1.Properties.NullText = "Depo Seçiniz ...";
            DepoListe();
            kritikliste();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string path = "StokListe.xlsx";
            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string path = "StokListe.xlsx";
            gridControl1.ExportToPdf(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }
    }
}
