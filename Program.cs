using AdventOfCode2020.Day_2;
using AdventOfCode2020.Day_3;
using AdventOfCode2020.Day_4;
using AdventOfCode2020.Day_5;
using AdventOfCode2020.Day_6;
using AdventOfCode2020.Day_7;
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
        }

    }
}
