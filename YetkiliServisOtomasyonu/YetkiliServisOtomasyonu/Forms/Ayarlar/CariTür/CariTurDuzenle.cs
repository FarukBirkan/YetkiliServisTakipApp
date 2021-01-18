using DevExpress.XtraEditors;
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
    public partial class CariTurDuzenle : Form
    {
        public CariTurDuzenle()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void listele()
        {
            var liste = (from a in db.TblCariTür
                         select new
                         {
                             a.Id,
                          Cari_Tür_Adı=   a.CariTürAdi,
                           Cari_Tür_Açıklama=  a.CariTürAciklama,
                         Açıklama=    a.Aciklama,
                             a.KayitEden,
                             a.KayitTarih
                         }).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
        }
        private void CariTurDuzenle_Load(object sender, EventArgs e)
        {
            listele();

        }
        void refresh()
        {
            try
            {
                Form1 ff = new Form1();
                int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                var ct = db.TblCariTür.Find(id);

                ct.CariTürAdi = txtcaritüradi.Text;
                ct.CariTürAciklama = txtcaritüraciklama.Text;
                ct.Aciklama = memoaciklama.Text;
                ct.KayitEden =GirisEkran.kullanici;
                ct.KayitTarih = DateTime.Today;

                db.SaveChanges();
                XtraMessageBox.Show("Güncellendi", "Durum");
                listele();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Hatası !!!" ,"Hata");
            }
        }
        void delete()
        {
            try
            {
                int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                var deger = db.TblCariTür.Find(id);
                db.TblCariTür.Remove(deger);
                db.SaveChanges();
                XtraMessageBox.Show("Kayıt Silindi", "Durum");
                listele();

            }
            catch (Exception)
            {
                XtraMessageBox.Show("Veri Hatası !!!", "Hata");

            }
          
        }
        void clear()
        {
            txtcaritüradi.Text = "";
            txtcaritüraciklama.Text = "";
            memoaciklama.Text = "";

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            refresh();
            clear();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = XtraMessageBox.Show("Veri Silinsin mi ?", "Durum", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                delete();
                clear();
            }
            else
            {
                listele();
                clear();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            txtcaritüradi.Text = gridView1.GetFocusedRowCellValue("Cari_Tür_Adı").ToString();
            txtcaritüraciklama.Text = gridView1.GetFocusedRowCellValue("Cari_Tür_Açıklama").ToString();
            memoaciklama.Text = gridView1.GetFocusedRowCellValue("Açıklama").ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
