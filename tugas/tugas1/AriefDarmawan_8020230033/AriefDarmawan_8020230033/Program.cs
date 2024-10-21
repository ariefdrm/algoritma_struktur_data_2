using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                catch (Exception e)
                {
                    Console.WriteLine("Error message : {0}", e.Message);
                    Thread.Sleep(1000);
                    Console.WriteLine("NIM harus berupa angka. Data gagal ditambahkan!!!");
                }
            }
            else
            {
                // Failure message
                Console.WriteLine("Data gagal ditambahkan. Harap isi semua kolom!!!");
            }
            Console.WriteLine();
            Console.Write("Press the Enter key to continue...");

            Console.ReadKey();
        }

        // Edit data
        static void EditData(ArrayList Nama, ArrayList Nim, ArrayList Jurusan)
        {
            // display current data
            TampilData(Nama, Nim, Jurusan);

            // ask to user to choose which data to edit
            Console.Write("\nMasukkan nomor data yang ingin diubah (1 - {0}): ", Nama.Count);
            string atIndex = Console.ReadLine();

            // validation if index input is empty
            if (!string.IsNullOrWhiteSpace(atIndex))
            {
                int index = int.Parse(atIndex) - 1;

                // check if the index is valid
                if (index >= 0 && index < Nama.Count)
                {
                    // ask to user to edit
                    Console.Clear();
                    Console.WriteLine("\nMasukkan data yang ingin diubah : ");
                    Console.WriteLine("Nama     : {0}", Nama[index]);
                    Console.WriteLine("Nim      : {0}", Nim[index]);
                    Console.WriteLine("Jurusan  : {0}", Jurusan[index]);

                    // ask for the new data
                    Console.Write("\nMasukkan nama baru (kosongkan jika tidak ingin mengubah): ");
                    string namaBaru = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(namaBaru))
                    {
                        Nama[index] = namaBaru;
                    }

                    Console.Write("Masukkan nim baru (kosongkan jika tidak ingin mengubah): ");
                    string nimBaru = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nimBaru))
                    {
                        try
                        {
                            Nim[index] = Int64.Parse(nimBaru);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("NIM tidak valid. NIM tidak diubah.");
                        }
                    }

                    Console.Write("Masukkan jurusan baru (kosongkan jika tidak ingin mengubah): ");
                    string jurusanBaru = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(jurusanBaru))
                    {
                        Jurusan[index] = jurusanBaru;
                    }

                    // Confirm the update
                    Console.WriteLine("\nData berhasil diperbarui.");
                }
                else
                {
                    Console.WriteLine("Nomor data tidak valid");
                }

                Console.Write("Press the Enter key to continue...");

                Console.ReadLine();
            }
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
        }

        // Remove data
        static void RemoveData(ArrayList Nama, ArrayList Nim, ArrayList Jurusan)
        {
            // display current data
            TampilData(Nama, Nim, Jurusan);

            // ask to user to choose which data to edit
            Console.Write("\nMasukkan nomor data yang ingin dihapus (1 - {0}): ", Nama.Count);
            string atIndex = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(atIndex))
            {
                int index = int.Parse(atIndex) - 1;

                if (index >= 0 && index < Nama.Count)
                {
                    Nama.RemoveAt(index);
                    Nim.RemoveAt(index);
                    Jurusan.RemoveAt(index);
                    Console.WriteLine("\nData berhasil dihapus!!!");
                }
                else
                {
                    Console.WriteLine("Data gagal dihapus. Nomor data tidak valid!!!");
                }
                Console.WriteLine("press the Enter key to continue...");
                Console.ReadKey();
            }
        }

        static void Main()
        {
            Mahasiswa mhs = new Mahasiswa();
            int pilihan;
            int delayMilisecond = 2000;

            atas:
            Console.Clear();
            Console.Write(
                "[1]Tambah Data\n[2]Tampilkan Data\n[3]Edit data\n[4]Hapus data\n[5]Bersihkan layar\n[6]Exit\nMasukkan Pilihan : "
            );
            string choice = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(choice))
            {
                pilihan = int.Parse(choice);
                switch (pilihan)
                {
                    case 1:
                        TambahData(mhs.nama, mhs.nim, mhs.jurusan);
                        break;
                    case 2:
                        TampilData(mhs.nama, mhs.nim, mhs.jurusan);
                        Console.Write("Press the Enter key to continue...");
                        Console.ReadKey();
                        break;
                    case 3:
                        EditData(mhs.nama, mhs.nim, mhs.jurusan);
                        break;
                    case 4:
                        RemoveData(mhs.nama, mhs.nim, mhs.jurusan);
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    case 6:
                        Console.WriteLine("BYE BYE :D");
                        Thread.Sleep(delayMilisecond);
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Inputan harus berupa angka");
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
