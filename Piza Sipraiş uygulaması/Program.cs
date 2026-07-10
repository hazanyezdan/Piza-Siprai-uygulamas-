using PizzaMatik.Decorators;
using PizzaMatik.Enums;
using PizzaMatik.Models;
using PizzaMatik.Services;
using System;using System.Collections.Generic; // Dictionary yapısını kullanabilmek için şart!
using System.Text.RegularExpressions;

namespace PizzaMatik
{
    class Program
    {
        // 1. ADIM: Sınıf seviyesinde (class içinde ama metotların dışında) tanımlıyoruz
        static Dictionary<int, Pizza> tumSiparisler = new Dictionary<int, Pizza>();
       
        static Random rastgele = new Random();
        static string isim;
        static string telefon;

        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen İsminizi Yazın");
             isim = Console.ReadLine();

            // İŞTE EKSİK OLAN KISIM BURASI:
            telefon = TelefonNumarasiAl();

            //sipariş yöneticimizi başlatıyoruz
            SiparisYonetici siparisYoneticisi = new SiparisYonetici();
            bool uygulamaCalisiyor = true;
            Console.WriteLine("=================================================");
            Console.WriteLine($"MERHABA {isim} PIZZAMATIK OTOMASYONUNA HOŞGELDİN");
            Console.WriteLine("=================================================");
            while (uygulamaCalisiyor)
            {
                Console.WriteLine("\n ----ANA MENU----");
                Console.WriteLine("1.Yeni Pizza Siparişi Oluştur");
                Console.WriteLine("2. Sipariş Numarası ile Sorgula");
                Console.WriteLine("3. Sipariş Özetini Gör ");
                Console.WriteLine("4.Çıkış");
                Console.Write("Seçiminiz: ");
                

                if (!int.TryParse(Console.ReadLine(), out int anaSecim))
                {
                    Console.WriteLine("Lütfen geçerli bir sayı giriniz!");
                    continue;
                }
                switch (anaSecim)
                {
                    case 1:
                        Pizza yeniPizza = PizzaSecimSureci(siparisYoneticisi);

                        if (yeniPizza != null)
                        {
                            int siparisNo = rastgele.Next(100000, 999999);

                            //sözlüğe kaydediyoruz
                            tumSiparisler.Add(siparisNo, yeniPizza);

                            Console.WriteLine("\n=================================================");
                            Console.WriteLine($"Siparişiniz Başarıyla Alındı!");
                            Console.WriteLine($"SİPARİŞ NUMARANIZ: {siparisNo}");
                            Console.WriteLine("Lütfen bu numarayı not ediniz.");
                            Console.WriteLine("=================================================");
                        }
                        break;
                    case 2:
                        SiparisSorgula();
                        break;

                    case 3:
                        //Doğrudan fatura basma ve uygulama kapama
                        siparisYoneticisi.FaturaYazdir();
                        //uygulamaCalisiyor = false;
                        break;
                    case 4:
                        uygulamaCalisiyor = false;
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim!Lütfen 1 ve 2  yazınız.");
                        break;

                }
            }
            Console.WriteLine("\nKapatmak için tuşa basın");
            Console.ReadKey();

        }
        static string TelefonNumarasiAl()
        {
            while (true)
            {
                Console.WriteLine("\nLütfen Telefon Numaranızı Giriniz (örn: 05xxxxxxxxx):");
                string telNo = Console.ReadLine()?.Trim(); // Kullanıcının girdiğini aldık

                // Hata buradaydı: 'numara' değil 'telNo' kontrol edilmeli
                if (Regex.IsMatch(telNo, @"^0[5]\d{9}$"))
                {
                    return telNo; // Doğruysa direkt numarayı dön ve bitir
                }

                Console.WriteLine("Hata: Geçersiz telefon numarası! Başında 0 olacak şekilde 11 hane giriniz.");
            }
        }

        static Pizza PizzaSecimSureci(SiparisYonetici yonetici)
        {
            Pizza secilenPizza = null;
            //pizza seçim adımı
            while (secilenPizza == null)
            {
                Console.WriteLine("\nPizza Tabanı seçin:");
                Console.WriteLine("1.Margarita");
                Console.WriteLine("2.Pepperoni");
                Console.WriteLine("Seciminiz:");
                if (int.TryParse(Console.ReadLine(), out int pizzaSecim))
                {
                    if (pizzaSecim == 1) secilenPizza = new Margarita();
                    else if (pizzaSecim == 2) secilenPizza = new Pepperoni();
                    else Console.WriteLine("Geçersiz pizza secimi!");

                }
                else Console.WriteLine("Lütfen sadece sayı giriniz!");

            }
            //Boyut Secimi 
            bool boyutSecildi = false;
            while (!boyutSecildi)
            {
                Console.WriteLine("\nPizza Boyutu Secin:");
                Console.WriteLine("1.Küçük");
                Console.WriteLine("2.Orta");
                Console.WriteLine("3.Büyük");
                Console.WriteLine("Seciminiz");

                if (int.TryParse(Console.ReadLine(), out int boyutSecim))
                {
                    if (boyutSecim == 1) { secilenPizza.Boyut = PizzaBoyutu.Kucuk; boyutSecildi = true; }
                    else if (boyutSecim == 2) { secilenPizza.Boyut = PizzaBoyutu.Orta; boyutSecildi = true; }
                    else if (boyutSecim == 3) { secilenPizza.Boyut = PizzaBoyutu.Buyuk; boyutSecildi = true; }
                    else Console.WriteLine("Geçersiz boyut secimi!");
                }
                else Console.WriteLine("Lütfen sadece sayı giriniz!");
            }
            //Hamur tipi seçimi
            bool hamurSecildi = false;
            while (!hamurSecildi)
            {
                Console.WriteLine("\nHamur Tipi Secin:");
                Console.WriteLine("1.İnce Hamur");
                Console.WriteLine("2.Kalın Hamur");
                Console.WriteLine("3.Ekstraİnce Hamur");
                Console.WriteLine("Seciminiz:");

                if (int.TryParse(Console.ReadLine(), out int hamurSecim))
                {
                    if (hamurSecim == 1) { secilenPizza.Hamur = HamurTipi.Ince; hamurSecildi = true; }
                    else if (hamurSecim == 2) { secilenPizza.Hamur = HamurTipi.Kalin; hamurSecildi = true; }
                    else if (hamurSecim == 3) { secilenPizza.Hamur = HamurTipi.EkstraInce; hamurSecildi = true; }
                    else Console.WriteLine("Geçersiz hamur seçimi!");
                }
                else Console.WriteLine("Lütfen sadece sayı giriniz!");

            }
            //Ekstra malzeme ekleme
            bool malzemeEklemeDevam = true;
            while (malzemeEklemeDevam)
            {
                Console.WriteLine("\nEkstra Malzeme Eklemek İster Misiniz?");
                Console.WriteLine("1.Mantar (+20TL)");
                Console.WriteLine("2.Zeytin (+15TL)");
                Console.WriteLine("3.Mısır (+10TL)");
                Console.WriteLine("4.Malzeme Ekleme Tamamla");
                Console.WriteLine("Seciminiz:");
                if (int.TryParse(Console.ReadLine(), out int malzemeSecim))
                {
                    if (malzemeSecim == 1)
                    {
                        secilenPizza = new Mantar(secilenPizza);
                        Console.WriteLine("->Mantar Eklendi.");
                    }
                    else if (malzemeSecim == 2)
                    {
                        secilenPizza = new Zeytin(secilenPizza);
                        Console.WriteLine("->Zeytin Eklendi.");
                    }
                    else if (malzemeSecim == 3)
                    {
                        secilenPizza = new Mısır(secilenPizza);
                        Console.WriteLine("->Mısır Eklendi.");
                    }
                    else if (malzemeSecim == 4)
                    {
                        malzemeEklemeDevam = false;
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz malzeme seçimi!");
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen sadece sayı giriniz!");
                }
            }
            //tasarlanan pizzayı sepet öneticisine gönderme
            yonetici.SepeteEkle(secilenPizza);
            Console.WriteLine("\n Pizzanız başarıyla sepete eklendi!");
            return secilenPizza;
        }
        //Sipariş sorgulama Metodunu yazıyoruz
        static void SiparisSorgula()
        {
            Console.WriteLine("\n Lütfen sorgulamak istediğiniz 6 haneli sipariş numarasını giriniz.");
            if (int.TryParse(Console.ReadLine(), out int arananNo))
            {
                if (tumSiparisler.TryGetValue(arananNo, out Pizza bulunanPizza))
                {
                Console.WriteLine("\n ===== SİPARİŞ DETAYI =====");

                Console.WriteLine($"Müşteri Adı: {isim}");
                Console.WriteLine($"Telefon Numarası: {telefon}");
                Console.WriteLine($"Sipariş Numarası:{arananNo}");
                Console.WriteLine($"Açıklama:{bulunanPizza.Aciklama}");
                Console.WriteLine($"Fiyat:{bulunanPizza.Fiyat}TL");
                Console.WriteLine("===============================");

                }
                else
                {
                  Console.WriteLine("\n[!] Bu numaraya ait sipariş bulunamadı!");
                }

            }
               else 
               {
                Console.WriteLine("Lütfen geçerli bir sipariş numarası girin.");
               }

        }  

    }
}

