using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriefDarmawan_8020230033
{
    internal class Program
    {
        // Add data
        static void TambahData(ArrayList Nama, ArrayList Nim, ArrayList Jurusan)
        {
            Console.Clear();

            // Input for Nama
            Console.Write("Masukkan nama : ");
            string namaInput = Console.ReadLine();

            // Input for Nim
            Console.Write("Masukkan nim : ");
            string nimInput = Console.ReadLine();

            // Input for Jurusan
            Console.Write("Masukkan jurusan : ");
            string jurusanInput = Console.ReadLine();

            Console.WriteLine();

            // Check if all inputs are valid (not empty or null)
            if (
                !string.IsNullOrWhiteSpace(namaInput)
                && !string.IsNullOrWhiteSpace(nimInput)
                && !string.IsNullOrWhiteSpace(jurusanInput)
            )
            {
                try
                {
                    // Add valid inputs to the ArrayLists
                    Nama.Add(namaInput);
                    Nim.Add(Int64.Parse(nimInput));
                    Jurusan.Add(jurusanInput);

                    // Success message
                    Console.WriteLine("Data berhasil ditambahkan!!!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("NIM harus berupa angka. Data gagal ditambahkan!!!");
                }
            }
            else
            {
                // Failure message
                Console.WriteLine("Data gagal ditambahkan. Harap isi semua kolom!!!");
            }
            Console.Write("Press the Enter key to continue...");

            Console.ReadKey();
        }

        // display data
        static void TampilData(ArrayList Nama, ArrayList Nim, ArrayList Jurusan)
        {
            int a = 1;
            Console.Clear();

            // Header for the table
            Console.WriteLine(
                "+----+------------------------+------------------+----------------------+"
            );
            Console.WriteLine(
                "| No | Nama                   | NIM              | Jurusan              |"
            );
            Console.WriteLine(
                "+----+------------------------+------------------+----------------------+"
            );

            for (int i = 0; i < Nama.Count; i++)
            {
                // Data rows
                Console.WriteLine(
                    "| {0,-2} | {1,-22} | {2,-16} | {3,-20} |",
                    a++,
                    Nama[i],
                    Nim[i],
                    Jurusan[i]
                );
            }
            Console.WriteLine(
                "+----+------------------------+------------------+----------------------+"
            );

            // End message
            Console.WriteLine("[END]");
            Console.Write("Press the Enter key to continue...");
        }

        static void Main(string[] args)
        {
            Mahasiswa mhs = new Mahasiswa();
            int pilihan;

            atas:
            Console.Clear();
            Console.Write(
                "[1]Tambah Data\n[2]Tampilkan Data\n[3]Bersihkan layar\n[4]Exit\nMasukkan Pilihan : "
            );
            pilihan = int.Parse(Console.ReadLine());

            switch (pilihan)
            {
                case 1:
                    TambahData(mhs.nama, mhs.nim, mhs.jurusan);
                    break;
                case 2:
                    TampilData(mhs.nama, mhs.nim, mhs.jurusan);
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }

            goto atas;
        }
    }

    class Mahasiswa
    {
        private ArrayList Nama = new ArrayList();
        private ArrayList Nim = new ArrayList();
        private ArrayList Jurusan = new ArrayList();

        public ArrayList nama
        {
            get { return Nama; }
            set { Nama = value; }
        }

        public ArrayList nim
        {
            get { return Nim; }
            set { Nim = value; }
        }
        public ArrayList jurusan
        {
            get { return Jurusan; }
            set { Jurusan = value; }
        }
    }
}
