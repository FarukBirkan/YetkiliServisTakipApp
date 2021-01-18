using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YetkiliServisOtomasyonu.Forms.Kartlar.ServisKart
{
    public partial class ServisListe : Form
    {
        public ServisListe()
        {
            InitializeComponent();
        }
        public static int id;
        public static string Cari;
        public static string ServisTarih;
        public static string ServisSaat;
        public static string aciklama;
        public static string servisaciklama;
        public static bool servisdurum;
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void liste()
        {
            var liste = (from a in db.TblServisler
                         orderby a.ServisTarihi ascending
                         orderby a.TalepSaat ascending
                         select new
                         {
                             a.Id,
                             a.TblCari.CariAdiSoyadi,
                             a.CariId,
                             Servis_Tarihi = a.ServisTarihi,
                             a.TalepSaat,
                             Açıklama = a.Aciklama,
                             Servis_Açıklama = a.ServisAciklama
                            ,
                             a.KayitEden,
                             a.KayitTarih,
                             a.ServisDurum
                         }).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["CariId"].Visible = false;
            gridView1.Columns["KayitEden"].Visible = false;
            gridView1.Columns["KayitTarih"].Visible = false;
            gridView1.Columns["ServisDurum"].Visible = false;
            gridView1.Columns["Id"].Visible = false;
        }
        private void ServisListe_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            Cari = gridView1.GetFocusedRowCellValue("CariId").ToString();
            ServisTarih = gridView1.GetFocusedRowCellValue("Servis_Tarihi").ToString();
            ServisSaat = gridView1.GetFocusedRowCellValue("TalepSaat").ToString();
            servisdurum =bool.Parse(gridView1.GetFocusedRowCellValue("ServisDurum").ToString());
            servisaciklama = gridView1.GetFocusedRowCellValue("Servis_Açıklama").ToString();
           aciklama = gridView1.GetFocusedRowCellValue("Açıklama").ToString();
            
            Forms.Kartlar.ServisKart.ServisKayit sk = new Forms.Kartlar.ServisKart.ServisKayit();

            sk.lblid.Text = id.ToString();
            sk.lookcari.EditValue = Cari.ToString();
            sk.servistarih.EditValue = ServisTarih.ToString();
            sk.timesaat.EditValue = ServisSaat.ToString();
            sk.memoservisaciklama.Text = servisaciklama.ToString();
            sk.memoaciklama.Text = aciklama.ToString();
            sk.checkBox1.Checked =bool.Parse(servisdurum.ToString());
           
            sk.MdiParent = this.MdiParent;
            sk.Show();
        }
    }
}
