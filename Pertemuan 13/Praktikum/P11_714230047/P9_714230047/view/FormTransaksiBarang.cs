﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using P9_714230047.controller;
using P9_714230047.lib;
using P9_714230047.model;

namespace P9_714230047.view
{
    public partial class FormTransaksiBarang : Form
    {
        Koneksi koneksi = new Koneksi();
        M_transaksi_barang m_transaksi_barang = new M_transaksi_barang();
        string id_transaksi;

        public void Tampil()
        {
            dataGridView1.DataSource = koneksi.ShowData("SELECT id_transaksi, t_barang.id_barang, nama_barang, harga, qty, total FROM t_transaksi JOIN t_barang ON t_barang.id_barang = t_transaksi.id_barang");
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "ID Barang";
            dataGridView1.Columns[2].HeaderText = "Nama Barang";
            dataGridView1.Columns[3].HeaderText = "Harga";
            dataGridView1.Columns[4].HeaderText = "Quantity";
            dataGridView1.Columns[5].HeaderText = "Total Harga";
        }
        public FormTransaksiBarang()
        {
            InitializeComponent();
        }

        public void GetDataBarang()
        {
            koneksi.OpenConnection();
            MySqlDataReader reader = koneksi.reader("SELECT * FROM t_barang");
            while (reader.Read())
            {
                int id_barang = reader.GetInt32("id_barang");
                comboBoxIdBarang.Items.Add(id_barang.ToString());
            }
            reader.Close();
            koneksi.CloseConnection();
        }


        public void getNamaBarang()
        {
            koneksi.OpenConnection();
            MySqlDataReader reader = koneksi.reader("SELECT * FROM t_barang WHERE id_barang = '" + comboBoxIdBarang.Text + "'");
            while (reader.Read())
            {
                string nama_barang = reader.GetString("nama_barang");
                textBoxNamaBarang.Text = nama_barang;
            }
            reader.Close();
            koneksi.CloseConnection();
        }

        public void getHargaBarang()
        {
            koneksi.OpenConnection();
            MySqlDataReader reader = koneksi.reader("SELECT * FROM t_barang WHERE id_barang = '" + comboBoxIdBarang.Text + "'");
            while (reader.Read())
            {
                int harga = reader.GetInt32("harga");
                textBoxHargaBarang.Text = harga.ToString();
            }
            reader.Close();
            koneksi.CloseConnection();
        }

        public void getTotal()
        {
            if (int.TryParse(textBoxQty.Text, out int qty) && int.TryParse(textBoxHargaBarang.Text, out int harga))
            {
                int total = qty * harga;
                textBoxTotal.Text = total.ToString();
            }
        }

        private void comboBoxIdBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            getNamaBarang();
            getHargaBarang();
            getTotal();
        }

        private void textBoxQty_TextChanged(object sender, EventArgs e)
        {
            getTotal();
        }

        private void textBoxCariData_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = koneksi.ShowData("SELECT id_transaksi, t_barang.id_barang, nama_barang, harga, qty, total FROM t_transaksi JOIN t_barang ON t_barang.id_barang = t_transaksi.id_barang WHERE id_transaksi LIKE '%" + textBoxCariData.Text + "%' OR t_barang.id_barang LIKE '%" + textBoxCariData.Text + "%' OR nama_barang LIKE '%" + textBoxCariData.Text + "%' OR harga LIKE '%" + textBoxCariData.Text + "%' OR qty LIKE '%" + textBoxCariData.Text + "%' OR total LIKE '%" + textBoxCariData.Text + "%'");
        }

        public void Reset()
        {
            comboBoxIdBarang.SelectedIndex = -1;
            textBoxNamaBarang.Text = "";
            textBoxHargaBarang.Text = "";
            textBoxQty.Text = "";
            textBoxTotal.Text = "";
            textBoxCariData.Text = "";
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (comboBoxIdBarang.SelectedIndex == -1 || textBoxQty.Text == "" || textBoxTotal.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TransaksiBarang transaksi = new TransaksiBarang();
                m_transaksi_barang.Id_barang = comboBoxIdBarang.Text;
                m_transaksi_barang.Qty = textBoxQty.Text;
                m_transaksi_barang.Total = textBoxTotal.Text;
                transaksi.Insert(m_transaksi_barang);
                Reset();
                Tampil();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void FormTransaksiBarang_Load(object sender, EventArgs e)
        {
            Tampil();
            GetDataBarang();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id_transaksi = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBoxIdBarang.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxQty.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (comboBoxIdBarang.SelectedIndex == -1 || textBoxQty.Text == "" || textBoxTotal.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TransaksiBarang transaksi = new TransaksiBarang();
                m_transaksi_barang.Id_barang = comboBoxIdBarang.Text;
                m_transaksi_barang.Qty = textBoxQty.Text;
                m_transaksi_barang.Total = textBoxTotal.Text;
                transaksi.Update(m_transaksi_barang, id_transaksi);
                Reset();
                Tampil();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("Apakah anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pesan == DialogResult.Yes)
            {
                TransaksiBarang transaksi = new TransaksiBarang();
                transaksi.Delete(id_transaksi);
                Reset();
                Tampil();
            }
        }

        private void textBoxTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxIdBarang_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            getNamaBarang();
            getHargaBarang();
            getTotal();
        }

        private void textBoxQty_TextChanged_1(object sender, EventArgs e)
        {
            getTotal();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel Documents (*.xlsx) | *.xlsx";
            save.FileName = "Report Transaksi.xlsx";

            if (save.ShowDialog() == DialogResult.OK)
            {
                string directory = Path.GetDirectoryName(save.FileName);
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(save.FileName);
                string extension = Path.GetExtension(save.FileName);
                int count = 1;
                string filePath = save.FileName;

                while (File.Exists(filePath))
                {
                    filePath = Path.Combine(directory, $"{fileNameWithoutExt} ({count}){extension}");
                    count++;
                }

                Excel excel_lib = new Excel();
                excel_lib.ExportToExcel(dataGridView1, filePath);

                MessageBox.Show("Data berhasil di export ke excel", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
