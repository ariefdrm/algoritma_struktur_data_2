using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arief_darmawan_uas_prakter
{
    internal class Program
    {
        static void Header()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("         UAS PRAKTEK          ");
            //Console.WriteLine("  ARIEF DARMAWAN (8020230033) ");
            Console.WriteLine("------------------------------");
        }

        static void TambahDataPertama(LinkedList<string> value)
        {
            Console.Clear();
            Header();
            Console.Write("Masukkan data pertama : ");
            string pertama = Console.ReadLine();

            value.AddFirst(pertama);
        }

        static void HapusDataTerakhir(LinkedList<string> value)
        {
            if (value.Count > 0)
            {
                value.RemoveLast();

                Console.WriteLine("Data terakhir berhasil di hapus!!!");
                Console.ReadKey();
            } else
            {
                Console.WriteLine("Data gagal dihapus, linked list kosong. Silahkan tambahkan terlebih dahulu!!!");
                Console.ReadKey();
            }
        }

        static void HapusDataKedua(LinkedList<string> value)
        {
            LinkedListNode<string> node = value.First;

            if (value.Count > 1)
            {
                value.Remove(node.Next);
            } else
            {
                Console.WriteLine("Linked list kurang dari 2");
            }

            Console.WriteLine("Data kedua berhasil dihapus");
            Console.ReadKey();
        }

        static void TampilkanSeluruhData(LinkedList<string> value)
        {
            int i = 1;
            foreach (string node in value)
            {
                if (i == 1)
                {
                    Console.Write($"{node}");
                } else
                {
                    Console.Write($"->{node}");
                }
                i++;
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Header();
                Console.WriteLine("1. Tambah Data pertama");
                Console.WriteLine("2. Hapus Data Terakhir");
                Console.WriteLine("3. Hapus Data Kedua");
                Console.WriteLine("4. Tampilkan Seluruh data");
                Console.WriteLine();
                Console.Write("Masukkan pilihan : ");
                int pilihan = int.Parse(Console.ReadLine());

                switch(pilihan)
                {
                    case 1:
                        TambahDataPertama(list); 
                        break;
                    case 2:
                        HapusDataTerakhir(list); 
                        break;
                    case 3:
                        HapusDataKedua(list);
                        break;
                    case 4:
                        TampilkanSeluruhData(list);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Masukkan pilihan 1-4");
                        break;
                }
            }
           
        }
    }
}
