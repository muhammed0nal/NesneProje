using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;

class Program
{
    // listeler
    static List<Musteri> musteriler = new List<Musteri>();
    static List<Firma> firmalar = new List<Firma>();
    static List<Oy> oylar = new List<Oy>();
    static Musteri aktifMusteri = null;
    static Firma aktifFirma = null;

    static void Main()
    {
        //// Örnek müşteri ve firma oluştur
        //musteriler.Add(new Musteri("1", "1", "Ad1", "Soyad1"));
        //musteriler.Add(new Musteri("2", "2", "Ad2", "Soyad2"));

        //firmalar.Add(new Firma("3", "3", "3","tuzla"));
        //firmalar.Add(new Firma("4", "4", "4","tuzla"));

        while (true)
        {
            //  anasayfa seçimler

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
            
            // girilen deger int'e çevriliyorsa ve secim 1 ve 7 arasında ise
            if (int.TryParse(Console.ReadLine(), out int secim) && secim >= 1 && secim <= 7)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                // seçimlerin switch case yapısı
                switch (secim)
                {
                    case 1:
                        Console.Clear();
                        MusteriGiris();
                        break;
                    case 2:
                        Console.Clear();
                        FirmaGiris();
                        break;
                    case 3:
                        Console.Clear();
                        OylariListele();
                        break;
                    case 4:
                        Console.Clear();
                        FirmalariListele();
                        break;
                    case 5:
                        Console.Clear();
                        MusteriKayit();
                        break;
                    case 6:
                        Console.Clear();
                        FirmaKayit();
                        break;
                    case 7:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("                         Geçersiz seçenek. Tekrar deneyin.");
                        break;
                }
            }

            // girilen deger int'e çevrilemiyorsa ve secim 1 ve 7 arasında değilse
            else
            {
                Console.Clear();
                Console.WriteLine("                         Geçersiz giriş. Lütfen 1 ile 7 arasında bir sayı seçin.");
            }
        }
    }

    // musteri girişi başarılı ise çalışan fonksiyon
    static void MusteriGiris()
    {
        
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("                                   Müşteri Giriş Ekranı");
        Console.WriteLine("");
        Console.Write("                                   Kullanıcı Adı: ");
        string kullaniciAdi = Console.ReadLine();
        Console.Write("                                   Şifre: ");
        string sifre = SifreGizleme(); // girilen şifre değerini (*) şeklinde göstermek için fonksiyon 

        // musteriler içinde ki kullanıcı adı ve şifrelerle girilen kullanıcı adı ve şifre eşleşmiyorsa null,
        // eşleşiyorsa eşleşen musteri objesi atanır
        Musteri musteri = musteriler.FirstOrDefault(m => m.KullaniciAdi == kullaniciAdi && m.Sifre == sifre);

        // musteriler içinde ki kullanıcı adı ve şifre girilen kullanıcı adı ve şifre ile eşleşiyor
        if (musteri != null)
        {
            Console.Clear();
            aktifMusteri = musteri;      // aktifmusteriye, musteri objesi atanır
            MusteriMenu();
            Console.WriteLine();
            Console.WriteLine();
        }
        
        // musteriler içinde ki kullanıcı adı ve şifre girilen kullanıcı adı ve şifre ile eşleşmiyor
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


    // müşteri girişi başarılı olursa çalışan fonkaiyon
    static void MusteriMenu()
    {
        // müşteri menü seçenekler
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
            Console.Write("                        4. Oy Sil");
            Console.WriteLine("                            |");
            Console.Write("                       |");
            Console.Write("                        5. Hesabı sil");
            Console.WriteLine("                        |");
            Console.Write("                       |");
            Console.Write("                        6. Çıkış");
            Console.WriteLine("                             |");
            Console.Write("                       |");
            Console.WriteLine("                                                             |");
            Console.Write("                       |");
            Console.WriteLine("                                                             |");
            Console.WriteLine("                    ----------------------------------------------------------------------                 ");
            Console.Write("                         Seçim yapınız.(1-5): ");


            // girilen deger int'e çevriliyorsa ve secim 1 ve 5 arasında ise 
            if (int.TryParse(Console.ReadLine(), out int secim) && secim >= 1 && secim <= 6)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                // musteri menu seçeneklerini switch-case'i
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
                        OySil();
                        break;
                    case 5:     
                        Console.WriteLine();
                        Console.Clear();
                        Console.Write("                                   Emin misin?");

                        // silme seçeneğine tıklanırsa emin misin diye sor
                        // evet seçilise sil ve ana erkana döne.
                        // hayır seçilirse musteri menu ekranına dön

                        string eminMisin = Console.ReadLine();
                        if (eminMisin == "e")
                        {
                            MusteriSil(aktifMusteri);
                            aktifMusteri = null;
                            Console.Clear();
                            Console.WriteLine("                                   Hesabınız başarıyla silindi.");
                            return;
                        }
                        break;

                    case 6:
                        Console.Clear();
                        aktifMusteri = null;
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("                         Geçersiz giriş. Lütfen 1 ile 6 arasında bir sayı seçin");
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("                         Geçersiz giriş. Lütfen 1 ile 6 arasında bir sayı seçin.");
            }
        }
    }

    // oy verme ekranı
    static void OyVer()
    {
        Console.Clear();
        Console.WriteLine("                                   Oy Verme Sayfası");
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("                                   Firma Adı: ");
        string firmaAdi = Console.ReadLine();

        // oy verilecek firma ismi firmalar listesinde yoksa null atar
        Firma firma = firmalar.FirstOrDefault(f => f.Ad == firmaAdi);

        if (firma != null)
        {
            string soyadGosterilsin;
            while (true)
            {
                Console.WriteLine();
                Console.Write("                                   Soyadınız Gözüksün mü? (e/h): ");
                soyadGosterilsin = Console.ReadLine();
                Console.WriteLine();

                // gizlilik için oylar listelendiğinde soyadın gözüksün mü sorusu 
                // e ve h dışında bir değer girilirse hata ver

                if (soyadGosterilsin.ToLower() == "e" || soyadGosterilsin.ToLower() == "h") {
                    break;
                }
                else
                {
                    Console.Clear() ;
                    Console.WriteLine("                                   Geçersiz değer. Lütfen e veya h girin.");
                }
            }


            double degerlendirme;
            while (true)
            {
                Console.WriteLine();
                Console.Write("                                   Değerlendirme (0-5): ");
                string degerlendirmeStr = Console.ReadLine();

                // değerlendirme double'a çevriliyorsa ve değerlendirme 0-ile 5 araında ise
                if (double.TryParse(degerlendirmeStr, out degerlendirme) && degerlendirme >= 0 && degerlendirme <= 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.Clear();
                    Console.WriteLine("                                   Geçersiz değer. Lütfen 0 ile 5 arasında bir sayı girin.");
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.Write("                                   Değerlendirme Notu: ");
            string degerlendirmeNotu = Console.ReadLine();
            Console.WriteLine();


            Oy yeniOy = new Oy(aktifMusteri, firma, degerlendirme, soyadGosterilsin, degerlendirmeNotu);
            oylar.Add(yeniOy);

            Console.Clear();
            Console.WriteLine("                                   Oy başarıyla verildi.");
            Console.WriteLine();
            Console.WriteLine();
        }
        else
        {
            // firma ismi mevcut değilse
            Console.Clear();
            Console.WriteLine("                                   Firma bulunamadı. Lütfen geçerli bir firma adı girin.");
            Console.WriteLine();
            Console.WriteLine();
        }
    }



    // oyları listeleme 
    static void OylariListele()
    {
        // oy yoksa 

        Console.Clear();
        if(oylar.Count() == 0) { 
            Console.WriteLine("                         Oy bulunmamaktadır.");
        }
        else  // oy varsa
        {
            // oylar listesinde ki tüm objeler tek tek çağrılır
            foreach (var oy in oylar)
            {
                // gelen oy objelerinde ki soyadgösterilsin mi değerine göre soyadları (*) lanır.
                string oyGorunenSoyad = oy.SoyadGosterilsin.ToLower() == "h" && oy.Musteri.Soyad.Length > 1
                    ? oy.Musteri.Soyad.Substring(0, 2) + new string('*', oy.Musteri.Soyad.Length - 2)
                    : oy.Musteri.Soyad;
                Console.WriteLine();

                Console.WriteLine($"                         Müşteri: {oy.Musteri.Ad} {oyGorunenSoyad}, Firma: {oy.Firma.Ad}, Değerlendirme: {oy.Degerlendirme}, Not: {oy.DegerlendirmeNotu}");
            }
        }
        
        Console.WriteLine();
    }

    // müşteri sayfasında sadece kendi verdiği oyları listeyebilir
    static void KullaniciOylariListele()
    {
        Console.Clear();

        // oylarda ki müşteriler arasında aktif olan müşteri seçilir ve kullanıcı oylarına atanır

        var kullaniciOylari = oylar.Where(o => o.Musteri == aktifMusteri);
        if (kullaniciOylari.Count() == 0)
        {
            // müşterinin hiç oyu yoksa

            Console.WriteLine("                         Mevcut müşterinin oyu bulunmamaktadır.");
        }
        else
        {
            Console.WriteLine($"                         {aktifMusteri.KullaniciAdi}'in oyları");
            foreach (var oy in kullaniciOylari)
            {
                Console.WriteLine($"                         Firma: {oy.Firma.Ad}, Değerlendirme: {oy.Degerlendirme}, Not: {oy.DegerlendirmeNotu}");
            }
        }
        
    }

    // firma giriş ekranı
    static void FirmaGiris()
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("                                   Firma Giriş Ekranı");
        Console.WriteLine("");
        Console.Write("                                   Kullanıcı Adı: ");
        string kullaniciAdi = Console.ReadLine();
        Console.Write("                                   Şifre: ");
        string sifre = SifreGizleme();   // girilen şifre değerini (*) şeklinde göstermek için fonksiyon 

        // firmalar içinde ki kullanıcı adı ve şifrelerle girilen kullanıcı adı ve şifre eşleşmiyorsa null,
        // eşleşiyorsa eşleşen firma objesi atanır

        Firma firma = firmalar.FirstOrDefault(f => f.KullaniciAdi == kullaniciAdi && f.Sifre == sifre);

        // firmalar içinde ki kullanıcı adı ve şifre girilen kullanıcı adı ve şifre ile eşleşm-iyor
        if (firma != null)
        {
            aktifFirma = firma;
            FirmaMenu();
        }
        else
        {
            // firmalar içinde ki kullanıcı adı ve şifre girilen kullanıcı adı ve şifre ile eşleşmiyor
            Console.WriteLine();
            Console.WriteLine();
            Console.Clear();
            Console.WriteLine("                                   Geçersiz kullanıcı adı veya şifre.");
        }
    }

    // firma menüsü
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
            Console.Write("                        3. Hesabı Sil");
            Console.WriteLine("                        |");
            Console.Write("                       |");
            Console.Write("                        4. Çıkış");
            Console.WriteLine("                             |");
            Console.Write("                       |");
            Console.WriteLine("                                                             |");
            Console.Write("                       |");
            Console.WriteLine("                                                             |");
            Console.WriteLine("                    ----------------------------------------------------------------------                 ");
            Console.Write("                         Seçim yapınız.(1-4): ");


            if (int.TryParse(Console.ReadLine(), out int secim) && secim >= 1 && secim <= 7)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                switch (secim)
                {
                    case 1:
                        FirmaOylariListele();
                        break;
                    case 2:
                        FirmalariListele();
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.Clear();
                        Console.Write("                                   Emin misin?");

                        string eminMisin = Console.ReadLine();
                        if (eminMisin == "e")
                        {
                            FirmaSil(aktifFirma);
                            aktifFirma = null;
                            Console.Clear();
                            Console.WriteLine("                                   Hesabınız başarıyla silindi.");
                            return;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        aktifFirma = null;
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("                         Geçersiz seçenek. Tekrar deneyin.");
                        break;
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("                         Geçersiz giriş. Lütfen 1 ile 4 arasında bir sayı seçin.");
            }


        }
        
    }

    static void FirmaOylariListele()
    {
        Console.Clear();
        var firmaOylari = oylar.Where(o => o.Firma == aktifFirma);

        if(firmaOylari.Count()==0)
        {
            Console.WriteLine("                         Firma için oy bulunmamaktadır.");
        }
        else
        {
            Console.WriteLine($"                         {aktifFirma.KullaniciAdi}'in aldığı oyları");
            foreach (var oy in firmaOylari)
            {
                string oyGorunenSoyad = oy.SoyadGosterilsin.ToLower() == "h" && oy.Musteri.Soyad.Length > 1
                    ? oy.Musteri.Soyad.Substring(0, 2) + new string('*', oy.Musteri.Soyad.Length - 2)
                    : oy.Musteri.Soyad;
                Console.WriteLine();

                Console.WriteLine($"                         Müşteri: {oy.Musteri.Ad} {oyGorunenSoyad}, Değerlendirme: {oy.Degerlendirme}, Not: {oy.DegerlendirmeNotu}");
            }
        }
    }



    static void FirmalariListele()
    {
        Console.Clear();
        if(!(firmalar.Count()==0))
        {
            foreach (var firma in firmalar)
            {
                var firmaOylari = oylar.Where(o => o.Firma == firma);
                int oyVerenMusteriSayisi = firmaOylari.Select(o => o.Musteri).Count();

                if (oyVerenMusteriSayisi > 0)
                {
                    double ortalamaOy = firmaOylari.Average(o => o.Degerlendirme);
                    Console.WriteLine($"                         Firma: {firma.Ad}, Oy Veren Müşteri Sayısı: {oyVerenMusteriSayisi}, Ortalama Oy: {ortalamaOy:F2}, Adres: {firma.Adres}");
                }
                else
                {
                    Console.WriteLine($"                         Firma: {firma.Ad}, Oy Veren Müşteri Sayısı: 0, Ortalama Oy: 0.00, Adres: {firma.Adres}");
                }
            }
        }
        else
        {
            Console.WriteLine("                         Listelenecek firma yok.");
        }
        
    }





    static void MusteriKayit()
    {
        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("                                   Müşteri Kayıt Ekranı");
            Console.WriteLine("");
            // tüm girdilerin kontrolleri yapılmıştır.
            Console.Write("                                   İsim: ");
            string isim = Console.ReadLine();
            if (string.IsNullOrEmpty(isim) || !StringDegerMi(isim))
            {
                Console.Clear() ;   
                Console.WriteLine("                                   İsim boş olamaz veya geçersiz karakter içeriyor. Lütfen tekrar girin.");
                continue;
            }
            Console.Write("                                   Soyisim: ");
            string soyisim = Console.ReadLine();
            if (string.IsNullOrEmpty(soyisim) || !StringDegerMi(soyisim))
            {
                Console.Clear();
                Console.WriteLine("                                   Soyisim boş olamaz veya geçersiz karakter içeriyor. Lütfen tekrar girin.");
                continue;
            }
            Console.Write("                                   Kullanıcı Adı: ");
            string kullaniciAdi = Console.ReadLine();
            if (string.IsNullOrEmpty(kullaniciAdi) || kullaniciAdi.Length <= 5)
            {
                Console.Clear();
                Console.WriteLine("                                   Kullanıcı adı boş olamaz ve en az 6 karakter olmalıdır. Lütfen tekrar girin.");
                continue;
            }
            Console.Write("                                   Şifre: ");
            string sifre = SifreGizleme();
            if (string.IsNullOrEmpty(sifre) || sifre.Length <= 8)
            {
                Console.Clear();
                Console.WriteLine("                                   Şifre boş olamaz ve en az 9 karakter olmalıdır. Lütfen tekrar girin.");
                continue;
            }

            // Hem müşteriler hem de firmalar arasında kullanıcı adı çakışması kontrolü
            if (musteriler.Any(m => m.KullaniciAdi == kullaniciAdi) || firmalar.Any(f => f.KullaniciAdi == kullaniciAdi))
            {
                // firmalarda girilen kullanıcı adı varsa true döner
                Console.Clear();
                Console.WriteLine("                                   Bu kullanıcı adı zaten kullanımda. Başka bir kullanıcı adı seçin.");
                continue;
            }

            Musteri yeniMusteri = new Musteri(kullaniciAdi, sifre, isim, soyisim);
            musteriler.Add(yeniMusteri);


            //   burada hata aldım ve sorunu çözemedim. gmail hesabının güvenliğiyle alakalı bir sorun
            // oluşuyor muhtemelen

            //try
            //{
            //    MailMessage mail = new MailMessage();
            //    SmtpClient smtpServer = new SmtpClient("smtp.yourprovider.com");

            //    mail.From = new MailAddress("mamimami7272mami@gmail.com");
            //    mail.To.Add("mamimami7272mami@gmail.com"); // Yeni müşterinin e-posta adresi olarak kullanabilirsiniz.
            //    mail.Subject = "Hoş Geldiniz!";
            //    mail.Body = "Merhaba " + isim + ",\n\n kayıt işleminiz başarılı. Hoşgeldiniz.";

            //    smtpServer.Port = 587;
            //    smtpServer.Credentials = new NetworkCredential("mamimami7272mami@gmail.com", "Kamilkoc7272.");
            //    smtpServer.EnableSsl = true;

            //    smtpServer.Send(mail);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("E-posta gönderme hatası: " + ex.Message);
            //}

            Console.Clear();
            Console.WriteLine("                                   Müşteri başarıyla kaydedildi.");
            break;
        }
    }

    static void FirmaKayit()
    {
        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("                                   Firma Kayıt Ekranı");
            Console.WriteLine("");
            Console.Write("                                   Firma Adı: ");
            string firmaAdi = Console.ReadLine();
            
            if (firmalar.Any(f => f.Ad == firmaAdi))
            {
                Console.Clear();
                Console.WriteLine("                                   Bu firma adı zaten kullanımda. Başka bir firma adı seçin.");
                continue;
            }
            if (firmaAdi.Length > 0)
            {
                Console.Clear();
                Console.WriteLine("                                   Bu firma adı çok kısa. Başka bir firma adı seçin.");
                continue;
            }

            Console.Write("                                   Firma Adresi: ");
            string firmaAdresi = Console.ReadLine();

            if (firmaAdresi.Length < 10)
            {
                Console.Clear();
                Console.WriteLine("Adres çok kısa.");
                continue;
            }

            Console.Write("                                   Kullanıcı Adı: ");
            string kullaniciAdi = Console.ReadLine();
            
            // Hem müşteriler hem de firmalar arasında kullanıcı adı çakışması kontrolü
            if (string.IsNullOrEmpty(kullaniciAdi) || kullaniciAdi.Length <= 5)
            {
                Console.Clear();
                Console.WriteLine("                                   Kullanıcı adı boş olamaz ve en az 6 karakter olmalıdır. Lütfen tekrar girin.");
                continue;
            } 
            if (musteriler.Any(m => m.KullaniciAdi == kullaniciAdi) || firmalar.Any(f => f.KullaniciAdi == kullaniciAdi))
            {
                Console.Clear();
                Console.WriteLine("                                   Bu kullanıcı adı zaten kullanımda. Başka bir kullanıcı adı seçin.");
                continue;
            }
            Console.Write("                                   Şifre: ");
            string sifre = SifreGizleme();
            if (string.IsNullOrEmpty(sifre) || sifre.Length <= 8)
            {
                Console.Clear();
                Console.WriteLine("                                   Şifre boş olamaz ve en az 9 karakter olmalıdır. Lütfen tekrar girin.");
                continue;
            }

            
         

            
            //   burada hata aldım ve sorunu çözemedim. gmail hesabının güvenliğiyle alakalı bir sorun
            // oluşuyor muhtemelen

            //try
            //1{
            //    MailMessage mail = new MailMessage();
            //    SmtpClient smtpServer = new SmtpClient("smtp.yourprovider.com");

            //    mail.From = new MailAddress("mamimami7272mami@gmail.com");
            //    mail.To.Add("mamimami7272mami@gmail.com"); // Yeni müşterinin e-posta adresi olarak kullanabilirsiniz.
            //    mail.Subject = "Hoş Geldiniz!";
            //    mail.Body = "Merhaba " + firmaAdi + ",\n\n kayıt işleminiz başarılı. Hoşgeldiniz.";

            //    smtpServer.Port = 587;
            //    smtpServer.Credentials = new NetworkCredential("mail", "sifre.");
            //    smtpServer.EnableSsl = true;

            //    smtpServer.Send(mail);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("E-posta gönderme hatası: " + ex.Message);
            //}


            Firma yeniFirma = new Firma(kullaniciAdi, sifre, firmaAdi,firmaAdresi);
            firmalar.Add(yeniFirma);
            Console.Clear();
            Console.WriteLine("                                   Firma başarıyla kaydedildi."); 
            break;
        }
    }


    
    // kayıt ve giriş sırasında kullanıcı şifre girerken şifreyi (*)'layan fonksşyon
    static string SifreGizleme()
    {
        string password = "";
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);

            // Backspace'i kontrol et
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
        }
        while (key.Key != ConsoleKey.Enter);

        Console.WriteLine(); // Enter tuşuna basıldığında yeni satıra geç
        return password;
    }


    static void MusteriSil(Musteri musteri)
    {
        musteriler.Remove(musteri);
        // Oyları da temizleme
        oylar.RemoveAll(oy => oy.Musteri == musteri);
    }

    static void FirmaSil(Firma firma)
    {
        firmalar.Remove(firma);
        // Oyları da temizleme
        oylar.RemoveAll(oy => oy.Firma == firma);
    }

    static bool StringDegerMi(string value)
    {
        return !value.Any(char.IsDigit); // Sadece harf içeriyorsa true döndürür.
    }


    static void OySil()
    {
        
        Console.Clear();
        int silinecekOySirasi = 0;
        var kullaniciOylari = oylar.Where(o => o.Musteri == aktifMusteri);
        if (kullaniciOylari.Count() == 0)
        {
            // müşterinin hiç oyu yoksa

            Console.WriteLine("                         Mevcut müşterinin oyu bulunmamaktadır.");
        }
        else
        {
            Console.WriteLine($"                         {aktifMusteri.KullaniciAdi}'in oyları");
            foreach (var oy in kullaniciOylari)
            {
                silinecekOySirasi++;
                Console.WriteLine(silinecekOySirasi);
                Console.WriteLine($"                         {silinecekOySirasi}) Firma: {oy.Firma.Ad}, Değerlendirme: {oy.Degerlendirme}, Not: {oy.DegerlendirmeNotu}");
            }
            Console.Write("                         Silmek istediğiniz oyu seçin: ");
            string secim = Console.ReadLine();
            if(!(int.TryParse(secim, out int secim_)))
            {
                Console.Clear();
                Console.WriteLine("                         Yanlış seçim. Sayı ve doğru aralıkta değer gir..");
            }else if( secim_ < 1)
            {
                Console.Clear();
                Console.WriteLine("                         Yanlış seçim. Sayı ve doğru aralıkta değer gir..");
            }else if(secim_>silinecekOySirasi){
                Console.WriteLine("                         Yanlış seçim. Sayı ve doğru aralıkta değer gir..");
            }else if (secim.Length <=0)
            {
                Console.WriteLine("                         Yanlış seçim. Sayı ve doğru aralıkta değer gir..");
            }
            else
            {
                Oy silinecekOy = oylar[secim_ - 1];
                oylar.Remove(silinecekOy);
                Console.Clear();
                Console.WriteLine("                         Oy başarıyla silindi.");
            }
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
    }
}

