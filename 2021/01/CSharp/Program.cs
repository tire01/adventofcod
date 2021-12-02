using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DayOneCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var data = TestDataHelper.GetData().ToArray();

            var answer = data
                .Skip(1)
                .Zip(data)
                .Select(pair => pair.First > pair.Second ? 0 : 1)
                .Sum();

            Console.WriteLine(answer);
        }


    }
    public static class TestDataHelper 
    {
        public static IEnumerable<int> GetData()
        {
            var lines = File.ReadAllText(@".\Data.txt").Split(Environment.NewLine);

            foreach (var line in lines)
            {
                if (Int32.TryParse(line, out var result))
                {
                    yield return result;
                }
            }
        }
    }

    public static class IEnumerableExtensionMethods
    {
        public static IEnumerable<(T a, T b)> Pairs<T>(this IEnumerable<T> source)
        {
            var firstOrNull = source.FirstOrDefault();

            if (firstOrNull == null)
                yield break;

            T previous = firstOrNull ?? default;

            foreach (var item in source.Skip(1))
            {
                yield return (previous, item);
                previous = item;
            }
        }

    }
}
