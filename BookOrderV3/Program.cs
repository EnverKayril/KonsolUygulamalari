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
            int selection = 1;
            uint piece = 1;
            double total = 0;

            string path = @"C:\Users\oscar\OneDrive\Masaüstü\BookOrder\Books.txt";
            List<Books> bookList = Books.AddBook(path);
            Books.GetInformation(bookList);
            List<BillInfo> billList = new List<BillInfo>();

            while (selection != 0)
            {
                Console.Write("Seçim Yapınız (0 çıkış): ");
                selection = Convert.ToInt32(Console.ReadLine());
                if (selection == 0)
                    break;

                Console.Write("Adet Giriniz: ");
                piece = Convert.ToUInt32(Console.ReadLine());

                var newBillItems = BillInfo.AddBill(bookList, selection, piece);

                billList.AddRange(newBillItems);

                foreach (var billItem in billList)
                {
                    total += billItem.SubTotal;
                }
                
            }


            BillInfo.GetInformation(billList);
            
            Console.WriteLine($"\n{"TOPLAM",50}{total,15}");



        }
     
    }


}
