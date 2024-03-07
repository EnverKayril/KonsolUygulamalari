using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace BookOrderV3
{
    public class Program
    {
        static void Main(string[] args)
        {
            double total = 0;
            string path = @"C:\Users\oscar\OneDrive\Masaüstü\BookOrder\Books.txt";
            List<Books> bookList = Books.AddBook(path);
            Books.GetInformation(bookList);
            List<BillInfo> billList = new List<BillInfo>();

            while (true)
            {
                int selection = GetSelection();

                if (selection == 0)
                    break;

                uint piece = GetPiece();

                var newBillItems = BillInfo.AddBill(bookList, selection, piece);

                billList.AddRange(newBillItems);

                foreach (var billItem in billList)
                {
                    total += billItem.SubTotal;
                }
            }

            string musteriAdi = GetCustomerName();

            BillInfo.GetInformation(billList);
            Console.WriteLine($"\n{"TOPLAM",50}{total,15}");
            BillInfo.WriteBill(musteriAdi, billList, total);
        }
        static int GetSelection()
        {
            Console.Write("Seçim Yapınız (0 çıkış): ");
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 0)
            {
                Console.WriteLine("Geçersiz giriş. Tekrar deneyin.");
                Console.Write("Seçim Yapınız (0 çıkış): ");
            }
            return selection;
        }
        static uint GetPiece()
        {
            Console.Write("Adet Giriniz: ");
            uint piece;
            while (!uint.TryParse(Console.ReadLine(), out piece) || piece == 0)
            {
                Console.WriteLine("Geçersiz giriş. Tekrar deneyin.");
                Console.Write("Adet Giriniz: ");
            }
            return piece;
        }
        static string GetCustomerName()
        {
            Console.Write("İsminizi giriniz: ");
            return Console.ReadLine();
        }
    }
}
