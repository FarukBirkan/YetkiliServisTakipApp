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

namespace YetkiliServisOtomasyonu.Forms.Raporlar
{
    public partial class KasaRapor : Form
    {
        public KasaRapor()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        
        private void KasaRapor_Load(object sender, EventArgs e)
        {
            try
            {
                label2.Text = db.TblKasaGiris.Where(a => a.KayitTarih == DateTime.Today).Sum(b => b.ToplamTutar).ToString();
                label4.Text = db.TblKasaCikis.Where(a => a.KayitTarihi == DateTime.Today).Sum(n => n.ToplamTutar).ToString();
                decimal giris = decimal.Parse(label2.Text);
                decimal cikis = decimal.Parse(label4.Text);
                label6.Text = (giris - cikis).ToString();
                label8.Text = db.TblKasaGiris.Where(a => a.Aciklama == "Veresiye Tahsilat" && a.KayitTarih == DateTime.Today).Sum(a => a.ToplamTutar).ToString() + "  TL";
                label13.Text = db.TblKasaCikis.Where(a => a.Aciklama.Contains("Gider") && a.KayitTarihi == DateTime.Today).Sum(s => s.ToplamTutar).ToString();
                label15.Text = db.TblVeresiye.Where(a => a.OdemeTarih == DateTime.Today).Sum(s => s.OdenecekTutar).ToString();

            }
            catch (Exception)
            {

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DateTime tarih1 = DateTime.Parse(dateEdit1.EditValue.ToString());
            DateTime tarih2 = DateTime.Parse(dateEdit2.EditValue.ToString());


            var liste = (from a in db.TblKasaGiris
                         where (a.KayitTarih >= tarih1 && a.KayitTarih <= tarih2)
                         orderby a.KayitTarih ascending
                         select new
                         {
                             //Tarih = a.KayitTarih,
                             //Giriş_Tür = a.Aciklama,
                             //Cari = a.TblCari.CariAdiSoyadi,
                             //Ürün = a.TblStok.StokAdi,
                             Tutar = a.ToplamTutar,

                         }).ToList().Sum(a=>a.Tutar);

            var liste2 = (from a in db.TblKasaCikis
                          where (a.KayitTarihi >= tarih1 && a.KayitTarihi <= tarih2)
                          select new { a.ToplamTutar}).ToList().Sum(a=>a.ToplamTutar);
            label17.Text = liste.ToString();
            label9.Text = liste2.ToString();

            label7.Text = (liste - liste2).ToString();
            //gridControl1.DataSource = liste.
            //     ToList();



            //DateTime ilk = DateTime.Parse(dateEdit1.EditValue.ToString());
            //DateTime son = DateTime.Parse(dateEdit2.EditValue.ToString());

            //label17.Text = db.TblKasaGiris.Where(a => a.KayitTarih == ilk && son <= a.KayitTarih).Sum(b => b.ToplamTutar).ToString();
            //label9.Text = db.TblKasaCikis.Where(a => a.KayitTarihi == ilk && son <= a.KayitTarihi).Sum(n => n.ToplamTutar).ToString();
            //if (label17.Text=="")
            //{
            //    label17.Text = "0";
            //    decimal giris = decimal.Parse(label17.Text);
            //    decimal cikis = decimal.Parse(label9.Text);

            //    label7.Text = (giris - cikis).ToString();
            //}
            //else if (label9.Text=="")
            //{
            //    label9.Text = "0";
            //    decimal giris = decimal.Parse(label17.Text);
            //    decimal cikis = decimal.Parse(label9.Text);

            //    label7.Text = (giris - cikis).ToString();
            //}
            //else
            //{
            //    decimal giris = decimal.Parse(label17.Text);
            //    decimal cikis = decimal.Parse(label9.Text);

            //    label7.Text = (giris - cikis).ToString();
            //}
            //try
            //{

            //}
            //catch (Exception)
            //{

            //    XtraMessageBox.Show("Lütfen Tarihlari Seçiniz","Durum");
            //}
        }
    }
}
