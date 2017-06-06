using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlinePizzaWebApplication.Models
{
    public class Categories
    {
        public Categories()
        {
            Pizzas = new HashSet<Pizzas>();
        }

        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "The field Name should only include letters and number.")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [StringLength(255, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Pizzas> Pizzas { get; set; }

    }
}