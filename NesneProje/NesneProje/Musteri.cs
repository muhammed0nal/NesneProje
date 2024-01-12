public class Musteri
{
    public string KullaniciAdi { get; set; }
    public string Sifre { get; set; }
    public string Ad { get; set; }
    public string Soyad { get; set; }

    public Musteri(string kullaniciAdi, string sifre, string ad, string soyad)
    {
        KullaniciAdi = kullaniciAdi;
        Sifre = sifre;
        Ad = ad;
        Soyad = soyad;
    }
}
