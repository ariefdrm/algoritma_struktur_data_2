using System.Collections;
using System.Runtime.CompilerServices;

internal class Program
{
  
    static void TambahData(ArrayList a)
    {
        Console.Write("masukkan nilai data : ");
        a.Add(int.Parse(Console.ReadLine()));
    }

    static void TampilData(ArrayList a)
    {
        foreach (int i in a)
        {
            Console.Write(i);
        }
    }
    private static void Main(string[] args) 
    {
        ArrayList data = new ArrayList();
        int pilihan;

        atas:

        Console.Write("[1]Tambah data\n[2]Tampilkan data\n[3]Bersihkan layar\nMasukkan pilihan: ");
        pilihan = int.Parse(Console.ReadLine());

        switch(pilihan)
        {
            case 1:
                TambahData(data); break;
            case 2:
                TampilData(data); break;
            case 3:
                Console.Clear(); break;
        }

        Console.WriteLine();
        goto atas;

        Console.ReadKey();
    }
    
  
}