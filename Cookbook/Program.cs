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
            List<Ingredient> ingredient = new List<Ingredient>
            {
                new Ingredient{Id=1,Name ="Молоко",Unit = "мл"},
                new Ingredient{Id=2,Name = "Яйца",Unit ="штук"},
                new Ingredient{Id=3,Name = "Перец",Unit ="грамм"},
                new Ingredient{Id=4,Name = "Горошек",Unit ="грамм"},
                new Ingredient{Id=5,Name = "Петрушка",Unit ="штук"},
                new Ingredient{Id=6,Name = "Колбаса",Unit ="грам"},
                new Ingredient{Id=7,Name = "Соль",Unit ="по вкусу"},
                new Ingredient{Id=8,Name = "Сельдь",Unit ="штука"},
                new Ingredient{Id=9,Name = "Свекла",Unit ="грамм"},
                new Ingredient{Id=11,Name = "Лук",Unit ="грамм"},
                new Ingredient{Id=12,Name = "Картофель",Unit ="грамм"},
                new Ingredient{Id=13,Name = "Морковь",Unit ="штука"},
                new Ingredient{Id=14,Name = "Сыр",Unit ="грамм"},
                new Ingredient{Id=15,Name = "Майонез",Unit ="грамм"},
                new Ingredient{Id=16,Name = "Рыбные консервы",Unit ="грамм"},
                new Ingredient{Id=17,Name = "Огурец",Unit ="штуки"}
            };
            List<Receipt> receipts = new List<Receipt>();
            receipts.Add(new Receipt{
                Name = "Мемоза",
                Text = "Тут описание как приготовить блюдо",
                Units = new List<Units>
            {
                new Units()
                {
                    Id = 16,
                    Weight = 200
                },
                new Units()
                {
                    Id = 12,
                    Weight = 300
                }, 
                new Units()
                {
                    Id = 13,
                    Weight = 200
                },
                new Units()
                {
                    Id = 11,
                    Weight = 11
                },
                new Units()
                {
                    Id = 14,
                    Weight = 150
                },
                new Units()
                {
                    Id = 15,
                    Weight = 250
                },
                new Units()
                {
                    Id = 2,
                    Weight = 4
                },
                new Units()
                {
                    Id =5,
                    Weight = 50
                }

            }});
            receipts.Add(new Receipt{
                Name = "Ольвье",
                Text =" Тут описание",
                Units = new List<Units>()
            {
                new Units()
                {
                    Id = 12,
                    Weight = 300
                   
                },
                new Units()
                {
                    Id = 6,
                    Weight = 300
                   
                },
                new Units()
                {
                    Id = 18,
                    Weight = 3
                },
                new Units()
                {

                    Id = 2,
                    Weight =3 
                },
                new Units()
                {
                    Id =13,
                    Weight = 1
                    
                },
                new Units()
                {
                    Id = 4,
                    Weight = 200
                },
                new Units()
                {
                    Id = 15,
                    Weight = 180
                    
                }
            }
            });
            receipts.Add(new Receipt
            {
                Name = "Сельдь под шубой",
                Text = " Тут описание",
                Units = new List<Units>()
                {
                    new Units()
                    {
                        Id = 8,
                        Weight = 1
                    },
                    new Units()
                    {
                        Id = 9,
                        Weight = 300
                    },
                    new Units()
                    {
                        Id = 13,
                        Weight = 5
                    },
                    new Units()
                    {
                        Id = 12,
                        Weight = 300
                    },
                    new Units()
                    {
                        Id = 11,
                        Weight = 1
                    },
                    new Units()
                    {
                        Id = 15,
                        Weight = 50
                    }
                }
            });

            Ingredient ings = ingredient.FirstOrDefault(x => x.Name.Contains("Сыр"));
            if (ings == null)
            {
                Console.WriteLine("Данный ингредиент не найден");
            }
            ings = ingredient.FirstOrDefault(x => x.Name.ToLower().Contains("сыр"));
            if (ings == null)
            {
                Console.WriteLine("Ингредиент не найден");
            }
            if (ings != null)
            {
                int id = ings.Id;
                foreach (Receipt rec in receipts)
                {
                    Console.Write($"Рецепт ,{rec.Name}");

                   Units units = rec.Units.FirstOrDefault(x => x.Id == id);
                   if (units != null)
                   {
                       Console.WriteLine(" :Ингредиент найден, требуется {0},{1},{2} ", ings.Name,units.Weight,ings.Unit);
                   }

                }
            }
            
        }
    }
}
