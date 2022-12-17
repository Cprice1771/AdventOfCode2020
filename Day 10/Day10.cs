using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day_10 {
    public class Day10 {
        private const string DATA_INPUT = "./Day 10/testsmall.txt";

        public int Solve() {
            var input = File.ReadAllLines(DATA_INPUT).Select(x => int.Parse(x)).ToList();
            input.Sort();
            var diff1 = 0;
            var diff2 = 0;
            var diff3 = 1;
            for(var i = 0; i < input.Count; i++) {
                int diff = 0;
                if (i > 0) {
                    diff = input[i] - input[i - 1];
                } else {
                    diff = input[i];
                }
                if (diff == 1) {
                    diff1++;
                } else if (diff == 2) {
                    diff2++;
                } else if (diff == 3) {
                    diff3++;
                }
            }

            return diff1 * diff3;
        }

        public ulong SolveBonus() {
            var input = File.ReadAllLines(DATA_INPUT).Select(x => ulong.Parse(x)).ToList();
            input.Sort();
            Dictionary<ulong, ulong> cache = new Dictionary<ulong, ulong>();

            input.Insert(0, 0);
            input.Add(input[input.Count - 1] + 3);

            for (var i = 0; i < input.Count; i++) {
                for(var j = 1; j <= 3; j++) {
                    if((i - j) < 0) {
                        break;
                    }

                    if(input[i] - input[i-j] <= 3) {
                        if(cache.ContainsKey(input[i])) {
                            cache[input[i]]++;
                        } else {
                            cache.Add(input[i], 1);
                        }
                    }
                }
            }

            ulong sum = 0;
            
            for (var i = 1; i < input.Count-1; i++) {
                ulong currSum = 1;
                for (var j = 1; j <= 3 && j + i < input.Count; j++) {
                    currSum *= cache[input[i + j]];
                }

                if(currSum > 1) {
                    sum += currSum;
                }

            }

            return sum;
        }
    }
}
