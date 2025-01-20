using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P9_714230047.model;
using System.Windows.Forms;

namespace P9_714230047.controller
{
    internal class Barang
    {
        Koneksi koneksi = new Koneksi();
        public bool Insert(M_barang barang)
        {
            Boolean status = false;
            try
            {
                koneksi.OpenConnection();
                koneksi.ExecuteQuery("INSERT INTO t_barang (nama_barang, harga) VALUES('" + barang.Nama_barang + "', '" + barang.Harga + "')");
                status = true;
                MessageBox.Show("Data berhasil ditambahkan", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            return status;
        }
        //Method update
        public bool Update(M_barang barang, string id)
        {
            Boolean status = false;
            try
            {
                koneksi.OpenConnection();
                koneksi.ExecuteQuery("UPDATE t_barang SET nama_barang='" + barang.Nama_barang + "'," + "harga='" + barang.Harga + "' WHERE id_barang = '" + id + "'");
                status = true;
                MessageBox.Show("Data berhasil diubah", "Informasi",MessageBoxButtons.OK, MessageBoxIcon.Information);koneksi.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            return status;
        }
        //Method delete
        public bool Delete(string id)
        {
            Boolean status = false;
            try
            {
                koneksi.OpenConnection();
                koneksi.ExecuteQuery("DELETE FROM t_barang WHERE id_barang='" + id + "'");
                status = true;
                MessageBox.Show("Data berhasil dihapus", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            return status;
        }
    }
}
