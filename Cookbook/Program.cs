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
            
            List<Receipt> receipts = new List<Receipt>();
            receipts.Add(new Receipt{Name = "Мемоза",Text = "Тут описание как приготовить блюдо",Ingredients =//Вот тут у меня сыпится исключение, я не знаю как добавить уже что попало стал писать
            {
                new Ingredient()
                {
                    Id = 1,
                    Name = "Колбаса",
                    Quantity = 200,
                    Unit = "грамм",
                },
                new Ingredient()
                {
                    Id = 2,
                    Name = "Горошек",
                    Quantity = 100,
                    Unit = "грамм"
                }, 
                new Ingredient()
                {
                    Id = 3,
                    Name = "Картофель",
                    Quantity = 3,
                    Unit = "Штуки",
                }
                
            }});
            




        }
    }
}
