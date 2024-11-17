using System;
using System.Collections;
using System.Threading;

namespace Sistem_antrian_download_film
{
    class Queue
    {
        public static void Add(ArrayList a, string input, int limit = 5)
        {
            if (a.Count < limit)
            {
                a.Add(input);
            }
            else
            {
                Console.WriteLine("Memory/Antrian penuh, silahkan tunggu hingga data dihapus");
            }
        }

        public static void Remove(ArrayList a)
        {
            if (a.Count > 0)
            {
                a.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("Memory/Antrian masih kosong");
            }
        }
    }

    class Film : Queue
    {
        string[] FamousFilmName =
        {
            "The Shawshank Redemption",
            "The Godfather",
            "The Dark Knight",
            "Schindler's List",
            "Pulp Fiction",
            "12 Angry Men",
            "The Lord of the Rings: The Return of the King",
            "The Good, the Bad and the Ugly",
            "Fight Club",
            "Forrest Gump",
            "Inception",
            "The Matrix",
            "Star Wars: Episode IV - A New Hope",
            "The Silence of the Lambs",
            "City of God",
            "It's a Wonderful Life",
            "The Usual Suspects",
            "Life is Beautiful",
            "Spirited Away",
            "Parasite",
        };

        ArrayList FilmName = new ArrayList();

        void Header(string HeaderName)
        {
            Console.WriteLine("======={0}=======", HeaderName);
            Console.WriteLine();
        }

        void Footer()
        {
            Console.Write("Tekan Enter untuk melanjutkan...");
            Console.ReadKey();
        }

        public string GetInput(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }

        void DisplayListFilmName(string[] value)
        {
            int totalMovies = value.Length;
            int FirstTableCount = 10; // Jumlah item di tabel pertama
            int SecondTableStart = 10; // Indeks awal tabel kedua (mulai dari film ke-11)

            Console.WriteLine(
                "+----+-----------------------------------------------+    +----+-----------------------------------------------+"
            );
            Console.WriteLine(
                "| No | Nama Film                                     |    | No | Nama Film                                     |"
            );
            Console.WriteLine(
                "+----+-----------------------------------------------+    +----+-----------------------------------------------+"
            );

            for (int i = 0; i < FirstTableCount; i++)
            {
                // Tabel pertama (nomor 1-10)
                string leftTable =
                    (i < totalMovies)
                        ? string.Format("| {0,-2} | {1,-45} |", i + 1, value[i])
                        : "|    |                                             |";

                // Tabel kedua (nomor 11-20)
                string rightTable =
                    ((i + SecondTableStart) < totalMovies)
                        ? string.Format(
                            "| {0,-2} | {1,-45} |",
                            i + SecondTableStart + 1,
                            value[i + SecondTableStart]
                        )
                        : "|    |                                             |";

                Console.WriteLine($"{leftTable}    {rightTable}");
            }
            Console.WriteLine(
                "+----+-----------------------------------------------+    +----+-----------------------------------------------+"
            );
        }

        void ChoiceFilmName(ArrayList a, string[] b)
        {
            Console.Clear();
            DisplayListFilmName(FamousFilmName);

            if (FilmName.Count > 0)
            {
                DisplayFilmDownload(a);
            }

            string Limit = GetInput(
                "Berapa banyak film yang ingin anda download (maksimal 5) kosong/default = 5 :"
            );
            Limit = string.IsNullOrEmpty(Limit) ? "5" : Limit;
            if (int.TryParse(Limit, out int ResultLimit))
            {
                for (int i = 0; i < ResultLimit; i++)
                {
                    string movieName = GetInput("Pilih No Film yang ingin anda download :");
                    if (int.TryParse(movieName, out int result))
                    {
                        Add(a, b[result - 1].ToString());
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Inputan harus angka!");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Inputan harus angka!");
            }

            Footer();
        }

        void DisplayFilmDownload(ArrayList a)
        {
            int no = 1;

            foreach (string item in a)
            {
                Console.WriteLine("{0}. {1, -45} [{2}]", no, item, "Ready");
                no++;
            }
            Console.WriteLine();
        }

        void DownloadProgress()
        {
            int totalSize = 100; // Simulasikan ukuran file total
            int currentSize = 0;
            int progress = 0;

            Console.Write("Downloading... ");

            while (currentSize < totalSize)
            {
                // Simulasikan proses download
                Thread.Sleep(100);
                currentSize++;

                // Hitung progres dalam persen
                progress = (int)((double)currentSize / totalSize * 100);

                // Hapus baris sebelumnya
                Console.Write("\r");

                // Tampilkan bar progres
                Console.Write("[");
                for (int i = 0; i < 20; i++)
                {
                    if (i < progress / 5)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("] {0}%", progress);
            }

            Console.WriteLine("\nDownload selesai!");
        }

        void DisplayMenu()
        {
            Console.Write("[1] Pilih Film (Add)\n[2] Download Film (Remove)\n[3] Keluar\n");
        }

        void HandleChoice(int Choice)
        {
            switch (Choice)
            {
                case 1:
                    if (FilmName.Count < 5)
                    {
                        ChoiceFilmName(FilmName, FamousFilmName);
                    }
                    else
                    {
                        Console.WriteLine(
                            "Antrian penuh, silahkan download film yang sudah di tambahkan"
                        );
                        Footer();
                    }
                    break;
                case 2:
                    Console.WriteLine("Keluar");
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }

        public void run()
        {
            while (true)
            {
                Console.Clear();
                Header("Sistem Antrian Download Film");

                if (FilmName.Count > 0)
                {
                    DisplayFilmDownload(FilmName);
                }

                DisplayMenu();
                string choiceInput = GetInput("Masukkan pilihan: ");

                if (!int.TryParse(choiceInput, out int choice))
                {
                    Console.WriteLine("Inputan harus angka!");
                    Footer();
                }
                HandleChoice(choice);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Film f = new Film();
            f.run();

            Console.ReadKey();
        }
    }
}
