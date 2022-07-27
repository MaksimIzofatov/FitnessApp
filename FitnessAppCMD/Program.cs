using FitnessAppBL.Controller;
using FitnessAppBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Resources;

namespace FitnessAppCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            //var culture = CultureInfo.CurrentCulture;
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("FitnessAppCMD.Languales.Messages", typeof(Program).Assembly);
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(resourceManager.GetString("hello", culture));

            Console.WriteLine(resourceManager.GetString("inputName", culture));
            string name = Console.ReadLine();


            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                string gender = Console.ReadLine();
                DateTime birthDay = ParseDateTime("дата рождения");
                double weight = ParseDouble("вес");
                double growth = ParseDouble("рост");
                userController.SetUserData(gender, birthDay, weight, growth);
            }
            Console.WriteLine(userController.CurrentUser);

            while (true) 
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("E - Что вы съели?");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.T:
                    case ConsoleKey.E:
                        var eating = EnterEating();
                        eatingController.Add(eating.food, eating.weight);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine(item.Key + " - " + item.Value);
                        }
                        break;
                    case ConsoleKey.F:
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.activity, exe.begin, exe.end);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()} ");
                        }
                        
                        break;
                    case ConsoleKey.Q:
                        Console.WriteLine("Вы точно хотите выйти? д/н");
                        var res = Console.ReadKey(true);
                        if (res.Key == ConsoleKey.L || res.Key == ConsoleKey.D)
                            Environment.Exit(0);
                        else
                            Console.WriteLine();
                        continue;

                }
                Console.ReadLine();
            }
        }

        private static (DateTime begin, DateTime end, Activity activity) EnterExercise()
        {
            Console.WriteLine("Введите название упражнения: ");
            string name = Console.ReadLine();

            double energy = ParseDouble("расход энергии а минуту");

            DateTime begin = ParseDateTime("начало упражнения");
            DateTime end = ParseDateTime("окончание упражнения");

            var activity = new Activity(name, energy);
            return (begin, end, activity);

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

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDay;
            while (true)
            {
                Console.Write($"Введите {value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDay))
                    break;
                else
                    Console.WriteLine($"Неверный формат {value}");
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
