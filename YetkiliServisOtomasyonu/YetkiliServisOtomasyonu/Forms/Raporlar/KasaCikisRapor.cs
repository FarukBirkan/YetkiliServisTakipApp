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
    public partial class KasaCikisRapor : Form
    {
        public KasaCikisRapor()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void kasacikisliste()
        {
            var liste = (from a in db.TblKasaCikis
                         
                         orderby a.KayitTarihi ascending
                         select new
                         {
                             Tarih = a.KayitTarihi,
                             Çıkış_Tür = a.Aciklama,
                             Cari = a.TblCari.CariAdiSoyadi,
                             Ürün = a.TblStok.StokAdi,
                             Tutar = a.ToplamTutar,

                         }).ToList();
            gridControl1.DataSource = liste.
                 ToList();
        }
        private void KasaCikisRapor_Load(object sender, EventArgs e)
        {
            kasacikisliste();
            lblveresiyekbugun.Text = db.TblKasaCikis.Where(a => a.Aciklama == "UrunAlis" && a.KayitTarihi==DateTime.Today).Sum(s => s.ToplamTutar).ToString();
            lblveresiyektoplam.Text = db.TblKasaCikis.Where(a => a.Aciklama == "UrunAlis").Sum(a => a.ToplamTutar).ToString();

            lblgiderbugün.Text= db.TblKasaCikis.Where(a => a.Aciklama.Contains("Gider") && a.KayitTarihi == DateTime.Today).Sum(s => s.ToplamTutar).ToString();
            lblgidertoplam.Text = db.TblKasaCikis.Where(a => a.Aciklama.Contains("Gider")).Sum(s => s.ToplamTutar).ToString();

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


                    var liste = (from a in db.TblKasaCikis
                                 where (a.KayitTarihi >= tarih1 && a.KayitTarihi <= tarih2)
                                 orderby a.KayitTarihi ascending
                                 select new
                                 {
                                     Tarih = a.KayitTarihi,
                                     Çıkış_Tür = a.Aciklama,
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
            kasacikisliste();

        }
    }
}
