using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2020.Day_12 {
    public class Day12 {

        public static double DegToRad(double degrees) {
            double radians = (Math.PI / 180) * degrees;
            return (radians);
        } 

        private const string FILE = "Day 12/Data.txt";

        private double xPos = 0;
        private double yPos = 0;
        private double direction = 0;
        private double xWaypoint = 0;
        private double yWaypoint = 0;

        public double Solve() {
            xPos = 0;
            yPos = 0;

            var instructions = File.ReadAllLines(FILE);

            foreach(var instruction in instructions) {
                var action = instruction[0];
                var distance = int.Parse(instruction.Substring(1));
                switch(action) {
                    case 'N':
                        yPos += distance;
                        break;
                    case 'E':
                        xPos += distance;
                        break;
                    case 'S':
                        yPos -= distance;
                        break;
                    case 'W':
                        xPos -= distance;
                        break;
                    case 'F':
                        xPos += Math.Cos(DegToRad(direction)) * distance;
                        yPos += Math.Sin(DegToRad(direction)) * distance;
                        break;
                    case 'L':
                        direction += distance;
                        break;
                    case 'R':
                        direction -= distance;
                        break;
                }
            }


            return Math.Abs(xPos) + Math.Abs(yPos);
        }

        public double SolveBonus() {
            xPos = 0;
            yPos = 0;
            xWaypoint = 10;
            yWaypoint = 1;

            var instructions = File.ReadAllLines(FILE);

            foreach (var instruction in instructions) {
                var action = instruction[0];
                var distance = int.Parse(instruction.Substring(1));
                var startingXWay = xWaypoint;
                var startingyWay = yWaypoint;
                switch (action) {
                    case 'N':
                        yWaypoint += distance;
                        break;
                    case 'E':
                        xWaypoint += distance;
                        break;
                    case 'S':
                        yWaypoint -= distance;
                        break;
                    case 'W':
                        xWaypoint -= distance;
                        break;
                    case 'F':
                        xPos += xWaypoint * distance;
                        yPos += yWaypoint * distance;
                        break;
                    case 'L':
                        xWaypoint = (Math.Cos(DegToRad(distance )) * startingXWay) - (Math.Sin(DegToRad(distance)) * startingyWay);
                        yWaypoint = (Math.Sin(DegToRad(distance )) * startingXWay) + (Math.Cos(DegToRad(distance)) * startingyWay);
                        break;
                    case 'R':
                        xWaypoint = (Math.Cos(DegToRad(distance * -1)) * startingXWay) - (Math.Sin(DegToRad(distance * -1)) * startingyWay);
                        yWaypoint = (Math.Sin(DegToRad(distance * -1)) * startingXWay) + (Math.Cos(DegToRad(distance * -1)) * startingyWay);
                        break;
                }
            }


            return Math.Abs(xPos) + Math.Abs(yPos);
        }
    }
}
