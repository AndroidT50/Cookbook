using System.Collections.Generic;

namespace Cookbook
{
    public class Ingredient
    {
        public int Id { get; set; } // уникальный идентификатор 
        public string Name { get; set; } // Имя продукта
        public float Quantity { get; set; } // количество
        public string Unit { get; set; } // ед. измерения (гр, ч.л, шт. ...)

    }
}
