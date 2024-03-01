using System.Security.AccessControl;

namespace BookOrderV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> billingInformation = new List<string>();
            double total = 0;
            int selection = 0;
            uint piece = 0;

            Welcome();

            bool isRun = true;
            while (isRun)
            {
                Console.WriteLine("Lütfen almak istediğiniz ürünü seçiniz. \nÜrünleri görüntülemek için '8'e basınız. \nSiparişi tamamlamak için '9'a basınız.");


                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Hatalı değer girdiniz. ");

                }
                

                if (selection == 8)
                {
                    Console.WriteLine(PrintList());
                    continue;
                }

                if (selection == 9)
                {
                    Console.WriteLine("KİTAP ADI        ADET  BİRİM FİYAT   ARA TOPLAM");
                    foreach (string billing in billingInformation)
                    {
                        Console.WriteLine(billing);
                    }
                    Console.WriteLine("GENEL TOPLAM : " + total);
                    isRun = false;
                    break;
                }

                Console.Write("Adet giriniz: ");

                try
                {
                    piece = Convert.ToUInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Hatalı değer girdiniz. ");
                }
                

                total += AddBill(billingInformation, selection, piece);
            }






            //Dışarıdan sipariş alınacak olan kitap miktarı girilsin. Sipariş sayısı 20 den az ise toplam ücretten %5 düşürülsün. 20-50 aralığında ise %10. 50-100 aralığında ise %15, 100 den fazla ise %25 indirim yapılsın. Kitabın birim fiyatı 20TL
        }

        private static void Welcome()
        {
            Console.WriteLine("Kitap Sipariş Programı\n");
            Console.WriteLine("Hoşgeldiniz.");
            Console.WriteLine(PrintList());
        }

        private static double AddBill(List<string> bill, int selection, uint piece)
        {
            double subTotal = SubTotal(piece, selection);
            string bookName = BooksList()[selection - 1];
            double singlePrice = BooksPrice()[selection - 1];
            string item = (bookName) + " " + (piece) + " " + (singlePrice) + " " + (subTotal);
            bill.Add(item);
            return subTotal;
        }

        private static double SubTotal(uint piece, int selection)
        {
            double bookPrice = BooksPrice()[selection - 1];
            double subTotal = bookPrice * piece;
            Console.WriteLine(subTotal);
            return subTotal;
        }

        private static string PrintList()
        {
            string[] bookList = BooksList();
            double[] priceList = BooksPrice();
            string list = "";

            for (int i = 0; i < bookList.Length; i++)
            {
                list = list + (i + 1) + ". " + bookList[i] + " -> " + priceList[i] + "\n";
            }
            return list;
        }

        private static string[] BooksList()
        {
            return new string[] { "Şiir Kitabı     ", "Çocuk Kitabı    ", "Roman           ", "Tarih Kitabı    ", "Felsefe Kitabı  ", "Biyografi Kitabı" };
        }

        private static double[] BooksPrice()
        {
            return new double[] { 18, 15, 22, 20, 17, 14 };
        }
    }
}
