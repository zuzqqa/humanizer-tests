using System;
using Humanizer;

namespace functionalTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.

            var sentence = "JakoscOprogramowaniaTONajlepszyPrzedmiot";

            sentence.Humanize();

            Console.WriteLine(sentence);
        }
    }
}