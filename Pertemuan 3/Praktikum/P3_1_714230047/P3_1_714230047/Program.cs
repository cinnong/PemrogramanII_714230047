using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P3_1_714230047
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                Console.Write("MENENTUKAN INDEKS PRESTASI MAHASISWA\n..... ");
                Console.Write("\nMasukkan Nama Mahasiswa: ");


                String nama = Console.ReadLine();

                Console.WriteLine("Masukkan Nilai: ");

                int nilai = Convert.ToInt16(Console.ReadLine());

                String[] grade = { "A", "B", "C", "D" };

                if (nilai >= 85)
                {
                    Console.WriteLine("Indeks nilai {0} adalah {1}", nama, grade[0]);
                }
                else if (nilai >= 70 && nilai < 85)
                {
                    Console.WriteLine("Indeks nilai {0} adalah {1}", nama, grade[1]);
                }
                else if (nilai >= 60 && nilai < 70)
                {
                    Console.WriteLine("Indeks nilai {0} adalah {1}", nama, grade[2]);
                }
                else
                {
                    Console.WriteLine("indeks nilai {0} adalah {1}", nama, grade[3]);
                }
                Console.WriteLine("\nMasukkan Indeks yang ditampilkan: ");
                char Indeks = Convert.ToChar(Console.ReadLine());
                Console.Write("Indeks prestasi (0) adalah", nama);

                prestasi(Indeks);

                Console.Write("\ningin mengulang kembali (Y/T)? ");
            }
            while (Console.ReadLine() == "Y");
        }
        private static void prestasi(char indeks)
        {
            switch (indeks)
            {
                case 'A':

                    Console.WriteLine("sangat baik");

                    break;

                case 'B':

                    Console.WriteLine("baik");

                    break;

                    Console.WriteLine("cukup");

                case 'C':

                    break;

                case 'D':

                    Console.WriteLine("buruk");

                    break;

            }

        }

    }
}
