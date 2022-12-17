using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day_13 {
    public class Day13 {

        private const string FILE = "Day 13/Data.txt";

        public int Solve() {
            var input = File.ReadAllLines(FILE);

            var startingTime = int.Parse(input[0]);
            var busTimes = input[1].Split(',').Where(x => x != "x").Select(x => int.Parse(x));

            var minTime = int.MaxValue;
            var busMinTime = int.MaxValue;
            foreach(var time in busTimes) {
                var timeToWait = time - (startingTime % time);
                //if((startingTime % time) == 0) {
                //    timeToWait = 0;
                //}
                if (minTime > timeToWait) {
                    minTime = timeToWait;
                    busMinTime = time;
                }
            }

            return minTime * busMinTime;
        }

        public ulong SolveBonus() {
            var input = File.ReadAllLines(FILE);

            var busTimes = input[1].Split(',').Select(x => {
                if (!int.TryParse(x, out int o))
                    return 0;

                return o;

            }).ToList();

            ulong time = (ulong)busTimes[0];
            while (true) {
                var found = true;
                for (var i = 1; i < busTimes.Count(); i++) {

                    if(busTimes[i] == 0) {
                        continue;
                    } else if((ulong)busTimes[i] - (time % (ulong)busTimes[i]) != (ulong)i) {
                        found = false;
                        break;
                    }

                }

                if(found) {
                    break;
                }

                time += (ulong)busTimes[0];
            } 

            return time;
        }
    }
}
