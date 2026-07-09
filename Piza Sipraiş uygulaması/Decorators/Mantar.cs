using PizzaMatik.Decorators;
using PizzaMatik.Models;

namespace PizzaMatik.Decorators
{
    public class Mantar : PizzaMalzemeDecorator
    {
        // Yapıcı metot (Constructor)
        public Mantar(Pizza pizza) : base(pizza) { }

        // Mevcut pizzanın açıklamasına "+ Ekstra Mantar" ekliyoruz
        public override string Aciklama => _pizza.Aciklama + ", + Ekstra Mantar";

        // Mevcut pizzanın fiyatına 20 TL mantar ücreti ekliyoruz
        public override double Fiyat => _pizza.Fiyat + 20.00;
    }
} 