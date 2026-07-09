using PizzaMatik.Decorators;
using PizzaMatik.Models;

namespace PizzaMatik.Decorators
{
    public class Mısır : PizzaMalzemeDecorator
    {
        public Mısır(Pizza pizza) : base(pizza) { }
        public override string Aciklama => _pizza.Aciklama + ",+Ekstra Mısır";
        public override double Fiyat => _pizza.Fiyat + 10.00;

    }
}