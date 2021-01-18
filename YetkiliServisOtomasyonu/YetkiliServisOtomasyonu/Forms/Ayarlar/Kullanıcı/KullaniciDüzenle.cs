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

namespace YetkiliServisOtomasyonu.Forms.Ayarlar.Kullanıcı
{
    public partial class KullaniciDüzenle : Form
    {
        public KullaniciDüzenle()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void Getir()
        {
            try
            {
                txtkullaniciadi.Text = gridView1.GetFocusedRowCellValue("KullanıcıAdi").ToString();
                txtkullanicisifre.Text = gridView1.GetFocusedRowCellValue("KullaniciSifre").ToString();
                txtmailadres.Text = gridView1.GetFocusedRowCellValue("KullaniciMail").ToString();
                memoEdit1.Text = gridView1.GetFocusedRowCellValue("Aciklama").ToString();
                checkEdit1.Checked = bool.Parse(gridView1.GetFocusedRowCellValue("YetkiDurum").ToString());
                lookdepartmen.Text = gridView1.GetFocusedRowCellValue("Departman").ToString();
            }
            catch (Exception)
            {

                
            }
        }
        void Departmanliste()
        {
            var liste = (from a in db.TblDepartman
                         select new
                         {
                             Departman_Adı = a.DepartmanAdi,
                             a.Id,

                         }).ToList();
            lookdepartmen.Properties.DataSource = liste.ToList();
            lookdepartmen.Properties.PopulateColumns();
            lookdepartmen.Properties.Columns["Id"].Visible = false;
        }
        void liste()
        {
            var liste = (from a in db.TblKullanici
                         select new
                         {
                             a.KullanıcıAdi,
                             a.KullaniciSifre,
                             a.Id,
                             a.KullaniciMail,
                             a.YetkiDurum,
                             a.Aciklama,
                             Departman = a.TblDepartman.DepartmanAdi,
                         }).ToList();
            gridControl1.DataSource = liste.ToList();
            gridView1.Columns["Id"].Visible = false;
            gridView1.Columns["KullaniciSifre"].Visible = false;
            gridView1.Columns["YetkiDurum"].Visible = false;
        }
        void delete()
        {
            int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            var deger = db.TblKullanici.Find(id);
            db.TblKullanici.Remove(deger);
            db.SaveChanges();
            XtraMessageBox.Show("Veri Silindi", "Durum");
            liste();

        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void KullaniciDüzenle_Load(object sender, EventArgs e)
        {
            liste();
            Departmanliste();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = XtraMessageBox.Show("Veri Silinsin mi ?", "Durum", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                delete();
                liste();
            }
            else
            {
                //  MessageBox.Show("Randevu Silinmedi", "Durum");
                liste();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtkullaniciadi.Text==""||txtkullanicisifre.Text=="")
                {
                    XtraMessageBox.Show("Kullanıcı İle İlgili Alanları Lütfen Doldurunuz !!!","Durum");
                    liste();
                }
                else
                {
                    int id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
                    var kk = db.TblKullanici.Find(id);

                    kk.KullanıcıAdi = txtkullaniciadi.Text;
                    kk.KullaniciSifre = txtkullanicisifre.Text;
                    kk.KullaniciMail = txtmailadres.Text;
                    kk.KayitTarih = DateTime.Today;
                    kk.YetkiDurum = checkEdit1.Checked;
                    kk.DepartmanId = int.Parse(lookdepartmen.EditValue.ToString());
                    kk.Aciklama = memoEdit1.Text;
                    db.SaveChanges();
                    XtraMessageBox.Show("Veri Güncellendi ", "Durum");
                    temizle();
                    liste();
                }
               
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Veri Güncellemede Hata", "Hata");
            }

        }
        void temizle()
        {
            txtkullaniciadi.Text = ""; txtkullanicisifre.Text = ""; txtmailadres.Text = ""; checkEdit1.Checked = false; memoEdit1.Text = "";

        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Getir();

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
