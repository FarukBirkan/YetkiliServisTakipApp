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

namespace YetkiliServisOtomasyonu.Forms.Ayarlar.CariTür
{
    public partial class CariTürKayit : Form
    {
        public CariTürKayit()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void listele()
        {
            var liste = (from a in db.TblCariTür
                         select new
                         {
                             Cari_Tür_Adı = a.CariTürAdi,
                             Cari_Tür_Açıklama = a.CariTürAciklama,
                             Açıklama = a.Aciklama,
                             KayıtEden=a.KayitEden,
                             KayıtTarih=a.KayitTarih
                         }).ToList();
            gridControl1.DataSource = liste.ToList();
        }
        void temizle()
        {
            txtcaritüradi.Text = "";
            memoaciklama.Text = "";
            txtcaritüraciklama.Text = "";
        }
        void add()
        {
          
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CariTürKayit_Load(object sender, EventArgs e)
        {
           

            listele();
            temizle();
          
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            temizle();

        }
        Form1 faf = new Form1();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtcaritüradi.Text==""||txtcaritüraciklama.Text==""||memoaciklama.Text=="")
            {
                XtraMessageBox.Show("Cari Tür Alanlarını Lütfen Boş Bırakmayınız !!!","Durum");
            }
            else
            {
                try
                {
                    Form1 ff = new Form1();
                    
                   
                    TblCariTür ct = new TblCariTür();
                    ct.CariTürAdi = txtcaritüradi.Text;
                    ct.CariTürAciklama = txtcaritüraciklama.Text;
                    ct.Aciklama = memoaciklama.Text;
                    ct.KayitEden = GirisEkran.kullanici;
                    ct.KayitTarih = DateTime.Today;
                    db.TblCariTür.Add(ct);
                    db.SaveChanges();
                    XtraMessageBox.Show("Cari Tür Eklenmiştir  !!!", "Durum");
                    temizle();
                    listele();
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Veri Hatası !!!", "Durum");
                }

            }

        }
    }
}
