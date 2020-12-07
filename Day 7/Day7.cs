using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day_7 {
    public class Day7 {

        private const string FILE_NAME = "Day 7/data.txt";

        public class BagCounter {
            public string Name { get; set; }
            public long Count { get; set; }
        }

        public class Bag {

            public string BagName { get; set; }
            public List<BagCounter> Contains { get; set; } = new List<BagCounter>();

            public bool Deepened { get; set; } = false;

            public Bag(string rule) {
                var tokens = rule.Split(" bags contain ");
                BagName = tokens[0];
                if (tokens[1] != "no other bags.") {
                    var bags = tokens[1].Split(',');
                    foreach (var bag in bags) {
                        var bagTokens = bag.Trim().Split(' ').ToList();
                        var count = int.Parse(bagTokens[0]);
                        bagTokens.RemoveAt(0);
                        bagTokens.RemoveAt(bagTokens.Count - 1);
                        Contains.Add(new BagCounter() {
                            Name = string.Join(' ', bagTokens),
                            Count = count
                        });
                    }
                }

            }

            public void Deepen() {

                if(Deepened) {
                    return;
                }

                var copy = new List<BagCounter>();
                foreach(var cpy in Contains) {
                    copy.Add(new BagCounter() {
                        Count = cpy.Count,
                        Name = cpy.Name
                    });
                }


                foreach (var bag in copy) {
                    var foundBag = Bags.FirstOrDefault(x => x.BagName == bag.Name);
                    if (foundBag == null) {
                        continue;
                    }

                    if (!foundBag.Deepened) {
                        foundBag.Deepen();
                    }

                    foreach(var toAdd in foundBag.Contains) {
                        if(Contains.Any(x => x.Name == toAdd.Name)) {
                            var index = Contains.FindIndex(x => x.Name == toAdd.Name);
                            Contains[index].Count += toAdd.Count * bag.Count;
                        } else {
                            Contains.Add(new BagCounter() {
                                Name = toAdd.Name,
                                Count = toAdd.Count * bag.Count
                        });
                        }
                    }
                }
                Deepened = true;
            }

            internal long CountBags() {
                long count = 0;
                foreach(var bag in Contains) {
                    count += bag.Count;
                }

                return count;
            }
        }

        private static List<Bag> Bags = new List<Bag>();

        

        public int Solve() {
            Bags.Clear();
            var rules = File.ReadAllLines(FILE_NAME);
            foreach(var rule in rules) {
                Bags.Add(new Bag(rule));
            }

            foreach(var bag in Bags) {
                bag.Deepen();
            }



            return Bags.Where(x => x.Contains.Any(x => x.Name == "shiny gold")).Count();
        }

        public long SolveBonus() {
            Bags.Clear();
            var rules = File.ReadAllLines(FILE_NAME);
            foreach (var rule in rules) {
                Bags.Add(new Bag(rule));
            }

            foreach (var bag in Bags) {
                bag.Deepen();
            }



            return Bags.First(x => x.BagName == "shiny gold").CountBags();
        }
    }
}
