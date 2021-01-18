using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YetkiliServisOtomasyonu
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            AnaEkran aa = new AnaEkran();
            aa.MdiParent = this;
            aa.Show();

            if (barStaticItem4.Caption == "True")
            {
                ribbonPage2.Visible = true;
                ribbonPage3.Visible = true;
                ribbonPage4.Visible = true;
            }
            else
            {
                ribbonPage2.Visible = false;
                ribbonPage3.Visible = false;
                ribbonPage4.Visible = false;
            }

            //txtkullanici.Caption = barStaticItem3.Caption;
            //barStaticItem3.Caption = txtkullanici.Caption;

            tarihsaat.Caption = DateTime.Now.ToLongDateString();

        }

        private void barButtonItem71_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Ayarlar.Departman.DepartmanListe dl = new Forms.Ayarlar.Departman.DepartmanListe();
            dl.MdiParent = this;
            dl.Show();
        }

        private void barButtonItem72_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Ayarlar.Departman.DepartmanKayıt de = new Forms.Ayarlar.Departman.DepartmanKayıt();
            de.ShowDialog();

        }

        private void barButtonItem73_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Ayarlar.Departman.DepartmanDüzenle dd = new Forms.Ayarlar.Departman.DepartmanDüzenle();
            dd.ShowDialog();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Ayarlar.Kullanıcı.KullaniciKayit kk = new Forms.Ayarlar.Kullanıcı.KullaniciKayit();
            kk.ShowDialog();
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Ayarlar.Kullanıcı.KullaniciDüzenle kd = new Forms.Ayarlar.Kullanıcı.KullaniciDüzenle();
            kd.ShowDialog();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Ayarlar.Kullanıcı.KullaniciListe kl = new Forms.Ayarlar.Kullanıcı.KullaniciListe();
            kl.MdiParent = this;
            kl.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem79_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Ayarlar.CariTür.CariTurListe ctl = new Forms.Ayarlar.CariTür.CariTurListe();
            ctl.MdiParent = this;
            ctl.Show();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Kartlar.CariKartKayıt ckk = new Forms.Kartlar.CariKartKayıt();
            ckk.MdiParent = this;
            ckk.Show();
        }

        private void barButtonItem80_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Ayarlar.CariTür.CariTürKayit ck = new Forms.Ayarlar.CariTür.CariTürKayit();
            ck.ShowDialog();
        }

        private void barButtonItem81_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Ayarlar.CariTür.CariTurDuzenle cd = new Forms.Ayarlar.CariTür.CariTurDuzenle();
            cd.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Kartlar.CariKartListe cl = new Forms.Kartlar.CariKartListe();
            cl.MdiParent = this;
            cl.Show();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Kartlar.DepoKart.DepoKartKayit dk = new Forms.Kartlar.DepoKart.DepoKartKayit();
            dk.MdiParent = this;
            dk.Show();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Kartlar.StokKart.StokKartKayit skk = new Forms.Kartlar.StokKart.StokKartKayit();
            skk.MdiParent = this;
            skk.Show();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Kartlar.StokKart.StokListe sl = new Forms.Kartlar.StokKart.StokListe();
            sl.MdiParent = this;
            sl.Show();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Kartlar.ServisKart.ServisKayit srv = new Forms.Kartlar.ServisKart.ServisKayit();
            srv.MdiParent = this;
            srv.Show();
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Kartlar.KasaKart.KasaKartKayit kk = new Forms.Kartlar.KasaKart.KasaKartKayit();
            kk.MdiParent = this;
            kk.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Kartlar.ServisKart.ServisListe sl = new Forms.Kartlar.ServisKart.ServisListe();
            sl.MdiParent = this;
            sl.Show();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Kartlar.Veresiye.VeresiyeListesi vl = new Forms.Kartlar.Veresiye.VeresiyeListesi();
            vl.MdiParent = this;
            vl.Show();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Kartlar.VeresiyeKart.VeresiyeKayit vk = new Forms.Kartlar.VeresiyeKart.VeresiyeKayit();
            vk.MdiParent = this; vk.Show();
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Kartlar.KasaKart.KasaListe kl = new Forms.Kartlar.KasaKart.KasaListe();
            kl.MdiParent = this; kl.Show();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Kartlar.DepoKart.DepoListe dl = new Forms.Kartlar.DepoKart.DepoListe();
            dl.MdiParent = this;
            dl.Show();
        }

        private void barButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Kartlar.NotKart.NotListesi nl = new Forms.Kartlar.NotKart.NotListesi();
            nl.MdiParent = this;
            nl.Show();
        }

        private void barButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Kartlar.NotKart.NotKayit nk = new Forms.Kartlar.NotKart.NotKayit();
            nk.MdiParent = this;
            nk.Show();
        }

        private void barButtonItem46_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Raporlar.StokListe sl = new Forms.Raporlar.StokListe();
            sl.MdiParent = this;
            sl.Show();
        }

        private void barButtonItem47_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Raporlar.KritikStokListe kl = new Forms.Raporlar.KritikStokListe();
            kl.MdiParent = this;
            kl.Show();
        }

        private void barButtonItem48_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Raporlar.VeresiyeRaporListesi vrl = new Forms.Raporlar.VeresiyeRaporListesi();
            vrl.MdiParent = this;
            vrl.Show();
        }

        private void barButtonItem65_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Raporlar.GünlükServisPlanRaporu gspr = new Forms.Raporlar.GünlükServisPlanRaporu();
            gspr.MdiParent = this;
            gspr.Show();

        }

        private void barButtonItem50_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Raporlar.ServisPlanlamaListesi spl = new Forms.Raporlar.ServisPlanlamaListesi();
            spl.MdiParent = this;
            spl.Show();
        }

        private void barButtonItem64_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Raporlar.KaraListe kl = new Forms.Raporlar.KaraListe();
            kl.MdiParent = this;
            kl.Show();

        }

        private void barButtonItem84_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Raporlar.Günlük_Notlar nt = new Forms.Raporlar.Günlük_Notlar();
            nt.MdiParent = this;
            nt.Show();
        }

        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Raporlar.KasaGirisRapor KR = new Forms.Raporlar.KasaGirisRapor();

            KR.MdiParent = this;KR.Show();
        }

        private void barButtonItem82_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.GirisCikis.ÜrünSatis us = new Forms.GirisCikis.ÜrünSatis();
            us.MdiParent = this;
            us.Show();

        }

        private void barButtonItem89_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.GirisCikis.UrunAlis ua = new Forms.GirisCikis.UrunAlis();
            ua.MdiParent = this;
            ua.Show();
        }

        private void barButtonItem91_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Raporlar.KasaCikisRapor KC = new Forms.Raporlar.KasaCikisRapor();
            KC.MdiParent = this;
            KC.Show();

        }

        private void barButtonItem92_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.GirisCikis.GiderEkle ge = new Forms.GirisCikis.GiderEkle();
            ge.MdiParent = this;
            ge.Show();

        }

        private void barButtonItem94_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.GirisCikis.GelirEkle ge = new Forms.GirisCikis.GelirEkle();
            ge.MdiParent = this;
            ge.Show();

        }

        private void barButtonItem51_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Forms.Raporlar.KasaRapor kr = new Forms.Raporlar.KasaRapor();
            kr.MdiParent = this;
            kr.Show();

        }

        private void barButtonItem95_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AnaEkran aa = new AnaEkran();
            aa.MdiParent = this;
            aa.Show();

        }

        private void barButtonItem76_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();

            GirisEkran ge = new GirisEkran();
            ge.ShowDialog();
        }
    }
}
