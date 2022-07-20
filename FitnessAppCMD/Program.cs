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
            Console.WriteLine("Вас приветствует приложение FitnessApp");
            
            Console.WriteLine("Введите имя пользователя");
            string name = Console.ReadLine();


            var userController = new UserController(name);

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
            Console.ReadLine();
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
                    Console.WriteLine($"Неверный формат {name}");
            }
        }
    }
}
