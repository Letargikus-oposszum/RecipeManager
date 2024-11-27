using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public Author Author { get; set; }
        public List<Ingridient> Ingridients { get; set; } = new List<Ingridient>();
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
    }
}
