using Demo.Pizzeria.Domain;
using System;
using Xunit;

namespace Demo.Pizzeria.Tests
{
    public class PizzaPricerTests
    {
        [Fact]
        public void Plain_small_tomato_costs_only_the_base_price_for_a_small_pizza()
        {
            var p = new PizzaPricer(6, 7, 8, 0.5m);
            var price = p.CalculatePrice(new Pizza(PizzaSize.Small, PizzaBase.Tomato, Array.Empty<Ingredient>()));
            Assert.Equal(6, price);
        }

        [Fact]
        public void Small_pepperoni_and_mushrooms_on_tomato_base_is_priced_correctly()
        {
            var pricer = new PizzaPricer(6, 7, 8, 0.5m);
            var pizza = new Pizza(PizzaSize.Small, PizzaBase.Tomato, new[] { new Ingredient("Pepperoni", 0.8m), new Ingredient("Mushrooms", 0.3m) });
            var price = pricer.CalculatePrice(pizza);
            Assert.Equal(7.1m, price);
        }

        [Fact]
        public void Small_pepperoni_and_mushrooms_on_tomato_base_is_priced_correctly_with_builder()
        {
            var pricer = new PizzaPricer(6, 7, 8, 0.5m);
            var pizzaBuilder = PizzaBuilder
                .CreateSmallPizza()
                .WithTomatoBase()
                .WithPepperoni()
                .WithMushrooms();
            var price = pricer.CalculatePrice(pizzaBuilder.Pizza);
            Assert.Equal(7.1m, price);
        }
    }
}