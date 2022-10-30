using Demo.Pizzeria.Domain;
using System.Collections.Generic;

namespace Demo.Pizzeria.Tests
{
    public class PizzaBuilder
    {
        private PizzaSize size;
        private PizzaBase pizzaBase;
        private readonly List<Ingredient> ingredients = new();

        public static PizzaBuilder CreateSmallPizza()
        {
            return new PizzaBuilder().WithSize(PizzaSize.Small);
        }

        public PizzaBuilder WithSize(PizzaSize size)
        {
            this.size = size;
            return this;
        }

        public PizzaBuilder WithBase(PizzaBase pizzaBase)
        {
            this.pizzaBase = pizzaBase;
            return this;
        }

        public PizzaBuilder WithPepperoni()
        {
            this.ingredients.Add(new Ingredient("Pepperoni", 0.8m));
            return this;
        }

        public PizzaBuilder WithMushrooms()
        {
            this.ingredients.Add(new Ingredient("Mushrooms", 0.3m));
            return this;
        }

        public PizzaBuilder WithTomatoBase()
        {
            this.pizzaBase = PizzaBase.Tomato;
            return this;
        }

        public Pizza Pizza
        {
            get { return new Pizza(size, pizzaBase, ingredients); }
        }
    }
}