public class Oy
{
    public Musteri Musteri { get; set; }
    public Firma Firma { get; set; }
    public double Degerlendirme { get; set; }
    public string SoyadGosterilsin { get; set; }
    public string DegerlendirmeNotu { get; set; }

    public Oy(Musteri musteri, Firma firma, double degerlendirme, string soyadGosterilsin, string degerlendirmeNotu)
    {
        Musteri = musteri;
        Firma = firma;
        Degerlendirme = degerlendirme;
        SoyadGosterilsin = soyadGosterilsin;
        DegerlendirmeNotu = degerlendirmeNotu;
    }
}

