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

            Console.WriteLine("Введите пол");
            string gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            var birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите вес");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост");
            double growth = double.Parse(Console.ReadLine());


            var userController = new UserController(name, gender, birthDate, weight, growth);
            userController.Save();
        }
    }
}
