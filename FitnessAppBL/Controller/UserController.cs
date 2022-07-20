using FitnessAppBL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppBL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового контроллера приложения
        /// </summary>
        /// <param name="user"> Пользователь </param>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double growth)
        {
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, growth);
        }

        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

        /// <summary>
        /// Загрузить данные пользвотеля
        /// </summary>
        /// <returns> Пользователь приложения </returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                //TODO: Что делать, если пользователя не прочитали 
            }
        }
    }
}
