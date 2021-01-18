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
    public partial class GiderEkle : Form
    {
        public GiderEkle()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void giderliste()
        {
            var liste = (from a in db.TblKasaCikis
                         where (a.Aciklama.Contains("Gider"))
                         orderby a.KayitTarihi ascending
                         select new
                         {
                             a.Id,
                             Tarih= a.KayitTarihi,
                             a.ToplamTutar,
                           Gider_Tür =   a.Aciklama,
                         }).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
        }
        void add()
        {
            try
            {
               // tutarhesapla();
                TblKasaCikis kg = new TblKasaCikis();
             //   kg.CariId = int.Parse(lookUpEdit1.EditValue.ToString());
             //   kg.StokId = int.Parse(gridView2.GetFocusedRowCellValue("Id").ToString());
            //    kg.Miktar = int.Parse(txtmiktar.Text);
            //    kg.BirimTutar = decimal.Parse(txtbirimtutar.Text);
                kg.ToplamTutar = decimal.Parse(textEdit1.Text);
                kg.Aciklama = "Gider  "+memoEdit1.Text;
                kg.KayitEden = GirisEkran.kullanici;
                kg.KayitTarihi = DateTime.Today;
                db.TblKasaCikis.Add(kg);
                db.SaveChanges();
                XtraMessageBox.Show("Gider Eklenmiştir ... ", "Durum");
                giderliste();



                //int id = int.Parse(gridView2.GetFocusedRowCellValue("Id").ToString());



                //var stok = db.TblStok.Find(id);


             //   stok.StokMiktar = int.Parse(lblstok.Text.ToString()) + int.Parse(txtmiktar.Text.ToString());


                db.SaveChanges();
                giderliste();

            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Okuma Hatası ... ", "Durum");
            }
            // XtraMessageBox.Show("Güncellendi", "Durum");

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (memoEdit1.Text=="")
            {
                XtraMessageBox.Show("Açıklama Kısmına Lütfen Gider Türünü Yazınız ....");
            }
            else
            {
                add();
            }
           
        }

        private void GiderEkle_Load(object sender, EventArgs e)
        {
            giderliste();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                var deger = db.TblKasaCikis.Find(id);
                db.TblKasaCikis.Remove(deger);
                db.SaveChanges();
                XtraMessageBox.Show("Kayıt Silindi", "Durum");
                giderliste();

            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Okuma Hatası ...","Durum");
                giderliste();
            }

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
          //  lblid.Text =int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
        }
    }
}
