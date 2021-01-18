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

namespace YetkiliServisOtomasyonu.Forms.Kartlar.KasaKart
{
    public partial class KasaKartKayit : Form
    {
        public KasaKartKayit()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void kasalistele()
        {
            var listele = (from k in db.TblKasa
                           select new
                           {
                               Kasa_Adı = k.KasaAdi,
                               Adres = k.KasaAdres,
                               Açıklama = k.Aciklama,
                               Kayıt_Eden = k.KayitEden,
                           }).ToList();
            gridControl1.DataSource = listele.ToList();
            gridView1.Columns["Kayıt_Eden"].Visible = false;
        }
        private void KasaKartKayit_Load(object sender, EventArgs e)
        {
            kasalistele();
        }
        void temizle()
        {
            txtkasaadi.Text = "";memoadres.Text = "";memoaciklama.Text = "";
        }
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = XtraMessageBox.Show("Veri Silinsin mi ?", "Durum", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                    delete();
                kasalistele();
                    lblid.Text = "";
                    temizle(); 
                //lookcaritur.Properties.NullText = "Cari Türü Seçiniz ... ";
            }
            else
            {
                XtraMessageBox.Show("Veri Silinmedi !!!", "Durum");
                kasalistele();

            }
        }
        void add()
        {
            TblKasa ks = new TblKasa();
            ks.KasaAdi = txtkasaadi.Text;
            ks.KasaAdres = memoadres.Text;
            ks.Aciklama = memoaciklama.Text;
            ks.KayitEden = GirisEkran.kullanici; ks.KayitTarih = DateTime.Today;
            db.TblKasa.Add(ks);
            db.SaveChanges();
            XtraMessageBox.Show("Kasa Kayit Edilmiştir", "Durum");
            kasalistele();

        }
        void delete()
        {

            try
            {
                int id = int.Parse(lblid.Text);
                var deger = db.TblKasa.Find(id);
                db.TblKasa.Remove(deger);
                db.SaveChanges();
                XtraMessageBox.Show("Kayıt Silindi", "Durum");
                kasalistele();

            }
            catch (Exception)
            {


                XtraMessageBox.Show("Kasa Kart ile İlgili Hareket Kaydı Vardır ..", "Hata");

            }

        }
       
        void güncelle()
        {

            try
            {
                Form1 ff = new Form1();
                int id = int.Parse(lblid.Text);
                var ks = db.TblKasa.Find(id);
                // stok.CariTür = int.Parse(lookcaritur.EditValue.ToString());
                ks.KasaAdi = txtkasaadi.Text;
                ks.KasaAdres = memoadres.Text;
                ks.Aciklama = memoaciklama.Text;
                ks.KayitEden = GirisEkran.kullanici;
                ks.KayitTarih = DateTime.Today;




                db.SaveChanges();
                XtraMessageBox.Show("Güncellendi", "Durum");
                kasalistele();


                //int stokıd = int.Parse(VeresiyeListesi.stok.ToString());
                //var gg = db.TblStok.Find(stokıd);
                //gg.StokMiktar = stok - int.Parse(txtkullanilanmiktar.Text);
                //db.SaveChanges();
                //XtraMessageBox.Show("Stok Miktarı Güncellendi", "Durum");

                // lblid.Text = "";
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
                kasalistele();
            }
           

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            kasalistele();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            add();
        }
    }
}
