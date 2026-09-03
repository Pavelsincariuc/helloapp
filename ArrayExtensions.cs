////ГЛАВА 12 ЗАДАНИЕ 1
using System;
using System.Collections.Generic;
using System.Linq;

// public static class ArrayExtensions
// {
//     public static T[] SubArray<T>(this T[] array, int startIndex, int length)
//     {
//         return array.Skip(startIndex).Take(length).ToArray();
//     }
// }
//
// class Program
// {
//     static void Main()
//     {
//         int[] numbers = [10, 20, 30, 40, 50, 60, 70, 80];
//         
//         int[] result = numbers.SubArray(2, 3); 
//
//         Console.WriteLine(string.Join(", ", result));
//
//
//     }
// }

////ГЛАВА 12 ЗАДАНИЕ 2
// public static class ExceptionExtensions
// {
//     
//     public static bool ContainsException<T>(this Exception ex) where T : Exception
//     {
//         
//         while (ex != null)
//         {
//             
//             if (ex is T)
//             {
//                 return true; 
//             }
//
//             
//             ex = ex.InnerException;
//         }
//
//         return false; 
//     }
// }
//
// class Program
// {
//     static void Main()
//     {
//         
//         var innerMost = new NullReferenceException("Самая глубокая ошибка");
//         var middle = new ArgumentException("Средняя ошибка", innerMost);
//         var top = new InvalidOperationException("Самая верхняя ошибка", middle);
//
//        
//         
//         bool hasNullRef = top.ContainsException<NullReferenceException>();
//         Console.WriteLine(hasNullRef); 
//
//         bool hasArgument = top.ContainsException<ArgumentException>();
//         Console.WriteLine(hasArgument); 
//
//         bool hasHttpError = top.ContainsException<System.Net.Http.HttpRequestException>();
//         Console.WriteLine(hasHttpError);
//     }
// }


////ГЛАВА 12 ЗАДАНИЕ 3
// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// public static class FilterExtensions
// {
//     public static int[] GetNumbersGreaterThan62(IEnumerable<object?> items)
//     {
//         return items
//             .Where(x => x != null)                             
//             .Select(x => x!.ToString())                        
//             .Where(s => int.TryParse(s, out int n) && n > 62)  
//             .Select(s => int.Parse(s))                         
//             .ToArray();                                        
//     }
// }
//
// class Program
// {
//     static void Main()
//     {
//        
//         object?[] mixedData = { "100", 45, null, "50", "abc", 75, "62", "63", null };
//         
//         int[] result = FilterExtensions.GetNumbersGreaterThan62(mixedData);
//         
//         Console.WriteLine(string.Join(", ", result)); 
//     }
// }






//ГЛАВА 12 ЗАДАНИЕ 4
//  using System;
//  using System.Collections.Generic;
//  using System.IO;
//  using System.Linq;
//
//  class Program
//  {
//      static void Main(string[] args)
//      {
//          
//          string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
//
//          List<string> inputPaths = new List<string>
//          {
//              Path.Combine(homeDir, "Downloads"), 
//              "/System/NonExistentFolder123",    
//              Path.Combine(homeDir, "Desktop")    
//          };
//
//          Console.WriteLine("Проверяем пути:");
//          foreach (var path in inputPaths)
//          {
//              Console.WriteLine($" - {path} (Существует: {Directory.Exists(path)})");
//          }
//
//          Console.WriteLine("\nСчитываем файлы...");
//          List<string> fileNames = GetFileNamesFromValidDirectories(inputPaths);
//
//          Console.WriteLine($"\nВсего найдено файлов: {fileNames.Count}");
//          foreach (string fileName in fileNames.Take(20)) 
//          {
//              Console.WriteLine($"• {fileName}");
//          }
//      }
//
//      public static List<string> GetFileNamesFromValidDirectories(IEnumerable<string> paths)
//      {
//          if (paths == null) return new List<string>();
//
//          List<string> result = new List<string>();
//
//          foreach (var path in paths)
//          {
//              if (Directory.Exists(path))
//              {
//                  try
//                  {
//                      
//                      var files = Directory.EnumerateFiles(path)
//                                           .Select(Path.GetFileName);
//                      result.AddRange(files);
//                  }
//                  catch (UnauthorizedAccessException)
//                  {
//                      
//                  }
//                  catch (Exception ex)
//                  {
//                      Console.WriteLine($"Ошибка при чтении {path}: {ex.Message}");
//                  }
//              }
//          }
//
//          return result;
//      }
// } 