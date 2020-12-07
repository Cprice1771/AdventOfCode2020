using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2020.Day_6 {
    public class Day6 {

        private const string FILE_NAME = "Day 6/data.txt";

        public int Solve() {
            var total = 0;
            var lines = File.ReadAllLines(FILE_NAME);
            var answeredPositively = new List<char>();
            foreach(var line in lines) {
                if(string.IsNullOrWhiteSpace(line)) {
                    total += answeredPositively.Count;
                    answeredPositively.Clear();
                    continue;
                }

                foreach(var question in line) {
                    if(!answeredPositively.Contains(question)) {
                        answeredPositively.Add(question);
                    }
                }
            }

            total += answeredPositively.Count;
            answeredPositively.Clear();

            return total;
        }

        public int SolveBonus() {
            var total = 0;
            var lines = File.ReadAllLines(FILE_NAME);
            var partySize = 0;
            var answeredPositively = new Dictionary<char, int>();
            foreach (var line in lines) {
                if (string.IsNullOrWhiteSpace(line)) {


                    foreach(var kvp in answeredPositively) {
                        if(kvp.Value == partySize) {
                            total++;
                        }
                    }
                    
                    partySize = 0;
                    answeredPositively.Clear();
                    continue;
                }

                partySize++;

                foreach (var question in line) {
                    if (!answeredPositively.ContainsKey(question)) {
                        answeredPositively.Add(question, 1);
                    } else {
                        answeredPositively[question] += 1;
                    }
                }
            }

            foreach (var kvp in answeredPositively) {
                if (kvp.Value == partySize) {
                    total++;
                }
            }

            return total;
        }
    }
}
