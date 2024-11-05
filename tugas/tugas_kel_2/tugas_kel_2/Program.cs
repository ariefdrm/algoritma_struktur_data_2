using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading;
using System.Threading.Tasks;

namespace tugas_kel_2
{
    class Stacks
    {
        // Fungsi untuk menambahkan element
        public static void push(ArrayList a, string input)
        {
            a.Add(input);
        }

        // Fungsi untuk menghapus element terakhir
        public static void pop(ArrayList a)
        {
            if (a.Count > 0)
            {
                a.RemoveAt(a.Count - 1);
            }
        }

        // Fungsi untuk menghapus semua element
        public static void clear(ArrayList a)
        {
            a.Clear();
        }

        // Fungsin untuk print element terakhir
        public static void peek(ArrayList a)
        {
            if (a.Count > 0)
            {
                Console.Write("Last Element: {0}\n", a[a.Count - 1].ToString());
            }
            else
            {
                Console.WriteLine("Nothing in Stack!");
            }
        }
    }

    class TextEditor : Stacks
    {
        // Menginisialisasi variabel
        private string text = "";
        private ArrayList undoText = new ArrayList();
        private ArrayList redoText = new ArrayList();

        // Encapsulation for "TextInput"
        public string CurrentText
        {
            get { return text; } // mengembalikan nilai dari "text"
            set { text = value; } // atur nilai dari "text"
        }

        // Encapsulation for "UndoText"
        public ArrayList UndoTextInput
        {
            get { return undoText; } // mengembalikan nilai dari "undoText"
            set { undoText = value; } // atur nilai dari "undoText"
        }

        // Encapsulation for "RedoText"
        public ArrayList RedoTextInput
        {
            get { return redoText; } // mengembalikan nilai dari "redoText"
            set { redoText = value; } // atur nilai dari "redoText"
        }

        // Fungsi untuk undo
        public void Undo(string currentText)
        {
            if (UndoTextInput.Count > 0) // cek jika stack tidak kosong
            {
                push(RedoTextInput, currentText); // Add currentText to the RedoTextInput
                CurrentText = UndoTextInput[UndoTextInput.Count - 1].ToString(); // Atur "currentText" ke dengan elemen terakhir di "UndoTextInput
                pop(UndoTextInput); // Has the last element in the "UndoTextInput"
            }
            else
            {
                Console.WriteLine("Nothing to undo!");
                Console.ReadKey();
            }
        }

        // Fungsi untuk redo
        public void Redo(string currentText)
        {
            if (RedoTextInput.Count > 0) // cek jika stack tidak kosong
            {
                push(UndoTextInput, currentText); // Tambahkan teks lama ke "UndoTextInput"
                CurrentText = RedoTextInput[RedoTextInput.Count - 1].ToString(); // Atur "currentText" ke dengan elemen terakhir di "RedoTextInput"
                pop(RedoTextInput); // Hapus elemen terakhir di "RedoTextInput"
            }
            else
            {
                Console.WriteLine("Nothing to redo!");
                Console.ReadKey();
            }
        }

        // Fungsi untuk menampilkan teks
        public void DisplayCurrentText(string a)
        {
            Console.WriteLine("{0} {1}", a, CurrentText); // Mencetak / menampilkan elemen
        }

        // Fungsi untuk menampilkan isi dalam stack
        public void DisplayStack(ArrayList a, ArrayList b)
        {
            int index = (a.Count == 0) ? b.Count : a.Count; // mencari jumlah elemen pada kedua ArrayList
            string isEmpty = " ";
            int NoA = index;
            int NoB = index;

            Console.WriteLine("+----+-------------------------+----+-------------------------+");
            Console.WriteLine("| No | Undo Text               | No | Redo Text               |");
            Console.WriteLine("+----+-------------------------+----+-------------------------+");
            for (int i = index; i > 0; i--) //  Untuk menampilkan elemen dari index terakhir ke index pertama
            {
                if (a.Count == 0) // cek jika ArrayList pertama tidak kosong
                {
                    // Mencetak / menampilkan elemen
                    Console.WriteLine(
                        "| {0,-2} | {1, -23} | {2,-2} | {3, -23} |",
                        isEmpty,
                        isEmpty,
                        NoB--,
                        b[i - 1]
                    );
                }
                else if (b.Count == 0) // cek jika ArrayList kedua tidak kosong
                {
                    // Mencetak / menampilkan elemen
                    Console.WriteLine(
                        "| {0,-2} | {1, -23} | {2,-2} | {3, -23} |",
                        NoA--,
                        a[i - 1],
                        isEmpty,
                        isEmpty
                    );
                }
                else // cek jika kedua ArrayList tidak kosong
                {
                    // Mencetak / menampilkan elemen
                    Console.WriteLine(
                        "| {0,-2} | {1, -23} | {2,-2} | {3, -23} |",
                        NoA--,
                        a[i - 1],
                        NoB--,
                        b[i - 1]
                    );
                }
            }
            Console.WriteLine("+----+-------------------------+----+-------------------------+");
        }

        // Fungsi untuk print last element
        public void DisplayLastElement(ArrayList a, ArrayList b)
        {
            System.Console.WriteLine();
            Console.Write("Undo text: ");
            peek(a);
            Console.Write("Redo text: ");
            peek(b);
            Footer();
        }

        // Fungsi untuk mengambil input dari user
        public string GetInput(string input)
        {
            Console.Write(input); // Untuk input dari user
            return Console.ReadLine(); // Ambil input dari user
        }

        // Function to edit text
        public void Edit()
        {
            Console.Clear();
            Headers("EDIT TEXT");
            string newText = GetInput("Masukkan teks baru: "); // Masukkan teks baru
            if (!string.IsNullOrWhiteSpace(newText))
            {
                push(UndoTextInput, CurrentText); // Tambahkan teks lama ke "UndoTextInput"
                clear(RedoTextInput); // Hapus semua elemen pada "RedoTextInput"

                CurrentText = newText; // Atur CurrentText ke teks baru
            }
            else
            {
                Console.WriteLine("Teks tidak boleh kosong. Silahkan ulangi kembali.!!!");
                Footer();
                // Edit();
            }
        }

        // Fungsi untuk debugging
        public void Debugging()
        {
            Console.Clear();
            Console.Write("Current Text: {0}\n", CurrentText);
            Console.WriteLine();

            DisplayStack(UndoTextInput, RedoTextInput);

            Console.ReadKey();
        }

        // Header dan Footer
        public void Headers(string headerName)
        {
            Console.WriteLine("======={0}=======", headerName);
            Console.WriteLine();
        }

        public void Footer()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Akhir dari fungsi header dan footer

        // Fungsi untuk menampilkan menu
        public void DisplayMenu()
        {
            Console.Clear();
            Headers("Undo/Redo Text Editor"); // Tampilkan header
            DisplayCurrentText("The current text is: "); // Tampilkan teks saat ini "currentText"

            if (UndoTextInput.Count > 0 || RedoTextInput.Count > 0) // Cek jika stack tidak kosong
            {
                Console.WriteLine();
                DisplayStack(UndoTextInput, RedoTextInput); // Tampilkan stack, jika stack tidak kosong
            }

            Console.WriteLine();
            Console.WriteLine("[1] Edit / Tambahkan teks baru\n[2] Undo\n[3] Redo\n[4] Exit"); // Tampilkan menu
        }

        // Fungsi untuk menghandle "choice"
        public void HandleChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Edit(); // Jalankan fungsi "Edit"
                    break;
                case 2:
                    Undo(CurrentText); // Jalankan fungsi "Undo"
                    break;
                case 3:
                    Redo(CurrentText); // Jalankan fungsi "Redo"
                    break;
                case 4:
                    Environment.Exit(0); // Keluar dari program
                    break;
                case 5:
                    DisplayLastElement(UndoTextInput, RedoTextInput);
                    break;
            }
        }

        // Fungsi untuk menjalankan program
        public void Run()
        {
            Headers("Undo/Redo Text Editor"); // Mencetak / menampilkan header
            CurrentText = GetInput("Masukkan teks: "); // Mengambil input dari user
            if (string.IsNullOrWhiteSpace(CurrentText)) // cek jika teks input adalah whitespace / kosong
            {
                Console.WriteLine("Teks tidak boleh kosong. Silahkan ulangi kembali.!!!"); // Pesan error
                Footer();
                Console.Clear();
                Run(); // Menjalankan ulang program jika teks input adalah whitespace / kosong
            }

            while (true)
            {
                DisplayMenu(); // mencetak / menampilkan menu
                string choiceInput = GetInput("Masukkan pilihan: "); // mengambil input dari user

                if (!int.TryParse(choiceInput, out int choice)) // cek jika input bukan integer dan konversi ke integer
                {
                    Console.WriteLine("Input harus berupa angka. Silahkan ulangi kembali.!!!"); // Pesan error
                    Console.ReadKey();
                }
                HandleChoice(choice); // menjalankan fungsi "HandleChoice" dengan pilihan yang telah diterima
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextEditor tx = new TextEditor();
            tx.Run();
        }
    }
}
