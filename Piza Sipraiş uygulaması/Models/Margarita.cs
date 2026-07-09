using PizzaMatik.Enums;
namespace PizzaMatik.Models
{
    public class Margarita: Pizza
    {
        public override string Aciklama => "Margarita Pizza(Mozzarella,Fesleğen";
        public override double Fiyat => Boyut switch
        {
            PizzaBoyutu.Kucuk => 170.00,
            PizzaBoyutu.Orta => 210.00,
            PizzaBoyutu.Buyuk => 260.00,
            _ => 210.00
        };
    }
}





