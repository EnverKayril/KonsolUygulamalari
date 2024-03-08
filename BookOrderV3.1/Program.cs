using System.Xml.Schema;

namespace BookOrderV3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\oscar\OneDrive\Masaüstü\BookOrder\Books.txt";
            List<Books> bookList =  Books.AddBook(path);
            List<Bill> billList = new List<Bill>();
            Bill.GetBook(bookList);
            byte selection = 1;
            uint piece = 0;
            double total = 0;

            while (true)
            {
                selection:
                try
                {
                    Console.Write("Seçim yapınız: ");
                    selection = byte.Parse(Console.ReadLine());
                    if (selection == 0)
                        break;
                    else if (selection >= bookList.Count+1)
                        goto selection;
                }
                catch
                {
                    goto selection;
                }
                piece:
                try
                {
                    Console.Write("Adet giriniz: ");
                    piece = uint.Parse(Console.ReadLine());
                }
                catch
                {
                    goto piece;
                }
                billList.AddRange(Bill.AddBill(billList,bookList,selection,piece));
                foreach (Bill item in billList)
                { total += item.subTotal; }
                Console.WriteLine($"{"Ara Toplam",50}{total,15}");
            }
            
            Console.WriteLine($"\n{"TOPLAM",50}{total,15}");
            Console.Write("Firma İsmi Giriniz: ");
            string musteriadi = Console.ReadLine();
            Bill.PrintBill(billList);
            Bill.SaveBill(billList, musteriadi, total);

        }
    }


}
