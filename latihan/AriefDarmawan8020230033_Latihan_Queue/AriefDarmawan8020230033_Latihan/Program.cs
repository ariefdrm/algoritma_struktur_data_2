using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriefDarmawan8020230033_Latihan
{
    internal class Program
    {
        static void Header()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("*  PROGRAM LAYANAN PENGAMBILAN OBAT *");
            Console.WriteLine("*           PADA RS. ABC            *");
            Console.WriteLine("*                                   *");
            Console.WriteLine("-------------------------------------");
        }

        static void TambahAntrian(ArrayList nama, ArrayList obat)
        {
            Console.Clear();

            Console.Write("Masukkan nama : ");
            string Nama = Console.ReadLine();
            Console.Write("Masukkan obat : ");
            string Obat = Console.ReadLine();

            nama.Add(Nama);
            obat.Add(Obat);
        }
        
        static void PanggilAntrian(ArrayList nama, ArrayList obat)
        {
            if (nama.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Nama : {0}", nama[0]);
                nama.RemoveAt(0);
                obat.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("Antrian masih kosong, silahkan tambahkan antrian terlebih dahulu");
            }
        }

        static void DaftarAntrian(ArrayList nama, ArrayList obat)
        {
            int no = 1;
            if (nama.Count > 0)
            {
                for (int i = 0; i < nama.Count; i++)
                {
                    Console.WriteLine("Antrian {0}", no++);
                    Console.WriteLine("Nama : {0}", nama[i]);
                    Console.WriteLine("Obat : {0}", obat[i]);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Antrian Kosong");
            }
        }

        static void KosongkanAntrian(ArrayList nama, ArrayList obat)
        {
            if (nama.Count > 0 && obat.Count > 0)
            {
                nama.Clear();
                obat.Clear();
            }
            else
            {
                Console.WriteLine("Antrian masih kosong, silahkan tambahkan antrian terlebih dahulu");
            }
        }

        static void Exit()
        {
            Environment.Exit(0);
        }
        static void Main(string[] args)
        {
            ArrayList nama = new ArrayList();   
            ArrayList obat = new ArrayList();   

            while (true)
            {
                Header();
                Console.WriteLine("1. Tambah Antrian.\n2. Panggil Antrian.\n3. Daftar Antrian.\n4. Kosongkan antrian.\n5. Exit.\n ");
                Console.Write("Masukkan pilihan : ");
                int pilihan = int.Parse(Console.ReadLine());

                switch (pilihan)
                {
                    case 1:
                          TambahAntrian(nama, obat);
                        break;
                    case 2:
                        PanggilAntrian(nama, obat);
                        break;
                    case 3:
                        DaftarAntrian(nama, obat);
                        break;
                    case 4:
                        KosongkanAntrian(nama, obat);
                        break;
                    case 5:
                        Exit();
                    break;
                }
            }
        }
    }
}
