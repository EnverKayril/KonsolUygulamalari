namespace Hesap_Makinesi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hesap Makinesi Uygulaması\n");
            Console.WriteLine("İşlem : [+][-][*][/] \nSıfırlamak için '8' \n Çıkış için '9'");
            double sayi1 = 0;
            double sayi2 = 0;
            double sayi3 = 0;
            string mathOp = "";

            try
            {
                Console.Write("1. Sayıyı Giriniz : ");
                sayi1 = Convert.ToDouble(Console.ReadLine());
                sayi1 = 0 + sayi1;
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Değer Girdiniz.");
            }

            while (mathOp != "9")
            {
                try
                {
                    Console.Write("Operatör Giriniz : ");
                    mathOp = Console.ReadLine();
                    Console.Write("2. Sayıyı Giriniz :");
                    sayi2 = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Hatalı Değer Girdiniz");
                }

                switch (mathOp)
                {
                    case "+":
                        sayi1 = sayi1 + sayi2;
                        Console.WriteLine(sayi1);
                        break;

                    case "-":
                        sayi1 = sayi1 - sayi2;
                        Console.WriteLine(sayi1);
                        break;

                    case "*":
                        sayi1 = sayi1 * sayi2;
                        Console.WriteLine(sayi1);
                        break;

                    case "/":
                        sayi1 = sayi1 / sayi2;
                        Console.WriteLine(sayi1);
                        break;

                    case "8":
                        sayi1 = 1;
                        Console.WriteLine("Sıfırlandı." + sayi1);
                        break;

                    case "9":
                        Console.WriteLine("Çıkış Yapıldı.");
                        break;

                    default:
                        Console.WriteLine("Geçerli Bir Operatör Tanımı Giriniz.");
                        break;

                }

            }
        }
    }
}
