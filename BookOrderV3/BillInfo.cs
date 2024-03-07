using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOrderV3
{
    public class BillInfo
    {
        internal static object billList;

        public string BookNo { get; set; }
        public string BookName { get; set; }
        public uint Piece { get; set; }
        public double Price { get; set; }
        public double SubTotal { get { return Price * Piece; } }

        public BillInfo(string bookNo, string bookName, uint piece, double price)
        {
            BookNo = bookNo;
            BookName = bookName;
            Piece = piece;
            Price = price;
        }
        public static List<BillInfo> AddBill(List<Books> booksList, int selection, uint piece)
        {
            if (selection < 0 || selection > booksList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(selection), "Geçersiz seçim.");
            }

            var selectedBook = booksList[selection - 1];
            var billItem = new BillInfo(selectedBook.BookNo.ToString(), selectedBook.BookName, piece, selectedBook.BookPrice);
            return new List<BillInfo> { billItem };
        }

        public static void GetInformation(List<BillInfo> billList)
        {
            Console.WriteLine($"{"Kitap No",-10}{"Kitap Adı",-20}{"Adet",10}{"Fiyatı",10}{"Ara Toplam",15}");
            foreach (var billItem in billList)
            {
                Console.WriteLine($"{billItem.BookNo,-10}{billItem.BookName.Trim(),-20}{billItem.Piece,10}{billItem.Price,10}{billItem.SubTotal,15}");
            }
        }

        public static void WriteBill(string musteriAdi, List<BillInfo> txt, double total)
        {
            string path = @"C:\Users\oscar\OneDrive\Masaüstü\BookOrder\Satışlar\" + musteriAdi;

            Directory.CreateDirectory(path);

            using (StreamWriter sw = new StreamWriter(path + "\\" + DateTime.Now.TimeOfDay + "-"+ musteriAdi+".txt"))
            {   
                sw.WriteLine($"{"Kitap No",-10}{"Kitap Adı",-20}{"Adet",10}{"Fiyatı",10}{"Ara Toplam",15}");
                
                foreach (var billItem in txt)
                {
                    sw.WriteLine($"{billItem.BookNo,-10}{billItem.BookName.Trim(),-20}{billItem.Piece,10}{billItem.Price,10}{billItem.SubTotal,15}");
                }
                sw.WriteLine($"\n{"TOPLAM",50}{total,15}");
            }
        }
    }
}