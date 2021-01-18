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

namespace YetkiliServisOtomasyonu.Forms.Kartlar.VeresiyeKart
{
    public partial class VeresiyeTahsilat : Form
    {
        public VeresiyeTahsilat()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void cariliste()
        {
            var liste = (from a in db.TblCari
                         select new
                         {
                             a.Id,
                             Cari = a.CariAdiSoyadi,
                             Telefon = a.CariTelefon

                         }).ToList();
            lookcari.Properties.DataSource = liste.ToList();
            lookcari.Properties.PopulateColumns();
            lookcari.Properties.Columns["Id"].Visible = false;

        }
        void stokliste()
        {
            var liste = (from a in db.TblStok
                         select new
                         {
                             a.Id,
                             Stok = a.StokAdi,
                             // Telefon = a.CariTelefon

                         }).ToList();
            lookUpEdit1.Properties.DataSource = liste.ToList();
            lookUpEdit1.Properties.PopulateColumns();
            lookUpEdit1.Properties.Columns["Id"].Visible = false;

        }
        void ödemeplanlistesi()
        {
            var liste = (from a in db.TblVeresiyeDurum
                         where (a.TblVeresiye.CariId == int.Parse(lookcari.EditValue.ToString()))
                         select new
                         {
                             a.Id,

                             Ödeme_Tarih = a.OdemeTarih,
                             Ödenecek_Tutar = a.TblVeresiye.OdenecekTutar,
                             Ödeme_Tutar = a.OdemeTutar,
                             Kalan_Tutar = a.KalanTutar,

                         }).ToList();
        }
        void hesapla()
        {
            lblcariadi.Text = lookcari.Text.ToString();
            decimal odenecektutar = decimal.Parse(db.TblVeresiye.Where(x => x.VeresiyeKod == txtveresiyekod.Text).Sum(a => a.OdenecekTutar).ToString());
            lblveresiyetutari.Text = odenecektutar.ToString();
            lblodenenveresiyetutarı.Text = db.TblVeresiyeDurum.Where(x => x.TblVeresiye.VeresiyeKod == txtveresiyekod.Text).Sum(a => a.OdemeTutar).ToString();
            
        }
        void istatistik()
        {
            try
            {
                  int deger = int.Parse(lblid.Text.ToString());
                   lblcariadi.Text = lookcari.Text.ToString();

                decimal odenecek = decimal.Parse(db.TblVeresiye.Where(x => x.VeresiyeKod == txtveresiyekod.Text).Sum(x => x.OdenecekTutar).ToString());
                lblveresiyetutari.Text = odenecek.ToString();
                lblodenenveresiyetutarı.Text = (db.TblVeresiyeDurum.Where(a => a.TblVeresiye.VeresiyeKod == txtveresiyekod.Text).Sum(c => c.OdemeTutar).ToString());

                decimal veresiye = decimal.Parse(odenecek.ToString());
                decimal odeme = decimal.Parse(db.TblVeresiyeDurum.Where(a => a.TblVeresiye.VeresiyeKod == txtveresiyekod.Text).Sum(c => c.OdemeTutar).ToString());
                lblkalanveresiyetutar.Text = (veresiye - odeme).ToString();
            }
            catch (Exception)
            {


            }


        }
        private void VeresiyeTahsilat_Load(object sender, EventArgs e)
        {
            cariliste();
            veresiyeliste();
            stokliste();
            // ürünliste();
            // veresiyeliste();



            //  XtraMessageBox.Show(VeresiyeListesi.stok.ToString());

            // lookurun.Properties.PopulateColumns();
            // txturun.Text = "Ürün Seçiniz ...";

            istatistik();

            // cariliste();
            //  stokliste();
            lblveresiyetutari.Text = txtödemetutar.Text;
            lblcariadi.Text = lookcari.Text;
            //ödemeplanlistesi();
        }
        void veresiyeliste()
        {
            if (lblid.Text == "")
            {
                gridView1.Columns.Clear();
            }
            else
            {
                var liste = (from a in db.TblVeresiyeDurum
                             where (a.VeresiyeId == VeresiyeListesi.id)
                             select new
                             {
                                 //a.Id,
                                 //a.VeresiyeKod,
                                 //a.TblCari.CariAdiSoyadi,
                                 //a.TblCari.CariTelefon,
                                 //a.TblCari.CariTelefon2,
                                 //a.TblCari.CariAdres,
                                 //a.TblCari.CariMailAdres,
                                 //a.TblStok.StokAdi,
                                 //a.TblStok.StokMarka,
                                 //a.TblStok.StokModel,
                                 //a.CariId,
                                 //a.StokId,
                                 //a.VeresiyeTutar,
                                 //a.VeresiyeTarih,
                                 //a.OdemeTarih,
                                 //a.OdenecekTutar,
                                 a.Id,
                                 a.TblVeresiye.TblCari.CariAdiSoyadi,
                                 // a.TblVeresiye.TblCari.CariTelefon,
                                 //  a.TblVeresiye.TblCari.CariTelefon2,
                                 a.TblVeresiye.VeresiyeTutar,

                                 a.OdemeTarih,
                                 a.OdemeTutar,
                                 a.KalanTutar,
                                 a.KayitEden,
                                 a.KayitTarih,
                                 a.Aciklama


                             }).ToList();
                gridControl1.DataSource = liste.ToList();
                gridView1.Columns["Id"].Visible = false;
                //  gridView1.Columns["CariId"].Visible = false;
                //   gridView1.Columns["StokId"].Visible = false;
                gridView1.Columns["KayitEden"].Visible = false;
                gridView1.Columns["KayitTarih"].Visible = false;
                gridView1.Columns["Aciklama"].Visible = false;
                //   gridView1.Columns["VeresiyeTarih"].Visible = false;
            }
        }

        void kasagiris()
        {
            Forms.Kartlar.VeresiyeKart.VeresiyeListesi vl = new VeresiyeListesi();
            TblKasaGiris kg = new TblKasaGiris();

            kg.CariId = int.Parse(lookcari.EditValue.ToString());
            kg.StokId = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            kg.StokId = VeresiyeListesi.stok;
            kg.Miktar = int.Parse(txtkullanilanmiktar.Text);
            kg.BirimTutar = 0;
            kg.ToplamTutar = decimal.Parse(textEdit1.Text);
            kg.Aciklama = "Veresiye Tahsilat";
            kg.KayitEden = GirisEkran.kullanici;
            kg.KayitTarih = DateTime.Today;
            db.TblKasaGiris.Add(kg);
            db.SaveChanges();

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lblkalanveresiyetutar.Text=="")
            {
                istatistik();
                TblVeresiyeDurum vd = new TblVeresiyeDurum();
                vd.VeresiyeId = int.Parse(lblid.Text);
                vd.OdemeTutar = decimal.Parse(textEdit1.Text);
                vd.KalanTutar = decimal.Parse(lblveresiyetutari.Text) - decimal.Parse(textEdit1.Text);
                
                vd.KalanTutar = decimal.Parse(lblkalanveresiyetutar.Text);
                vd.OdemeTarih = DateTime.Today;
                vd.KayitEden = GirisEkran.kullanici;
                vd.KayitTarih = DateTime.Today;
                vd.Aciklama = memoaciklama.Text;

                db.TblVeresiyeDurum.Add(vd);
                db.SaveChanges();
                XtraMessageBox.Show("Tahsilat Bilgileri Kayıt Edilmiştir", "Durum");
               
                veresiyeliste();
                kasagiris();
                if (lblveresiyetutari.Text == lblodenenveresiyetutarı.Text)
                {
                    XtraMessageBox.Show("Cariye Ait Borç Kalmamıştır  ...", "Durum");
                }
            }
            else
            {
                istatistik();
                TblVeresiyeDurum vd = new TblVeresiyeDurum();
                vd.VeresiyeId = int.Parse(lblid.Text);
                vd.OdemeTutar = decimal.Parse(textEdit1.Text);
                vd.KalanTutar = decimal.Parse(lblveresiyetutari.Text) - decimal.Parse(textEdit1.Text);
                vd.KalanTutar = decimal.Parse(lblkalanveresiyetutar.Text);
                vd.OdemeTarih = DateTime.Today;
                vd.KayitEden = GirisEkran.kullanici;
                vd.KayitTarih = DateTime.Today;
                vd.Aciklama = memoaciklama.Text;

                db.TblVeresiyeDurum.Add(vd);
                db.SaveChanges();
                XtraMessageBox.Show("Tahsilat Bilgileri Kayıt Edilmiştir", "Durum");
                istatistik();
                veresiyeliste();
                kasagiris();
                if (lblveresiyetutari.Text == lblodenenveresiyetutarı.Text)
                {
                    XtraMessageBox.Show("Cariye Ait Borç Kalmamıştır  ...", "Durum");
                }
            }
            //try
            //{
            //    if (lblkalanveresiyetutar.Text == "")
            //    {
                   
            //    }
            //    else
            //    {
            //        istatistik();
            //        TblVeresiyeDurum vd = new TblVeresiyeDurum();
            //        vd.VeresiyeId = int.Parse(lblid.Text);
            //        vd.OdemeTutar = decimal.Parse(textEdit1.Text);
            //        vd.KalanTutar = decimal.Parse(lblkalanveresiyetutar.Text) - decimal.Parse(textEdit1.Text);
            //        //vd.KalanTutar = decimal.Parse(lblkalanveresiyetutar.Text);
            //        vd.OdemeTarih = DateTime.Today;
            //        vd.KayitEden = GirisEkran.kullanici;
            //        vd.KayitTarih = DateTime.Today;
            //        vd.Aciklama = memoaciklama.Text;

            //        db.TblVeresiyeDurum.Add(vd);
            //        db.SaveChanges();
            //        XtraMessageBox.Show("Tahsilat Bilgileri Kayıt Edilmiştir", "Durum");
            //        istatistik();
            //        veresiyeliste();
            //        kasagiris();

            //        if (lblveresiyetutari.Text == lblodenenveresiyetutarı.Text)
            //        {
            //            XtraMessageBox.Show("Cariye Ait Borç Kalmamıştır  ...", "Durum");
            //        }
            //    }

            //}
            //catch (Exception)
            //{
            //    //XtraMessageBox.Show("Veri Hatası", "Durum");

            //}
        }
    }
}
