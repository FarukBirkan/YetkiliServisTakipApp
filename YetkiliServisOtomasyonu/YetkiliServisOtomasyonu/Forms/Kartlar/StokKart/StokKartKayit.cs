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

namespace YetkiliServisOtomasyonu.Forms.Kartlar.StokKart
{
    public partial class StokKartKayit : Form
    {
        public StokKartKayit()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void temizle()
        {
            txtstokno.Text = "";
            txtstokadi.Text = "";
            txtmarka.Text = "";
            txtmodel.Text = "";
            txtmiktar.Text = "";
            txtalismiktar.Text = "";
            txtsatismiktar.Text = "";
            txtkritikstokmiktar.Text = "";
            lookdepo.Properties.NullText = "Lütfen Depo Seçiniz ...";
            looktedarikci.Properties.NullText = "Lütfen Tedarikçi Seçiniz ...";
            memoaciklama.Text = "";
        }
        void listele()
        {
            var liste = (from a in db.TblStok
                         select new
                         {
                             a.StokNo,
                             a.StokAdi,
                             a.StokMarka,
                             a.StokModel,
                             a.StokAlisFiyat,
                             a.StokSatisFiyat,
                             a.TblDepo.DepoAdi,

                             a.StokMiktar,
                             a.KritikStokDurum,
                             Tedarikçi = a.TblCari.CariAdiSoyadi
                         }).ToList();
            gridControl1.DataSource = liste.ToList();

        }
        void depoliste()
        {
            var depo = (from a in db.TblDepo
                        select new
                        {
                            a.Id,
                            Depo_Adı = a.DepoAdi
                        }).ToList();

            lookdepo.Properties.DataSource = depo.ToList();
            lookdepo.Properties.PopulateColumns();
            lookdepo.Properties.Columns["Id"].Visible = false;
        }
        void tedarikciliste()
        {
            var tedarikci = (from a in db.TblCari

                             select new
                             {
                                 a.Id,
                                 Cari = a.CariAdiSoyadi
                             }).ToList();
            looktedarikci.Properties.DataSource = tedarikci.ToList();
            looktedarikci.Properties.PopulateColumns();
            looktedarikci.Properties.Columns["Id"].Visible = false;
        }
        void add()
        {
            try
            {
                TblStok stk = new TblStok();
                stk.StokNo = txtstokno.Text;
                stk.StokAdi = txtstokadi.Text;
                stk.StokMarka = txtmarka.Text;
                stk.StokModel = txtmodel.Text;
                stk.StokMiktar = int.Parse(txtmiktar.Text);
                stk.StokAlisFiyat = decimal.Parse(txtalismiktar.Text);
                stk.StokSatisFiyat = decimal.Parse(txtsatismiktar.Text);
                stk.DepoId = int.Parse(lookdepo.EditValue.ToString());

                stk.KayitEden = GirisEkran.kullanici;
                stk.KayitTarih = DateTime.Today;
                stk.KritikStokDurum = int.Parse(txtkritikstokmiktar.Text);
                stk.AliciCari = int.Parse(looktedarikci.EditValue.ToString());
                stk.Aciklama = memoaciklama.Text;
                db.TblStok.Add(stk);
                db.SaveChanges();
                XtraMessageBox.Show("Ürün Kayıt Edilmiştir ...", "Durum");
                listele();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Hatası", "Durum");
            }

        }
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void StokKartKayit_Load(object sender, EventArgs e)
        {
            lookdepo.Properties.NullText = "Depo Seçimi Yapınız ...";
            looktedarikci.Properties.NullText = "Tedarikçi Seçiniz ...";
            listele();
            depoliste();
            tedarikciliste();
        }
        void delete()
        {

            try
            {
                int id = int.Parse(lblid.Text);
                var deger = db.TblStok.Find(id);
                db.TblStok.Remove(deger);
                db.SaveChanges();
                XtraMessageBox.Show("Kayıt Silindi", "Durum");
                listele();

            }
            catch (Exception)
            {


                XtraMessageBox.Show("Stok Kart ile İlgili Hareket Kaydı Vardır ..", "Hata");

            }

        }
        void güncelle()
        {

            try
            {
                Form1 ff = new Form1();
                int id = int.Parse(lblid.Text);
                var stok = db.TblStok.Find(id);
                // stok.CariTür = int.Parse(lookcaritur.EditValue.ToString());
                stok.StokNo = txtstokno.Text;
                stok.StokAdi = txtstokadi.Text;
                stok.StokMarka = txtmarka.Text;
                stok.StokModel = txtmodel.Text;
                stok.StokMiktar = int.Parse(txtmiktar.Text);
                stok.StokAlisFiyat = decimal.Parse(txtalismiktar.Text);
                stok.StokSatisFiyat = decimal.Parse(txtsatismiktar.Text);
                stok.DepoId = int.Parse(lookdepo.EditValue.ToString());
                stok.KayitEden = GirisEkran.kullanici;
                stok.KayitTarih = DateTime.Today;
                stok.KritikStokDurum = int.Parse(txtkritikstokmiktar.Text);
                stok.AliciCari = int.Parse(looktedarikci.EditValue.ToString());
                stok.Aciklama = memoaciklama.Text;



                db.SaveChanges();
                XtraMessageBox.Show("Güncellendi", "Durum");
                listele();
                lblid.Text = "";
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Hatası .... ", "Hata");
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lblid.Text == "")
            {
                add();

            }
            else
            {
                güncelle();
            }

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {

            listele();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            add();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
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
    }
}
