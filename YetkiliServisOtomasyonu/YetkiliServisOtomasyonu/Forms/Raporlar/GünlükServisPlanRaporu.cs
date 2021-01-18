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
    public partial class GünlükServisPlanRaporu : Form
    {
        public GünlükServisPlanRaporu()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void servisliste()
        {
            var liste = (from a in db.TblServisler
                         where (a.ServisDurum == false && a.ServisTarihi == DateTime.Today)
                         orderby a.TalepSaat ascending
                         select new
                         {
                             Tarih = a.ServisTarihi,
                             Saat = a.TalepSaat,
                             Müşteri = a.TblCari.CariAdiSoyadi,
                             Telefon = a.TblCari.CariTelefon,
                             Adres = a.TblCari.CariAdres,
                             ServisAçıklama=a.ServisAciklama,
                             Açıklama = a.Aciklama,
                             Durum = a.ServisDurum

                         }).ToList();
            gridControl1.DataSource = liste.ToList();
           
        }
        private void GünlükServisPlanRaporu_Load(object sender, EventArgs e)
        {
            servisliste();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string path = "GünlükServisListesi.txt";
            gridControl1.ExportToText(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string path = "GünlükServisListesi.pdf";
            gridControl1.ExportToPdf(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string path = "GünlükServisListesi.xlsx";
            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }
    }
}
