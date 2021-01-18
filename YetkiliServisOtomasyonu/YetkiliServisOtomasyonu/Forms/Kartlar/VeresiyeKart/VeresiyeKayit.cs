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
    public partial class VeresiyeKayit : Form
    {
        public VeresiyeKayit()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();

        void temizle()
        {
            txtveresiyekod.Text = "";
            lookcari.Properties.NullText = "Cari Seçiniz ...";
            txturun.Properties.NullText = "Ürün Seçiniz ...";
            txtveresiyetutar.Text = "";
            txtodemetarih.Text = "";
            txtödemetutar.Text = "";
            memoaciklama.Text = "";
            txtkullanilanmiktar.Text = "";
            lblstok.Text = "";
            lblid.Text = "";
        }
        void add()
        {
            try
            {
                decimal tutar =decimal.Parse(gridView2.GetFocusedRowCellValue("Satış_Fiyat").ToString());
                int miktar =int.Parse(txtkullanilanmiktar.Text);
                decimal toplamtutar = tutar * miktar;
                txtödemetutar.Text = toplamtutar.ToString();
                TblVeresiye vr = new TblVeresiye();
                vr.VeresiyeKod = txtveresiyekod.Text;
                vr.CariId = int.Parse(lookcari.EditValue.ToString());
                vr.StokId = int.Parse(gridView2.GetFocusedRowCellValue("Id").ToString());
                vr.VeresiyeTutar = decimal.Parse(txtveresiyetutar.Text);
                vr.VeresiyeTarih = DateTime.Today;
                vr.OdemeTarih = DateTime.Parse(txtodemetarih.Text);
                vr.OdenecekTutar = decimal.Parse(txtödemetutar.Text);
                vr.KayitEden = GirisEkran.kullanici;
                vr.KayitTarih = DateTime.Today;
                vr.Aciklama = memoaciklama.Text;
                vr.UrunMiktari = int.Parse(txtkullanilanmiktar.Text);
                db.TblVeresiye.Add(vr);
                db.SaveChanges();
                XtraMessageBox.Show("Veresiye Bilgileri Kayıt Edilmiştir ...", "Durum");
                veresiyeliste();


                int id = int.Parse(gridView2.GetFocusedRowCellValue("Id").ToString());



                var stok = db.TblStok.Find(id);


                stok.StokMiktar = int.Parse(lblstok.Text.ToString()) - int.Parse(txtkullanilanmiktar.Text.ToString());


                db.SaveChanges();
                stokliste();
                //int stokıd = int.Parse(lookurun.EditValue.ToString());
                //var gg = db.TblStok.Find(stokıd);
                //gg.StokMiktar = stok - int.Parse(txtkullanilanmiktar.Text);
                //db.SaveChanges();
                //XtraMessageBox.Show("Stok Miktarı Güncellendi", "Durum");


            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Hatası ...", "Durum");
            }

        }
        void cariliste()
        {
            var liste = (from a in db.TblCari
                         select new
                         {
                             a.Id,
                             Cari = a.CariAdiSoyadi,
                             Telefon=a.CariTelefon
                            
                         }).ToList();
            lookcari.Properties.DataSource = liste.ToList();
            lookcari.Properties.PopulateColumns();
            lookcari.Properties.Columns["Id"].Visible = false;

        }
        
        //void veresiyeliste()
        //{
        //    if (lblid.Text == "")
        //    {
        //        gridView1.Columns.Clear();
        //    }
        //    else
        //    {
        //        var liste = (from a in db.TblVeresiyeDurum
        //                     where (a.VeresiyeId == VeresiyeListesi.id)
        //                     select new
        //                     {
        //                         //a.Id,
        //                         //a.VeresiyeKod,
        //                         //a.TblCari.CariAdiSoyadi,
        //                         //a.TblCari.CariTelefon,
        //                         //a.TblCari.CariTelefon2,
        //                         //a.TblCari.CariAdres,
        //                         //a.TblCari.CariMailAdres,
        //                         //a.TblStok.StokAdi,
        //                         //a.TblStok.StokMarka,
        //                         //a.TblStok.StokModel,
        //                         //a.CariId,
        //                         //a.StokId,
        //                         //a.VeresiyeTutar,
        //                         //a.VeresiyeTarih,
        //                         //a.OdemeTarih,
        //                         //a.OdenecekTutar,
        //                         a.Id,
        //                         a.TblVeresiye.TblCari.CariAdiSoyadi,
        //                         a.TblVeresiye.TblCari.CariTelefon,
        //                         a.TblVeresiye.TblCari.CariTelefon2,
        //                         a.TblVeresiye.VeresiyeTutar,

        //                         a.OdemeTarih,
        //                         a.OdemeTutar,
        //                         a.KalanTutar,
        //                         a.KayitEden,
        //                         a.KayitTarih,
        //                         a.Aciklama


        //                     }).ToList();
        //        gridControl1.DataSource = liste.ToList();
        //        gridView1.Columns["Id"].Visible = false;
        //        //  gridView1.Columns["CariId"].Visible = false;
        //        //   gridView1.Columns["StokId"].Visible = false;
        //        gridView1.Columns["KayitEden"].Visible = false;
        //        gridView1.Columns["KayitTarih"].Visible = false;
        //        gridView1.Columns["Aciklama"].Visible = false;
        //        //   gridView1.Columns["VeresiyeTarih"].Visible = false;
        //    }


        //}
        //void veresiyetutar()
        //{
        //    var liste = (from a in db.TblVeresiye
        //                 where (a.VeresiyeKod == txtveresiyekod.Text)
        //                 select new
        //                 {
        //                     a.VeresiyeTutar
        //                 }
        //                ).ToList();
        //}

        void istatistik()
        {
            try
            {
                //int deger = int.Parse(lblid.Text.ToString());
                //lblcariadi.Text = lookcari.Text.ToString();

                //decimal odenecek = decimal.Parse(db.TblVeresiye.Where(x => x.VeresiyeKod == txtveresiyekod.Text).Sum(x => x.VeresiyeTutar).ToString());
                //lblveresiyetutar.Text = odenecek.ToString();
                //lblveresiyeodenentutar.Text = (db.TblVeresiyeDurum.Where(a => a.TblVeresiye.VeresiyeKod == txtveresiyekod.Text).Sum(c => c.OdemeTutar).ToString());

                //decimal veresiye = decimal.Parse(odenecek.ToString());
                //decimal odeme = decimal.Parse(lblveresiyeodenentutar.Text.ToString());
                //lblkalanveresiyetutar.Text = (veresiye - odeme).ToString();
            }
            catch (Exception)
            {


            }


        }
        void stokliste()
        {
            var liste = (from a in db.TblStok
                         select new
                         {
                             a.Id,
                             Stok_Adı = a.StokAdi,
                             Marka = a.StokMarka,
                             Model = a.StokModel,
                             Alış_Fiyat = a.StokAlisFiyat,
                             Satış_Fiyat = a.StokSatisFiyat,
                             Miktar = a.StokMiktar,
                         }).ToList();
            gridControl2.DataSource = liste.ToList();
            gridView2.Columns["Id"].Visible = false;

        }
        int stok;
        void veresiyeliste()
        {
            var liste = (from a in db.TblVeresiye
                         select new
                         {
                             a.Id,

                             a.TblCari.CariAdiSoyadi,
                             a.TblCari.CariTelefon,
                             a.TblCari.CariTelefon2,
                             a.TblCari.CariAdres,
                             a.TblCari.CariMailAdres,
                             a.TblStok.StokAdi,
                             a.TblStok.StokMarka,
                             a.TblStok.StokModel,
                             a.UrunMiktari,
                             a.CariId,
                             a.StokId,
                             a.VeresiyeTutar,
                             a.VeresiyeTarih,
                             a.OdemeTarih,
                             a.OdenecekTutar,

                             a.KayitEden,
                             a.KayitTarih,
                             a.Aciklama,
                             a.VeresiyeKod,
                             a.TblStok.StokMiktar,



                         }).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
            gridView1.Columns["CariId"].Visible = false;
            gridView1.Columns["StokId"].Visible = false;
            gridView1.Columns["KayitEden"].Visible = false;
            gridView1.Columns["KayitTarih"].Visible = false;
            gridView1.Columns["VeresiyeTarih"].Visible = false;
            gridView1.Columns["VeresiyeKod"].Visible = false;
            gridView1.Columns["StokMiktar"].Visible = false;

        }
        private void VeresiyeKayit_Load(object sender, EventArgs e)
        {
            cariliste();
            veresiyeliste();
            stokliste();
            // ürünliste();
           // veresiyeliste();

          

            //  XtraMessageBox.Show(VeresiyeListesi.stok.ToString());
           
            // lookurun.Properties.PopulateColumns();
            txturun.Text = "Ürün Seçiniz ...";

            istatistik();
            //if (lblid.Text == "")
            //{
            //   // groupControl4.Visible = false;
            //}
            //else
            //{
            //  //  groupControl4.Visible = true;
            //    //labelControl9.Visible = true;
            //    //labelControl16.Visible = true;
            //    //labelControl17.Visible = true;
            //    ////labStok.Visible = true;
            //    //labVerilenSayi.Visible = true;
            //    //LabStokKalan.Visible = true;

            //    //LabStokKalan.Text =(int.Parse(labStok.Text.ToString()) - int.Parse(labVerilenSayi.Text.ToString())).ToString();
            //}



        }
        void delete()
        {
           
            try
            {
                int id = int.Parse(lblveresiyeid.Text);
                var deger = db.TblVeresiye.Find(id);
                db.TblVeresiye.Remove(deger);
                db.SaveChanges();
                XtraMessageBox.Show("Kayıt Silindi", "Durum");
                veresiyeliste();
                stokliste();

            }
            catch (Exception)
            {


                XtraMessageBox.Show("Veresiye Kart ile İlgili Hareket Kaydı Vardır ..", "Hata");

            }

        }
        void stokgüncelle()
        {

        }
        void güncelle()
        {

            try
            {
                Form1 ff = new Form1();
                int id = int.Parse(lblid.Text);
                var vrs = db.TblVeresiye.Find(id);
                // stok.CariTür = int.Parse(lookcaritur.EditValue.ToString());
                vrs.VeresiyeKod = txtveresiyekod.Text;
                vrs.CariId = int.Parse(lookcari.EditValue.ToString());
                vrs.StokId = int.Parse(gridView2.GetFocusedRowCellValue("Id").ToString());
                vrs.VeresiyeTutar = decimal.Parse(txtveresiyetutar.Text);
                vrs.VeresiyeTarih = DateTime.Today;
                vrs.OdemeTarih = DateTime.Parse(txtodemetarih.EditValue.ToString());
                vrs.OdenecekTutar = decimal.Parse(txtödemetutar.Text);
                vrs.KayitEden = GirisEkran.kullanici;
                vrs.KayitTarih = DateTime.Today;
                vrs.Aciklama = memoaciklama.Text;
                vrs.UrunMiktari = int.Parse(txtkullanilanmiktar.Text);




                db.SaveChanges();
                XtraMessageBox.Show("Güncellendi", "Durum");
                //veresiyeliste();


                //int stokıd = int.Parse(VeresiyeListesi.stok.ToString());
                //var gg = db.TblStok.Find(stokıd);
                //gg.StokMiktar = stok - int.Parse(txtkullanilanmiktar.Text);
                //db.SaveChanges();
                //XtraMessageBox.Show("Stok Miktarı Güncellendi", "Durum");

                // lblid.Text = "";
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Hatası .... ", "Hata");
            }
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {


        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            delete();
            temizle();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            //veresiyeliste();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            temizle();
        }

        private void simpleButton8_Click_1(object sender, EventArgs e)
        {
            veresiyeliste();
        }
        void kasagiris()
        {
            //Forms.Kartlar.VeresiyeKart.VeresiyeListesi vl = new VeresiyeListesi();
            //TblKasaGiris kg = new TblKasaGiris();

            //kg.CariId = int.Parse(lookcari.EditValue.ToString());
            //kg.StokId = int.Parse(gridView2.GetFocusedRowCellValue("Id").ToString());
            //kg.Miktar = int.Parse(txtkullanilanmiktar.Text);
            //kg.BirimTutar = 0;
            //kg.ToplamTutar = decimal.Parse(txtodemetutar.Text);
            //kg.Aciklama = "Veresiye Tahsilat";
            //kg.KayitEden = GirisEkran.kullanici;
            //kg.KayitTarih = DateTime.Today;
            //db.TblKasaGiris.Add(kg);
            //db.SaveChanges();

        }
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            veresiyeliste();
            if (txturun.Text== "Ürün Seçiniz ...")
            {
                XtraMessageBox.Show("Stok Listesinden Seçim Yapınız ...","Durum");
            }
            else
            {
                add();
                temizle();
            }
           // add();
            // XtraMessageBox.Show("Stok Çıkış Yapınız ...", "Durum");
          //  veresiyeliste();
           // temizle();

            //if (lblid.Text == "")
            //{

            //    // stokgüncelle();
            //    // stokgüncelle();
            //    //istatistik();
            //}
            //else
            //{
            //    güncelle();
            //    istatistik();

            //    //   temizle();
            //}

        }

        private void simpleButton9_Click_1(object sender, EventArgs e)
        {
            delete();
            istatistik();
        }
        Forms.Kartlar.VeresiyeKart.VeresiyeListesi vl = new VeresiyeListesi();
        private void simpleButton4_Click(object sender, EventArgs e)
        { //istatistik();

            //MessageBox.Show(stok.ToString());
           try
            {
                //if (lblkalanveresiyetutar.Text == "0")
                //{

                //    istatistik();
                //    TblVeresiyeDurum vd = new TblVeresiyeDurum();
                //    vd.VeresiyeId = int.Parse(lblid.Text);
                //    vd.OdemeTutar = decimal.Parse(txtodemetutar.Text);
                //    vd.KalanTutar = decimal.Parse(lblveresiyetutar.Text) - decimal.Parse(txtodemetutar.Text);
                //    vd.OdemeTarih = DateTime.Today;
                //    vd.KayitEden = GirisEkran.kullanici;
                //    vd.KayitTarih = DateTime.Today;
                //    vd.Aciklama = memoaciklamatahsilat.Text;

                //    db.TblVeresiyeDurum.Add(vd);
                //    db.SaveChanges();
                //    XtraMessageBox.Show("Tahsilat Bilgileri Kayıt Edilmiştir", "Durum");
                //    istatistik();
                //    veresiyeliste();
                //    kasagiris();
                //    if (lblveresiyetutar.Text == lblveresiyeodenentutar.Text)
                //    {
                //        XtraMessageBox.Show("Cariye Ait Borç Kalmamıştır  ...", "Durum");
                //    }
                //}
                //else
                //{
                //    istatistik();
                //    TblVeresiyeDurum vd = new TblVeresiyeDurum();
                //    vd.VeresiyeId = int.Parse(lblid.Text);
                //    vd.OdemeTutar = decimal.Parse(txtodemetutar.Text);
                //    vd.KalanTutar = decimal.Parse(lblkalanveresiyetutar.Text) - decimal.Parse(txtodemetutar.Text);
                //    vd.OdemeTarih = DateTime.Today;
                //    vd.KayitEden = GirisEkran.kullanici;
                //    vd.KayitTarih = DateTime.Today;
                //    vd.Aciklama = memoaciklamatahsilat.Text;

                //    db.TblVeresiyeDurum.Add(vd);
                //    db.SaveChanges();
                //    XtraMessageBox.Show("Tahsilat Bilgileri Kayıt Edilmiştir", "Durum");
                //    istatistik();
                   veresiyeliste();
                //    kasagiris();

                //    if (lblveresiyetutar.Text == lblveresiyeodenentutar.Text)
                //    {
                //        XtraMessageBox.Show("Cariye Ait Borç Kalmamıştır  ...", "Durum");
                //    }
                //}

            }
            catch (Exception)
            {
                //XtraMessageBox.Show("Veri Hatası", "Durum");

            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //    int kalanstok =int.Parse(labStok.Text) - int.Parse(txtkullanilanmiktar.Text);
            //    XtraMessageBox.Show(kalanstok.ToString());
            //stokgüncelle();
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            txturun.Text = (gridView2.GetFocusedRowCellValue("Stok_Adı").ToString());
            txtveresiyetutar.Text = (gridView2.GetFocusedRowCellValue("Satış_Fiyat").ToString());
            lblstok.Text = (gridView2.GetFocusedRowCellValue("Miktar").ToString());
        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = XtraMessageBox.Show("Veri Silinsin mi ? ", "Durum", MessageBoxButtons.OKCancel);
            if (dialog == DialogResult.OK)
            {
                delete();
            }
            else
            {
                XtraMessageBox.Show("Silinmedi..", "Durum");
            }

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            lblveresiyeid.Text = (gridView1.GetFocusedRowCellValue("Id").ToString());

        }
    }
}
