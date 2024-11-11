using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_4_714230047
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Laki-Laki");
            comboBox1.Items.Add("Perempuan");

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validasi RadioButton (Pilihan Jadwal)
            if (!(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked))
            {
                MessageBox.Show("Harus memilih salah satu pilihan jadwal", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validasi CheckBox (Pilihan Kelas)
            if (!(checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked ||
                  checkBox5.Checked || checkBox6.Checked || checkBox7.Checked || checkBox8.Checked))
            {
                MessageBox.Show("Harus memilih salah satu pilihan kelas", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mengambil data dari komponen
            string nama = textBox1.Text;
            string jenisKelamin = comboBox1.SelectedItem?.ToString() ?? "Tidak diisi";

            // Mengambil jadwal dari setiap RadioButton yang dipilih di groupBox2
            string jadwal = radioButton1.Checked ? radioButton1.Text :
                            radioButton2.Checked ? radioButton2.Text :
                            radioButton3.Checked ? radioButton3.Text :
                            radioButton4.Text;

            // Mengambil kelas dari setiap CheckBox yang dipilih di groupBox1
            string kelas = "";
            foreach (Control ctrl in groupBox1.Controls) // Mengambil dari groupBox1 untuk kelas
            {
                if (ctrl is CheckBox cb && cb.Checked)
                {
                    kelas += cb.Text + ", ";
                }
            }
            kelas = kelas.TrimEnd(',', ' '); // Menghapus koma di akhir teks

            string tanggalLahir = dateTimePicker1.Value.ToString("dd-MM-yyyy");

            // Tampilkan hasil pada MessageBox dengan ikon tanda seru biru
            MessageBox.Show($"Nama: {nama}\nJenis Kelamin: {jenisKelamin}\nTanggal Lahir: {tanggalLahir}\n" +
                            $"Pilihan Kelas: {kelas}\nPilihan Jadwal: {jadwal}",
                            "Informasi Pendaftaran", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
