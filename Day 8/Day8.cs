using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day_8 {
    public class Day8 {

        private const string DATA_INPUT = "./Day 8/data.txt";

        public class SolutionOutput {
            public bool Completed { get; set; }
            public int AccResult { get; set; }
            public List<int> InstructionHistory { get; set; }
        }

        public int Solve() {
            int acc = 0;
            int currentLine = 0;
            string currentInstruction;
            int currentParam;
            List<int> seenLines = new List<int>();

            var input = File.ReadAllLines(DATA_INPUT);
            while (currentLine < input.Length) {

                if(seenLines.Any(x => x == currentLine)) {
                    return acc;
                }

                seenLines.Add(currentLine);
                var tokens = input[currentLine].Split(' ');
                currentInstruction = tokens[0];
                currentParam = int.Parse(tokens[1]);
                switch(currentInstruction) {
                    case "acc":
                        acc += currentParam;
                        currentLine++;
                        break;
                    case "nop":
                        currentLine++;
                        break;
                    case "jmp":
                        currentLine += currentParam;
                        break;

                }
            }

            return acc;
        }

        private SolutionOutput solveInput(string[] input) {
            int acc = 0;
            int currentLine = 0;
            string currentInstruction;
            int currentParam;
            List<int> seenLines = new List<int>();

            while (currentLine < input.Length) {
                
                if (seenLines.Any(x => x == currentLine)) {
                    seenLines.Add(currentLine);
                    return new SolutionOutput {
                        InstructionHistory = seenLines,
                        AccResult = acc,
                        Completed = false
                    };
                }
                seenLines.Add(currentLine);
                var tokens = input[currentLine].Split(' ');
                currentInstruction = tokens[0];
                currentParam = int.Parse(tokens[1]);
                switch (currentInstruction) {
                    case "acc":
                        acc += currentParam;
                        currentLine++;
                        break;
                    case "nop":
                        currentLine++;
                        break;
                    case "jmp":
                        currentLine += currentParam;
                        break;

                }
            }

            return new SolutionOutput {
                InstructionHistory = seenLines,
                AccResult = acc,
                Completed = true
            };
        }

        public int SolveBonus() {
           

            var input = File.ReadAllLines(DATA_INPUT);
            var completed = false;
            var count = 0;

            //while (!completed) {
                var res = solveInput(input);
                if(res.Completed) {
                    return res.AccResult;
                }

                for(var i = res.InstructionHistory.Count - 1; i >= 0; i--) {
                    var copy = File.ReadAllLines(DATA_INPUT);
                    if(copy[res.InstructionHistory[i]].Contains("jmp")) {
                        copy[res.InstructionHistory[i]] = copy[res.InstructionHistory[i]].Replace("jmp", "nop");
                    } else if (copy[res.InstructionHistory[i]].Contains("nop")) {
                        copy[res.InstructionHistory[i]]= copy[res.InstructionHistory[i]].Replace("nop", "jmp");
                    }
                    var res2 = solveInput(copy);
                    if (res2.Completed) {
                        return res2.AccResult;
                    }
                }

            //    count++;
            //    if(count > 10000) {
            //        break;
            //    }
            //}

            return 0;
            
        }
    }
}
