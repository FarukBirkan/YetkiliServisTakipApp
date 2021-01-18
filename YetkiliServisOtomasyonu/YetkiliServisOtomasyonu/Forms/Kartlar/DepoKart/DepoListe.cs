using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YetkiliServisOtomasyonu.Forms.Kartlar.DepoKart
{
    public partial class DepoListe : Form
    {
        public DepoListe()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        public static int id;
        public static string kod;
        public static string adi;
        public static string adres;
        public static string tel;
        public static string aciklama;
        void depoliste()
        {
            var liste = (from a in db.TblDepo
                         select new
                         { 
                             a.Id,
                          Kod=   a.DepoKod,
                          Depo=   a.DepoAdi,
                          Adres=   a.DepoAdres,
                           Telefon=  a.DepoTel,
                           Açıklama=  a.Aciklama,
                           KayıtEden=  a.KayitEden,
                           KayıtTarih=  a.KayitTarih,
                             
                         }).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
            gridView1.Columns["KayıtEden"].Visible = false;
            gridView1.Columns["KayıtTarih"].Visible = false;
        }
        private void DepoListe_Load(object sender, EventArgs e)
        {
            depoliste();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            kod=(gridView1.GetFocusedRowCellValue("Kod").ToString());
            adi = (gridView1.GetFocusedRowCellValue("Depo").ToString());
            adres = (gridView1.GetFocusedRowCellValue("Adres").ToString());
            tel = (gridView1.GetFocusedRowCellValue("Telefon").ToString());
            aciklama = (gridView1.GetFocusedRowCellValue("Açıklama").ToString());

            Forms.Kartlar.DepoKart.DepoKartKayit dkk = new DepoKartKayit();
            dkk.lblid.Text = id.ToString();
            dkk.txtdepoKod.Text = kod;
            dkk.txtdepoadi.Text = adi;
            dkk.memoadres.Text = adres;
            dkk.txttelefon.Text = tel;
            dkk.memoaciklama.Text = aciklama;

            dkk.MdiParent = this.MdiParent;
            dkk.Show();
        }
    }
}
