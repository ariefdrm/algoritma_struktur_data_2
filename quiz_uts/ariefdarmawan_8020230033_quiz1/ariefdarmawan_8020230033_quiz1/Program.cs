using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ariefdarmawan_8020230033_quiz1
{
    internal class Program
    {
        static void header()
        {
            Console.WriteLine("------Program Quiz-------");
        }
        static void tambahData(ArrayList Name, ArrayList Nik, ArrayList JenisKelamin)
        {
            Console.Clear();

            Console.Write("Nama          : ");
            string nama = Console.ReadLine();

            Console.Write("Nik           : ");
            int nik = int.Parse(Console.ReadLine());

            Console.Write("Jenis Kelamin : ");
            string Jk = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nama) && !string.IsNullOrWhiteSpace(Jk))
            {
                Console.Clear();

                try
                {
 
                    Name.Add(nama);
                    Nik.Add(nik);
                    JenisKelamin.Add(Jk);

                    Console.WriteLine("Data berhasil ditambahkan...");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nik: harus berupa angka");
                }
            } else
            {
                Console.WriteLine("Data gagal ditambahkan...");
            }

            Console.ReadKey();
        }

        static void semuaData(ArrayList Name, ArrayList Nik, ArrayList JenisKelamin)
        {
            Console.Clear();
            int a = 0;

            Console.WriteLine("+----+------------------------+-----------+-----------+");
            Console.WriteLine("| No | Nama                   |           |           |");
            Console.WriteLine("+----+------------------------+-----------+-----------+");

            for (int i = 0; i < Name.Count; i++)
            {
                a++;
                Console.WriteLine("| {0,-3}| {1,-23}| {2,-10}| {3,-9} |", a , Name[i], Nik[i], JenisKelamin[i]);
            }
            Console.WriteLine("+----+------------------------+-----------+-----------+");
            Console.WriteLine("[end]");

            Console.ReadKey();

        }
        static void Main(string[] args)
        {
            ArrayList Name = new ArrayList();
            ArrayList Nik = new ArrayList();
            ArrayList JenisKelamin = new ArrayList();

Atas:
            Console.Clear();
            header();
            Console.Write("[1] Tambah data\n[2] Tampil/Semua data\n[3] Exit\nMasukkan pilihan : ");
            int choice = int.Parse(Console.ReadLine());


            switch (choice)
            {
                case 1:
                header();
                tambahData(Name, Nik, JenisKelamin);
                break;
                case 2:
                    header();
                semuaData(Name, Nik, JenisKelamin);
                break;
                case 3:
                Environment.Exit(0);
                break;

            }
            goto Atas;

            Console.ReadKey();
        }
    }
}
