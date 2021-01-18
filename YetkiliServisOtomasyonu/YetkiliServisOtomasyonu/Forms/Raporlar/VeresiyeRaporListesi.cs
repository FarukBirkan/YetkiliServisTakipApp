using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YetkiliServisOtomasyonu.Forms.Raporlar
{
    public partial class VeresiyeRaporListesi : Form
    {
        public VeresiyeRaporListesi()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void veresiyeliste()
        {
            var liste = (from a in db.TblVeresiyeDurum
                         select new
                         {
                             a.TblVeresiye.TblCari.CariAdiSoyadi,
                             a.TblVeresiye.TblStok.StokAdi,
                             a.TblVeresiye.VeresiyeTutar,
                             a.OdemeTutar,
                             a.KalanTutar,
                             a.TblVeresiye.VeresiyeTarih,
                             a.OdemeTarih

                         }).ToList();
            gridControl1.DataSource = liste.ToList();
        }
        //void cariliste()
        //{
        //    var liste = (from a in db.TblCari
        //                 select new
        //                 {
        //                     AdSoyad = a.CariAdiSoyadi,
        //                     a.Id
        //                 }).ToList();
        //    lookUpEdit1.Properties.DataSource = liste.ToList();
        //    lookUpEdit1.Properties.PopulateColumns();
        //    lookUpEdit1.Properties.Columns["Id"].Visible = false;
        //}
        private void VeresiyeRaporListesi_Load(object sender, EventArgs e)
        {
         //   cariliste();
            veresiyeliste();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

        }
    }
}
