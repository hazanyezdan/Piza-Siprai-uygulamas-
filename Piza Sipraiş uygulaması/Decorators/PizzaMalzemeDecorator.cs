using PizzaMatik.Models;

namespace PizzaMatik.Decorators
{
    //bu sınıf hem pizzadır hem de içinde bir pizza barındırır.
    public abstract class PizzaMalzemeDecorator:Pizza
    {
        protected Pizza _pizza;
        //yapıcı metotto (constructor) süsleyeceğimiz pizzayı içeriye alıyoruz.
        protected PizzaMalzemeDecorator(Pizza pizza)
        {
            _pizza = pizza;
            //Seçilen pizzanın boyutu ve hamurunu
            this.Boyut = pizza.Boyut;
            this.Hamur = pizza.Hamur;
        }
    }
}

