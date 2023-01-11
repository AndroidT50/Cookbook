using System.Collections.Generic;

namespace Cookbook
{
    public class Receipt
    {
        public string Name ;
        public string Text ;
        public List<Ingredient> Ingredients { get; set; }
    }
}