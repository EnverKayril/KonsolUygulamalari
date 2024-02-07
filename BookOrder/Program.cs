using System;

namespace BookOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Birim Fiyatları
            double siir = 18;
            double cocuk = 15;
            double roman = 22;
            double tarih = 20;
            double felsefe = 17;
            double biyografi = 14;
            int secim = 0;
            uint adet = 0;
            double toplam = 0;
            double KDV = 0.10;
            double KDVsizFiyat = 0.90;
            double indirim = 0;


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
                            adet = Convert.ToUInt32(Console.ReadLine());
                            Console.WriteLine("Ara Toplam : " + siir * adet);
                            toplam = toplam + siir * adet;
                            break;

                        case 2:
                            Console.Write("Çocuk Kitabı İçin Adet Giriniz: ");
                            adet = Convert.ToUInt32(Console.ReadLine());
                            Console.WriteLine("Ara Toplam : " + cocuk * adet);
                            toplam = toplam + cocuk * adet;
                            break;

                        case 3:
                            Console.Write("Roman İçin Adet Giriniz: ");
                            adet = Convert.ToUInt32(Console.ReadLine());
                            Console.WriteLine("Ara Toplam : " + roman * adet);
                            toplam = toplam + roman * adet;
                            break;

                        case 4:
                            Console.Write("Tarih Kitabı İçin Adet Giriniz: ");
                            adet = Convert.ToUInt32(Console.ReadLine());
                            Console.WriteLine("Ara Toplam : " + tarih * adet);
                            toplam = toplam + tarih * adet;
                            break;

                        case 5:
                            Console.Write("Felsefe Kitabı İçin Adet Giriniz: ");
                            adet = Convert.ToUInt32(Console.ReadLine());
                            Console.WriteLine("Ara Toplam : " + felsefe * adet);
                            toplam = toplam + felsefe * adet;
                            break;

                        case 6:
                            Console.Write("Biyografi Kitabı İçin Adet Giriniz: ");
                            adet = Convert.ToUInt32(Console.ReadLine());
                            Console.WriteLine("Ara Toplam : " + biyografi * adet);
                            toplam = toplam + biyografi * adet;
                            break;

                        case 8:
                            if (toplam < 400)
                            {
                                indirim = 0.95;
                                Console.WriteLine("Toplam : " + (toplam * indirim) * KDVsizFiyat);
                                Console.WriteLine("KDV : " + (toplam * indirim) * KDV);
                                Console.WriteLine("Genel Toplam :" + toplam * indirim);
                            }
                            else if (toplam >= 400 && toplam < 1000)
                            {
                                indirim = 0.90;
                                Console.WriteLine("Toplam : " + (toplam * indirim) * KDVsizFiyat);
                                Console.WriteLine("KDV : " + (toplam * indirim) * KDV);
                                Console.WriteLine("Genel Toplam :" + toplam * indirim);
                            }
                            else if (toplam >= 1000 && toplam < 2000)
                            {
                                indirim = 0.85;
                                Console.WriteLine("Toplam : " + (toplam * indirim) * KDVsizFiyat);
                                Console.WriteLine("KDV : " + (toplam * indirim) * KDV);
                                Console.WriteLine("Genel Toplam :" + toplam * indirim);
                            }
                            else
                            {
                                indirim = 0.75;
                                Console.WriteLine("Toplam : " + (toplam * indirim) * KDVsizFiyat);
                                Console.WriteLine("KDV : " + (toplam * indirim) * KDV);
                                Console.WriteLine("Genel Toplam :" + toplam * indirim);
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
