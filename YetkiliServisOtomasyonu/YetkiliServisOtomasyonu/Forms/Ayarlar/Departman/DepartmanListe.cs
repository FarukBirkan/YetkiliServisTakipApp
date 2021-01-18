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

namespace YetkiliServisOtomasyonu.Forms.Ayarlar.Departman
{
    public partial class DepartmanListe : DevExpress.XtraEditors.XtraForm
    {
        public DepartmanListe()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void listele()
        {
            var liste = (from a in db.TblDepartman
                         select new
                         {
                             a.Id,
                            Departman_Adı = a.DepartmanAdi,
                            Açıklama= a.Aciklama,
                            Kayıt_Eden= a.KayitEden,
                            Kayıt_Tarihi= a.KayitTarih
                         }).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
            gridView1.Columns["Kayıt_Eden"].Visible = false;
            gridView1.Columns["Kayıt_Tarihi"].Visible = false;
        }
        private void DepartmanListe_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}