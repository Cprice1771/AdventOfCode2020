using AdventOfCode2020.Day_10;
using AdventOfCode2020.Day_11;
using AdventOfCode2020.Day_2;
using AdventOfCode2020.Day_3;
using AdventOfCode2020.Day_4;
using AdventOfCode2020.Day_5;
using AdventOfCode2020.Day_6;
using AdventOfCode2020.Day_7;
using AdventOfCode2020.Day_8;
using AdventOfCode2020.Day_9;
using System;

namespace AdventOfCode2020 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine($"Day 1: {new Day1().SolveBonus()}");
            Console.WriteLine($"Day 1 Bonus: {new Day1().SolveBonus()}");


            Console.WriteLine($"Day 2: {new Day2().Solve()}");
            Console.WriteLine($"Day 2 Bonus: {new Day2().SolveBonus()}");

            Console.WriteLine($"Day 3: {new Day3().Solve()}");
            Console.WriteLine($"Day 3 Bonus: {new Day3().SolveBonus()}");

            Console.WriteLine($"Day 4: {new Day4().Solve(false)}");
            Console.WriteLine($"Day 4 Bonus: {new Day4().Solve(true)}");

            Console.WriteLine($"Day 5: {new Day5().Solve()}");
            Console.WriteLine($"Day 5 Bonus: {new Day5().SolveBonus()}");

            Console.WriteLine($"Day 6: {new Day6().Solve()}");
            Console.WriteLine($"Day 6 Bonus: {new Day6().SolveBonus()}");

            Console.WriteLine($"Day 7: {new Day7().Solve()}");
            Console.WriteLine($"Day 7 Bonus: {new Day7().SolveBonus()}");

            Console.WriteLine($"Day 8: {new Day8().Solve()}");
            Console.WriteLine($"Day 8 Bonus: {new Day8().SolveBonus()}");

            Console.WriteLine($"Day 9: {new Day9().Solve()}");
            Console.WriteLine($"Day 9 Bonus: {new Day9().SolveBonus()}");

            Console.WriteLine($"Day 10: {new Day10().Solve()}");
            Console.WriteLine($"Day 10 Bonus: {new Day10().SolveBonus()}");

            Console.WriteLine($"Day 11: {new Day11().Solve()}");
        }

    }
}
