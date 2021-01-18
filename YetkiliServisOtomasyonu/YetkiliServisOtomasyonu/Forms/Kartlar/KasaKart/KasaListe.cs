using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YetkiliServisOtomasyonu.Forms.Kartlar.KasaKart
{
    public partial class KasaListe : Form
    {
        public KasaListe()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        public static int id;
        public static string adi;
        public static string Adres;
        public static string Aciklama;
        
        void kasaliste()
        {
            var liste = (from a in db.TblKasa
                         select new
                         {
                             a.Id,
                          Kasa_Adı=   a.KasaAdi,
                           Adres=  a.KasaAdres,
                          Açıklama=   a.Aciklama,
                             a.KayitEden,
                             a.KayitTarih,
                             
                         }).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
            gridView1.Columns["KayitEden"].Visible = false;
            gridView1.Columns["KayitTarih"].Visible = false;
           // gridView1.Columns[""].Visible = false;
                }
        private void KasaListe_Load(object sender, EventArgs e)
        {
            kasaliste();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            id =int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            adi =(gridView1.GetFocusedRowCellValue("Kasa_Adı").ToString());
            Adres =(gridView1.GetFocusedRowCellValue("Adres").ToString());
            Aciklama =(gridView1.GetFocusedRowCellValue("Açıklama").ToString());


            Forms.Kartlar.KasaKart.KasaKartKayit kkk = new KasaKartKayit();

            kkk.lblid.Text =(id.ToString());
            kkk.txtkasaadi.Text = adi;
            kkk.memoadres.Text = Adres;
            kkk.memoaciklama.Text = Aciklama;
            kkk.MdiParent = this.MdiParent;
            kkk.Show();
        }
    }
}
