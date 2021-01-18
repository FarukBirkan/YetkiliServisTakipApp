using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YetkiliServisOtomasyonu.Forms.Raporlar
{
    public partial class KaraListe : Form
    {
        public KaraListe()
        {
            InitializeComponent();
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();

        void liste()
        {
            var kara = (from a in db.TblCari
                        where (a.CariDurum == true)
                        select new
                        {
                            a.TblCariTür.CariTürAdi,
                            a.CariAdiSoyadi,
                            a.CariTelefon,
                            a.CariAdres,a.CariMailAdres,
                          
                        }).ToList();
            gridControl1.DataSource = kara.ToList();

        }
        private void KaraListe_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string path = "KaraListesi.pdf";
            gridControl1.ExportToPdf(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string path = "KaraListesi.txt";
            gridControl1.ExportToText(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string path = "KaraListesi.xlsx";
            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }
    }
}
