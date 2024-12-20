using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace latihan_ArrayList
{
    internal class Program
    {
        static  string GetInput(string input) {
            Console.Write(input);
            return Console.ReadLine();
        }

        static void Header()
        {
            Console.WriteLine("========= Menu =========");
        }

        static void footer()
        {
            Console.WriteLine("========================");
        }

        static void Confirm()
        {
            Console.WriteLine("Tekan enter untuk melanjutkan program!!!");
            Console.ReadKey();
        }
         static void TambahData(LinkedList<string> value)
        {
            Console.Clear();    
            value.AddFirst(GetInput("Tambah data pertama : "));

            Console.WriteLine("data berhasil ditambahkan!!!");
            Confirm();

        }

        static void TambahDataTerakhir(LinkedList<string> value)
        {
            Console.Clear();
            value.AddLast(GetInput("Tambahkan data terakhir : "));

            Console.WriteLine("data berhasil ditambahkan!!!");
            Confirm();
        }

         static  void HapusDataPertama(LinkedList<string> value)
        {
            value.RemoveFirst();
            Console.WriteLine("data pertama berhasil dihapus!!!");
            Confirm();
        }

        static void HapusDataTerakhir(LinkedList<string> value)
        {
            value.RemoveLast();
            Console.WriteLine("data terakhir berhasil dihapus!!!");
            Confirm();
        }

        static void TampilkanSeluruhData(LinkedList<string> value)
        {
            Console.Clear();
            int no = 1;
            foreach (var item in value)
            {
                Console.WriteLine($"{no++}. {item.ToString()}");
            }
            Confirm();
        }

        static void Main(string[] args)
        {
            LinkedList<string> value = new LinkedList<string>();
           

            while (true)
            {
                Console.Clear();
                Header();
                Console.WriteLine("1. Tambah data pertama");
                Console.WriteLine("2. Tambah data terakhir");
                Console.WriteLine("3. Hapus data pertama");
                Console.WriteLine("4. Hapus data terakhir");
                Console.WriteLine("5. Tampilkan seluruh data");
                Console.WriteLine("6. Keluar");
                footer();
                int pilihan = int.Parse(GetInput("masukkan pilihan : "));
                switch (pilihan)
                {
                    case 1:
                        TambahData(value);
                        break;
                    case 2:
                        TambahDataTerakhir(value);
                        break;
                    case 3:
                        HapusDataPertama(value);
                        break;
                    case 4:
                        HapusDataTerakhir(value);
                        break;
                    case 5:
                        TampilkanSeluruhData(value);
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("masukkan pilihan 1-6");
                        break;
                }
            }
        }
    }
}
