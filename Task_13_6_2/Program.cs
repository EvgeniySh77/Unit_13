using System.Diagnostics;

namespace Task_13_6_2
{
    internal class Program
    {
        static void Main()
        {
            var frequentWords = new List<string>();
            var path = @"C:/Users/Public/Documents/Text1.txt";
            var text = File.ReadAllText(path);                        

            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());            

            char[] delimiterChars = { ' ', '\t', '\n', '\r' };

            string[] words = noPunctuationText.ToUpper().Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            frequentWords = words.Where(g => g.Length > 2).GroupBy(g => g)
                .OrderByDescending(g => g.Count()).Select(g => g.Key).Take(10).ToList();

            Console.WriteLine("10 слов чаще всего встречающихся в тексте и состоящих из более двух букв:");
            foreach (var line in frequentWords)
            {                
                Console.Write(line + " ");
            }           

            Console.ReadKey();
        }
    }
}