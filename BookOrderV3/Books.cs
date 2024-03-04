using BookOrderV3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BookOrderV3
{
    public class Books
    {

        public Books(string BookNo, string BookName, string BookPrice)
        {
            this.BookNo = int.Parse(BookNo);
            this.BookName = BookName;
            this.BookPrice = double.Parse(BookPrice);
        }

        public int BookNo { get; set; }
        public string BookName { get; set; }
        public double BookPrice { get; set; }


        public static List<Books> AddBook(string path)
        {
            List<Books> bookList = new List<Books>();

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] bookInfo = line.Split('-');

                    if (bookInfo.Length == 3)
                    {
                        Books book = new Books(bookInfo[0], bookInfo[1], bookInfo[2]);
                        bookList.Add(book);
                    }
                    else throw new ArgumentException("Eksik bilgi: " + line);
                }
            }
            return bookList;
        }

        public static void GetInformation(List<Books> x)
        {
            Console.WriteLine($"{"Kitap No",-10}{"Kitap Adı",-20}{"Fiyatı",6}");
            foreach (var book in x)
            {
                Console.WriteLine($"{book.BookNo,-10}{book.BookName.TrimStart(),-20}{book.BookPrice,6}");
            }
        }
    }

}