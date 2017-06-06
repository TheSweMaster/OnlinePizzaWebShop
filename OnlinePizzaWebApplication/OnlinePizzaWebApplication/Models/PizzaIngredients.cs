using System.ComponentModel;

namespace OnlinePizzaWebApplication.Models
{
    public class PizzaIngredients
    {
        public int Id { get; set; }

        [DisplayName("Select Pizza")]
        public int PizzaId { get; set; }

        [DisplayName("Select Ingredient")]
        public int IngredientId { get; set; }

        public virtual Ingredients Ingredient { get; set; }
        public virtual Pizzas Pizza { get; set; }
    }
}