using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOrderV3._2
{
    public class Books
    {
        public int bookNo { get; set; }
        public string bookName { get; set; }
        public double bookPrice { get; set; }

        public static List<Books> AddBooks(string path)
        {
            List<Books> bookList = new List<Books>();
            StreamReader sr = new StreamReader(path);
            while (sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] bookInfo = line.Split('-');
                Books book = new Books()
                {
                    bookNo = int.Parse(bookInfo[0]),
                    bookName = bookInfo[1],
                    bookPrice = double.Parse(bookInfo[2]),
                };
                bookList.Add(book);
            }
            return bookList;
        }

        public static void GetBook(List<Books> bookList)
        {
            Console.WriteLine($"{"Kitap Id",-12}{"Kitap Adı",-20}{"Fiyatı",-10}");
            foreach (Books book in bookList)
            {
                Console.WriteLine($"{book.bookNo,-12}{book.bookName.Trim(),-20}{book.bookPrice,-10}");
            }


        }


    }
}
