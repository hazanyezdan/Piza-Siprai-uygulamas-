using PizzaMatik.Enums;
using PizzaMatik.Enums;
namespace PizzaMatik.Models
{
    public abstract class Pizza
    {
        //Her pizzanın açıklaması ve fiyatı olmak zorunda.
        public abstract string Aciklama { get; }
        public abstract double Fiyat {  get; }

        //Varsayılan pizza boyutları
        public PizzaBoyutu Boyut { get; set; } = PizzaBoyutu.Orta;
        public HamurTipi Hamur { get; set; } = HamurTipi.Ince;

    }
}
