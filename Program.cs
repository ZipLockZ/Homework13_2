using System.Diagnostics;

namespace Homework_13_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StreamReader stream = new StreamReader("C:\\Users\\ivan\\Desktop\\Text1.txt");
            popular10words();
        }
        static void popular10words()
        {
            string txt = File.ReadAllText("C:\\Users\\ivan\\Desktop\\Text1.txt");

            var noPunctuationText = new string(txt.Where(c => !char.IsPunctuation(c)).ToArray());

            char[] delimetrs = new char[] { ' ', '\r', '\n', '\t' };

            var words = noPunctuationText.Split(delimetrs);

            Console.WriteLine(words.Length);

            List<string> list = new List<string>();

            foreach (var word in words)
            {
                list.Add(word);
                Console.WriteLine(word);
            }
            SortedDictionary<string, int> sortwords = new SortedDictionary<string, int>();

            foreach (var word in words)
            {

                if (word.Length > 3)
                {

                    if (!sortwords.ContainsKey(word))
                    {
                        sortwords.Add(word, 1);
                    }
                    else
                    {
                        sortwords[word] += 1;
                    }
                }
            }
            var sorted = sortwords.OrderByDescending(x => x.Value).ToArray();

            var top10 = sorted.Take(10);

            Console.WriteLine("Топ 10 самых распространненых слов в тексте :");

            foreach (KeyValuePair<string, int> word in top10)
            {
                Console.WriteLine(word.Key + ":" + word.Value);
            }
        }
    }
}

