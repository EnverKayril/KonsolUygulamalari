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

                selection:
                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Hatalı değer girdiniz. Lütfen seçim yapınız. ");
                    goto selection;
                }
                

                if (selection == 8)
                {
                    Console.WriteLine(PrintList());
                    continue;
                }
                
                if (selection == 9)
                {
                    Console.WriteLine($"{"KİTAP ADI",-20}{"ADET",8}{"BİRİM FİYATI",18}{"ARA TOPLAM",15}");
                    foreach (string billing in billingInformation)
                    {
                        Console.WriteLine(billing);
                    }
                    Console.WriteLine($"\n{"GENEL TOPLAM",46}{total,15}");
                    isRun = false;
                    break;
                }

                Console.Write("Adet giriniz: ");
                piece:
                try
                {
                    piece = Convert.ToUInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Hatalı değer girdiniz. Lütfen adet giriniz. ");
                    goto piece;
                }
                

                total += AddBill(billingInformation, selection, piece);
            }

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
            string item = ($"{bookName,-20}{piece,8}{singlePrice,18}{subTotal,15}");
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

