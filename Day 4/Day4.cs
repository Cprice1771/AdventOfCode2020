using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2020.Day_4 {
    public class Day4 {
        private const string BIRTH_YEAR = "byr";
        private const string ISSUE_YEAR = "iyr";
        private const string EXPIRATION_YEAR = "eyr";
        private const string HEIGHT = "hgt";
        private const string HAIR_COLOR = "hcl";
        private const string EYE_COLOR = "ecl";
        private const string PASSPORT_ID = "pid";
        private const string COUNTRY_ID = "cid";

        private const string FILE_NAME = "Day 4/data.txt";

        class PassportData {
            public string BirthYear { get; set; } = null;
            public string IssueYear { get; set; } = null;
            public string ExpirationYear { get; set; } = null;
            public string Height { get; set; } = null;
            public string HairColor { get; set; } = null;

            public string EyeColor { get; set; } = null;
            public string PassportId { get; set; } = null;
            public string CountryId { get; set; } = null;

            public bool IsValid() {
                return !string.IsNullOrEmpty(BirthYear) &&
                    !string.IsNullOrEmpty(IssueYear) &&
                    !string.IsNullOrEmpty(ExpirationYear) &&
                    !string.IsNullOrEmpty(Height) &&
                    !string.IsNullOrEmpty(HairColor) &&
                    !string.IsNullOrEmpty(EyeColor) &&
                    !string.IsNullOrEmpty(PassportId);
            }

            private bool validateHeight(string height) {
                if(height.Contains("cm")) {
                    return int.TryParse(height.Replace("cm", ""), out int hgtcm) && hgtcm >= 150 && hgtcm <= 193;
                } else if(height.Contains("in")) {
                    return int.TryParse(height.Replace("in", ""), out int hgtcm) && hgtcm >= 59 && hgtcm <= 76;
                }

                return false;
            }

            private bool ValidateHairColor(string hairColor) {

                var charArr = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

                if(!(hairColor.Length == 7 && hairColor[0] == '#')) {
                    return false;
                }

                for(var i = 1; i < hairColor.Length; i++) {
                    if(!charArr.Contains(hairColor[i])) {
                        return false;
                    }
                }

                return true;
            }

            

            public bool BonusIsValid() {
                return !string.IsNullOrEmpty(BirthYear) &&
                    int.TryParse(BirthYear, out int byear) &&
                    byear >= 1920 && byear <= 2002 &&
                    !string.IsNullOrEmpty(IssueYear) &&
                    int.TryParse(IssueYear, out int iyear) &&
                    iyear >= 2010 && iyear <= 2020 &&
                    !string.IsNullOrEmpty(ExpirationYear) &&
                    int.TryParse(ExpirationYear, out int iexpyear) &&
                    iexpyear >= 2020 && iexpyear <= 2030 &&
                    !string.IsNullOrEmpty(Height) &&
                    validateHeight(Height) &&
                    !string.IsNullOrEmpty(HairColor) &&
                    ValidateHairColor(HairColor) &&
                    !string.IsNullOrEmpty(EyeColor) &&
                    new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(EyeColor) &&
                    !string.IsNullOrEmpty(PassportId) &&
                    PassportId.Length == 9 && long.TryParse(PassportId, out long pid);
            }
        }

        public int Solve(bool bonus = false) {
            var file = File.ReadAllLines(FILE_NAME);
            var validCount = 0;
            var passport = new PassportData();
            foreach (var line in file) {
                if(string.IsNullOrWhiteSpace(line)) {

                    if(bonus) {
                        if (passport.BonusIsValid()) {
                            validCount++;
                        }
                    } else {
                        if (passport.IsValid()) {
                            validCount++;
                        }
                    }
                    
                    passport = new PassportData();
                    continue;
                }

                foreach(var token in line.Split(' ')) {
                    var kvp = token.Split(':');
                    switch(kvp[0]) {
                        case BIRTH_YEAR:
                            passport.BirthYear = kvp[1];
                            break;
                        case ISSUE_YEAR:
                            passport.IssueYear = kvp[1];
                            break;
                        case EXPIRATION_YEAR:
                            passport.ExpirationYear = kvp[1];
                            break;
                        case HEIGHT:
                            passport.Height = kvp[1];
                            break;
                        case HAIR_COLOR:
                            passport.HairColor = kvp[1];
                            break;
                        case EYE_COLOR:
                            passport.EyeColor = kvp[1];
                            break;
                        case PASSPORT_ID:
                            passport.PassportId = kvp[1];
                            break;
                        case COUNTRY_ID:
                            passport.CountryId = kvp[1];
                            break;

                    }
                }

            }

            
            if (passport.IsValid()) {
                validCount++;
            }
            

            return validCount;

        }
    }
}
