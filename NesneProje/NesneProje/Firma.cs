public class Firma
{
    public string KullaniciAdi { get; set; }
    public string Sifre { get; set; }
    public string Ad { get; set; }

    public Firma(string kullaniciAdi, string sifre, string ad)
    {
        KullaniciAdi = kullaniciAdi;
        Sifre = sifre;
        Ad = ad;
    }
}
