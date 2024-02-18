using System.Security.AccessControl;

namespace BookOrderV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double total = 0;
            double tax = 0;
            double Kdv = 0.10;
            
            List<string> fatura = new List<string>();
            

            Console.WriteLine("Hoşgeldiniz. Lütfen almak istediğiniz ürünü seçiniz.");


            Console.WriteLine(PrintList());

            bool isRun = true;

            while (isRun)
            {
                Console.Write("Seçim Yapınız: ");
                int secim = Convert.ToInt32(Console.ReadLine());
                
                if (secim == 8)
                {
                    Console.WriteLine("KITAP ADI  \t\t\t ADET \t  BİRİM FİYATI  \t  ARA TOPLAM");
                    foreach (string kalem in fatura)
                    {
                        Console.WriteLine(kalem);
                    }
                    Console.WriteLine("Total : " + total);
                    isRun = false;
                    break;
                }
                //PADLEFT
                Console.WriteLine("Adet giriniz: ");
                uint adet = Convert.ToUInt32(Console.ReadLine());

                
                total += addFatura(fatura,secim,adet);
                


            }





        }

        private static double addFatura( List<string> x, int secim, uint adet)
        {
            double aratoplam = OrderBook(secim, adet);
            double singlePrice = PriceList()[secim - 1];
            string kitapAdi = Books()[secim - 1];
            string kalem = kitapAdi + " \t\t\t" + adet + "\t " + singlePrice +"\t " + aratoplam;
            x.Add(kalem);
            return aratoplam;
        }

        private static string PrintList()
        {
            string[] nameList = Books();
            double[] priceList = PriceList();
            
            string text = "";

            for (int i = 0; i < nameList.Length; i++)
            {
                text = text + (i + 1) + ". " + nameList[i] + "  -  " + priceList[i] + "\n";
            }
            return text;
        }

        private static double OrderBook(int secim, uint adet)
        {
            double bookPrice = PriceList()[secim - 1];
            double aratoplam = bookPrice * adet;
            Console.WriteLine(aratoplam);
            return aratoplam;
        }

        private static string[] Books()
        {
            return new string[] { "Şiir Kitabı", "Çocuk Kitabı", "Roman", "Tarih Kitabı", "Felsefe Kitabı", "Biyografi Kitabı" };
        }

        private static double[] PriceList()
        {
            return new double[] { 18, 15, 22, 20, 17, 14 };
        }
    }
}
