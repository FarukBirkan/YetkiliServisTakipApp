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

namespace YetkiliServisOtomasyonu.Forms.Kartlar.ServisKart
{
    public partial class ServisKayit : Form
    {
        public ServisKayit()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void add()
        {
            try
            {
                TblServisler ss = new TblServisler();
                ss.CariId = int.Parse(lookcari.EditValue.ToString());
                ss.ServisTarihi = DateTime.Parse(servistarih.EditValue.ToString());
                ss.TalepSaat = timesaat.Text.ToString();
                ss.Aciklama = memoaciklama.Text.ToString();
                ss.ServisAciklama = memoservisaciklama.Text.ToString();
                ss.KayitEden = GirisEkran.kullanici;
                ss.KayitTarih = DateTime.Today;
                ss.ServisDurum = checkBox1.Checked;
                db.TblServisler.Add(ss);
                db.SaveChanges();
                XtraMessageBox.Show("Servis Kaydı Oluşturuldu ...");
                servisler();
                // ss.TblServisDurum =bool.Parse(checkBox1.Checked.ToString());


            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Hatası...","Durum");
            }

        }
        void servisler()
        {
            var liste = (from a in db.TblServisler
                         where (a.CariId == ServisListe.id && a.ServisDurum==true)
                         orderby a.ServisTarihi descending
                         select new
                         {
                             a.ServisTarihi,
                             a.TalepSaat,
                             a.TblCari.CariAdiSoyadi,
                             a.TblCari.CariTelefon,
                             a.TblCari.CariTelefon2,
                             a.TblCari.CariAdres,
                             a.ServisAciklama,
                             a.Aciklama
                         }).ToList();
            gridControl1.DataSource = liste.ToList();
        }
        void cariliste()
        {
            var cari = (from a in db.TblCari
                        select new
                        {
                            a.Id,
                           Cari= a.CariAdiSoyadi,
                        }).ToList();
            lookcari.Properties.DataSource = cari.ToList();
           
            lookcari.Properties.PopulateColumns();
            lookcari.Properties.Columns["Id"].Visible = false;

        }
        void delete()
        {
            int id = int.Parse(lblid.Text);
            var deger = db.TblServisler.Find(id);
            db.TblServisler.Remove(deger);
            db.SaveChanges();
            XtraMessageBox.Show("Servis Kayıt Bilgileri Silindi", "Durum");
            servisler();

            try
            {
               
            }
            catch (Exception)
            {


                XtraMessageBox.Show("Servis Kart ile İlgili Hareket Kaydı Vardır ..", "Hata");

            }

        }
        void güncelle()
        {

            try
            {
                Form1 ff = new Form1();
                int id = int.Parse(lblid.Text);
                var servis = db.TblServisler.Find(id);
                // stok.CariTür = int.Parse(lookcaritur.EditValue.ToString());
                servis.CariId = int.Parse(lookcari.EditValue.ToString());
                servis.ServisTarihi = DateTime.Parse(servistarih.EditValue.ToString());
                servis.TalepSaat = timesaat.Text;
                servis.ServisDurum = checkBox1.Checked;
                servis.ServisAciklama = memoservisaciklama.Text;
                servis.Aciklama = memoaciklama.Text;
                servis.KayitEden = GirisEkran.kullanici ;
                servis.KayitTarih=DateTime.Today;
              



                db.SaveChanges();
                XtraMessageBox.Show("Servis Bilgileri Güncellendi", "Durum");
                servisler();
                lblid.Text = "";
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Hatası .... ", "Hata");
            }
        }
        private void ServisKayit_Load(object sender, EventArgs e)
        {
            //lblid.Text = "";
            lookcari.Properties.NullText = "Cari Seçiniz ...";
            cariliste();
            servisler();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lblid.Text == "")
            {
                add();

            }
            else
            {
                güncelle();
            }
          
        }
        void temizle()
        {
            lookcari.Properties.NullText = "Cari Türü Seçiniz ...";
            servistarih.Text = "";
            timesaat.Text = "";
            memoaciklama.Text="";
            memoservisaciklama.Text = "";
        }
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = XtraMessageBox.Show("Veri Silinsin mi ?", "Durum", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                delete();
                servisler();
                lblid.Text = "";
                temizle();
                lookcari.Properties.NullText = "Cari Türü Seçiniz ... ";
            }
            else
            {
                XtraMessageBox.Show("Veri Silinmedi !!!", "Durum");
            }
          
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            servisler();
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
