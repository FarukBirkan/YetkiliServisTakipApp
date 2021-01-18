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

namespace YetkiliServisOtomasyonu.Forms.Kartlar.Veresiye
{
    public partial class TahsilatGiris : Form
    {
        public TahsilatGiris()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void liste()
        {
            var ödemeplan = (from a in db.TblVeresiyeDurum
                             where (a.VeresiyeId == VeresiyeListesi.id)
                             select new
                             {
                                 a.TblVeresiye.TblCari.CariAdiSoyadi,
                                 a.OdemeTutar,
                                 a.KalanTutar,
                                 a.OdemeTarih

                             }).ToList();
            gridControl1.DataSource = ödemeplan.ToList();
        }
        void hesap()
        {
            try
            {
                int deger = int.Parse(lblid.Text.ToString());
                // lblcariadi.Text = lookcari.Text.ToString();

                decimal odenecek = decimal.Parse(db.TblVeresiye.Where(x => x.VeresiyeKod == txtveresiyekod.Text).Sum(x => x.OdenecekTutar).ToString());
                lblveresiyetutar.Text = odenecek.ToString();
                lblödenentutar.Text = (db.TblVeresiyeDurum.Where(a => a.TblVeresiye.VeresiyeKod == txtveresiyekod.Text).Sum(c => c.OdemeTutar).ToString());

                decimal veresiye = decimal.Parse(odenecek.ToString());
                decimal odeme = decimal.Parse(db.TblVeresiyeDurum.Where(a => a.TblVeresiye.VeresiyeKod == txtveresiyekod.Text).Sum(c => c.OdemeTutar).ToString());
                lblkalantutar.Text = (veresiye - odeme).ToString();
            }
            catch (Exception)
            {


            }
        }
      void addkasa()
        {
            TblKasaGiris kg = new TblKasaGiris();
            kg.CariId = int.Parse(lookcari.EditValue.ToString());
            kg.StokId = int.Parse(lookstok.EditValue.ToString());
            kg.Miktar =(VeresiyeListesi.Miktarı);
            kg.BirimTutar = VeresiyeListesi.Veresiye_Tutar;
            kg.ToplamTutar =decimal.Parse( txttahsilat.Text);
            kg.Aciklama = "Veresiye Tahsilat";
            kg.KayitEden = GirisEkran.kullanici;
            kg.KayitTarih = DateTime.Today;
            db.TblKasaGiris.Add(kg);
            db.SaveChanges();
            XtraMessageBox.Show("Tahsilat Kasaya Aktarılmıştır", "Durum");
            try
            {
               

            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri adagsdgsfsdOkuma Hatası ...", "Durum");
            }


        }
        void cariliste()
        {
            var liste = (from a in db.TblCari
                         select new
                         {
                             Cari_Id=a.Id,
                             Cari = a.CariAdiSoyadi,
                             Telefon = a.CariTelefon

                         }).ToList();
            lookcari.Properties.DataSource = liste.ToList();
            lookcari.Properties.PopulateColumns();
            lookcari.Properties.Columns["Cari_Id"].Visible = false;

        }
        void UrunListe()
        {
            var liste = (from a in db.TblStok
                         select new
                         {
                            Stok_Id = a.Id,
                             Urun = a.StokAdi,
                            

                         }).ToList();
            lookstok.Properties.DataSource = liste.ToList();
            lookstok.Properties.PopulateColumns();
            lookstok.Properties.Columns["Stok_Id"].Visible = false;

        }
        void hh()
        {
            lblödenentutar.Text = (db.TblVeresiyeDurum.Where(a => a.VeresiyeId == VeresiyeListesi.id).Sum(c => c.OdemeTutar).ToString());
            if (lblödenentutar.Text == "")
            {
                lblödenentutar.Text = "0";
                lblkalantutar.Text = (VeresiyeListesi.ÖdenecekTutar - decimal.Parse(lblödenentutar.Text)).ToString();

            }
            else
            {

                lblkalantutar.Text = (VeresiyeListesi.ÖdenecekTutar - decimal.Parse(lblödenentutar.Text)).ToString();

            }
        }
        private void TahsilatGiris_Load(object sender, EventArgs e)
        {
            cariliste();
            UrunListe();

            liste();

            hh();
           
        }
        void add()
        {
            try
            {
                if (lblkalantutar.Text == "0")
                {
                    TblVeresiyeDurum vd = new TblVeresiyeDurum();
                    vd.VeresiyeId = int.Parse(lblid.Text);
                    vd.OdemeTutar = decimal.Parse(txttahsilat.Text);
                    //vd.KalanTutar = decimal.Parse(lblkalantutar.Text);
                    vd.KalanTutar = (VeresiyeListesi.ÖdenecekTutar) - decimal.Parse(txttahsilat.Text);
                    vd.OdemeTarih = DateTime.Today;
                    vd.KayitEden = GirisEkran.kullanici;
                    vd.Aciklama = memoEdit1.Text;
                    vd.KayitTarih = DateTime.Today;
                    db.TblVeresiyeDurum.Add(vd);
                    db.SaveChanges();
                    XtraMessageBox.Show("Tahsilat Bilgileri Kayıt Edilmiştir", "Durum");
                   
                    liste();
                    hh();
                    //lblödenentutar.Text = (db.TblVeresiyeDurum.Where(a => a.VeresiyeId == VeresiyeListesi.id).Sum(c => c.OdemeTutar).ToString());
                    //decimal kalan = (VeresiyeListesi.Veresiye_Tutar) - decimal.Parse(lblödenentutar.Text);
                    //lblkalantutar.Text = kalan.ToString();
                    if (VeresiyeListesi.Veresiye_Tutar == decimal.Parse(lblödenentutar.Text))
                    {
                        XtraMessageBox.Show("Cariye Ait Bu Kartta Borç Kalmamıştır ...", "Durum");
                    }
                   

                }

                else
                {
                    TblVeresiyeDurum vd = new TblVeresiyeDurum();
                    vd.VeresiyeId = int.Parse(lblid.Text);
                    vd.OdemeTutar = decimal.Parse(txttahsilat.Text);
                    //vd.KalanTutar = decimal.Parse(lblkalantutar.Text);
                    vd.KalanTutar = decimal.Parse(lblkalantutar.Text) - decimal.Parse(txttahsilat.Text);
                    vd.OdemeTarih = DateTime.Today;
                    vd.KayitEden = GirisEkran.kullanici;
                    vd.Aciklama = memoEdit1.Text;
                    vd.KayitTarih = DateTime.Today;
                    db.TblVeresiyeDurum.Add(vd);
                    db.SaveChanges();
                    XtraMessageBox.Show("Tahsilat Bilgileri Kayıt Edilmiştir", "Durum");
                  
                    liste();
                    hh();
                    //lblödenentutar.Text = (db.TblVeresiyeDurum.Where(a => a.VeresiyeId == VeresiyeListesi.id).Sum(c => c.OdemeTutar).ToString());
                    //decimal kalan = (VeresiyeListesi.Veresiye_Tutar) - decimal.Parse(lblödenentutar.Text);
                    //lblkalantutar.Text = kalan.ToString();
                    if (VeresiyeListesi.Veresiye_Tutar == decimal.Parse(lblödenentutar.Text))
                    {
                        XtraMessageBox.Show("Cariye Ait Bu Kartta Borç Kalmamıştır ...", "Durum");
                    }
                  
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Veri Okuma Hatası ...", "Durum");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            add();
            addkasa();
        }
    }
}
