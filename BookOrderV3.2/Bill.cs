using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOrderV3._2
{
    public class Bill : Books
    {
        public byte selection { get; set; }
        public uint piece { get; set; }
        public double subTotal { get { return piece * bookPrice; } }

        public Bill(int BookNo, string BookName, uint Piece, double BookPrice)
        {
            bookNo = BookNo;
            bookName = BookName;
            bookPrice = BookPrice;
            piece = Piece;
        }

        public static List<Bill> AddBill(List<Bill> billList, List<Books> bookList, byte selection, uint piece)
        {
            var select = bookList[selection - 1];
            Bill items = new Bill(select.bookNo, select.bookName, piece, select.bookPrice);
            billList.Add(items);
            return billList;
        }

        public static void PrintBill(List<Bill> billList)
        {
            Console.WriteLine($"{"Kitap No",-10}{"Kitap Adı",-20}{"Adet",-10}{"Fiyat",-10}{"Ara Toplam",-10}");
            foreach (var billItem in billList)
            {
                Console.WriteLine($"{billItem.bookNo,-10}{billItem.bookName,-20}{billItem.piece,-10}{billItem.bookPrice,-10}{billItem.subTotal,-10}");
            }
        }

        public static void SaveBill(List<Bill> billList, string musteriAdi, double total)
        {
            string path = @"C:\Users\oscar\OneDrive\Masaüstü\BookOrder\Satışlar\" + musteriAdi;
            Directory.CreateDirectory(path);

            using (StreamWriter sw = new StreamWriter(path + "\\" + DateTime.Now.Day + "-" + musteriAdi + ".txt"))
            {
                sw.WriteLine($"{"Kitap No",-10}{"Kitap Adı",-20}{"Adet",-10}{"Fiyat",-10}{"Ara Toplam",-10}");
                foreach (Bill bill in billList)
                {
                    sw.WriteLine($"{bill.bookNo,-10}{bill.bookName.Trim(),-20}{bill.piece,-10}{bill.bookPrice,-10}{bill.subTotal,-10}");
                }
                sw.WriteLine($"\n{"TOPLAM",50}{total,15}");
            }

        }
    }
}
