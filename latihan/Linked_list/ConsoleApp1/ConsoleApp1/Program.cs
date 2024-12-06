using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Tampilkan(LinkedList<string> words, string test)
        {
            Console.WriteLine(test);
            int i = 1;
            foreach (var item in words)
            {
                if (i == 1)
                {
                    Console.Write("[{0}]", item);
                }
                else
                {
                    Console.Write("->[{0}]", item);
                }
                i++;
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            LinkedList<string> nama = new LinkedList<string>();

            nama.AddLast("Andri");
            nama.AddLast("Budi");
            nama.AddLast("Indah");
            Tampilkan(nama, " Menambah 3 nama : ");

            nama.AddFirst("Dini");
            Tampilkan(nama, "Menambahkan 'Dini' diawal : ");

            LinkedListNode<string> mark = nama.Find("Budi");

            nama.AddAfter(mark, "Gina");
            Tampilkan(nama, "Menambahkan 'Gina' setelah 'Budi'");

            nama.AddBefore(mark, "Susi");
            Tampilkan(nama, "Menambahkan 'Susi' sebelum 'Budi'");

            nama.RemoveFirst();
            Tampilkan(nama, "Menghapus nama pertama");

            nama.RemoveLast();
            Tampilkan(nama, "Menghapus nama terakhir");

            nama.Remove(mark);
            Tampilkan(nama, "Menghapus nama 'Budi'");

            Console.ReadKey();
        }
    }
}
