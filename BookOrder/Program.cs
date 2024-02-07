namespace BookOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Birim Fiyatları
            int siir = 18;
            int cocuk = 15;
            int roman = 22;
            int tarih = 20;
            int felsefe = 17;
            int biyografi = 14;
            int secim = 0;
            int adet = 0;
            int toplam = 0;


            Console.WriteLine("Hoşgeldiniz. Lütfen almak istediğiniz ürünü seçiniz.");
            Console.WriteLine("1. Şiir \n2. Çocuk \n3. Roman \n4. Tarih \n5. Felsefe \n6. Biyografi \nSiparişi Tamamlamak için '8'e Basınız. \nSipariş Vermeden Çıkış Yapmak İçin '9'a Basınız. \n ");

            while (secim != 9 && secim != 8)
            {
                try
                {
                    Console.Write("Seçim Yapınız :");
                    secim = Convert.ToInt32(Console.ReadLine());

                    switch (secim)
                    {
                        case 1:
                            Console.Write("Şiir Kitabı İçin Adet Giriniz: ");
                            adet = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ara Toplam : " + siir * adet);
                            toplam = toplam + siir * adet;
                            break;

                        case 2:
                            Console.Write("Çocuk Kitabı İçin Adet Giriniz: ");
                            adet = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ara Toplam : " + cocuk * adet);
                            toplam = toplam + cocuk * adet;
                            break;

                        case 3:
                            Console.Write("Roman İçin Adet Giriniz: ");
                            adet = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ara Toplam : " + roman * adet);
                            toplam = toplam + roman * adet;
                            break;

                        case 4:
                            Console.Write("Tarih Kitabı İçin Adet Giriniz: ");
                            adet = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ara Toplam : " + tarih * adet);
                            toplam = toplam + tarih * adet;
                            break;

                        case 5:
                            Console.Write("Felsefe Kitabı İçin Adet Giriniz: ");
                            adet = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ara Toplam : " + felsefe * adet);
                            toplam = toplam + felsefe * adet;
                            break;

                        case 6:
                            Console.Write("Biyografi Kitabı İçin Adet Giriniz: ");
                            adet = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ara Toplam : " + biyografi * adet);
                            toplam = toplam + biyografi * adet;
                            break;

                        case 8:
                            if (toplam < 400)
                            {
                                Console.WriteLine("Toplam : " + (toplam * 0.95) * 0.90);
                                Console.WriteLine("KDV : " + (toplam * 0.95) * 0.10);
                                Console.WriteLine("Genel Toplam :" + toplam * 0.95);
                            }
                            else if (toplam >= 400 && toplam < 1000)
                            {
                                Console.WriteLine("Toplam : " + (toplam * 0.90) * 0.90);
                                Console.WriteLine("KDV : " + (toplam * 0.90) * 0.10);
                                Console.WriteLine("Genel Toplam :" + toplam * 0.90);
                            }
                            else if (toplam >= 1000 && toplam < 2000)
                            {
                                Console.WriteLine("Toplam : " + (toplam * 0.85) * 0.90);
                                Console.WriteLine("KDV : " + (toplam * 0.85) * 0.10);
                                Console.WriteLine("Genel Toplam :" + toplam * 0.85);
                            }
                            else
                            {
                                Console.WriteLine("Toplam : " + (toplam * 0.75) * 0.90);
                                Console.WriteLine("KDV : " + (toplam * 0.75) * 0.10);
                                Console.WriteLine("Genel Toplam :" + toplam * 0.75);
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Hatalı değer girdiniz.");
                }

            }
            //Dışarıdan sipariş alınacak olan kitap miktarı girilsin. Sipariş sayısı 20 den az ise toplam ücretten %5 düşürülsün. 20-50 aralığında ise %10. 50-100 aralığında ise %15, 100 den fazla ise %25 indirim yapılsın. Kitabın birim fiyatı 20TL
        }
    }
}
