using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        /// <summary>
        /// Доработайте вашу телефонную книгу из практики предыдущего юнита так, 
        /// чтобы контакты телефонной книги были отсортированы сперва по имени, а затем по возрасту.
        /// </summary>
        
        static void Main()
        {
            // создаём пустой список с типом данных Contact
            var sourcePhoneBook = new List<Contact>();

            // добавляем контакты
            sourcePhoneBook.Add(new Contact("Игорь", 79990000001, "igor@example.com",29));
            sourcePhoneBook.Add(new Contact("Сергей", 79990000010, "serge@example.com",33));
            sourcePhoneBook.Add(new Contact("Анатолий", 79990000011, "anatoly@example.com",50));
            sourcePhoneBook.Add(new Contact("Валерий", 79990000012, "valera@example.com", 24));
            sourcePhoneBook.Add(new Contact("Сергей", 799900000013, "serg@example.com",25));
            sourcePhoneBook.Add(new Contact("Иннокентий", 799900000013, "innokentii@example.com",44));

            var phoneBook = sourcePhoneBook.OrderBy(x => x.Name).ThenBy(x => x.Age);
            while (true)
            {
                Console.WriteLine("Введите номер страницы справочника:");
                // Читаем введенный с консоли символ
                var input = Console.ReadKey().KeyChar;

                // проверяем, число ли это
                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                // если не соответствует критериям - показываем ошибку
                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");
                }
                // если соответствует - запускаем вывод
                else
                {
                    // пропускаем нужное количество элементов и берем 2 для показа на странице
                    var pageContent = phoneBook.Skip((pageNumber - 1) * 2).Take(2);
                    Console.WriteLine();

                    // выводим результат
                    foreach (var entry in pageContent)
                        Console.WriteLine($"{entry.Name} : {entry.PhoneNumber}\t {entry.Age}" );

                    Console.WriteLine();
                }
            }
        }
    }
    public class Contact // модель класса
    {
        public Contact(string name, long phoneNumber, String email, int age) // метод-конструктор
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Age = age;
        }

        public String Name { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
        public int Age { get; }

    }
}

