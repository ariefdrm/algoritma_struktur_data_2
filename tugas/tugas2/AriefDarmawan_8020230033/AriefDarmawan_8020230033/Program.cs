using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AriefDarmawan_8020230033
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

        public static void Head(ArrayList a)
        {
            if (a.Count > 0)
            {
                Console.WriteLine("Data pertama dalam antrian adalah: {0}", a[0]);
            }
            else
            {
                Console.WriteLine("Antrian masih kosong");
            }
        }

        public static void Tail(ArrayList a)
        {
            if (a.Count > 0)
            {
                Console.WriteLine("Data terakhir dalam antrian adalah: {0}", a[a.Count - 1]);
            }
            else
            {
                Console.WriteLine("Antrian masih kosong");
            }
        }
    }

    class Film : Queue
    {
        // Menginisiasikan variable yang digunakan
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

        // Untuk menampilkan header utama
        void MainHeader()
        {
            string[] header =
            {
                "  ___ _    _                        _       _                _                 _              _    __ _ _       ",
                " / __(_)__| |_ ___ _ __    __ _ _ _| |_ _ _(_)__ _ _ _    __| |_____ __ ___ _ | |___  __ _ __| |  / _(_) |_ __  ",
                " \\__ \\ (_-<  _/ -_) '  \\  / _` | ' \\  _| '_| / _` | ' \\  / _` / _ \\ V  V / ' \\| / _ \\/ _` / _` | |  _| | | '  \\ ",
                " |___/_/__/\\__\\___|_|_|_| \\__,_|_||_\\__|_| |_\\__,_|_||_| \\__,_\\___/\\_/\\_/|_||_|_\\___/\\__,_\\__,_| |_| |_|_|_|_|_|",
                "                                                                                                                ",
            };

            foreach (string s in header)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(s);
                Console.ResetColor();
            }
        }

        void Footer()
        {
            Console.Write("Tekan Enter untuk melanjutkan...");
            Console.ReadKey();
        }

        // Untuk mengambil input dari user
        public string GetInput(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }

        // Menampilkan daftar film dalam format tabel
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

        // Menampilkan daftar film yang siap diunduh
        void DisplayFilmDownload(ArrayList a, int no = 1)
        {
            foreach (string item in a)
            {
                Console.WriteLine(" {0}. {1, -45} [{2}]", no, item, "Ready");
                no++;
            }
            Console.WriteLine();
        }

        // Hitung mundur
        void CountDown(ArrayList a, int no = 1)
        {
            int CountDown = 3;
            while (CountDown >= 0)
            {
                Console.Clear();
                MainHeader();
                Console.WriteLine(" {0}. {1, -45} [  {2, 1}  ]", no, a[0], CountDown);
                CountDown--;
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        // Memvisualisasikan download progress
        void DownloadProgress(ArrayList a, string selectedFilm)
        {
            int no = 1;
            int totalSize = 100; // Simulasikan ukuran file total
            int currentSize = 0;
            int progress = 0;

            CountDown(a);
            Console.Clear();
            MainHeader();
            while (currentSize < totalSize)
            {
                // Simulasikan proses download
                Thread.Sleep(100);
                currentSize++;

                // Hitung progres dalam persen
                progress = (int)((double)currentSize / totalSize * 100);

                // Hapus baris sebelumnya
                Console.Write("\r");

                // Tampilkan nama film yang sedang di download
                Console.Write(" {0}. {1, -45} ", no, selectedFilm);

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
                Console.Write("] {0}% ", progress);
            }
            Console.Clear();
            MainHeader();
            Console.WriteLine(
                " {0}. {1, -45} {2} {3}%",
                no,
                selectedFilm,
                "[       Success      ]",
                progress
            );

            // Console.WriteLine("Download selesai!");
        }

        // Mengambil inputan user untuk memilih film
        void GetInputFilm(int resultLimit, ArrayList a, string[] b)
        {
            for (int i = 0; i < resultLimit; i++)
            {
                string movieName = GetInput(
                    $"No.{i + 1} Pilih No Film yang ingin anda download : "
                );
                // cek jika inputan adalah angka, dan angka tersebut tidak melebihi jumlah film
                if (int.TryParse(movieName, out int result) && result > 0 && result <= b.Length)
                {
                    string SelectedFilm = b[result - 1];

                    // cek jika film sudah di tambahkan/diinput
                    if (a.Contains(SelectedFilm))
                    {
                        string Confirm = GetInput(
                            "Film sudah ada, apakah anda ingin melanjutkan (y/n)?"
                        );
                        if (Confirm.ToLower() != "y")
                        {
                            Console.WriteLine("Film tidak ditambahkan ke dalam antrian");
                            continue;
                        }
                    }

                    // Tambahkan film ke dalam antrian
                    Add(a, SelectedFilm);
                }
                else if (result > 20)
                {
                    Console.WriteLine(
                        "Film tidak ada, silahkan input kembali nomor film yang ingin anda download"
                    );
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Inputan harus angka!");
                    break;
                }
            }
        }

        // Tambah/Add film
        void AddFilm(ArrayList a, string[] b)
        {
            Console.Clear();
            MainHeader();
            Console.WriteLine();

            // Menampilkan daftar film
            DisplayListFilmName(FamousFilmName);

            // Tampilkan film yang sudah di diinput jika ada
            if (FilmName.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Film yang sudah di tambahkan :");
                DisplayFilmDownload(a);
            }

            // Tentukan batas masksimal yang dapat diinput
            int MaxLimit = 5 - a.Count;
            if (MaxLimit <= 0)
            {
                Console.WriteLine("Antrian penuh, silahkan download film yang sudah di tambahkan");
                return;
            }

            // Prompt untuk jumlah film yangg ingin diinput
            string Limit = GetInput(
                $"Berapa banyak film yang ingin anda download (maksimal {MaxLimit}) kosong/default = {MaxLimit} : "
            );

            Limit = string.IsNullOrEmpty(Limit) ? MaxLimit.ToString() : Limit; // cek jika kosong, maka default = MaxLimit

            int.TryParse(Limit, out int ResultLimit); // Cek jika inputan bukan angka, lalu konversi menjadi integer
            Console.WriteLine();

            // Memanggil method untuk memilih film
            GetInputFilm(ResultLimit, a, b);

            Footer();
        }

        // Hapus film dari list
        void DownloadFilm(ArrayList a)
        {
            if (FilmName.Count > 0)
            {
                string FirstFilm = a[0].ToString(); // Mengambil film pertama

                Console.Clear();
                Console.WriteLine();

                DownloadProgress(a, FirstFilm); // Memanggil method download progress
                Remove(a); // Menghapus film pertama dari antrian / list
            }
            else
            {
                // Pesan error jika antrian masih kosong
                Console.WriteLine("Antrian masih kosong, silahkan tambahkan film terlebih dahulu");
            }

            DisplayFilmDownload(FilmName, 1 + 1); // Menampilkan film selanjutnya mulai dari angka 2

            Footer();
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
                        AddFilm(FilmName, FamousFilmName);
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
                    DownloadFilm(FilmName);
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
                MainHeader();
                int choice = 0;

                if (FilmName.Count > 0)
                {
                    DisplayFilmDownload(FilmName);
                }

                DisplayMenu();
                string choiceInput = GetInput("Masukkan pilihan: ");
                if (!int.TryParse(choiceInput, out choice))
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
