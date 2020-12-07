using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day_3 {
    public class Day3 {


        private const string FILE_PATH = "Day 3/data.txt";
        public char[][] map;

        public int Solve() {
            map = File.ReadAllLines(FILE_PATH).Select(x => x.ToCharArray()).ToArray();
            var x = 0;
            var y = 0;
            var trees = 0;
            while (y < map.Length) {
                if (map[y][x] == '#') {
                    trees++;
                }

                x += 3;
                y++;

                x = x % map[0].Length;
            }


            return trees;
        }

        public class Vector {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public long SolveBonus() {
            map = File.ReadAllLines(FILE_PATH).Select(x => x.ToCharArray()).ToArray();

            var vectors = new List<Vector>() {
                new Vector() { X = 1, Y = 1 },
                new Vector() { X = 3, Y = 1 },
                new Vector() { X = 5, Y = 1 },
                new Vector() { X = 7, Y = 1 },
                new Vector() { X = 1, Y = 2 },
            };

            var allTrees = new List<int>();

            foreach(var vect in vectors) {
                var x = 0;
                var y = 0;
                var trees = 0;
                while (y < map.Length) {
                    if (map[y][x] == '#') {
                        trees++;
                    }

                    x += vect.X;
                    y += vect.Y;

                    x = x % map[0].Length;
                }

                allTrees.Add(trees);
            }

            long runningTotal = allTrees[0];
            for(var i = 1; i < allTrees.Count; i++) {
                runningTotal *= allTrees[i];
            }

            return runningTotal;
           
        }



    }
}
