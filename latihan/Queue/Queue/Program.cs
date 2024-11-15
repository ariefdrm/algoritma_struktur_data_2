using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    internal class Program
    {
        static void tambah(ArrayList a, int limit)
        {
            if (a.Count < limit)
            {
                Console.Write("Masukkan data : ");
                a.Add(Console.ReadLine());
            } else
            {
                Console.WriteLine("Antrian penuh, silahkan keluarkan terlebih dahulu");
            }
        }

        static void hapus(ArrayList a)
        {
            if (a.Count > 0)
            {
                a.RemoveAt(0);
            } else
            {
                Console.WriteLine("Antrian penuh");
            }
        }

        static void tampil(ArrayList a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                Console.Write("[{0}]", a[i]);
            }
            Console.WriteLine();
        }

        static void tail(ArrayList a) 
        {
            Console.WriteLine("[{0}]", a[a.Count - 1]);
        }

        static void head(ArrayList a)
        {
            Console.WriteLine("[{0}]", a[0]);
        }

        static void Main(string[] args)
        {
            int batas = 4;
            ArrayList data = new ArrayList();
            int pilihan;

        atas:
            Console.Write("[1] tambah\n[2] hapus\n[3] head\n[4] tail\n[5] tampilkan\nmasukkan pilihan : ");
            pilihan = int.Parse(Console.ReadLine());

            switch (pilihan)
            {
                case 1:
                    tambah(data, batas); 
                    break;
                case 2:
                    hapus(data);
                    break;
                case 3:
                    head(data);
                    break;
                case 4:
                    tail(data);
                    break;
                case 5:
                    tampil(data);
                    break;
            }

            goto atas;
        }
    }
}
