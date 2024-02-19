using System.Security.AccessControl;

namespace EK_Kagitcilik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> faturaDetayı = new List<string>();
            double total = 0;

            Console.WriteLine("Kağıt Sipariş Sistemi\n");
            


            bool isRun = true;
            while (isRun)
            {
                Console.WriteLine(Kagıtlar() + "Siparişi tamamlamak için '9'a basınız.");
                Console.Write("\nKağıt Cinsini Seçiniz: ");
                int secim1 = Convert.ToInt32(Console.ReadLine());
                if (secim1 == 9) 
                {
                    Console.WriteLine("KAĞIT CİNSİ \t  M2 FİYATI\tKAĞIT ENİ \t TOP METRAJI \t\t TOPLAM");
                    foreach (string kalem in faturaDetayı)
                    {
                        Console.WriteLine(kalem);
                    }
                    Console.WriteLine("\n\t\t\t\t\t   GENEL TOPLAM  \t\t" + Math.Round(total));
                    isRun = false; 
                    break;
                }

                Console.WriteLine(KagitEnleri());
                Console.Write("Kağıt Enini Seçiniz: ");
                int secim2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(TopMetrajlari());
                Console.Write("Top Metrajını Seçiniz: ");
                int secim3 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Adet Giriniz: ");
                uint adet = Convert.ToUInt32(Console.ReadLine());

                total += Fatura(faturaDetayı, secim1, secim2, secim3, adet);
            }
        }




        private static double Fatura(List<string>fis, int secim1, int secim2, int secim3, uint adet)
        {
            string kagitCinsi = KagıtCinsi()[secim1 - 1];
            double metrekareFiyatı = MetrekareFiyatı()[secim1 - 1];
            double kagitEni = KagıtEni()[secim2 - 1];
            double topMetraji = TopMetraji()[secim3 - 1];
            double araToplam = AraToplam(secim1, secim2, secim3, adet);
            string item = ("\t" + kagitCinsi + "\t\t" + metrekareFiyatı + "\t    " + kagitEni + "\t\t\t" + topMetraji + "\t\t" + araToplam);
            fis.Add(item);
            return Math.Round(araToplam,2);
        }

        private static double AraToplam(int secim1, int secim2,int secim3, uint adet )
        {
            double metrekareFiyati = MetrekareFiyatı()[secim1 - 1];
            double kagitEni = KagıtEni()[secim2 - 1];
            double topMetraji = TopMetraji()[secim3 - 1];
            double araToplam = metrekareFiyati * kagitEni * topMetraji * adet;
            Console.WriteLine(Math.Round(araToplam, 2));
            return Math.Round(araToplam, 2);
        }

        private static string[] KagıtCinsi()
        {
            return new string[] { "s37", "c40", "a50" };
        }
        private static double[] MetrekareFiyatı()
        {
            return new double[] { 2.40, 1.80, 2.60 };
        }
        private static double[] KagıtEni()
        {
            return new double[] { 1.00, 1.60, 1.80, 2.20, 3.20 };
        }
        private static double[] TopMetraji()
        {
            return new double[] { 300, 500, 700 };
        }

        private static string Kagıtlar()
        {
            string[] kagıtCinsi = KagıtCinsi();
            double[] metrekareFiyat = MetrekareFiyatı();
            string list = "";
            for (int i = 0; i < kagıtCinsi.Length; i++)
            {
                list = list + (i + 1) + ". " + kagıtCinsi[i] + " -> " + metrekareFiyat[i] +"\n";
            }
            return list;
        }

        private static string KagitEnleri()
        {
            double[] kagitEni = KagıtEni();
            string list = "";
            for (int i = 0;i < kagitEni.Length;i++)
            {
                list = list + (i + 1) + ". " + kagitEni[i] + "\n";
            }
            return list;
        }

        private static string TopMetrajlari()
        {
            double[] topMetraj = TopMetraji();
            string list = "";
            for (int i = 0; i < topMetraj.Length; i++) 
            {
                list = list + (i + 1) + ". " + topMetraj[i] + "\n";
            }
            return list;
        }


    }
}
