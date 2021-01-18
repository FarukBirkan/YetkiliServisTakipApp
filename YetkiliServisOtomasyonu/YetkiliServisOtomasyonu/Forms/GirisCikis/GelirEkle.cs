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

namespace YetkiliServisOtomasyonu.Forms.GirisCikis
{
    public partial class GelirEkle : Form
    {
        public GelirEkle()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void kasagiris()
        {
            var liste = (from a in db.TblKasaGiris
                         where (a.Aciklama.Contains("Gelir"))
                         select new
                         {
                            a.Id,
                            Cari= a.TblCari.CariAdiSoyadi,
                            Tutar= a.ToplamTutar,
                            Açıklama= a.Aciklama
                         }).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;

        }
        void add()
        {
            try
            {
                TblKasaGiris kg = new TblKasaGiris();
                kg.ToplamTutar = decimal.Parse(textEdit1.Text);

                kg.Aciklama ="Gelir  "+ memoEdit1.Text;
                kg.KayitEden = GirisEkran.kullanici;
                kg.KayitTarih = DateTime.Today;

                db.TblKasaGiris.Add(kg);
                
                db.SaveChanges();
                XtraMessageBox.Show("Kasaya = " + textEdit1.Text + " TL " + " Eklendi");

            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Okuma Hatası ...","Durum");
            }
        }
        void cariliadd()
        {
            try
            {
                TblKasaGiris kg = new TblKasaGiris();
                kg.CariId = int.Parse(lookUpEdit1.EditValue.ToString());
                kg.ToplamTutar = decimal.Parse(textEdit1.Text);
                kg.Aciklama ="Gelir  "+ memoEdit1.Text;
                kg.KayitEden = GirisEkran.kullanici;
                kg.KayitTarih = DateTime.Today;
                db.TblKasaGiris.Add(kg);
                db.SaveChanges();
                XtraMessageBox.Show("Kasaya = " + textEdit1.Text + " TL " + " Eklendi");

            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Okuma Hatası ...", "Durum");
            }
        }
        void cariliste()
        {
            var cariler = (from a in db.TblCari
                          
                           select new
                           {
                               a.Id,
                            Cari=   a.CariAdiSoyadi,
                             Telefon=  a.CariTelefon,
                           }).ToList();
            lookUpEdit1.Properties.DataSource = cariler.ToList();
            lookUpEdit1.Properties.PopulateColumns();
            lookUpEdit1.Properties.Columns["Id"].Visible = false;
        }
        private void GelirEkle_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.NullText = "Cari Seçiniz ...";
            kasagiris();
            cariliste();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lookUpEdit1.Text=="Cari Seçiniz ...")
            {
                add();
                kasagiris();
            }
            else
            {
                cariliadd();
                kasagiris();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                var deger = db.TblKasaGiris.Find(id);
                db.TblKasaGiris.Remove(deger);
                db.SaveChanges();
                XtraMessageBox.Show("Kayıt Silindi", "Durum");
                kasagiris();

            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Okuma Hatası ...", "Durum");
                kasagiris();
            }
        }
    }
}
