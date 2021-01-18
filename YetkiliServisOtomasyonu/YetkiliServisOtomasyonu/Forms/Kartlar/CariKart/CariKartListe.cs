using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YetkiliServisOtomasyonu.Forms.Kartlar
{
    public partial class CariKartListe : Form
    {
        public CariKartListe()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        public static int ıd;
        public static string Cari_Türü;
        public static string CariKod;
        public static string AdSoyad;
        public static string İl;
        public static string İlçe;
        public static string MailAdres;
        public static string Telefon;
        public static string Telefon2;
        public static string Adres;
        public static string VergiNo;
        public static string VergiDaire;
        public static string KayitEden;
        public static string KayitTarih;
        public static string CariAçıklama;
        public static string Açıklama;
        public static bool CariDurum;
        public static string CariPostakod;
        void listele()
        {
            var liste = (from a in db.TblCari
                         select new
                         {
                             a.Id,
                             Cari_Tür=a.CariTür,
                             Cari_Türü = a.TblCariTür.CariTürAdi,
                             Cari_Kod = a.CariKod,
                             Ad_Soyad = a.CariAdiSoyadi,
                             İl = a.CariIl,
                             İlçe = a.CariIlce,
                             MailAdres = a.CariMailAdres,
                             Telefon = a.CariTelefon,
                             Telefon2 = a.CariTelefon2,
                             Adres = a.CariAdres,
                             VergiNo = a.CariVergiNo,
                             VergiDaire = a.CariVergiDaire,
                             a.KayitEden,
                             a.KayitTarih,
                             a.CariAciklama,
                             a.Aciklama,
                             a.CariDurum,
                             a.CariPostaKod                            
                         }

                       ).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
            gridView1.Columns["KayitEden"].Visible = false;
            gridView1.Columns["KayitTarih"].Visible = false;
            gridView1.Columns["CariAciklama"].Visible = false;
            gridView1.Columns["Aciklama"].Visible = false;
            gridView1.Columns["CariDurum"].Visible = false;
            gridView1.Columns["CariPostaKod"].Visible = false;
            gridView1.Columns["Cari_Tür"].Visible = false;

        }
        private void CariKartListe_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {


            ıd = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            AdSoyad = Convert.ToString(gridView1.GetFocusedRowCellValue("Ad_Soyad").ToString());
            Cari_Türü = Convert.ToString(gridView1.GetFocusedRowCellValue("Cari_Türü").ToString());
            CariKod = Convert.ToString(gridView1.GetFocusedRowCellValue("Cari_Kod").ToString());
            İl = Convert.ToString(gridView1.GetFocusedRowCellValue("İl").ToString());
            İlçe = Convert.ToString(gridView1.GetFocusedRowCellValue("İlçe").ToString());
            MailAdres = Convert.ToString(gridView1.GetFocusedRowCellValue("MailAdres").ToString());
            Telefon = Convert.ToString(gridView1.GetFocusedRowCellValue("Telefon").ToString());
            Telefon2 = Convert.ToString(gridView1.GetFocusedRowCellValue("Telefon2").ToString());
            Adres = Convert.ToString(gridView1.GetFocusedRowCellValue("Adres").ToString());
            VergiNo = Convert.ToString(gridView1.GetFocusedRowCellValue("VergiNo").ToString());
            VergiDaire = Convert.ToString(gridView1.GetFocusedRowCellValue("VergiDaire").ToString());
            KayitEden = Convert.ToString(gridView1.GetFocusedRowCellValue("KayitEden").ToString());
            KayitTarih = Convert.ToString(gridView1.GetFocusedRowCellValue("KayitTarih").ToString());
            CariAçıklama = Convert.ToString(gridView1.GetFocusedRowCellValue("CariAciklama").ToString());
            Açıklama = Convert.ToString(gridView1.GetFocusedRowCellValue("Aciklama").ToString());
            CariDurum = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("CariDurum").ToString());
            CariPostakod = Convert.ToString(gridView1.GetFocusedRowCellValue("CariPostaKod").ToString());

            Forms.Kartlar.CariKartKayıt ck = new CariKartKayıt();
            ck.lblid.Text = ıd.ToString();
            ck.txtcariadsoyad.Text = AdSoyad.ToString();
            ck.lookcaritur.EditValue = Convert.ToString(gridView1.GetFocusedRowCellValue("Cari_Tür").ToString());
            ck.txtcarikod.Text = CariKod.ToString();
            ck.txtil.Text = İl.ToString();
            ck.txtilce.Text = İlçe.ToString();
            ck.txtmailadres.Text = MailAdres.ToString();
            ck.txttelefon.Text = Telefon.ToString();
            ck.txttelefon2.Text = Telefon2.ToString();
            ck.memoadres.Text = Adres.ToString();
            ck.txtvergino.Text = VergiNo.ToString();
            ck.txtvergidairesi.Text = VergiDaire.ToString();
            ck.memocariaciklama.Text = CariAçıklama.ToString();
            ck.memoaciklama.Text = Açıklama.ToString();
            ck.checkBox1.Checked =bool.Parse(CariDurum.ToString());
            ck.txtpostakod.Text = CariPostakod.ToString();

            ck.MdiParent = this.MdiParent;
            ck.Show();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
           // ıd = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());

        }
    }
}
