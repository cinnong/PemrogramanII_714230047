using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace P6_3_714230047
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SetErrorMessages(TextBox textBox, string warningMessage, string wrongMessage, string correctMessage)
        {
            epWarning.SetError(textBox, warningMessage);
            epWrong.SetError(textBox, wrongMessage);
            epCorrect.SetError(textBox, correctMessage);
        }    
            private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Leave(object sender, EventArgs e)
        {

        }

        private void txtHuruf_Leave(object sender, EventArgs e)
        {
            if (txtHuruf.Text == "")

            {

                SetErrorMessages(txtHuruf, "Textbox Huruf tidak boleh kosong!", "", "");
            }
            else if(txtHuruf.Text.All(Char.IsLetter))
            {
                SetErrorMessages(txtHuruf, "", "", "betul");
            }
            else
            {
                SetErrorMessages(txtHuruf, "", "Inputan hanya boleh huruf!", "");
            }
        }

        private void txtAngka_TextChanged(object sender, EventArgs e)
        {
            if (txtAngka.Text == "")
            {
                SetErrorMessages(txtAngka, "Textbox Angka tidak boleh kosong!", "", "");
            }
            else if (txtAngka.Text.All(Char.IsNumber))
            {
                SetErrorMessages(txtAngka, "", "", "Betul!");
            }
            else
            {
                SetErrorMessages(txtAngka, "", "Inputan hanya boleh angka!", "");
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")

            {
                SetErrorMessages(txtEmail, "Textbox Email tidak boleh kosong!", "", "");
            }
            else if (Regex.IsMatch(txtEmail.Text, @"^^[^@\s]+@[^@\s]+(\.[^@\s]+)+$"))
            {
                SetErrorMessages(txtEmail, "", "", "Betul!");
            }
            else
            {
                SetErrorMessages(txtEmail, "", "Format email salah!\nContoh: alb.c", "");
            }
        }

        private void txtAngka1_Leave(object sender, EventArgs e)
        {
            // Validasi TextBox Angka1 wajib diisi
            if (string.IsNullOrEmpty(txtAngka1.Text))
            {
                SetErrorMessages(txtAngka1, "Textbox Angka1 wajib diisi!", "", "");
            }
            //else
            //{
            //    SetErrorMessages(textAngka1, "", "", "Betul!");
            //}

            // Memeriksa apakah Angka2 sudah terisi saat keluar dari Angka1
            if (string.IsNullOrEmpty(txtAngka2.Text))
            {
                SetErrorMessages(txtAngka2, "Textbox Angka2 juga wajib diisi!", "", "");
            }
        }


        private void txtAngka2_Leave(object sender, EventArgs e)
        {
            {
                // Validasi TextBox Angka2 wajib diisi
                if (string.IsNullOrEmpty(txtAngka2.Text))
                {
                    SetErrorMessages(txtAngka2, "Textbox Angka2 wajib diisi!", "", "");
                }
                else
                {
                    SetErrorMessages(txtAngka2, "", "", "Betul!");
                }

                // Jika Angka2 sudah terisi, lakukan pengecekan pada Angka1
                if (!string.IsNullOrEmpty(txtAngka2.Text))
                {
                    // Memeriksa apakah Angka1 sudah terisi
                    if (string.IsNullOrEmpty(txtAngka1.Text))
                    {
                        SetErrorMessages(txtAngka1, "Textbox Angka1 wajib diisi!", "", "");
                    }
                    else
                    {
                        // Jika Angka1 dan Angka2 terisi, bandingkan nilainya
                        int angka1, angka2;
                        if (int.TryParse(txtAngka1.Text, out angka1) && int.TryParse(txtAngka2.Text, out angka2))
                        {
                            if (angka1 > angka2)
                            {
                                SetErrorMessages(txtAngka1, "", "", "Betul!"); // Tampilkan icon correct pada Angka1 jika Angka1 > Angka2
                            }
                            else
                            {
                                SetErrorMessages(txtAngka1, "", "Angka1 harus lebih besar dari Angka2!", ""); // Tampilkan pesan error jika tidak
                                SetErrorMessages(txtAngka2, "", "Angka1 harus lebih besar dari Angka2!", ""); // Tampilkan pesan error jika tidak
                            }
                        }
                        else
                        {
                            SetErrorMessages(txtAngka1, "", "Input tidak valid!", "");
                            SetErrorMessages(txtAngka2, "", "Input tidak valid!", "");
                        }
                    }
                }
            }
        }

        private void txtAngka1_TextChanged(object sender, EventArgs e)
        {
            if (txtAngka1.Text == "")
            {
                SetErrorMessages(txtAngka1, "Textbox Angka1 tidak boleh kosong!", "", "");
            }
            else if (txtAngka1.Text.All(Char.IsDigit))
            {
                SetErrorMessages(txtAngka1, "", "", "Betul!");
            }
            else
            {
                SetErrorMessages(txtAngka1, "", "Inputan hanya boleh angka!", "");
            }

        }

        private void txtAngka2_TextChanged(object sender, EventArgs e)
        {
            if (txtAngka2.Text == "")
            {
                SetErrorMessages(txtAngka2, "Textbox Angka2 tidak boleh kosong!", "", "");
            }
            else if (txtAngka2.Text.All(Char.IsDigit))
            {
                SetErrorMessages(txtAngka2, "", "", "Betul!");
            }
            else
            {
                SetErrorMessages(txtAngka2, "", "Inputan hanya boleh angka!", "");
            }

        }
    }
}
