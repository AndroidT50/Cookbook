using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ingredient ingredient1 = new Ingredient();
            ingredient1.Id = 1;
            ingredient1.Name = "Test";
            ingredient1.Unit = "грамм";

            List<Receipt> Ingredient = new List<Receipt>();
            Ingredient.Add(new Receipt{Name = "мемоза"});
            Ingredient.Add(new Receipt{Text = "Тут описание как приготвить"});
            Receipt Ingredient2 = new Receipt();
            Ingredient2.Ingredients.Add("Петрушка");


        }
    }
}
