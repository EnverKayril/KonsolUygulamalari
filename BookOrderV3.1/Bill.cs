using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BookOrderV3._1
{
    public class Bill : Books
    {
        public byte selection {  get; set; }
        public uint piece { get; set; }
        public double subTotal { get { return piece * bookPrice; } }

        public Bill(int BookNo, string BookName, uint Piece, double BookPrice)
        {
            bookId = BookNo;
            bookName = BookName;
            bookPrice = BookPrice;
            piece = Piece;
        }

        public static List<Bill>AddBill(List<Bill> billList,List<Books> bookList, byte selection, uint piece)
        {
            Bill items = new Bill(bookList[selection-1].bookId, bookList[selection-1].bookName, piece, bookList[selection-1].bookPrice);
            billList.Add(items);
            return billList;

        }
        public static void PrintBill(List<Bill> billList)
        {
            Console.WriteLine($"{"Kitap No",-10}{"Kitap Adı",-20}{"Adet",-10}{"Fiyat",-10}{"Ara Toplam",-10}");
            foreach (var billItem in billList)
            {
                Console.WriteLine($"{billItem.bookId,-10}{billItem.bookName,-20}{billItem.piece,-10}{billItem.bookPrice,-10}{billItem.subTotal,-10}");
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
                    sw.WriteLine($"{bill.bookId,-10}{bill.bookName.Trim(),-20}{bill.piece,-10}{bill.bookPrice,-10}{bill.subTotal,-10}");
                }
                sw.WriteLine($"\n{"TOPLAM",50}{total,15}");

            }
        }
    }
}
