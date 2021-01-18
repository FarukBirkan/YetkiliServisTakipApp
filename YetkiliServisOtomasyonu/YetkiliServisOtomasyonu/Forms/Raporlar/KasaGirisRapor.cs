using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YetkiliServisOtomasyonu.Forms.Raporlar
{
    public partial class KasaGirisRapor : Form
    {
        public KasaGirisRapor()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void kasagirisliste()
        {
            var liste = (from a in db.TblKasaGiris

                         orderby a.KayitTarih ascending
                         select new
                         {
                             Tarih = a.KayitTarih,
                             Giriş_Tür = a.Aciklama,
                             Cari = a.TblCari.CariAdiSoyadi,
                             Ürün = a.TblStok.StokAdi,
                             Tutar = a.ToplamTutar,

                         }).ToList();
            gridControl1.DataSource = liste.
                 ToList();
        }
        private void KasaRapor_Load(object sender, EventArgs e)
        {
            kasagirisliste();
         
            lblveresiyekbugun.Text = db.TblKasaGiris.Where(a => a.Aciklama == "Veresiye Tahsilat" && a.KayitTarih == DateTime.Today).Sum(a => a.ToplamTutar).ToString() + "  TL";
            lblveresiyektoplam.Text = db.TblKasaGiris.Where(a => a.Aciklama == "Veresiye Tahsilat").Sum(a => a.ToplamTutar).ToString() + "  TL";



            lblkasagiristoday.Text = db.TblKasaGiris.Where(a => a.KayitTarih == DateTime.Today).Sum(b => b.ToplamTutar).ToString() + " TL";
            lblkasagiristotal.Text = db.TblKasaGiris.Sum(a => a.ToplamTutar).ToString();

            //  lblkasagiristoday.Text =(toplam.ToString());

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dateEdit1.Text == null && dateEdit2.Text == null)
            {
                XtraMessageBox.Show("Lüften Tarihleri Seçiniz");
            }
            else
            {
                try
                {
                    DateTime tarih1 = DateTime.Parse(dateEdit1.EditValue.ToString());
                    DateTime tarih2 = DateTime.Parse(dateEdit2.EditValue.ToString());


                    var liste = (from a in db.TblKasaGiris
                                 where (a.KayitTarih>=tarih1&&a.KayitTarih<=tarih2)
                         orderby a.KayitTarih ascending
                                 select new
                                 {
                                     Tarih = a.KayitTarih,
                                     Giriş_Tür = a.Aciklama,
                                     Cari = a.TblCari.CariAdiSoyadi,
                                     Ürün = a.TblStok.StokAdi,
                                     Tutar = a.ToplamTutar,

                                 }).ToList();
                    gridControl1.DataSource = liste.
                         ToList();
                   
                    //lblhesapgiris.Text = db.TblKasa.Where(x => x.Tarih >= tarih1 && x.Tarih <= tarih2).Sum(z => z.Tutar).ToString();
                    //lblhesapcikis.Text = db.TblKasaCikis.Where(x => x.Tarih >= tarih1 && x.Tarih <= tarih2).Sum(z => z.Tutar).ToString();


                    //lblhesaptoplam.Text = (db.TblKasa.Where(x => x.Tarih >= tarih1 && x.Tarih <= tarih2).Sum(z => z.Tutar) - db.TblKasaCikis.Where(x => x.Tarih >= tarih1 && x.Tarih <= tarih2).Sum(z => z.Tutar)).ToString();

                }
                catch (Exception)
                {

                    XtraMessageBox.Show("Sorgu Hatası Tekrar Deneyiniz ", "Durum");
                }
            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            kasagirisliste();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string path = "KasaGiris.xlsx";
            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }
    }
}
