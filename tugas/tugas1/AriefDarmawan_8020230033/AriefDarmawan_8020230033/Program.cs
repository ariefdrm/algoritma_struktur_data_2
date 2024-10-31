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
        // get input from user
        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        // continue program
        static void ContinueProgram()
        {
            Console.Write("Press the Enter key to continue...");
            Console.ReadKey();
        }

        // Confirm program
        static string ConfirmProgram()
        {
            string answer = GetInput("Apakah anda ingin melanjutkan (y/n)? :  ");
            return answer;
        }

        static bool GetNimInput(out long nimInput)
        {
            string nimInputStr = GetInput("Masukkan Nim : ");

            if (long.TryParse(nimInputStr, out nimInput))
            {
                return true;
            }
            else
            {
                Console.WriteLine(
                    "\nNim harus berupa angka. Data gagal ditambahkan. Silahkan ulangi kembali.!!!"
                );
                ContinueProgram();

                return false;
            }
        }

        // Add data
        static void TambahData(ArrayList Nama, ArrayList Nim, ArrayList Jurusan)
        {
            // Clear console
            Console.Clear();

            // Get input for input
            string nameInput = GetInput("Masukkan Nama : ");

            // Get input for Nim
            long nimInput;
            if (!GetNimInput(out nimInput))
            {
                return; // Exit the method if Nim input is invalid
            }

            // Get input for jurusan
            string jurusanInput = GetInput("Masukkan Jurusan : ");

            // Check if all inputs are valid
            if (!string.IsNullOrWhiteSpace(nameInput) && !string.IsNullOrWhiteSpace(jurusanInput))
            {
                // Add data to ArrayList
                Nama.Add(nameInput);
                Nim.Add(nimInput);
                Jurusan.Add(jurusanInput);

                Console.WriteLine("Data berhasil ditambahkan!!!");
            }
            else
            {
                Console.WriteLine("Data gagal ditambahkan. Silahkan ulangi kembali!!!");
            }

            ContinueProgram();
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

        static void tampilDataPerIndex(ArrayList Nama, ArrayList Nim, ArrayList Jurusan, int index)
        {
            Console.WriteLine("Nama     : {0}", Nama[index]);
            Console.WriteLine("Nim      : {0}", Nim[index]);
            Console.WriteLine("Jurusan  : {0}", Jurusan[index]);
        }

        // Edit data
        static void EditData(ArrayList Nama, ArrayList Nim, ArrayList Jurusan)
        {
            // display current data
            TampilData(Nama, Nim, Jurusan);

            // ask to user to choose which data to edit
            string atIndex = GetInput(
                $"\nMasukkan nomor data yang ingin diubah (1 - {Nama.Count}): "
            );

            // validation if index input is empty
            if (!string.IsNullOrWhiteSpace(atIndex))
            {
                int index = int.Parse(atIndex) - 1;
                string answer = string.Empty;

                // check if the index is valid
                if (index >= 0 && index < Nama.Count)
                {
                    // ask to user to edit
                    Console.Clear();
                    Console.WriteLine("\nMasukkan data yang ingin diubah : ");
                    tampilDataPerIndex(Nama, Nim, Jurusan, index);

                    // ask for the new data
                    string namaBaru = GetInput(
                        "\nMasukkan nama baru (kosongkan jika tidak ingin mengubah): "
                    );
                    string nimBaru = GetInput(
                        "Masukkan nim baru (kosongkan jika tidak ingin mengubah): "
                    );
                    string jurusanBaru = GetInput(
                        "Masukkan jurusan baru (kosongkan jika tidak ingin mengubah : "
                    );

                    // Check if there are non-empty inputs and confirm the value change
                    Console.WriteLine();
                    if (
                        !string.IsNullOrWhiteSpace(namaBaru)
                        || !string.IsNullOrWhiteSpace(nimBaru)
                        || !string.IsNullOrWhiteSpace(jurusanBaru)
                    )
                    {
                        answer = ConfirmProgram();
                    }

                    if (answer == "y" || answer == "Y")
                    {
                        Console.Clear();
                        // Display old and new data
                        string resultName = (
                            string.IsNullOrWhiteSpace(namaBaru) ? Nama[index].ToString() : namaBaru
                        );
                        Console.WriteLine("Nama     : {0} --> {1}", Nama[index], resultName);

                        string resultNim = (
                            string.IsNullOrWhiteSpace(nimBaru) ? Nim[index].ToString() : nimBaru
                        );
                        Console.WriteLine("Nim      : {0} --> {1}", Nim[index], resultNim);

                        string resultJurusan = (
                            string.IsNullOrWhiteSpace(jurusanBaru)
                                ? Jurusan[index].ToString()
                                : jurusanBaru
                        );
                        Console.WriteLine("Jurusan  : {0} --> {1}", Jurusan[index], resultJurusan);

                        // Change name to new value
                        if (!string.IsNullOrWhiteSpace(namaBaru))
                        {
                            Nama[index] = namaBaru;
                        }

                        // change nim to new value
                        if (!string.IsNullOrWhiteSpace(nimBaru))
                        {
                            try
                            {
                                Nim[index] = Int64.Parse(nimBaru);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("NIM harus berupa angka. NIM tidak diubah!!!");
                            }
                        }

                        // change jurusan to new value
                        if (!string.IsNullOrWhiteSpace(jurusanBaru))
                        {
                            Jurusan[index] = jurusanBaru;
                        }

                        // Confirm the update
                        Console.WriteLine("\nData berhasil diperbarui.!!!");
                    }
                    else
                    {
                        Console.WriteLine("Perubahan data dibatalkan.!!!");
                    }
                }
                else
                {
                    Console.WriteLine("Nomor data tidak valid");
                }
                Console.WriteLine();
                ContinueProgram();
            }
        }

        // Remove data
        static void RemoveData(ArrayList Nama, ArrayList Nim, ArrayList Jurusan)
        {
            // display current data
            TampilData(Nama, Nim, Jurusan);

            // ask to user to choose which data to edit
            string atIndex = GetInput(
                $"\nMasukkan nomor data yang ingin dihapus (1 - {Nama.Count}): "
            );

            if (!string.IsNullOrWhiteSpace(atIndex))
            {
                try
                {
                    int index = int.Parse(atIndex) - 1;

                    String answer = GetInput("Apakah anda yakin ingin menghapus data ini (y/n)? ");

                    if (answer == "y" || answer == "Y")
                    {
                        // Check if the index is valid
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
                    }
                    else
                    {
                        Console.WriteLine("Data gagal dihapus. Silahkan coba lagi!!!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input harus berupa angka. Data gagal dihapus!!");
                }
                Console.WriteLine();
                ContinueProgram();
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
                try
                {
                    pilihan = int.Parse(choice);
                    switch (pilihan)
                    {
                        case 1:
                            TambahData(mhs.nama, mhs.nim, mhs.jurusan);
                            break;
                        case 2:
                            TampilData(mhs.nama, mhs.nim, mhs.jurusan);
                            ContinueProgram();
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
                catch (FormatException)
                {
                    Console.WriteLine("Pilihan harus berupa angka. Masukkan pilihan kembali!!!");
                    Thread.Sleep(delayMilisecond);
                    goto atas;
                }
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
