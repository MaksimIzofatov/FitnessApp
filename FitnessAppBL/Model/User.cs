using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppBL.Model
{
    public class User
    { 
        #region Свойства
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Пол пользователя
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Дата рождения пользователя
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// Вес пользователя
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост пользователя
        /// </summary>
        public double Growth { get; set; }
        #endregion

        /// <summary>
        /// Создать нового пользвателя
        /// </summary>
        /// <param name="name"> Имя </param>
        /// <param name="gender"> Пол </param>
        /// <param name="birthDate"> Дата рождения </param>
        /// <param name="weight"> Вес </param>
        /// <param name="growth"> Рост </param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double growth)
        {
            #region Проверка входным параметров
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            if (gender == null)
                throw new ArgumentNullException("Пол не может быть null", nameof(gender));
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
                throw new ArgumentException("Невозможная дата рождения", nameof(birthDate));
            if (weight <= 0)
                throw new ArgumentException("Вес не может быть меньше или равен 0", nameof(weight));
            if (growth <= 0)
                throw new ArgumentException("Рост не может быть меньше либо равен 0", nameof(growth));
            #endregion
            
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Growth = growth;
        }

        public override string ToString() => Name;
    }
}
