using System.Diagnostics;

namespace Task_13_6_1
{
    internal class Program
    {
        static void Main()
        {
            var path = @"C:/Users/Public/Documents/Text1.txt";
            var text = File.ReadAllText(path);            

            char[] delimiterChars = { ' ', '\t', '\n', '\r' };
            string[] words = text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);                     

            var list = new List<string>();
            var linkedList = new LinkedList<string>();

            var measuringList = new Stopwatch();
            foreach (var line in words)
            {
                measuringList.Start();
                list.Add(line);
                measuringList.Stop();                
            }            

            var measuringLinkedList = new Stopwatch();
            foreach (var line in words)
            {
                measuringLinkedList.Start();    
                linkedList.AddLast(line);
                measuringLinkedList.Stop();                
            }
            
            Console.WriteLine($"Число элементов в структуре данных List({list.Count}) и LinkedList({linkedList.Count}) равны.");
            Console.WriteLine($"Время вставки элементов в List = {measuringList.ElapsedMilliseconds} мс.");
            Console.WriteLine($"Время вставки элементов в LinkedList = {measuringLinkedList.ElapsedMilliseconds} мс.");
            Console.WriteLine($"Вставка элементов в List происходит быстрее чем в LinkedList, примерно в " +
                $"{measuringLinkedList.ElapsedMilliseconds / measuringList.ElapsedMilliseconds} раз(а)...");

            Console.ReadKey();
        }
    }
}