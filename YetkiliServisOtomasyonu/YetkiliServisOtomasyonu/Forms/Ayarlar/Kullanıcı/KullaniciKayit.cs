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
    public partial class KullaniciKayit : DevExpress.XtraEditors.XtraForm
    {
        public KullaniciKayit()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void departmanliste()
        {
            var liste = (from a in db.TblDepartman
                         select new
                         {
                             a.Id,
                             Departman_Adı = a.DepartmanAdi,

                         }).ToList();
            lookdepartmen.Properties.DataSource = liste.ToList();
            lookdepartmen.Properties.PopulateColumns();
            lookdepartmen.Properties.Columns["Id"].Visible = false;
        }
        void add()
        {
            try
            {
                TblKullanici kk = new TblKullanici();
                kk.KullanıcıAdi = txtkullaniciadi.Text;
                kk.KullaniciSifre = txtkullanicisifre.Text;
                kk.KullaniciMail = txtmailadres.Text;
                kk.KayitTarih = DateTime.Today;
                kk.Aciklama = memoEdit1.Text;
                kk.YetkiDurum = checkEdit1.Checked;
                kk.DepartmanId = int.Parse(lookdepartmen.EditValue.ToString());
                db.TblKullanici.Add(kk);
                db.SaveChanges();
                XtraMessageBox.Show("Kullanıcı Kayıt Edildi ", "Kayıt Durum");
                listele();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Kullanıcı İle İlgili Gerekli Alanları Doldurunuz !!!", "Durum");
            }
        }
        void listele()
        {
            var listele = (from a in db.TblKullanici
                           select new
                           {
                               Kullanıcı_Adı = a.KullanıcıAdi,
                               Mail_Adres = a.KullaniciMail,
                               Departman = a.TblDepartman.DepartmanAdi

                           }).ToList();
            gridControl1.DataSource = listele.ToList();
        }
        private void KullaniciKayit_Load(object sender, EventArgs e)
        {
            listele();
            lookdepartmen.Properties.NullText = "Lütfen Departman Seçiniz !!! ";
            departmanliste();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            txtkullaniciadi.Text = "";
            txtkullanicisifre.Text = "";
            txtmailadres.Text = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtkullaniciadi.Text==""||txtkullanicisifre.Text==""||txtmailadres.Text=="")
            {
                XtraMessageBox.Show("Kullanıcı İle İlgili Gerekli Alanları Doldurunuz !!!","Durum" );
            }
            else
            {
                add();
            }
        
        }
    }
}