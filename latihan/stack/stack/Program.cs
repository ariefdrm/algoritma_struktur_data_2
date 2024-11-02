using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stack
{
    internal class Program
    {
        static void push(ArrayList a, int limit)
        {
            if (a.Count < limit)
            {
                Console.Write("masukkan data : ");
                a.Add(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("STACK penuh, silahkan pop terlebih dahulu");
            }
        }

        
        static void pop(ArrayList a) {
            if (a.Count > 0)
            {
                a.RemoveAt(a.Count - 1);
            } else { Console.WriteLine("Stack kosong"); }

        }

        static void tampil(ArrayList a)
        {
            for (int i = a.Count; i > 0; i--)
            {
                Console.WriteLine("[{0}]", a[i-1]);
            }
        }

        static void top(ArrayList a) {
            Console.WriteLine("[{0}]", a[a.Count - 1]);
        }



        static void Main(string[] args)
        {
            int batas = 4;
            ArrayList data = new ArrayList();
            int pilihan;

        atas:
            Console.Write("[1] push\n[2] pop\n[3] top\n[4] tampilkan/masukkan pilihan : ");
            pilihan = int.Parse(Console.ReadLine());

            switch (pilihan)
            {
                case 1:
                    push(data, batas);
                    break;
                case 2:
                    pop(data);
                    break;
                case 3:
                    top(data);
                    break;
                case 4:
                    tampil(data);
                    break;
            }

            goto atas;
        }
    }
}
