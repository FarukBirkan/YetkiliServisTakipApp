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
    public partial class DepartmanKayıt : DevExpress.XtraEditors.XtraForm
    {
        public DepartmanKayıt()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void listele()
        {
            var liste = (from a in db.TblDepartman
                         select new
                         {
                             a.Id,
                             Departman_Adı = a.DepartmanAdi,
                             Açıklama = a.Aciklama,
                             Kayıt_Eden = a.KayitEden,
                             Kayıt_Tarihi = a.KayitTarih
                         }).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
            gridView1.Columns["Kayıt_Eden"].Visible = false;
            gridView1.Columns["Kayıt_Tarihi"].Visible = false;
        }
        private void DepartmanKayıt_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtdepartmanadi.Text=="")
            {
                XtraMessageBox.Show("Lütfen Departman Adı Yazınız !!!","Hata");
                listele();

            }
            else if (memoaciklama.Text=="")
            {
                XtraMessageBox.Show("Departman İle İlgili Açıklama Yazınız !!! ","Hata");
                listele();
            }
            else
            {
                Form1 dd = new Form1();
                TblDepartman dpt = new TblDepartman();
                dpt.DepartmanAdi = txtdepartmanadi.Text;
                dpt.Aciklama = memoaciklama.Text;
                dpt.KayitEden = GirisEkran.kullanici;
                dpt.KayitTarih = DateTime.Today;
                db.TblDepartman.Add(dpt);
                db.SaveChanges();
                XtraMessageBox.Show("Departman Kayıt Edilmiştir", "Kayıt Durum");
                listele();
            }
            

        }
    }
}