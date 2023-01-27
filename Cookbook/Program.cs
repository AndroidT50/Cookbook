using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Runtime.InteropServices;

namespace Cookbook
{
    internal class Program
    {
        private static string _token = "5631049378:AAHkcA_Ug19bHXLSnNIDhKeoLDSnU9u-_1w";
        private static async Task Main(string[] args)
        {
            
            var bot = new TelegramBotClient(_token);
            var me = await bot.GetMeAsync();

            Console.WriteLine($" My bot : {me.Username} {me.Id}");

            bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync,
                new Telegram.Bot.Polling.ReceiverOptions
                {
                    AllowedUpdates = Array.Empty<UpdateType>()


                });
            Console.ReadKey();
        }
        private static Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken arg3)
        {
            var ErrorMesage = exception.Message;
            Console.WriteLine(ErrorMesage);
            return Task.CompletedTask;
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken arg3)
        {
            try
            {
                switch (update.Type)
                {
                    case UpdateType.Message:
                        await BotOneMessageReceived(bot, update.Message);
                        break;
                }
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(bot, exception, arg3);
            }

        }
        private static async Task BotOneMessageReceived(ITelegramBotClient bot, Message message)
        {

            List<Ingredient> ingredient = new List<Ingredient>
            {
                new Ingredient{Id=1,Name ="молоко",Unit = "мл"},
                new Ingredient{Id=2,Name = "яйца",Unit ="штук"},
                new Ingredient{Id=3,Name = "Перец",Unit ="грамм"},
                new Ingredient{Id=4,Name = "Горошек",Unit ="грамм"},
                new Ingredient{Id=5,Name = "Петрушка",Unit ="штук"},
                new Ingredient{Id=6,Name = "Колбаса",Unit ="грам"},
                new Ingredient{Id=7,Name = "соль",Unit ="по вкусу"},
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
            receipts.Add(new Receipt
            {
                Name = "Мемоза",
                Text = "Тут описание как приготовить блюдо",
                Units = new List<Unit>
            {
                new Unit()
                {
                    Id = 16,
                    Weight = 200
                },
                new Unit()
                {
                    Id = 12,
                    Weight = 300
                },
                new Unit()
                {
                    Id = 13,
                    Weight = 200
                },
                new Unit()
                {
                    Id = 11,
                    Weight = 11
                },
                new Unit()
                {
                    Id = 14,
                    Weight = 150
                },
                new Unit()
                {
                    Id = 15,
                    Weight = 250
                },
                new Unit()
                {
                    Id = 2,
                    Weight = 4
                },
                new Unit()
                {
                    Id =5,
                    Weight = 50
                }

            }
            });
            receipts.Add(new Receipt
            {
                Name = "Ольвье",
                Text = " Тут описание",
                Units = new List<Unit>()
            {
                new Unit()
                {
                    Id = 12,
                    Weight = 300

                },
                new Unit()
                {
                    Id = 6,
                    Weight = 300

                },
                new Unit()
                {
                    Id = 18,
                    Weight = 3
                },
                new Unit()
                {

                    Id = 2,
                    Weight =3
                },
                new Unit()
                {
                    Id =13,
                    Weight = 1

                },
                new Unit()
                {
                    Id = 4,
                    Weight = 200
                },
                new Unit()
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
                Units = new List<Unit>()
                {
                    new Unit()
                    {
                        Id = 8,
                        Weight = 1
                    },
                    new Unit()
                    {
                        Id = 9,
                        Weight = 300
                    },
                    new Unit()
                    {
                        Id = 13,
                        Weight = 5
                    },
                    new Unit()
                    {
                        Id = 12,
                        Weight = 300
                    },
                    new Unit()
                    {
                        Id = 11,
                        Weight = 1
                    },
                    new Unit()
                    {
                        Id = 15,
                        Weight = 50
                    }
                }
            });

            Console.WriteLine($"message {message.Text}");
            Console.WriteLine($"message{message.Type}");
            if (message.Type != MessageType.Text)
            {
                return;
            }
            //var s = message.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            //var action2 = s[0];

            var action = message.Text.ToLower();
            Ingredient ings = ingredient.FirstOrDefault(x => x.Name.ToLower().Contains(action));
            if (ings == null) { await bot.SendTextMessageAsync(message.Chat.Id, $" Данный ингредиент не найден"); };

            if (ings != null)
            {
                int id = ings.Id;
                foreach (Receipt rec in receipts)
                {

                    { await bot.SendTextMessageAsync(message.Chat.Id, $" Рецепт {rec.Name}"); };

                    Unit units = rec.Units.FirstOrDefault(x => x.Id == id);
                    if (units != null)
                    {
                        await bot.SendTextMessageAsync(message.Chat.Id, $" :Ингредиент найден, требуется '{0}','{1}','{2}' "/* ings.Name, units.Weight, ings.Unit*/);
                    }

                }
            }

            switch (action)
            {
                case "/start":
                    var username = $"{message.From.FirstName} {message.From.LastName}. Твой ник телеграмме {message.From.Username} ";
                    await bot.SendTextMessageAsync(message.Chat.Id, $" Привет {username}");
                    await bot.SendTextMessageAsync(message.Chat.Id, "Добро пожаловать в телеграмм бота");
                    break;

                case "/help":
                    await bot.SendTextMessageAsync(message.Chat.Id, $" тут помощь ");
                    break;
                case "/Поиск":
                    await bot.SendTextMessageAsync(message.Chat.Id, $" Введите Ингредиет для поиска");
                    break;
                
            }


        }
       
       
            


        

    }
}
