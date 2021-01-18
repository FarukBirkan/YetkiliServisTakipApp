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

namespace YetkiliServisOtomasyonu.Forms.Kartlar.DepoKart
{
    public partial class DepoKartKayit : Form
    {
        public DepoKartKayit()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void depolistesi()
        {
            var liste = (from a in db.TblDepo
                         select new
                         {
                             a.DepoKod,
                             a.DepoAdi,
                             a.DepoTel,
                             a.DepoAdres,
                             a.Aciklama
                             
                         }).ToList();
            gridControl1.DataSource = liste.ToList();

        }
        void temizle()
        {
            txtdepoKod.Text = "";
            txtdepoadi.Text = "";txttelefon.Text = "";
            memoadres.Text = "";memoaciklama.Text = "";
        }
        void add()
        {
            TblDepo dp = new TblDepo();
            dp.DepoKod = txtdepoKod.Text;
            dp.DepoAdi = txtdepoadi.Text;
            dp.DepoTel = txttelefon.Text;
            dp.DepoAdres = memoadres.Text;
            dp.Aciklama = memoaciklama.Text;
            dp.KayitEden = GirisEkran.kullanici;
            dp.KayitTarih = DateTime.Today;
            db.TblDepo.Add(dp);
            db.SaveChanges();
            XtraMessageBox.Show("Kayıt Eklendi","Durum");
            depolistesi();
            temizle();

        }


        void delete()
        {

            try
            {
                int id = int.Parse(lblid.Text);
                var deger = db.TblDepo.Find(id);
                db.TblDepo.Remove(deger);
                db.SaveChanges();
                XtraMessageBox.Show("Kayıt Silindi", "Durum");
                depolistesi ();

            }
            catch (Exception)
            {


                XtraMessageBox.Show("Depo Kart ile İlgili Hareket Kaydı Vardır ..", "Hata");

            }

        }

        void güncelle()
        {

            try
            {
                Form1 ff = new Form1();
                int id = int.Parse(lblid.Text);
                var dp = db.TblDepo.Find(id);
                // stok.CariTür = int.Parse(lookcaritur.EditValue.ToString());
                dp.DepoKod = txtdepoKod.Text;
                dp.DepoAdi = txtdepoadi.Text;
                dp.DepoTel = txttelefon.Text;
                dp.DepoAdres = memoadres.Text;
                dp.Aciklama = memoaciklama.Text;
             
                dp.KayitEden = GirisEkran.kullanici;
                dp.KayitTarih = DateTime.Today;




                db.SaveChanges();
                XtraMessageBox.Show("Güncellendi", "Durum");
                depolistesi();


               
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Hatası .... ", "Hata");
            }
        }
        private void DepoKartKayit_Load(object sender, EventArgs e)
        {
            depolistesi();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lblid.Text=="")
            {
                add();
                depolistesi();
            }
            else
            {
                güncelle();

                temizle();
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = XtraMessageBox.Show("Veri Silinsin mi ?", "Durum", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
              delete();
            depolistesi();
             lblid.Text = "";
              temizle();
              
            }
            else
            {
                XtraMessageBox.Show("Veri Silinmedi !!!", "Durum");
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            depolistesi();
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
