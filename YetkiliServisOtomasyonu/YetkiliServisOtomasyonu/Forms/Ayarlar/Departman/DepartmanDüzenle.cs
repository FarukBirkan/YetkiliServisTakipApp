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
    public partial class DepartmanDüzenle : DevExpress.XtraEditors.XtraForm
    {
        public DepartmanDüzenle()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void listele()
        {
            var liste = (from a in db.TblDepartman
                         select new
                         {
                             Departman_Adı = a.DepartmanAdi,
                             Açıklama = a.Aciklama,
                             a.Id
                         }).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
        }
        void refresh()
        {
            Form1 ff = new Form1();
            int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            var departman = db.TblDepartman.Find(id);

            departman.DepartmanAdi = txtdepartmanadi.Text;
            departman.Aciklama = memoaciklama.Text;
            departman.KayitEden = GirisEkran.kullanici;
            departman.KayitTarih = DateTime.Today;

            db.SaveChanges();
            XtraMessageBox.Show("Güncellendi", "Durum");
            listele();
        }
        void delete()
        {
            int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            var deger = db.TblDepartman.Find(id);
            db.TblDepartman.Remove(deger);
            db.SaveChanges();
            XtraMessageBox.Show("Kayıt Silindi", "Durum");
            listele();

        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DepartmanDüzenle_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            txtdepartmanadi.Text = gridView1.GetFocusedRowCellValue("Departman_Adı").ToString();
            memoaciklama.Text = gridView1.GetFocusedRowCellValue("Açıklama").ToString();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = XtraMessageBox.Show("Veri Silinsin mi ?", "Durum", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                delete();
                listele();
                txtdepartmanadi.Text = "";
                memoaciklama.Text = "";
            }
            else
            {
                listele();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            txtdepartmanadi.Text = "";
            memoaciklama.Text = "";
        }
    }
}