namespace Cookbook
{
    public class Ingredient
    {
        public int Id { get; set; } // уникальный идентификатор 
        public string Name { get; set; } // Имя продукта
        public string Unit { get; set; } // ед. измерения (гр, ч.л, шт. ...)
        public float Quantity { get; set; } // количество
    }
}
