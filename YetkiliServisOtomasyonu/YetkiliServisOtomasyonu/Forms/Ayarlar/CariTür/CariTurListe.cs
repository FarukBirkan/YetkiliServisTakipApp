using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YetkiliServisOtomasyonu.Forms.Ayarlar.CariTür
{
    public partial class CariTurListe : Form
    {
        public CariTurListe()
        {
            InitializeComponent();
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void listele()
        {
            var liste = (from a in db.TblCariTür
                         select new
                         {
                             Cari_Tür_Adı = a.CariTürAdi,
                             Cari_Tür_Açıklama = a.CariTürAciklama,
                             Açıklama = a.Aciklama
                         }).ToList();
            gridControl1.DataSource = liste.ToList();
        }
        private void CariTurListe_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
