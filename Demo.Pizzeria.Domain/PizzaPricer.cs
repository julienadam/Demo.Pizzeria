using System.Linq;

namespace Demo.Pizzeria.Domain
{
    public class PizzaPricer
    {
        public decimal PriceForSmall { get; }
        public decimal PriceForMedium { get; }
        public decimal PriceForLarge { get; }
        public decimal CreamBaseSupplement { get; }

        public PizzaPricer(decimal priceForSmall, decimal priceForMedium, decimal priceForLarge, decimal creamBaseSupplement)
        {
            PriceForSmall = priceForSmall;
            PriceForMedium = priceForMedium;
            PriceForLarge = priceForLarge;
            CreamBaseSupplement = creamBaseSupplement;
        }

        public decimal CalculatePrice(Pizza pizza)
        {
            decimal price = 0m;

            switch (pizza.Size)
            {
                case PizzaSize.Small:
                    price += PriceForSmall;
                    break;
                case PizzaSize.Medium:
                    price += PriceForMedium;
                    break;
                case PizzaSize.Large:
                    price += PriceForLarge;
                    break;
            }
            
            if (pizza.Base == PizzaBase.Cream)
            {
                price += CreamBaseSupplement;
            }

            price += pizza.Ingredients.Sum(i => i.Price);

            return price;
        }
    }
}