using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOrderV3
{
    public class BillInfo
    {
        double subTotal;

        public BillInfo(string BookName, uint Piece, double Price, double Subtotal)
        {

        }

        public BillInfo(int bookNo, string bookName, uint piece, double bookPrice)
        {
            BookNo = bookNo;
            BookName = bookName;
            Piece = piece;
            Price = bookPrice;
        }

        public int BookNo { get; set; }
        public string BookName { get; set; }
        public uint Piece { get; set; }
        double Price { get; set; }
        double SubTotal { get { return subTotal; } set { subTotal = Price * Piece; } }


        public static List<BillInfo> AddBill(List<Books> x, int selection, uint piece)
        {
            List<BillInfo> billList = new List<BillInfo>();

            BillInfo item = new BillInfo(x[selection - 1].BookName, piece, x[selection - 1].BookPrice, Subtotal(piece, x[selection - 1].BookPrice));
            billList.Add(item);

            Console.WriteLine(Subtotal);

            return billList;
        }

        public static double Subtotal(uint piece, double price)
        {
            return price * piece;
        }

        public static void GetInformation(List<BillInfo> x)
        {
            Console.WriteLine($"{"Kitap No",-10}{"Kitap Adı",-20}{"Adet",9}{"Fiyatı",6}{"Ara Toplam",15}");
            int i = 1;
            foreach (var book in x)
            {
                Console.WriteLine($"{i}{book.BookName.TrimStart(),-20}{book.Piece,9}{book.Price,6}{book.SubTotal}");
            }
        }


    }
}


