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
    public partial class ÜrünSatis : Form
    {
        public ÜrünSatis()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void satisliste()
        {
            var liste = (from a in db.TblKasaGiris
                         where (a.Aciklama == "UrunSatis")
                         select new
                         {
                             a.Id,
                             a.TblCari.CariAdiSoyadi,
                             a.TblStok.StokAdi,
                             a.Miktar,
                             a.BirimTutar,
                             a.ToplamTutar,

                         }
                       ).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
        }
        void cariliste()
        {
            var liste = (from a in db.TblCari
                         select new
                         {
                             a.Id,
                             Cari = a.CariAdiSoyadi,
                             a.CariTelefon,

                         }).ToList();
            lookUpEdit1.Properties.DataSource = liste.ToList();
            lookUpEdit1.Properties.PopulateColumns();
            lookUpEdit1.Properties.Columns["Id"].Visible = false;
        }
        void urunliste()
        {
            var liste = (from a in db.TblStok
                         select new
                         {
                             a.Id,
                             Ürün = a.StokAdi,
                             Marka = a.StokMarka,
                             Model = a.StokModel,
                             Alış_Fiyat = a.StokAlisFiyat,
                             Satış_Fiyat = a.StokSatisFiyat,
                             Stok_Miktar = a.StokMiktar

                         }).ToList();
            gridControl2.DataSource = liste.ToList();

            gridView2.Columns["Id"].Visible = false;
        }
        void add()
        {
            try
            {
                tutarhesapla();
                TblKasaGiris kg = new TblKasaGiris();
                kg.CariId = int.Parse(lookUpEdit1.EditValue.ToString());
                kg.StokId = int.Parse(gridView2.GetFocusedRowCellValue("Id").ToString());
                kg.Miktar = int.Parse(txtmiktar.Text);
                kg.BirimTutar = decimal.Parse(txtbirimtutar.Text);
                kg.ToplamTutar = decimal.Parse(txttoplamtutar.Text);
                kg.Aciklama = "UrunSatis";
                kg.KayitEden = GirisEkran.kullanici;
                kg.KayitTarih = DateTime.Today;
                db.TblKasaGiris.Add(kg);
                db.SaveChanges();
                XtraMessageBox.Show("Ürün Satışı Gerçekleşmiştir ... ", "Durum");
                satisliste();



                int id = int.Parse(gridView2.GetFocusedRowCellValue("Id").ToString());



                var stok = db.TblStok.Find(id);


                stok.StokMiktar = int.Parse(lblstok.Text.ToString()) - int.Parse(txtmiktar.Text.ToString());


                db.SaveChanges();
                urunliste();

            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Okuma Hatası ... ", "Durum");
            }
            // XtraMessageBox.Show("Güncellendi", "Durum");

        }
        private void ÜrünSatis_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.PopulateColumns();
            lookUpEdit1.Properties.NullText = "Cari Seçiniz ... ";

            cariliste();
            urunliste();
            satisliste();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            add();
        }
        int stok;
        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            //  stok=int.Parse(lookUpEdit2.Properties.Columns["StokMiktar"].ToString());
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            txturun.Text = gridView2.GetFocusedRowCellValue("Ürün").ToString();
            lblstok.Text = gridView2.GetFocusedRowCellValue("Stok_Miktar").ToString();
            txtbirimtutar.Text = gridView2.GetFocusedRowCellValue("Satış_Fiyat").ToString();
            if (lblstok.Text == "0" )
            {
                XtraMessageBox.Show("Elinizde Seçtiniz Ürün Yoktur ...", "Durum");
            }
        }
        void tutarhesapla()
        {
            try
            {
                decimal birim, miktar, toplam;
                birim = decimal.Parse(txtbirimtutar.Text);
                miktar = decimal.Parse(txtmiktar.Text);
                toplam = miktar * birim;
                txttoplamtutar.Text = toplam.ToString();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Hatası", "Durum");
            }

        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            tutarhesapla();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = XtraMessageBox.Show("Veri Silinsin mi ?", "Durum", MessageBoxButtons.OKCancel);
            if (dialog == DialogResult.OK)
            {
               
                try
                {
                    int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                    var deger = db.TblKasaGiris.Find(id);
                    db.TblKasaGiris.Remove(deger);
                    db.SaveChanges();
                    XtraMessageBox.Show("Kayıt Silindi", "Durum");
                    DialogResult dialog2 = new DialogResult();
                    dialog2 = XtraMessageBox.Show("Ürün İade mi ?", "Durum", MessageBoxButtons.OKCancel);
                    satisliste();


                    if (dialog2==DialogResult.OK)
                    {
                        Forms.Kartlar.StokKart.StokListe sk = new Kartlar.StokKart.StokListe();
                        sk.MdiParent = this.MdiParent;
                        sk.Show();
                    }
                  



                   
                }
                catch (Exception)
                {


                    XtraMessageBox.Show("Satış Listesinden Seçim Yapmalısınız  ..", "Hata");

                }
            }


        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //lblkasaId.Text = (gridView2.GetFocusedRowCellValue("Id").ToString());
        }
    }
}
