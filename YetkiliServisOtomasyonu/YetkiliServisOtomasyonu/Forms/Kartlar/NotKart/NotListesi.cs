using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YetkiliServisOtomasyonu.Forms.Kartlar.NotKart
{
    public partial class NotListesi : Form
    {
        public NotListesi()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        public static int id;
        public static string NotBaslik;
        public static string NotIcerik;
        public static DateTime NotTarih;
        public static bool durum;

        void notliste()
        {
            var liste = (from a in db.TblNotlar
                         select new
                         {
                             a.Id,
                             Başlık = a.NotBaslik,
                             İçerik = a.Noticerik,
                             Tarih = a.NotTarih,
                             Durum = a.NotDurum,
                             a.KayitEden,
                             a.KayitTarih
                         }
                         ).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
            gridView1.Columns["KayitEden"].Visible = false;
            gridView1.Columns["KayitTarih"].Visible = false;
        }
        private void NotListesi_Load(object sender, EventArgs e)
        {
            notliste();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            NotBaslik = (gridView1.GetFocusedRowCellValue("Başlık").ToString());
            NotIcerik = (gridView1.GetFocusedRowCellValue("İçerik").ToString());
            NotTarih = DateTime.Parse(gridView1.GetFocusedRowCellValue("Tarih").ToString());
            durum =bool.Parse(gridView1.GetFocusedRowCellValue("Durum").ToString());

            Forms.Kartlar.NotKart.NotKayit nk = new NotKayit();
            nk.lblid.Text = id.ToString();
            nk.txtnotbaslik.Text = NotBaslik;
            nk.memoicerik.Text = NotIcerik;
            nk.nottarih.EditValue = NotTarih;
            nk.checkBox1.Checked = durum;

            nk.MdiParent = this.MdiParent;
            nk.Show();

        }
    }
}
