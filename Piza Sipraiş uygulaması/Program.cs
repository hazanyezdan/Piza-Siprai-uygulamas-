using System;
using PizzaMatik.Enums;
using PizzaMatik.Models;
using PizzaMatik.Decorators;
using PizzaMatik.Services;

namespace PizzaMatik
{
    class Program
    {
        static void Main(string[] args)
        {
            //sipariş yöneticimizi başlatıyoruz
            SiparisYonetici siparisYoneticisi = new SiparisYonetici();
            bool uygulamaCalisiyor = true;
            Console.WriteLine("==========================");
            Console.WriteLine("PIZZAMATIK OTOMASYONUNA HOŞGELDİNİZ");
            Console.WriteLine("==========================");
            while(uygulamaCalisiyor)
            {
                Console.WriteLine("\n ----ANA MENU----");
                Console.WriteLine("1.Yeni Pizza Siparişi Oluşur");
                Console.WriteLine("2.Sipariş Özetini Görün");
                
                if(!int.TryParse(Console.ReadLine(),out int anaSecim))
                {
                    Console.WriteLine("Lütfen geçerli bir sayı giriniz!");
                    continue;
                }
                switch(anaSecim)
                {
                    case 1:
                        PizzaSecimSureci(siparisYoneticisi);
                        break;
                    case 2:
                        //Doğrudan fatura basma ve uygulama kapama
                        siparisYoneticisi.FaturaYazdir();
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
        static void PizzaSecimSureci(SiparisYonetici yonetici)
        {
            Pizza secilenPizza = null;
            //pizza seçim adımı
            while(secilenPizza==null)
            {
                Console.WriteLine("\nPizza Tabanı seçin:");
                Console.WriteLine("1.Margarita");
                Console.WriteLine("2.Pepperoni");
                Console.WriteLine("Seciminiz:");
                 if(int.TryParse(Console.ReadLine(),out int pizzaSecim))
                {
                    if (pizzaSecim == 1) secilenPizza = new Margarita();
                    else if (pizzaSecim == 2) secilenPizza = new Pepperoni();
                    else Console.WriteLine("Geçersiz pizza secimi!");

                }
                else
                {
                    Console.WriteLine("Lütfen sadece sayı giriniz!");
                }
            }
            //Boyut Secimi 
            bool boyutSecildi = false;
            while(!boyutSecildi)
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
            while(!hamurSecildi)
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
                while(malzemeEklemeDevam)
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
                }
    }
}

