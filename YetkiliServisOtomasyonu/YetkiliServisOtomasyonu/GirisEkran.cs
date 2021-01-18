using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace YetkiliServisOtomasyonu
{
    public partial class GirisEkran : SplashScreen
    {
        public GirisEkran()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void listele()
        {
            var liste = (from a in db.TblKullanici
                         select new
                         {
                             Kullanıcı_Adı = a.KullanıcıAdi,
                             a.Id
                         }).ToList();
            lookUpEdit1.Properties.DataSource = liste.ToList();
           // lookUpEdit1.Properties.Columns["Id"].Visible = false;
        }

        private void GirisEkran_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.NullText = "Kullanıcı Adı Seçiniz ";
            listele();
            lookUpEdit1.Properties.PopulateColumns();
             lookUpEdit1.Properties.Columns["Id"].Visible = false;

        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
        public static string kullanici;
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            TblKullanici kk = new TblKullanici();
            TblKullanici durum = db.TblKullanici.Where
                (a => a.KullanıcıAdi == lookUpEdit1.Text && a.KullaniciSifre == txtsifre.Text).SingleOrDefault();
           
            if (durum == null)
            {
                XtraMessageBox.Show("KULLANICI ADI / ŞİFRE HATALI ", "HATA");
            }
            else if (durum != null)
            {
                //  RandevuSistem rs = new RandevuSistem();
                // rs.barStaticItem2.Caption = txtkullanici.Text;
              //  Forms.Ayarlar.CariTür.CariTürKayit ctk = new Forms.Ayarlar.CariTür.CariTürKayit();

                Form1 ff = new Form1();
                lbldurum.Text = (durum.YetkiDurum.ToString());
                ff.txtkullanici.Caption = lookUpEdit1.Text;
                kullanici = lookUpEdit1.Text;
               // ActiveForm.Text = lookUpEdit1.Text;
             //   ctk.labelControl5.Text = lookUpEdit1.Text;            
                ff.barStaticItem4.Caption = lbldurum.Text;
                ff.Show();
                this.Hide();
            }

        }
    }
}