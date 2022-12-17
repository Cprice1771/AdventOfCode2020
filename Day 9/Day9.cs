using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day_9 {
    public class Day9 {
        private const string DATA_INPUT = "./Day 9/data.txt";

        public long Solve() {
            var input = File.ReadAllLines(DATA_INPUT).Select(x => long.Parse(x)).ToList();
            var preamble = 25;

            for(var i = preamble;i < input.Count; i++) {
                var valid = false;
                var offset = (i - preamble);
                for (var j = 0 + offset ; j < (preamble - 1) + offset; j++) {
                    for (var k = j + 1; k < preamble + offset; k++) {
                        if(input[j] + input[k] == input[i]) {
                            valid = true;
                            break;
                        }
                    }

                    if(valid) {
                        break;
                    }
                }

                if(!valid) {
                    return input[i];
                }
            }


            return 0;
        }

        public long SolveBonus() {
            var input = File.ReadAllLines(DATA_INPUT).Select(x => long.Parse(x)).ToList();
            var targetSum = Solve();
            
            for(var i = 0; i < input.Count; i++) {
                for(var j = 1; j < input.Count; j++) {
                    long sum = 0;
                    for(var k = i; k <=j; k++) {
                        sum += input[k];
                    }

                    if(sum == targetSum) {
                        var min = input[i];
                        var max = input[i];

                        for (var k = i + 1; k <= j; k++) {
                            if(input[k] > max) {
                                max = input[k];
                            } 
                            
                            if (input[k] < min) {
                                min = input[k];
                            }
                        }

                        return min + max;
                    }
                }
            }

            return -1;
        }
    }
}
