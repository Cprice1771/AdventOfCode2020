using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day_2 {
    public class Day2 {

        private const string FILE_PATH = "Day 2/Data.txt";

        class PasswordStruct {
            public int MinCharacterCount { get; set; }
            public int MaxCharacterCount { get; set; }
            public char Character { get; set; }
            public string Password { get; set; }
        }

        public int Solve() {
            var validPasswordCount = 0;
            var data = File.ReadAllLines(FILE_PATH).Select(x => {
                var tokens = x.Split(" ");

                return new PasswordStruct() {
                    MinCharacterCount = int.Parse(tokens[0].Split('-')[0]),
                    MaxCharacterCount = int.Parse(tokens[0].Split('-')[1]),
                    Character = tokens[1][0],
                    Password = tokens[2]
                };
            });

            foreach(var pw in data) {
                var characterCount = 0;
                foreach(var character in pw.Password) {
                    if(character == pw.Character) {
                        characterCount++;
                    }
                }

                if(pw.MinCharacterCount <= characterCount && 
                    pw.MaxCharacterCount >= characterCount) {
                    validPasswordCount++;
                }
            }

            return validPasswordCount;
        }

        class BonusPasswordStruct {
            public int Position1 { get; set; }
            public int Position2 { get; set; }
            public char Character { get; set; }
            public string Password { get; set; }
        }

        public int SolveBonus() {
            var validPasswordCount = 0;
            var data = File.ReadAllLines(FILE_PATH).Select(x => {
                var tokens = x.Split(" ");

                return new BonusPasswordStruct() {
                    Position1 = int.Parse(tokens[0].Split('-')[0]),
                    Position2 = int.Parse(tokens[0].Split('-')[1]),
                    Character = tokens[1][0],
                    Password = tokens[2]
                };
            });

            foreach (var pw in data) {
                if(pw.Password[pw.Position1 - 1] == pw.Character ^ pw.Password[pw.Position2 - 1] == pw.Character) {
                    validPasswordCount++;
                }
            }

            return validPasswordCount;
        }
    }
}
