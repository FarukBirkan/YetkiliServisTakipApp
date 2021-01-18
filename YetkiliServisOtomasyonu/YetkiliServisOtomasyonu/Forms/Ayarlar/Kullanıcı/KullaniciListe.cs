using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace YetkiliServisOtomasyonu.Forms.Ayarlar.Kullanıcı
{
    public partial class KullaniciListe : DevExpress.XtraEditors.XtraForm
    {
        public KullaniciListe()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void listele()
        {
            var liste = (from a in db.TblKullanici
                         select new
                         {
                             a.KullanıcıAdi,
                             a.KullaniciMail,
                           //  a.KullaniciSifre,
                             a.KayitTarih,
                             a.Id
                         }).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
           // gridView1.Columns["Id"].Visible = false;
        }
        private void KullaniciListe_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}