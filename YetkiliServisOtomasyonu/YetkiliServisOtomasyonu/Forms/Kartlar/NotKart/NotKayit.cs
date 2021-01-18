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

namespace YetkiliServisOtomasyonu.Forms.Kartlar.NotKart
{
    public partial class NotKayit : Form
    {
        public NotKayit()
        {
            InitializeComponent();
        }
        void notliste()
        {
            var liste = (from a in db.TblNotlar
                         select new
                         {
                             a.Id,
                             Başlık = a.NotBaslik,
                             İçerik = a.Noticerik,
                             Tarih = a.NotTarih,
                             Durum = a.NotDurum,
                             a.KayitEden,
                             a.KayitTarih
                         }
                         ).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
            gridView1.Columns["KayitEden"].Visible = false;
            gridView1.Columns["KayitTarih"].Visible = false;
        }
        private void NotKayit_Load(object sender, EventArgs e)
        {
            notliste();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void add()
        {
            try
            {
                TblNotlar ntl = new TblNotlar();
                ntl.NotBaslik = txtnotbaslik.Text;
                ntl.Noticerik = memoicerik.Text;
                ntl.NotTarih = DateTime.Parse(nottarih.EditValue.ToString());
                ntl.Aciklama = memoaciklama.Text;
                ntl.NotDurum = checkBox1.Checked;
                ntl.KayitEden = GirisEkran.kullanici;
                ntl.KayitTarih = DateTime.Today;
                db.TblNotlar.Add(ntl);
                db.SaveChanges();
                XtraMessageBox.Show("Not Kayıt Edildi ...", "Durum");
                notliste();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Hatası ...", "Durum");
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
        void temizle()
        {
            txtnotbaslik.Text = "";
            memoicerik.Text = "";nottarih.Text = "";
            memoaciklama.Text = "";

        }
        void delete()
        {
            int id = int.Parse(lblid.Text);
            var deger = db.TblNotlar.Find(id);
            db.TblNotlar.Remove(deger);
            db.SaveChanges();
            XtraMessageBox.Show("Not Kayıt Bilgileri Silindi", "Durum");
            notliste();

            try
            {

            }
            catch (Exception)
            {


                XtraMessageBox.Show("Not Kart ile İlgili Hareket Kaydı Vardır ..", "Hata");

            }

        }
        void güncelle()
        {

            try
            {
                Form1 ff = new Form1();
                int id = int.Parse(lblid.Text);
                var not = db.TblNotlar.Find(id);
                // stok.CariTür = int.Parse(lookcaritur.EditValue.ToString());
                not.NotBaslik = txtnotbaslik.Text;
                not.Noticerik = memoicerik.Text;
                not.NotTarih = DateTime.Parse(nottarih.EditValue.ToString());
                not.Aciklama = memoaciklama.Text;

                not.NotDurum = checkBox1.Checked;
                not.KayitEden = GirisEkran.kullanici;
                not.KayitTarih = DateTime.Today;




                db.SaveChanges();
                XtraMessageBox.Show("Not Bilgileri Güncellendi", "Durum");
                notliste();
                lblid.Text = "";
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Hatası .... ", "Hata");
            }
        }
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = XtraMessageBox.Show("Veri Silinsin mi ?", "Durum", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                 delete();
                notliste();
                lblid.Text = "";
                temizle();
                //lookcari.Properties.NullText = "Cari Türü Seçiniz ... ";
            }
            else
            {
                XtraMessageBox.Show("Veri Silinmedi !!!", "Durum");
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            notliste();
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
