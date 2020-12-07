using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020 {
    public class Day1 {

        public int[] testData = new int[] { 1721,
                                        979,
                                        366,
                                        299,
                                        675,
                                        1456 };

        public int Solve() {

            var data = File.ReadAllLines("Day 1/data.txt").Select(x => int.Parse(x)).ToArray();

            for(var i = 0; i < data.Length; i++) {
                for(var j = i+1; j < data.Length; j++) {
                    if(data[i] + data[j] == 2020) {
                        return data[i] * data[j];
                    }
                }
            }

            return 0;
        }

        public int SolveBonus() {

            var data = File.ReadAllLines("Day 1/data.txt").Select(x => int.Parse(x)).ToArray();

            for (var i = 0; i < data.Length; i++) {
                for (var j = i+1; j < data.Length; j++) {
                    for(var k = j+1; k < data.Length; k++) {
                        if (data[i] + data[j] + data[k] == 2020) {
                            return data[i] * data[j] * data[k];
                        }
                    }
                }
            }

            return 0;
        }
    }
}
