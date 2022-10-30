using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Pizzeria.Domain
{
    public class Ingredient
    {
        public string Name { get; }
        public decimal Price { get; }

        public Ingredient(string name, decimal price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
        }
    }

    public enum PizzaBase
    {
        Tomato,
        Cream
    }

    public enum PizzaSize
    {
        Small,
        Medium,
        Large
    }

    public class Pizza
    {
        public PizzaSize Size { get; }
        public PizzaBase Base { get; }
        public ICollection<Ingredient> Ingredients { get; }

        public Pizza(PizzaSize size, PizzaBase pizzaBase, ICollection<Ingredient> ingredients)
        {
            this.Base = pizzaBase;
            this.Size = size;
            this.Ingredients = ingredients;
        }
    }
}
