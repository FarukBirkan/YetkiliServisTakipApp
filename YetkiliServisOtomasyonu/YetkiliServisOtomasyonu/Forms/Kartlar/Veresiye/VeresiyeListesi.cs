using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YetkiliServisOtomasyonu.Forms.Kartlar.Veresiye
{
    public partial class VeresiyeListesi : Form
    {
        public VeresiyeListesi()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();

        void veresiyeliste()
        {
            var liste = (from a in db.TblVeresiye
                         select new
                         {
                             a.Id,

                             Cari = a.TblCari.CariAdiSoyadi,
                             Telefon = a.TblCari.CariTelefon,
                             Telefon_2 = a.TblCari.CariTelefon2,
                             Adres = a.TblCari.CariAdres,
                             Mail = a.TblCari.CariMailAdres,
                             Urun_Adi = a.TblStok.StokAdi,
                             Marka = a.TblStok.StokMarka,
                             Model = a.TblStok.StokModel,
                             Veresiye_Miktarı = a.UrunMiktari,
                             Cari_Id = a.CariId,
                             Stok_Id = a.StokId,
                             Veresiye_Tutarı = a.VeresiyeTutar,
                             Miktar = a.UrunMiktari,
                             Veresiye_Kayıt_Tarihi = a.VeresiyeTarih,
                             Ödeme_Tarihi = a.OdemeTarih,
                             Ödenecek_Tutar = a.OdenecekTutar,

                             Kayıt_Eden = a.KayitEden,
                             Kayıt_Tarihi = a.KayitTarih,
                             Açıklama = a.Aciklama,
                             Veresiye_Kod = a.VeresiyeKod,
                             StokMiktarı = a.TblStok.StokMiktar,



                         }).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
            gridView1.Columns["Cari_Id"].Visible = false;
            gridView1.Columns["Stok_Id"].Visible = false;
            gridView1.Columns["Kayıt_Eden"].Visible = false;
            gridView1.Columns["Kayıt_Tarihi"].Visible = false;
            gridView1.Columns["Veresiye_Kayıt_Tarihi"].Visible = false;
            gridView1.Columns["Veresiye_Kod"].Visible = false;
            gridView1.Columns["StokMiktarı"].Visible = false;

        }
        private void VeresiyeListesi_Load(object sender, EventArgs e)
        {
            veresiyeliste();
        }
        public static int id;
        public static int CARIid;
        public static int STOKid;
        public static string CariAdı;
        public static string Telefon;
        public static string Telefon2;
        public static string Adres;
        public static string MailAdres;
        public static string UrunAdi;
        public static string Marka;
        public static string Model;
        public static string VeresiyeMiktarı;
        public static int CariId;
        //public static int StokId;
        public static decimal Veresiye_Tutar;
        public static DateTime Veresiye_Kayıt_Tarihi;
        public static DateTime ÖdemeTarihi;
        public static decimal ÖdenecekTutar;
        public static string Açıklama;
        public static int VeresiyeKod;
        public static int StokMiktarı;
        public static int Miktarı;

        void bakiye()
        {

        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            CARIid = int.Parse(gridView1.GetFocusedRowCellValue("Cari_Id").ToString());
            STOKid = int.Parse(gridView1.GetFocusedRowCellValue("Stok_Id").ToString());
            CariAdı = (gridView1.GetFocusedRowCellValue("Cari").ToString());
            Telefon = (gridView1.GetFocusedRowCellValue("Telefon").ToString());
            Telefon2 = (gridView1.GetFocusedRowCellValue("Telefon_2").ToString());
            Adres = (gridView1.GetFocusedRowCellValue("Adres").ToString());
            MailAdres = (gridView1.GetFocusedRowCellValue("Mail").ToString());
            UrunAdi = (gridView1.GetFocusedRowCellValue("Urun_Adi").ToString());
            Marka = (gridView1.GetFocusedRowCellValue("Marka").ToString());
            Model = (gridView1.GetFocusedRowCellValue("Model").ToString());
            Veresiye_Tutar = decimal.Parse(gridView1.GetFocusedRowCellValue("Veresiye_Tutarı").ToString());
            Veresiye_Kayıt_Tarihi = DateTime.Parse(gridView1.GetFocusedRowCellValue("Veresiye_Kayıt_Tarihi").ToString());
            ÖdemeTarihi = DateTime.Parse(gridView1.GetFocusedRowCellValue("Ödeme_Tarihi").ToString());
            ÖdenecekTutar = decimal.Parse(gridView1.GetFocusedRowCellValue("Ödenecek_Tutar").ToString());
            Açıklama = (gridView1.GetFocusedRowCellValue("Açıklama").ToString());
            VeresiyeKod = int.Parse(gridView1.GetFocusedRowCellValue("Veresiye_Kod").ToString());
            StokMiktarı = int.Parse(gridView1.GetFocusedRowCellValue("StokMiktarı").ToString());
            Miktarı = int.Parse(gridView1.GetFocusedRowCellValue("Veresiye_Miktarı").ToString());

            Forms.Kartlar.Veresiye.TahsilatGiris tg = new TahsilatGiris();
            tg.lblid.Text = id.ToString();

            tg.lookcari.EditValue = CARIid;
            tg.lookstok.EditValue = STOKid;
            tg.txtveresiyetutar.Text = Veresiye_Tutar.ToString();
            tg.dateveresiyekayittarih.EditValue = Veresiye_Kayıt_Tarihi.ToString();
            tg.dateödemetarih.Text = ÖdemeTarihi.ToString();
            tg.txtödenecektutar.Text = ÖdenecekTutar.ToString();
            tg.memoaciklama.Text = Açıklama;
            tg.txtveresiyekod.Text = VeresiyeKod.ToString();
            tg.txtveresiyemiktar.Text = Miktarı.ToString();
            tg.lblveresiyetutar.Text = ÖdenecekTutar.ToString();

            tg.MdiParent = this.MdiParent;
            tg.Show();

        }
    }
}
