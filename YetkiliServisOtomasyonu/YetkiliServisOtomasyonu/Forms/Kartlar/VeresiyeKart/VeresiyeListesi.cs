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
    public partial class VeresiyeListesi : Form
    {
        public VeresiyeListesi()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        public static int id;
        public static string VeresiyeKod;
        public static int cari;
        public static int stok;
        public static int stokmiktar;
        public static decimal VeresiyeTutar;
        public static DateTime VeresiyeTarih;
        public static DateTime OdemeTarih;
        public static decimal OdenecekTutar;
        public static string KayitEden;
        public static DateTime  KayitTarih;
        public static string Aciklama;
        public static int UrunMiktari;

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
        private void VeresiyeListesi_Load(object sender, EventArgs e)
        {
            veresiyeliste();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            VeresiyeKod = gridView1.GetFocusedRowCellValue("VeresiyeKod").ToString();
            cari =int.Parse(gridView1.GetFocusedRowCellValue("CariId").ToString());
            stok =int.Parse(gridView1.GetFocusedRowCellValue("StokId").ToString());
            VeresiyeTutar=decimal.Parse(gridView1.GetFocusedRowCellValue("VeresiyeTutar").ToString());
            VeresiyeTarih=DateTime.Parse(gridView1.GetFocusedRowCellValue("VeresiyeTarih").ToString());
            OdemeTarih = DateTime.Parse(gridView1.GetFocusedRowCellValue("OdemeTarih").ToString());
            OdenecekTutar = decimal.Parse(gridView1.GetFocusedRowCellValue("OdenecekTutar").ToString());
            KayitEden = gridView1.GetFocusedRowCellValue("KayitEden").ToString();
            KayitTarih =DateTime.Parse(gridView1.GetFocusedRowCellValue("KayitTarih").ToString());
            Aciklama =(gridView1.GetFocusedRowCellValue("Aciklama").ToString());
            stokmiktar = int.Parse(gridView1.GetFocusedRowCellValue("StokMiktar").ToString());
            UrunMiktari = int.Parse(gridView1.GetFocusedRowCellValue("UrunMiktari").ToString());
            Forms.Kartlar.VeresiyeKart.VeresiyeTahsilat vt = new VeresiyeTahsilat();

            vt.lblid.Text = id.ToString();
            vt.txtveresiyekod.Text = VeresiyeKod;
            vt.lookcari.EditValue = cari;
          
            vt.lookUpEdit1.EditValue = stok;
            vt.txtveresiyetutar.Text =(VeresiyeTutar.ToString());
            vt.txtodemetarih.Text = VeresiyeTarih.ToString();
            vt.txtödemetutar.Text = OdenecekTutar.ToString();
            //vt.lblveresiyetutari = OdenecekTutar.ToString();
            vt.memoaciklama.Text = Aciklama.ToString();
            vt.lblstok.Text = stokmiktar.ToString();
            vt.txtkullanilanmiktar.Text = UrunMiktari.ToString();

            //sk.lblid.Text = id.ToString();
            //sk.txtveresiyekod.Text = VeresiyeKod.ToString();
            //sk.lookcari.EditValue = cari.ToString();
            //sk.txturun.Text = stok.ToString();
            //sk.txtveresiyetutar.Text = VeresiyeTutar.ToString();
            //sk.txtodemetarih.Text = OdemeTarih.ToString();
            //sk.txtödemetutar.Text = OdenecekTutar.ToString();
            //sk.memoaciklama.Text = Aciklama.ToString();
            //sk.lblstok.Text =stokmiktar.ToString();
            //sk.labverilensayi.Text = UrunMiktari.ToString();
            //sk.txtkullanilanmiktar.Text = UrunMiktari.ToString();

            vt.MdiParent = this.MdiParent;
            vt.Show();
        }
    }
}
