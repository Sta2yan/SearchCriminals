using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchCriminals
{
    class Progam
    {
        static void Main(string[] args)
        {
            List<Criminal> criminals = new List<Criminal>()
            {
                new Criminal("Альберт Энштейн", 200, 50, "Еврей", false),
                new Criminal("Андрей Игоревич", 50, 200, "Немец", false),
                new Criminal("Павел Петренко", 180, 180, "Немец", true),
                new Criminal("Антонио Бондерас", 179, 90, "Дагестанец", false),
                new Criminal("Алексей Падчинов", 150, 75, "Британец", true),
                new Criminal("Кирилл Добролюбов", 170, 110, "Русский", false),
                new Criminal("Дмитрий Чепоренко", 66, 60, "Еврей", false)
            };

            var filteredCriminals = criminals.OrderBy(criminal => criminal.IsTakenCustody).TakeWhile(criminal => criminal.IsTakenCustody == false);

            Console.WriteLine("Введите начальный рост преступника:");
            int height = GetNumber(Console.ReadLine());
            Console.WriteLine("Введите начальный вес преступника:");
            int weight = GetNumber(Console.ReadLine());
            Console.WriteLine("Введите национальность преступника:");
            string national = Console.ReadLine();

            filteredCriminals = criminals.Where(criminal => criminal.Height >= height).Where(criminal => criminal.Weight >= weight).Where(criminal => criminal.National == national);

            foreach (var criminal in filteredCriminals)
            {
                criminal.ShowInfo();
            }
        }

        static int GetNumber(string textNumber)
        {
            int number;

            while (int.TryParse(textNumber, out number) == false)
            {
                Console.WriteLine("Повторите попытку:");
                textNumber = Console.ReadLine();
            }

            return number;
        }
    }

    class Criminal
    {
        public string Name { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string National { get; private set; }
        public bool IsTakenCustody { get; private set; }

        public Criminal(string name, int height, int weight, string national, bool isTakenCustody)
        {
            Name = name;
            Height = height;
            Weight = weight;
            National = national;
            IsTakenCustody = isTakenCustody;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя - {Name} | Рост - {Height} см | Вес - {Weight} кг | Национальность - {National} | Взят под стражу - {IsTakenCustody}");
        }
    }
}