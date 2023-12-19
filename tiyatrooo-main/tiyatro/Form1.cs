using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tiyatro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        tiyatroo tiyatrolar;

        List<tiyatroo> oyunListesi=new List<tiyatroo>();




        private void Form1_Load(object sender, EventArgs e)
        {
            oyunListesi.Add(new tiyatroo(1, "Yılbaşı Tiyatro Gecesi", new DateTime(2023, 12,23), 60, "Adt Sahne", false, 575.00));
            oyunListesi.Add(new tiyatroo(2, "Cırcır Böcekleri İtler ve Biz", new DateTime(2023, 12, 23), 75, "Fişekhane Ana Sahnesi", false, 500.00));
            dgvListele.DataSource = oyunListesi.ToList();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string oyunAdi =cmbAd .Text;
            DateTime tarih =dtpTarih .Value;
            decimal sure = nudSure.Value;
            string sahne = cmbSahne.Text;
            bool muzikal= chkMuzikal.Checked;
            double fiyat =Convert.ToInt32(txtFiyat.Text);

            tiyatroo tiyatrolar = new tiyatroo(id, oyunAdi, tarih, sure , sahne, muzikal, fiyat);

            oyunListesi.Add(tiyatrolar);
            dgvListele.DataSource = oyunListesi.ToList();


        }

        private void dgvListele_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow secilensatir = dgvListele.SelectedRows[0];

            tiyatroo secilenOyun=secilensatir.DataBoundItem as tiyatroo;

            DialogResult result = MessageBox.Show("Seçilen Oyunu silinsin mi?", "Oyunu Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                oyunListesi.Remove(secilenOyun);
            }

            dgvListele.DataSource = oyunListesi.ToList();
        }

        private void dgvListele_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          txtId.Text = dgvListele.CurrentRow.Cells["id"].Value.ToString();
            cmbAd.Text = dgvListele.CurrentRow.Cells["ad"].Value.ToString();
            dtpTarih.Value = (DateTime)dgvListele.CurrentRow.Cells["tarih"].Value;
            nudSure.Value =(decimal) dgvListele.CurrentRow.Cells["sure"].Value;
            cmbSahne.Text = dgvListele.CurrentRow.Cells["sahne"].Value.ToString();
            chkMuzikal.Checked = (bool)dgvListele.CurrentRow.Cells["muzikal"].Value;
            txtFiyat.Text = dgvListele.CurrentRow.Cells["fiyat"].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DataGridViewRow secilenSatir = dgvListele.SelectedRows[0];

             tiyatroo secilenOyun=secilenSatir.DataBoundItem as tiyatroo;

            int id = Convert.ToInt32(txtId.Text);
            string ad = cmbAd.Text;
            DateTime tarih = dtpTarih.Value;
            decimal sure = nudSure.Value;
            string sahne = cmbSahne.Text;
            bool muzikal = chkMuzikal.Checked;
            double fiyat = Convert.ToInt32(txtFiyat.Text);


            secilenOyun.Id = id;
            secilenOyun.Ad = ad;
            secilenOyun.Tarih = tarih;
            secilenOyun.Sure = sure;
            secilenOyun.Sahne = sahne;
            secilenOyun.Muzikal = muzikal;
            secilenOyun.Fiyat= fiyat;

            dgvListele.DataSource = null;
            dgvListele.DataSource = oyunListesi.ToList();
        }
    }
}
