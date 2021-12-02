using System;
using System.IO;
using System.Linq;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();

            Part2();

            Console.ReadKey();
        }

        public static void Part1() {
            var commands = File.ReadAllLines(@"Data.txt").Select(Parse).GroupBy(o => o.firstChar).ToDictionary(k => k.Key, k => k.Select(o => o.value).Sum());

            int depth = 0;

            depth += commands['d'];
            depth -= commands['u'];

            var position = commands['f'];

            var result = position * depth;

            Console.WriteLine($"Part One: {result}");
        }

        public static void Part2()
        {
            var deltas = File.ReadAllLines(@"Data.txt").Select(Parse).Select(FindDeltas).ToList();

            (int depth, int distance, int aim) position = (0, 0, 0);

            foreach (var d in deltas) 
            {
                position = Apply(position, d);
            }

            var result = position.depth * position.distance;

            Console.WriteLine($"Part Two: {result}");

        }

        public static (int depth, int distance, int aim) Apply((int depth, int distance, int aim) p, (int detlaA, int deltaH) delta) 
        {
            return (ApplyDepth(p, delta), ApplyDistance(p.distance, delta), ApplyAim(p.aim, delta));
        }

        public static int ApplyAim(int aim, (int detlaA, int deltaH) delta) 
        {
            return aim + delta.detlaA;
        }

        public static int ApplyDistance(int distance, (int detlaA, int deltaH) delta)
        {
            return distance + delta.deltaH;
        }

        public static int ApplyDepth((int depth, int distance, int aim) p, (int detlaA, int deltaH) delta)
        {
            return p.depth + (delta.deltaH * p.aim);
        }


        public static (int detlaA, int deltaH) FindDeltas((char firstChar, int value) command) => command switch
        {
            (firstChar: 'u', { }) => (command.value * -1, 0),
            (firstChar: 'd', { }) => (command.value, 0),
            (firstChar: 'f', { }) => (0, command.value),
            _ => (0, 0)
        };
        
        public static (char firstChar, int value) Parse(string line)
        {
            var tokens = line.Split(' ');

            return (tokens[0][0], int.Parse(tokens[1]));
        }
    }

   

    
}
