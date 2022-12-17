using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day_11 {
    class Day11 {
        private const string DATA_INPUT = "./Day 11/data.txt";

        private int CountOccupied(List<List<char>> mapA) {
            var count = 0;
            for (var x = 0; x < mapA.Count; x++) {
                for (var y = 0; y < mapA[x].Count; y++) {
                    if (mapA[x][y] == '#') {
                        count++;
                    }
                }
            }

            return count;
        }

        private bool AreMapsSame(List<List<char>> mapA, List<List<char>> mapB) {

            if(mapA.Count != mapB.Count || mapA[0].Count != mapB[0].Count) {
                return false;
            }

            for(var x = 0; x < mapA.Count; x++) {
                for(var y = 0; y < mapA[x].Count; y++) {
                    if(mapA[x][y] != mapB[x][y]) {
                        return false;
                    }
                }
            }

            return true;
        }

        private int GetOccupiedCountAdjcent(List<List<char>> currentMap, int x, int y) {

            var count = 0;

            for(var xOffset = -1; xOffset <= 1; xOffset++) {
                for(var yOffset = -1; yOffset <= 1; yOffset++) {

                    var checkX = x + xOffset;
                    var checkY = y + yOffset;

                    if(xOffset == 0 && yOffset == 0) {
                        continue;
                    }

                    if(checkX < 0 || checkX >= currentMap.Count) {
                        continue;
                    }

                    if(checkY < 0 || checkY >= currentMap[x].Count) {
                        continue;
                    }

                    if(currentMap[checkX][checkY] == '#') {
                        count++;
                    }


                }
            }


            return count;
        }

        private List<List<char>> DoIteration(List<List<char>> currentMap) {
            var newMap = new List<List<char>>();

            for(var x = 0; x < currentMap.Count; x++) {
                newMap.Add(new List<char>());
                for (var y = 0; y < currentMap[x].Count; y++) {
                    if(currentMap[x][y] == '.') {
                        newMap[x].Add('.');
                    }

                    if (currentMap[x][y] == 'L') {
                        if(GetOccupiedCountAdjcent(currentMap, x, y) == 0) {
                            newMap[x].Add('#');
                        } else {
                            newMap[x].Add('L');
                        }
                    }


                    if (currentMap[x][y] == '#') {
                        if (GetOccupiedCountAdjcent(currentMap, x, y) >= 4) {
                            newMap[x].Add('L');
                        } else {
                            newMap[x].Add('#');
                        }
                    }
                }
            }


            return newMap;
        }


        public int Solve() {
            var input = File.ReadAllLines(DATA_INPUT);

            var map = new List<List<char>>();

            for(var i = 0; i < input.Length; i++) {
                map.Add(input[i].ToCharArray().ToList());
            }

            var maxRuns = 0;

            while(true) {
                var nextMap = DoIteration(map);
                if(AreMapsSame(nextMap, map)) {
                    return CountOccupied(nextMap);
                }
                map = nextMap;
                maxRuns++;
                if(maxRuns > 10000) {
                    break;
                }
            }

            return 0;
            
        }

        private int GetOccupiedCountAdjcentBonus(List<List<char>> currentMap, int x, int y) {

            var count = 0;

            for (var xOffset = -1; xOffset <= 1; xOffset++) {
                for (var yOffset = -1; yOffset <= 1; yOffset++) {
                    var checkX = x + xOffset;
                    var checkY = y + yOffset;

                    do {
                        if (xOffset == 0 && yOffset == 0) {
                            break;
                        }

                        if (checkX < 0 || checkX >= currentMap.Count) {
                            break;
                        }

                        if (checkY < 0 || checkY >= currentMap[x].Count) {
                            break;
                        }


                        if (currentMap[checkX][checkY] == '#') {
                            count++;
                            break;
                        } else if(currentMap[checkX][checkY] == '.') {
                            checkY += yOffset;
                            checkX += xOffset;
                            continue;
                        }


                        break;
                    } while (true);

                }
            }


            return count;
        }

        private List<List<char>> DoIterationBonus(List<List<char>> currentMap) {
            var newMap = new List<List<char>>();

            for (var x = 0; x < currentMap.Count; x++) {
                newMap.Add(new List<char>());
                for (var y = 0; y < currentMap[x].Count; y++) {
                    if (currentMap[x][y] == '.') {
                        newMap[x].Add('.');
                    }

                    if (currentMap[x][y] == 'L') {
                        if (GetOccupiedCountAdjcentBonus(currentMap, x, y) == 0) {
                            newMap[x].Add('#');
                        } else {
                            newMap[x].Add('L');
                        }
                    }


                    if (currentMap[x][y] == '#') {
                        if (GetOccupiedCountAdjcentBonus(currentMap, x, y) >= 5) {
                            newMap[x].Add('L');
                        } else {
                            newMap[x].Add('#');
                        }
                    }
                }
            }


            return newMap;
        }

        public int SolveBonus() {
            var input = File.ReadAllLines(DATA_INPUT);

            var map = new List<List<char>>();

            for (var i = 0; i < input.Length; i++) {
                map.Add(input[i].ToCharArray().ToList());
            }

            var maxRuns = 0;

            while (true) {
                var nextMap = DoIterationBonus(map);
                if (AreMapsSame(nextMap, map)) {
                    return CountOccupied(nextMap);
                }
                map = nextMap;
                maxRuns++;
                if (maxRuns > 10000) {
                    break;
                }
            }

            return 0;

        }
    }
}
