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

namespace YetkiliServisOtomasyonu
{
    public partial class AnaEkran : Form
    {
        public AnaEkran()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void servisliste()
        {
            var liste = (from a in db.TblServisler
                         where (a.ServisTarihi == DateTime.Today)
                         orderby a.TalepSaat ascending
                         select new
                         {
                            // Tarih = a.ServisTarihi,
                           //  Saat = a.TalepSaat,
                             Müşteri = a.TblCari.CariAdiSoyadi,
                             Telefon = a.TblCari.CariTelefon,
                             Adres = a.TblCari.CariAdres,
                             ServisAçıklama = a.ServisAciklama,
                             Açıklama = a.Aciklama,
                             Durum = a.ServisDurum

                         }).ToList();
            gridControl1.DataSource = liste.ToList();

        }
        void günlükveresiyeödeme()
        {
            var liste = (from a in db.TblVeresiye
                         where (a.OdemeTarih == DateTime.Today)
                         select new
                         {
                             a.TblCari.CariAdiSoyadi,
                             a.TblCari.CariTelefon,
                             a.TblCari.CariTelefon2,
                            
                             a.TblStok.StokAdi,
                             a.OdenecekTutar
                         }).ToList();
            gridControl2.DataSource = liste.ToList();

        }
        void kritikliste()
        {
            var liste = (from a in db.TblStok
                         where (a.StokMiktar == a.KritikStokDurum || a.KritikStokDurum >= a.StokMiktar)
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
            gridControl3.DataSource = liste.ToList();
        }
        private void AnaEkran_Load(object sender, EventArgs e)
        {
            servisliste();
            günlükveresiyeödeme();
            kritikliste();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string path = "ServisListesi.xlsx";
            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }
    }
}
