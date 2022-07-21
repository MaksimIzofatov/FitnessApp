using FitnessAppBL.Controller;
using FitnessAppBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Вас приветствует приложение FitnessApp");

            Console.WriteLine("Введите имя пользователя");
            string name = Console.ReadLine();


            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                string gender = Console.ReadLine();
                DateTime birthDay = ParseDateTime();
                double weight = ParseDouble("вес");
                double growth = ParseDouble("рост");
                userController.SetUserData(gender, birthDay, weight, growth);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("E - Что вы съели?");
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.E || key.Key == ConsoleKey.T)
            {
                var eating = EnterEating();
                eatingController.Add(eating.food, eating.weight);
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine(item.Key + " - " + item.Value);
                }
            }
            Console.ReadLine();
        }

        private static (Food food, double weight) EnterEating()
        {
            Console.Write($"Имя продукта: ");
            string foodName = Console.ReadLine();

            double calories = ParseDouble("калорийность");
            double proteins = ParseDouble("белки");
            double fats = ParseDouble("жиры");
            double carbs = ParseDouble("углеводы");

            double weight = ParseDouble("вес порции");
            var product = new Food(foodName, proteins, fats, carbs, calories);

            return (product, weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDay;
            while (true)
            {
                Console.Write("Введите дату рождения (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDay))
                    break;
                else
                    Console.WriteLine("Неверный формат даты рождения");
            }

            return birthDay;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                else
                    Console.WriteLine($"Неверный формат поля {name}");
            }
        }
    }
}
