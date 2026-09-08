// using System;
//
//
// public class SimpleResource : IDisposable
// {
//     
//     public void Dispose()
//     {
//         Console.WriteLine("Dispose Очистили ресурс сразу");
//         
//         
//         GC.SuppressFinalize(this);
//     }
//
//     
//     ~SimpleResource()
//     {
//         Console.WriteLine("Финализатор Забыли Dispose GC подчищает сам.");
//     }
// }
//
// class Pr
// {
//     static void Main()
//     {
//         
//         using (var res1 = new SimpleResource())
//         {
//             Console.WriteLine("Работаем с res1...");
//         }
//
//         
//         CreateAndForget();
//         
//         GC.Collect(); 
//         GC.WaitForPendingFinalizers(); 
//     }
//
//     static void CreateAndForget()
//     {
//         var res2 = new SimpleResource();
//         Console.WriteLine("Работаем с res2 (без using)...");
//     }
// } 