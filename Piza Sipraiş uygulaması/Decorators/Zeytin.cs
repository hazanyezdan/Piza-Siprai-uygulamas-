using PizzaMatik.Decorators;
using PizzaMatik.Models;

namespace PizzaMatik.Decorators
{
    public class Zeytin:PizzaMalzemeDecorator
    {
        public Zeytin(Pizza pizza):base(pizza) { }
        public override string Aciklama => _pizza.Aciklama + ",+Ekstra Zeytin";
        public override double Fiyat => _pizza.Fiyat + 15.00;

    }
}