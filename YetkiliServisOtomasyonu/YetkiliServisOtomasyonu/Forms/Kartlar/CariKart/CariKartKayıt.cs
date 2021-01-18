using DevExpress.XtraEditors;
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
    public partial class CariKartKayıt : Form
    {
        public CariKartKayıt()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void cariturListe()
        {
            var liste = (from a in db.TblCariTür
                         
                         select new
                         {
                             a.Id,
                             Cari_Tür = a.CariTürAdi
                         }).ToList();
            lookcaritur.Properties.DataSource = liste.ToList();
            lookcaritur.Properties.PopulateColumns();
            lookcaritur.Properties.Columns["Id"].Visible = false;
        }
        void add()
        {
           
            try
            {
                TblCari cari = new TblCari();
                cari.CariKod = txtcarikod.Text;
                cari.CariTür = int.Parse(lookcaritur.EditValue.ToString());
                cari.CariAdiSoyadi = txtcariadsoyad.Text;
                cari.CariTelefon = txttelefon.Text;
                cari.CariTelefon2 = txttelefon2.Text;
                cari.CariMailAdres = txtmailadres.Text;
                cari.CariAdres = memoadres.Text;
                cari.CariIl = txtil.Text;
                cari.CariIlce = txtilce.Text;
                cari.CariPostaKod = txtpostakod.Text;
                cari.CariVergiDaire = txtvergidairesi.Text;
                cari.CariVergiNo = txtvergino.Text;
                cari.CariAciklama = memocariaciklama.Text;
                cari.Aciklama = memoaciklama.Text;
                cari.CariDurum = checkBox1.Checked;
                cari.KayitEden = GirisEkran.kullanici;
                cari.KayitTarih = DateTime.Today;

                db.TblCari.Add(cari);
                db.SaveChanges();
                XtraMessageBox.Show("Cari Eklendi", "Başarılı");
                listele();

            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Hatası", "Hata");

            }
        }
        void listele()
        {
            var liste = (from a in db.TblCari
                         select new
                         {
                             a.Id,
                             a.TblCariTür.CariTürAdi,
                             a.CariTür,
                             a.CariKod,

                             a.CariAdiSoyadi,
                             a.CariIl,
                             a.CariIlce,
                             a.CariMailAdres,
                             a.CariTelefon,
                             a.CariTelefon2,
                             a.CariAdres,
                             a.CariVergiNo,
                             a.CariVergiDaire


                         }

                       ).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
            gridView1.Columns["CariTür"].Visible = false;
           

        }
        private void CariKartKayıt_Load(object sender, EventArgs e)
        {
          //  lblid.Text =int.Parse("0").ToString();
            lookcaritur.Properties.NullText = "Cari Türü Seçiniz ... ";
            cariturListe();
            listele();
        }
        void güncelle()
        {
            try
            {
                             
                Form1 ff = new Form1();
                int id = int.Parse(lblid.Text);
                var cari = db.TblCari.Find(id);
                cari.CariTür =int.Parse(lookcaritur.EditValue.ToString());
                cari.CariKod = txtcarikod.Text;
                cari.CariAdiSoyadi = txtcariadsoyad.Text;
                cari.CariIl = txtil.Text;
                cari.CariIlce = txtilce.Text;
                cari.CariMailAdres = txtmailadres.Text;
                cari.CariTelefon = txttelefon.Text;
                cari.CariTelefon2 = txttelefon2.Text;
                cari.CariAdres = memoadres.Text;
                cari.CariVergiNo = txtvergino.Text;
                cari.CariVergiDaire = txtvergidairesi.Text;
                cari.KayitEden = GirisEkran.kullanici;
                cari.KayitTarih = DateTime.Today;
                cari.CariAciklama = memocariaciklama.Text;
                cari.Aciklama = memoaciklama.Text;
                cari.CariDurum = checkBox1.Checked;
                cari.CariPostaKod = txtpostakod.Text;
                cari.Aciklama = memoaciklama.Text;
              
                cari.KayitEden = GirisEkran.kullanici;
                cari.KayitTarih = DateTime.Today;

                db.SaveChanges();
                XtraMessageBox.Show("Güncellendi", "Durum");
                listele();
                lblid.Text = "";
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Hatası .... ", "Hata");
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lblid.Text=="")
            {
                add();
            }
            else
            {
                güncelle();
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            add();
        }
        void delete()
        {

            try
            {
                int id = int.Parse(lblid.Text);
                var deger = db.TblCari.Find(id);
                db.TblCari.Remove(deger);
                db.SaveChanges();
                XtraMessageBox.Show("Kayıt Silindi", "Durum");
                listele();

            }
            catch (Exception)
            {


                XtraMessageBox.Show("Cari Kart ile İlgili Hareket Kaydı Vardır ..", "Hata");

            }

        }
        void temizle()
        {
            txtcarikod.Text="";
            lookcaritur.Properties.NullText = "Cari Türü Seçiniz ... ";
            txtcariadsoyad.Text="";
            txttelefon.Text="";
            txttelefon2.Text="";
           txtmailadres.Text="";
            memoadres.Text="";
            txtil.Text="";
            txtilce.Text="";
            txtpostakod.Text="";
           txtvergidairesi.Text="";
             txtvergino.Text="";
             memocariaciklama.Text="";
             memoaciklama.Text="";
           checkBox1.Checked=false;
        }
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = XtraMessageBox.Show("Veri Silinsin mi ?", "Durum", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                delete();
                listele();
                lblid.Text = "";
                temizle(); lookcaritur.Properties.NullText = "Cari Türü Seçiniz ... ";
            }
            else
            {
                XtraMessageBox.Show("Veri Silinmedi !!!","Durum");
            }
            }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            
        }
    }
}
