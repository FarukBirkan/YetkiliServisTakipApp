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
    public partial class StokListe : Form
    {
        public StokListe()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        public static int id;
        public static string StokNo;
        public static string StokAdi;
        public static string Marka;
        public static string Model;
        public static string Miktar;
        public static string Alisfiyat;
        public static string SatisFiyat;
        public static int DepoId;
        public static string KayitEden;
        public static string KayitTarih;
        public static string KritikStok;
        public static int Satici;
        public static string Açiklama;
        void liste()
        {
            var liste = (from a in db.TblStok
                         select
                         new
                         {
                             a.Id,
                             a.StokNo,
                             Stok_Adı = a.StokAdi,
                             Marka = a.StokMarka,
                             Model = a.StokModel,
                             Stok = a.StokMiktar,

                             Alış_Fiyat = a.StokAlisFiyat,
                             Satış_Fiyat = a.StokSatisFiyat,
                             Depo = a.TblDepo.DepoAdi,
                             a.DepoId,

                             Kayıt_Eden = a.KayitEden,
                             Kayıt_Tarih = a.KayitTarih,
                             Kritik_Stok = a.KritikStokDurum,
                             Tedarikçi = a.TblCari.CariAdiSoyadi,
                             a.AliciCari,
                             Açıklama = a.Aciklama,

                         }).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
            gridView1.Columns["DepoId"].Visible = false;
            gridView1.Columns["Kayıt_Eden"].Visible = false;
            gridView1.Columns["Kayıt_Tarih"].Visible = false;
            gridView1.Columns["AliciCari"].Visible = false;
        }
        private void StokListe_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            StokNo = gridView1.GetFocusedRowCellValue("StokNo").ToString();
            StokAdi = gridView1.GetFocusedRowCellValue("Stok_Adı").ToString();
            Marka = gridView1.GetFocusedRowCellValue("Marka").ToString();
            Model = gridView1.GetFocusedRowCellValue("Model").ToString();
            Miktar = gridView1.GetFocusedRowCellValue("Stok").ToString();
            Alisfiyat = gridView1.GetFocusedRowCellValue("Alış_Fiyat").ToString();
            SatisFiyat = gridView1.GetFocusedRowCellValue("Satış_Fiyat").ToString();
            KritikStok = gridView1.GetFocusedRowCellValue("Kritik_Stok").ToString();
            DepoId = int.Parse(gridView1.GetFocusedRowCellValue("DepoId").ToString());
            KayitEden = (gridView1.GetFocusedRowCellValue("Kayıt_Eden").ToString());
            KayitTarih = (gridView1.GetFocusedRowCellValue("Kayıt_Tarih").ToString());
            Satici = int.Parse(gridView1.GetFocusedRowCellValue("AliciCari").ToString());
            Açiklama =(gridView1.GetFocusedRowCellValue("Açıklama").ToString());
            Forms.Kartlar.StokKart.StokKartKayit sk = new StokKartKayit();
            sk.lblid.Text = id.ToString();
            sk.txtstokno.Text = StokNo.ToString();
            sk.txtstokadi.Text = StokAdi.ToString();
            sk.txtmarka.Text = Marka.ToString();
            sk.txtmodel.Text = Model.ToString();
            sk.txtmiktar.Text = Miktar.ToString();
            sk.txtalismiktar.Text = Alisfiyat.ToString();
            sk.txtsatismiktar.Text = SatisFiyat.ToString();
            sk.lookdepo.EditValue = DepoId.ToString();
            sk.looktedarikci.EditValue = Satici.ToString();
            sk.txtkritikstokmiktar.Text = KritikStok.ToString();
            sk.memoaciklama.Text = Açiklama.ToString();
            sk.MdiParent = this.MdiParent;
            sk.Show();
        }
    }
}
