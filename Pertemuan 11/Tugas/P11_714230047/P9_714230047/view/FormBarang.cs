using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P9_714230047.controller;
using P9_714230047.model;

namespace P9_714230047.view
{
    public partial class FormBarang : Form
    {
        Koneksi koneksi = new Koneksi();
        M_barang m_barang = new M_barang();
        Barang barang = new Barang();

        public FormBarang()
        {
            InitializeComponent();
        }

        public void Tampil()
        {
            dataBarang.DataSource = koneksi.ShowData("SELECT * FROM t_barang");
            dataBarang.Columns[0].HeaderText = "ID";
            dataBarang.Columns[1].HeaderText = "Nama Barang";
            dataBarang.Columns[2].HeaderText = "Harga";
        }

        private void FormBarang_Load(object sender, EventArgs e)
        {
            Tampil();
        }

        public void Reset()
        {
            textBoxNamaBarang.Text = "";
            textBoxHarga.Text = "";
            textBoxCariData.Text = "";
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNamaBarang.Text) || string.IsNullOrWhiteSpace(textBoxHarga.Text))
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                m_barang.Nama_barang = textBoxNamaBarang.Text;
                m_barang.Harga = textBoxHarga.Text;

                if (barang.Insert(m_barang))
                {
                    Reset();
                    Tampil();
                }
                else
                {
                    MessageBox.Show("Gagal menambahkan data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show(
                "Apakah yakin akan menghapus data ini?",
                "Perhatian",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (pesan == DialogResult.Yes)
            {
                if (barang.Delete(textBoxCariData.Text))
                {
                    Reset();
                    Tampil();
                }
                else
                {
                    MessageBox.Show("Gagal menghapus data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBoxNamaBarang.Text = dataBarang.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBoxHarga.Text = dataBarang.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBoxCariData.Text = dataBarang.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNamaBarang.Text) || string.IsNullOrWhiteSpace(textBoxHarga.Text))
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                m_barang.Nama_barang = textBoxNamaBarang.Text;
                m_barang.Harga = textBoxHarga.Text;

                if (barang.Update(m_barang, textBoxCariData.Text))
                {
                    Reset();
                    Tampil();
                }
                else
                {
                    MessageBox.Show("Gagal mengubah data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCariData_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM t_barang WHERE id_barang LIKE '%" + textBoxCariData.Text + "%' OR nama_barang LIKE '%" + textBoxCariData.Text + "%'";
            dataBarang.DataSource = koneksi.ShowData(query);
        }
    }
}
