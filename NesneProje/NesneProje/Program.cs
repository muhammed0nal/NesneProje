using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Musteri> musteriler = new List<Musteri>();
    static List<Firma> firmalar = new List<Firma>();
    static List<Oy> oylar = new List<Oy>();
    static Musteri aktifMusteri = null;
    static Firma aktifFirma = null;

    static void Main()
    {
        //// Örnek müşteri ve firma oluştur
        musteriler.Add(new Musteri("1", "1", "Ad1", "Soyad1"));
        musteriler.Add(new Musteri("2", "2", "Ad2", "Soyad2"));

        firmalar.Add(new Firma("3", "3", "3"));
        firmalar.Add(new Firma("4", "4", "4"));

        while (true)
        {
            //Console.BackgroundColor = ConsoleColor.Yellow;
            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.Clear();



            Console.WriteLine("                    ----------------------------------------------------------------------                 ");
            Console.Write("                       |");
            Console.Write("                        Hoşgeldiniz...                        ");
            Console.WriteLine("|");
            Console.Write("                       |");
            Console.WriteLine("                                                              |");
            Console.Write("                       |");
            Console.Write("                       1. Müşteri Giriş");
            Console.WriteLine("                       |");
            Console.Write("                       |");
            Console.Write("                       2. Firma Giriş");
            Console.WriteLine("                         |");
            Console.Write("                       |");
            Console.Write("                       3. Oyları Listele");
            Console.WriteLine("                      |");
            Console.Write("                       |");
            Console.Write("                       4. Firmaları Listele");
            Console.WriteLine("                   |");
            Console.Write("                       |");
            Console.Write("                       5. Müşteri Kayıt");
            Console.WriteLine("                       |");
            Console.Write("                       |");
            Console.Write("                       6. Firma Kayıt");
            Console.WriteLine("                         |");
            Console.Write("                       |");
            Console.Write("                       7. Çıkış");
            Console.WriteLine("                               |");
            Console.Write("                       |");
            Console.WriteLine("                                                              |");
            Console.Write("                       |");
            Console.WriteLine("                                                              |");
            Console.WriteLine("                    ----------------------------------------------------------------------                 ");


            Console.Write("                         Seçim yapınız.(1-7): ");
            int secim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            switch (secim)
            {
                case 1:
                    MusteriGiris();
                    break;
                case 2:
                    FirmaGiris();
                    break;
                case 3:
                    OylariListele();
                    break;
                case 4:
                    FirmalariListele();
                    break;
                case 5:
                    MusteriKayit();
                    break;
                case 6:
                    FirmaKayit();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("                         Geçersiz seçenek. Tekrar deneyin.");

                    break;
            }
        }
    }

    static void MusteriGiris()
    {
        Console.Clear();
        Console.Write("                                   Kullanıcı Adı: ");
        string kullaniciAdi = Console.ReadLine();
        Console.Write("                                   Şifre: ");
        string sifre = Console.ReadLine();

        Musteri musteri = musteriler.FirstOrDefault(m => m.KullaniciAdi == kullaniciAdi && m.Sifre == sifre);

        if (musteri != null)
        {
            Console.Clear();
            aktifMusteri = musteri;
            MusteriMenu();
            Console.WriteLine();
            Console.WriteLine();

        }
        else
        {
            Console.WriteLine();
            Console.Clear();
            Console.WriteLine("                                   Geçersiz kullanıcı adı veya şifre.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    static void MusteriMenu()
    {
        while (true)
        {
            Console.WriteLine("                    ----------------------------------------------------------------------                 ");
            Console.Write("                       ");
            Console.Write($"                        Hoşgeldin {aktifMusteri.Ad}");
            Console.WriteLine("");
            Console.Write("                       |");
            Console.WriteLine("                                                             |");
            Console.Write("                       |");
            Console.Write("                        1. Oy Ver");
            Console.WriteLine("                            |");
            Console.Write("                       |");
            Console.Write("                        2. Oyları Listele");
            Console.WriteLine("                    |");
            Console.Write("                       |");
            Console.Write("                        3. Firmaları Listele");
            Console.WriteLine("                 |");
            Console.Write("                       |");
            Console.Write("                        4. Çıkış");
            Console.WriteLine("                             |");
            Console.Write("                       |");
            Console.WriteLine("                                                             |");
            Console.Write("                       |");
            Console.WriteLine("                                                             |");
            Console.WriteLine("                    ----------------------------------------------------------------------                 ");
            Console.Write("                         Seçim yapınız.(1-4): ");

            int secim = Convert.ToInt32(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    OyVer();
                    break;
                case 2:
                    KullaniciOylariListele();
                    break;
                case 3:
                    FirmalariListele();
                    break;
                case 4:
                    Console.Clear();
                    aktifMusteri = null;
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("                         Geçersiz seçenek. Tekrar deneyin.");
                    break;
            }
        }
    }

    static void OyVer()
    {
        Console.Clear();
        Console.WriteLine("                                   Oy Verme Sayfası");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("                                   Firma Adı: ");
        string firmaAdi = Console.ReadLine();
        Firma firma = firmalar.FirstOrDefault(f => f.Ad == firmaAdi);

        if (firma != null)
        {
            Console.WriteLine();
            Console.Write("                                   Soyadınız Gözüksün mü? (e/h): ");
            string soyadGosterilsin = Console.ReadLine();
            Console.WriteLine();


            double degerlendirme;
            while (true)
            {
                Console.WriteLine();
                Console.Write("                                   Değerlendirme (0-5): ");
                string degerlendirmeStr = Console.ReadLine();

                if (double.TryParse(degerlendirmeStr, out degerlendirme) && degerlendirme >= 0 && degerlendirme <= 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("                                   Geçersiz değer. Lütfen 0 ile 5 arasında bir sayı girin.");
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.Write("                                   Değerlendirme Notu: ");
            string degerlendirmeNotu = Console.ReadLine();
            Console.WriteLine();

            //string soyad = aktifMusteri.Soyad;

            //if (soyadGosterilsin.ToLower() == "h" && soyad.Length > 1)
            //{
            //    soyad = soyad.Substring(0, 1) + new string('*', soyad.Length - 1);
            //}

            Oy yeniOy = new Oy(aktifMusteri, firma, degerlendirme, soyadGosterilsin, degerlendirmeNotu);
            oylar.Add(yeniOy);

            Console.Clear();
            Console.WriteLine("                                   Oy başarıyla verildi.");
            Console.WriteLine();
            Console.WriteLine();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("                                   Firma bulunamadı. Lütfen geçerli bir firma adı girin.");
            Console.WriteLine();
            Console.WriteLine();
        }
    }



    static void OylariListele()
    {
        Console.Clear();
        foreach (var oy in oylar)
        {
            string oyGorunenSoyad = oy.SoyadGosterilsin.ToLower() == "h" && oy.Musteri.Soyad.Length > 1
                ? oy.Musteri.Soyad.Substring(0, 2) + new string('*', oy.Musteri.Soyad.Length - 2)
                : oy.Musteri.Soyad;
            Console.WriteLine();

            Console.WriteLine($"                         Müşteri: {oy.Musteri.Ad} {oyGorunenSoyad}, Firma: {oy.Firma.Ad}, Değerlendirme: {oy.Degerlendirme}, Not: {oy.DegerlendirmeNotu}");
        }
        Console.WriteLine();
    }

    static void KullaniciOylariListele()
    {
        Console.Clear();
        var kullaniciOylari = oylar.Where(o => o.Musteri == aktifMusteri);

        foreach (var oy in kullaniciOylari)
        {
            Console.WriteLine($"                         Firma: {oy.Firma.Ad}, Değerlendirme: {oy.Degerlendirme}, Not: {oy.DegerlendirmeNotu}");
        }
    }

    static void FirmaGiris()
    {
        Console.Clear();
        Console.Write("                                   Kullanıcı Adı: ");
        string kullaniciAdi = Console.ReadLine();
        Console.Write("                                   Şifre: ");
        string sifre = Console.ReadLine();

        Firma firma = firmalar.FirstOrDefault(f => f.KullaniciAdi == kullaniciAdi && f.Sifre == sifre);

        if (firma != null)
        {
            aktifFirma = firma;
            FirmaMenu();
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                   Geçersiz kullanıcı adı veya şifre.");
        }
    }

    static void FirmaMenu()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("                    ----------------------------------------------------------------------                 ");
            Console.Write("                       ");
            Console.WriteLine($"                        Hoşgeldin {aktifFirma.Ad}                          ");
            
            Console.Write("                       |");
            Console.WriteLine("                                                             |");
            Console.Write("                       |");
            Console.Write("                        1. Oyları Listele");
            Console.WriteLine("                    |");
            Console.Write("                       |");
            Console.Write("                        2. Firmaları Listele");
            Console.WriteLine("                 |");
            Console.Write("                       |");
            Console.Write("                        3. Çıkış");
            Console.WriteLine("                             |");
            Console.Write("                       |");
            Console.WriteLine("                                                             |");
            Console.Write("                       |");
            Console.WriteLine("                                                             |");
            Console.WriteLine("                    ----------------------------------------------------------------------                 ");
            Console.Write("                         Seçim yapınız.(1-3): ");
            int secim = Convert.ToInt32(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    FirmaOylariListele();
                    break;
                case 2:
                    FirmalariListele();
                    break;
                case 3:
                    aktifFirma = null;
                    return;
                default:
                    Console.WriteLine("                         Geçersiz seçenek. Tekrar deneyin.");
                    break;
            }
        }
    }

    static void FirmaOylariListele()
    {
        Console.Clear();
        var firmaOylari = oylar.Where(o => o.Firma == aktifFirma);

        foreach (var oy in firmaOylari)
        {
            string oyGorunenSoyad = oy.SoyadGosterilsin.ToLower() == "h" && oy.Musteri.Soyad.Length > 1
                ? oy.Musteri.Soyad.Substring(0, 2) + new string('*', oy.Musteri.Soyad.Length - 2)
                : oy.Musteri.Soyad;
            Console.WriteLine();

            Console.WriteLine($"                         Müşteri: {oy.Musteri.Ad} {oyGorunenSoyad}, Değerlendirme: {oy.Degerlendirme}, Not: {oy.DegerlendirmeNotu}");
        }
    }



    static void FirmalariListele()
    {
        Console.Clear();
        foreach (var firma in firmalar)
        {
            var firmaOylari = oylar.Where(o => o.Firma == firma);
            int oyVerenMusteriSayisi = firmaOylari.Select(o => o.Musteri).Count(); // Her bir müşteriyi bir kere say

            if (oyVerenMusteriSayisi > 0)
            {
                double ortalamaOy = firmaOylari.Average(o => o.Degerlendirme);
                Console.WriteLine($"                         Firma: {firma.Ad}, Oy Veren Müşteri Sayısı: {oyVerenMusteriSayisi}, Ortalama Oy: {ortalamaOy:F2}");
            }
            else
            {
                Console.WriteLine($"                         Firma: {firma.Ad}, Oy Veren Müşteri Sayısı: 0, Ortalama Oy: 0.00");
            }
        }
    }





    static void MusteriKayit()
    {
        Console.Clear();
        Console.Write("                                   İsim: ");
        string isim = Console.ReadLine();
        Console.Write("                                   Soyisim: ");
        string soyisim = Console.ReadLine();
        Console.Write("                                   Kullanıcı Adı: ");
        string kullaniciAdi = Console.ReadLine();
        Console.Write("                                   Şifre: ");
        string sifre = Console.ReadLine();

        // Hem müşteriler hem de firmalar arasında kullanıcı adı çakışması kontrolü
        if (musteriler.Any(m => m.KullaniciAdi == kullaniciAdi) || firmalar.Any(f => f.KullaniciAdi == kullaniciAdi))
        {
            Console.Clear();
            Console.WriteLine("                                   Bu kullanıcı adı zaten kullanımda. Başka bir kullanıcı adı seçin.");
            return;
        }

        Musteri yeniMusteri = new Musteri(kullaniciAdi, sifre, isim, soyisim);
        musteriler.Add(yeniMusteri);
        Console.Clear();
        Console.WriteLine("                                   Müşteri başarıyla kaydedildi.");
    }

    static void FirmaKayit()
    {
        Console.Clear();
        Console.Write("                                   Firma Adı: ");
        string firmaAdi = Console.ReadLine();
        Console.Write("                                   Kullanıcı Adı: ");
        string kullaniciAdi = Console.ReadLine();
        Console.Write("                                   Şifre: ");
        string sifre = Console.ReadLine();

        // Hem müşteriler hem de firmalar arasında kullanıcı adı çakışması kontrolü
        if (musteriler.Any(m => m.KullaniciAdi == kullaniciAdi) || firmalar.Any(f => f.KullaniciAdi == kullaniciAdi))
        {
            Console.Clear();
            Console.WriteLine("                                   Bu kullanıcı adı zaten kullanımda. Başka bir kullanıcı adı seçin.");
            return;
        }

        Firma yeniFirma = new Firma(kullaniciAdi, sifre, firmaAdi);
        firmalar.Add(yeniFirma);
        Console.Clear();
        Console.WriteLine("                                   Firma başarıyla kaydedildi.");
    }
}
