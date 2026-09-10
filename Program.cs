////ГЛАВА 6 ЗАДАНИЕ 1
// using System;
// using System.Collections; 
//
// class Program
// {
//     static void Main()
//     {
//         foreach (int number in GetFibonacci(8))
//         {
//             Console.Write(number + " ");
//         }
//     }
//     
//     public static IEnumerable GetFibonacci(int count)
//     {
//         if (count <= 0)
//             yield break;
//
//         int current = 0;
//         int next = 1;
//
//         for (int i = 0; i < count; i++)
//         {
//             yield return current;
//
//             int newNext = current + next;
//             current = next;
//             next = newNext;
//         }
//     }
// }
//
//
////ДЛЯ ЧЕГО НУЖЕН 
// namespace System
// {
//     public interface IComparable
//     {
//         int CompareTo(object? obj);
//     }
// }



////ГЛАВА 6 ЗАДАНИЕ 2
// using System;
//
// class Program
// {
//     private static Person2 d = new Person2("Ivan",  22);
//     static void Main()
//     {
//
//         Console.WriteLine(Compare(5, 10));
//
//
//         Console.WriteLine(Compare(3.14, 2.71));
//
//
//         Console.WriteLine(Compare("Арбуз", "Банан"));
//
//
//         Console.WriteLine(Compare('a', 'a'));
//         
//         Console.WriteLine(Compare(d, d));
//         
//     }
//
//
//     public static int Compare(object left, object right)
//     {
//         if (left == null && right == null) return 0;
//         if (left == null) return -1;
//         if (right == null) return 1;
//
//         
//         if (left.GetType() != right.GetType())
//         {
//             throw new ArgumentException($"Нельзя сравнить {left.GetType().Name} и {right.GetType().Name}!");
//         }
//
//         if (left is IComparable comparable)
//         {
//             return comparable.CompareTo(right);
//         }
//
//         throw new ArgumentException("Переданные типы не умеют сравниваться.");
//     }
//
// }







// class Person : IGamer, IDriver
// {
//     
//     void IGamer.Execute() 
//     { 
//         Console.WriteLine("Запускаю Counter-Strike!"); 
//     }
//
//     
//     void IDriver.Execute() 
//     { 
//         Console.WriteLine("Завожу двигатель и жму на газ!"); 
//     }
// }

// class Bird : IFlyable
// {
//     public void Fly() { ... }  
// }





////ГЛАВА 5 ЗАДАНИЕ 1
// class Program
// {
//     static void Main()
//     {
//         
//         try
//         {
//             Person person = new Person("Алексей", "Петров", 25);
//             Console.WriteLine($"Успешно создан: {person.FirstName} {person.LastName}, {person.Age} лет.");
//
//            
//             person.Age = -5; 
//         }
//         catch (ArgumentOutOfRangeException ex)
//         {
//             Console.WriteLine($"Перехвачена ошибка возраста: {ex.ParamName} -> {ex.Message}");
//         }
//
//        
//         try
//         {
//             Person invalidPerson = new Person("", "Иванов", 30);
//         }
//         catch (ArgumentException ex)
//         {
//             Console.WriteLine($"Перехвачена ошибка имени: {ex.Message}");
//         }
//     }
// }



////ГЛАВА 5 ЗАДАНИЕ 2
// using System;
//
// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("ТЕСТ 1: Успешное создание ");
//         TryCreatePerson("Иван", "Иванов", 25);
//
//         Console.WriteLine("\n ТЕСТ 2: Пустое имя");
//         TryCreatePerson("", "Петров", 30);
//
//         Console.WriteLine("\n ТЕСТ 3: Фамилия = null ");
//         TryCreatePerson("Алексей", null, 30);
//
//         Console.WriteLine("\n ТЕСТ 4: Отрицательный возраст");
//         TryCreatePerson("Мария", "Сидорова", -5);
//
//         Console.WriteLine("\n ТЕСТ 5: Слишком большой возраст");
//         TryCreatePerson("Елена", "Козлова", 180);
//     }
//
//    
//     static void TryCreatePerson(string firstName, string lastName, int age)
//     {
//         try
//         {
//             
//             Person person = new Person(firstName, lastName, age);
//             
//             
//             Console.WriteLine($"УСПЕХ: Создан {person.FirstName} {person.LastName}, {person.Age} лет.");
//         }
//         catch (ArgumentOutOfRangeException ex)
//         {
//          
//             Console.WriteLine($"ХОРОШО: Поймали ошибку возраста -> {ex.Message}");
//         }
//         catch (ArgumentException ex)
//         {
//         
//             Console.WriteLine($"ХОРОШО: Поймали ошибку имени/фамилии -> {ex.Message}");
//         }
//         catch (Exception ex)
//         {
//             
//             Console.WriteLine($"ХОРОШО: Поймали непредвиденную ошибку -> {ex.Message}");
//         }
//     }
// }


////ГЛАВА 5 ЗАДАНИЕ 3



















//using System;
// class Pony
// {
//     public string Name;
//     public string Type;
//     public int MagicLevel;
//     public int Power;
//     
//     // 🆕 1. Добавили новое поле
//     public bool HasLoveInterest;
//
//     // ============================================
//     // Главный конструктор — ЕДИНСТВЕННЫЙ, кто записывает данные в поля
//     // ============================================
//     public Pony(string name, string type, int magicLevel, int power, bool hasLoveInterest)
//     {
//         this.Name = name;
//         this.Type = type;
//         this.MagicLevel = magicLevel;
//         this.Power = power;
//         
//         // 🆕 Записываем любовный интерес
//         this.HasLoveInterest = hasLoveInterest;
//
//         Console.WriteLine($"Создан(а) пони: {Name}");
//     }
//
//     // ============================================
//     // Делегирующие конструкторы ("Матрёшка")
//     // ============================================
//
//     // По умолчанию: любовный интерес = false
//     public Pony(string name, string type, int magicLevel, int power)
//         : this(name, type, magicLevel, power, false) // 👈 передаем false в Главный
//     { }
//
//     // По умолчанию: сила = 50
//     public Pony(string name, string type, int magicLevel) 
//         : this(name, type, magicLevel, 50) // 👈 передаем 50 в предыдущий
//     { }
//
//     // По умолчанию: магия = 10
//     public Pony(string name, string type) 
//         : this(name, type, 10) 
//     { }
//
//     // По умолчанию: тип = "Земная пони"
//     public Pony(string name) 
//         : this(name, "Земная пони") 
//     { }
//
//     public void PrintInfo()
//     {
//         Console.WriteLine($"Имя: {Name}");
//         Console.WriteLine($"Тип: {Type}");
//         Console.WriteLine($"Уровень магии: {MagicLevel}");
//         Console.WriteLine($"Сила: {Power}");
//         // 🆕 Показываем в консоли
//         Console.WriteLine($"Влюблена/есть пара: {(HasLoveInterest ? "Да ❤️" : "Нет 💔")}");
//         Console.WriteLine("----------------------");
//     }
// }
//
// class Program
// {
//     static void Main()
//     {
//         // 1. Принцесса Каденс — указываем явно true в Главном конструкторе
//         Pony cadence = new Pony("Принцесса Каденс", "Аликорн", 95, 80, true);
//         cadence.PrintInfo();
//
//         // 2. Радуга Дэш — вызываем короткий конструктор (только имя и тип)
//         // По цепочке пролетит значение false, и нам не нужно было переписывать остальной код!
//         Pony rainbow = new Pony("Радуга Дэш", "Пегас");
//         rainbow.PrintInfo();
//         
//         Pony soarin = new Pony("Соарин", "Пегас", 65, 60, true);
//         soarin.PrintInfo();
//     }
// }


// class Program
// {
//     static void Main()
//     {
//         EmailNotification ivanNotification = new EmailNotification("ivan@gmail.com");
//         SmsNotification irinaNotification = new SmsNotification("08726282");
//         ivanNotification.Send("Привет");
//         irinaNotification.Send("Привет");
//         Check(ivanNotification);
//         
//
//
//         static void Check(object obj)
//         {
//             if (obj is EmailNotification)
//             {
//                 Console.WriteLine("Это почта!");
//             }
//             else
//             {
//                 Console.WriteLine("Не почта");
//             }
//         }
//
//     }
// }
//         



//ТЕМА 10 ЗАДАНИЕ 1
 using System;
 using System.Collections.Generic;

 // class Program
 // {
 //     static void Main()
 //     {
 //         List<string> words = new List<string> { "hello", "World", "csharp", "123", "code", "C#" };
 //
 //         
 //         List<string> result = words.FindAll(str => 
 //         {
 //             if (string.IsNullOrEmpty(str)) return false;
 //
 //            
 //             foreach (char c in str)
 //             {
 //                 if (!char.IsLower(c)) return false;
 //             }
 //             return true;
 //         });
 //
 //         
 //         foreach (string word in result)
 //         {
 //             Console.WriteLine(word);
 //         }
 //     }
 // }

//ТЕМА 10 ЗАДАНИЕ 2
 // using System;
 //
 // class Program
 // {
 //     static void Main()
 //     {
 //        
 //         BookStore store = new BookStore();
 //
 //      
 //         Customer buyer1 = new Customer("Алексей");
 //         Customer buyer2 = new Customer("Мария");
 //
 //         Console.WriteLine("--- Покупатели подписываются на уведомления\n");
 //         
 //         
 //         store.OnBookArrived += buyer1.ReceiveNotification;
 //         store.OnBookArrived += buyer2.ReceiveNotification;
 //
 //         Console.WriteLine("--- В магазин привезли новую книгу\n");
 //         
 //         
 //         store.AddBook("Ведьмак");
 //
 //         Console.WriteLine("\n--- Алексей отписывается от уведомлений\n");
 //         
 //        
 //         store.OnBookArrived -= buyer1.ReceiveNotification;
 //         
 //
 //         Console.WriteLine("--- В магазин привезли еще одну книгу\n");
 //         
 //         
 //         store.AddBook("Гарри Поттер");
 //     }
 // }
 //
 //
 // class BookStore
 // {
 //     
 //     public event Action<string> OnBookArrived;
 //
 //     public void AddBook(string bookTitle)
 //     {
 //         Console.WriteLine($"[Магазин] Поступила новая книга: «{bookTitle}»");
 //
 //       
 //         OnBookArrived?.Invoke(bookTitle);
 //     }
 // }
 //
 //
 // class Customer
 // {
 //     public string Name { get; }
 //
 //     public Customer(string name)
 //     {
 //         Name = name;
 //     }
 //
 //    
 //     public void ReceiveNotification(string bookTitle)
 //     {
 //         Console.WriteLine($"  -> Уведомление для {Name}: Книга «{bookTitle}» уже в продаже!");
 //     }
 // }

//  using System;
//  using System.Linq;
//
//  using var db = new AppDbContext();
//
// // 1. Добавляем запись в PostgreSQL
//  db.Users.Add(new User { Name = "Павел", Email = "pavel@example.com" });
//  db.SaveChanges();
//  Console.WriteLine("Пользователь успешно сохранен в PostgreSQL!");
//
// // 2. Читаем из базы
//  var user = db.Users.FirstOrDefault();
//  Console.WriteLine($"Прочитано из базы: ID={user?.Id}, Имя={user?.Name}");

 using helloapp;
 using Microsoft.EntityFrameworkCore;

 using (var db = new AppDbContext())
 {
     
     using var transaction = await db.Database.BeginTransactionAsync();

     try
     {
         Console.WriteLine("--- Начинаем транзакцию ---");

    
         var maria = await db.Users.FirstOrDefaultAsync(u => u.Name == "Мария");
         if (maria == null)
         {
             throw new Exception("Пользователь 'Мария' не найден в базе!");
         }

        
         var newOrder = new Order
         {
             Description = "Беспроводные наушники",
             Amount = 120.00m,
             RecipientName = "Мария Петрова",
             UserId = maria.Id
         };
         await db.Orders.AddAsync(newOrder);
         await db.SaveChangesAsync(); 

         Console.WriteLine("Заказ подготвлен к записи...");

         
         throw new Exception("Сбой сети! Транзакция должна отмениться!");

      
         await transaction.CommitAsync();

         Console.WriteLine("УСПЕХ: Транзакция успешно зафиксирована (Commit)!");
     }
     catch (Exception ex)
     {
        
         await transaction.RollbackAsync();

         Console.WriteLine($"ОШИБКА: {ex.Message}");
         Console.WriteLine("ОТКАТ: Никакие изменения НЕ записались в PostgreSQL!");
     }
 }