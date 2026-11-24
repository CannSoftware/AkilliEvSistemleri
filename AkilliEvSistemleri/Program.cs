using System;

enum CihazTuru
{
    Lamba = 1,
    Klima = 2,
    GuvenlikSistemi = 3
}

class Cihaz
{
    public int Kimlik { get; set; }
    public string Ad { get; set; }
    public CihazTuru Tur { get; set; }
    public bool AcikMi { get; set; }

    // Simdi constructor tanimlayalim
    public Cihaz(int kimlik, string ad, CihazTuru tur)
    {
        Kimlik = kimlik;
        Ad = ad;
        Tur = tur;
        AcikMi = false;
    }

    // Cihazi acma metodumuz
    public void Ac()
    {
        if (AcikMi == true)
        {
            Console.WriteLine("Bu cihaz zaten acik.");
        }
        else
        {
            AcikMi = true;
            Console.WriteLine(Ad + " acildi.");
        }
    }

    // Cihazi kapatma metodumuz
    public void Kapat()
    {
        if (AcikMi == false)
        {
            Console.WriteLine("Bu cihaz zaten kapali.");
        }
        else
        {
            AcikMi = false;
            Console.WriteLine(Ad + " kapatildi.");
        }
    }

    // Cihaz bilgilerini ekrana yazdirma
    public void BilgileriGoster()
    {
        Console.WriteLine("----------------------");
        Console.WriteLine("Kimlik: " + Kimlik);
        Console.WriteLine("Ad: " + Ad);
        Console.WriteLine("Tur: " + Tur);

        if (AcikMi == true)
        {
            Console.WriteLine("Durum: Acik");
        }
        else
        {
            Console.WriteLine("Durum: Kapali");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Cihazlari tutmak icin liste
        List<Cihaz> cihazlar = new List<Cihaz>();

        // Baslangicta bulunan cihazlar
        cihazlar.Add(new Cihaz(1, "Salon Lambasi", CihazTuru.Lamba));
        cihazlar.Add(new Cihaz(2, "Yatak Odasi Klimasi", CihazTuru.Klima));
        cihazlar.Add(new Cihaz(3, "Ev Alarmi", CihazTuru.GuvenlikSistemi));

        int secim = 0;

        while (secim != 5)
        {
            Console.WriteLine();
            Console.WriteLine("===== AKILLI EV SISTEMI =====");
            Console.WriteLine("1 - Cihazlari Listele");
            Console.WriteLine("2 - Yeni Cihaz Ekle");
            Console.WriteLine("3 - Cihaz Ac");
            Console.WriteLine("4 - Cihaz Kapat");
            Console.WriteLine("5 - Cikis");
            Console.Write("Seciminiz: ");

            if (!int.TryParse(Console.ReadLine(), out secim))
            {
                Console.WriteLine("Lutfen sayi giriniz.");
                continue;
            }

            if (secim == 1)
            {
                Console.WriteLine("\n--- CIHAZ LISTESI ---");

                foreach (Cihaz cihaz in cihazlar)
                {
                    cihaz.BilgileriGoster();
                }
            }
            else if (secim == 2)
            {
                Console.Write("Cihaz kimligi giriniz: ");
                int kimlik;

                if (!int.TryParse(Console.ReadLine(), out kimlik))
                {
                    Console.WriteLine("Gecersiz kimlik!");
                    continue;
                }

                bool varMi = false;

                foreach (Cihaz cihaz in cihazlar)
                {
                    if (cihaz.Kimlik == kimlik)
                    {
                        varMi = true;
                        break;
                    }
                }

                if (varMi == true)
                {
                    Console.WriteLine("Bu kimlige sahip cihaz zaten var!");
                }
                else
                {
                    Console.Write("Cihaz adi giriniz: ");
                    string ad = Console.ReadLine();

                    Console.WriteLine("Cihaz turunu seciniz:");
                    Console.WriteLine("1 - Lamba");
                    Console.WriteLine("2 - Klima");
                    Console.WriteLine("3 - Guvenlik Sistemi");
                    Console.Write("Tur: ");

                    int turSecimi;

                    if (!int.TryParse(Console.ReadLine(), out turSecimi)
                        || turSecimi < 1 || turSecimi > 3)
                    {
                        Console.WriteLine("Gecersiz cihaz turu!");
                        continue;
                    }

                    Cihaz yeniCihaz = new Cihaz(
                        kimlik,
                        ad,
                        (CihazTuru)turSecimi
                    );

                    cihazlar.Add(yeniCihaz);

                    Console.WriteLine("Yeni cihaz eklendi.");
                }
            }
            else if (secim == 3)
            {
                Console.Write("Acilacak cihazin kimligi: ");
                int kimlik;

                if (!int.TryParse(Console.ReadLine(), out kimlik))
                {
                    Console.WriteLine("Gecersiz kimlik!");
                    continue;
                }

                Cihaz bulunanCihaz = null;

                foreach (Cihaz cihaz in cihazlar)
                {
                    if (cihaz.Kimlik == kimlik)
                    {
                        bulunanCihaz = cihaz;
                        break;
                    }
                }

                if (bulunanCihaz != null)
                {
                    bulunanCihaz.Ac();
                }
                else
                {
                    Console.WriteLine("Boyle bir cihaz bulunamadi!");
                }
            }
            else if (secim == 4)
            {
                Console.Write("Kapatilacak cihazin kimligi: ");
                int kimlik;

                if (!int.TryParse(Console.ReadLine(), out kimlik))
                {
                    Console.WriteLine("Gecersiz kimlik!");
                    continue;
                }

                Cihaz bulunanCihaz = null;

                foreach (Cihaz cihaz in cihazlar)
                {
                    if (cihaz.Kimlik == kimlik)
                    {
                        bulunanCihaz = cihaz;
                        break;
                    }
                }

                if (bulunanCihaz != null)
                {
                    bulunanCihaz.Kapat();
                }
                else
                {
                    Console.WriteLine("Boyle bir cihaz bulunamadi!");
                }
            }
            else if (secim == 5)
            {
                Console.WriteLine("Program kapatiliyor...");
            }
            else
            {
                Console.WriteLine("Gecersiz secim yaptiniz!");
            }
        }
    }
}