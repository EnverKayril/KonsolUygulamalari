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
            string path = @"C:\Users\oscar\OneDrive\Masaüstü\BookOrder\Books.txt";
            List<Books> bookList = Books.AddBook(path);
            Books.GetInformation(bookList);

            while (selection != 0)
            {
                Console.Write("Seçim Yapınız: ");
                selection = Convert.ToInt32(Console.ReadLine());
                if (selection == 0)
                    break;

                Console.Write("Adet Giriniz: ");
                piece = Convert.ToUInt32(Console.ReadLine());

                BillInfo.AddBill(bookList, selection, piece);

                var newBillItems = BillInfo.AddBill(bookList, selection, piece);
                //BillInfo.billList.AddRange(newBillItems);

            }

            BillInfo.GetInformation(BillInfo.AddBill(bookList,selection,piece));



            




        }
     
    }


}
