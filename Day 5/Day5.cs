using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day_5 {
    public class Day5 {

        private const string FILE_NAME = "Day 5/data.txt";

        public int Solve() {
            var tickets = File.ReadAllLines(FILE_NAME);
            var maxId = 0;
            foreach(var ticket in tickets) {
                var minRow = 0;
                var maxRow = 127;
                var row = 0;
                var col = 0;
                for(var i = 0; i < 6; i++) {
                    if(ticket[i] ==  'F') {
                        maxRow -= ((maxRow - minRow) / 2) + 1;
                    }

                    if (ticket[i] == 'B') {
                        minRow += ((maxRow - minRow) / 2) + 1;
                    }
                }

                if(ticket[6] == 'F') {
                    row = minRow;
                } else {
                    row = maxRow;
                }

                var minCol = 0;
                var maxCol = 7;
                for (var i = 7; i < 9; i++) {
                    if (ticket[i] == 'L') {
                        maxCol -= ((maxCol - minCol) / 2) + 1;
                    }

                    if (ticket[i] == 'R') {
                        minCol += ((maxCol - minCol) / 2) + 1;
                    }
                }

                if (ticket[9] == 'L') {
                    col = minCol;
                } else {
                    col = maxCol;
                }

                var ticketId = (row * 8) + col;
                if(ticketId > maxId) {
                    maxId = ticketId;
                }
            }

            return maxId;

        }


        public int SolveBonus() {
            var tickets = File.ReadAllLines(FILE_NAME);
            var maxId = 0;
            var allIds = new List<int>();
            for(var r = 0; r < 128; r++) {
                for(var c = 0; c < 8; c++) {
                    allIds.Add((r * 8) + c);
                }
            }

            foreach (var ticket in tickets) {
                var minRow = 0;
                var maxRow = 127;
                var row = 0;
                var col = 0;
                for (var i = 0; i < 6; i++) {
                    if (ticket[i] == 'F') {
                        maxRow -= ((maxRow - minRow) / 2) + 1;
                    }

                    if (ticket[i] == 'B') {
                        minRow += ((maxRow - minRow) / 2) + 1;
                    }
                }

                if (ticket[6] == 'F') {
                    row = minRow;
                } else {
                    row = maxRow;
                }

                var minCol = 0;
                var maxCol = 7;
                for (var i = 7; i < 9; i++) {
                    if (ticket[i] == 'L') {
                        maxCol -= ((maxCol - minCol) / 2) + 1;
                    }

                    if (ticket[i] == 'R') {
                        minCol += ((maxCol - minCol) / 2) + 1;
                    }
                }

                if (ticket[9] == 'L') {
                    col = minCol;
                } else {
                    col = maxCol;
                }

                var ticketId = (row * 8) + col;
                allIds.Remove(ticketId);
            }

            var id = 0;

            for(var i = 1; i < allIds.Count; i++) {
                if((allIds[i] - allIds[i-1]) > 1) {
                    id = allIds[i];
                    break;
                }
            }

            return id;
        }
    }
}
