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
    public partial class Günlük_Notlar : Form
    {
        public Günlük_Notlar()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string path = "KaraListesi.xlsx";
            gridControl1.ExportToXlsx(path);
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string path = "KaraListesi.pdf";
            gridControl1.ExportToXlsx(path);
            // Open the created XLSX file with the default application.
            Process.Start(path);
        }
        DbYetkiliServisEntities db = new DbYetkiliServisEntities();
        void liste()
        {
            var notlar = (from a in db.TblNotlar
                          where (a.NotTarih == DateTime.Today)
                          orderby a.NotTarih ascending

                          select new
                          {
                              a.NotTarih,
                              
                              a.NotBaslik,
                              a.Noticerik,
                              
                          }).ToList();
            gridControl1.DataSource = notlar.ToList();

        }
        private void Günlük_Notlar_Load(object sender, EventArgs e)
        {
            liste();
        }
    }
}
