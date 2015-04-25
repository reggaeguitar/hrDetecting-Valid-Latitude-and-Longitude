using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace hrDetecting_Valid_Latitude_and_Longitude
{
    class Program
    {
        static void Main()
        {
            var numCases = Int32.Parse(Console.ReadLine());
            var regex = new Regex(@"\([+-]?(\d*\.?\d*), [+-]?(\d+\.?\d*)\)");
            while (numCases-- > 0)
            {
                var str = Console.ReadLine();
                bool valid = true;
                var match = regex.Match(str);
                if (match.Groups.Count != 3)
                {
                    valid = false;
                }
                else
                {
                    var str1 = match.Groups[1].Value;
                    var str2 = match.Groups[2].Value;
                    if (HasLeadingZeroes(str1))
                    {
                        valid = false;
                    }
                    if (valid && HasLeadingZeroes(str2))
                    {
                        valid = false;
                    }
                    if (valid && HasTrailingPeriod(str1))
                    {
                        valid = false;
                    }
                    if (valid && HasTrailingPeriod(str2))
                    {
                        valid = false;
                    }
                    if (valid)
                    {
                        var num1 = Double.Parse(str1);
                        var num2 = Double.Parse(str2);
                        valid = CheckNumericalRange(num1, 90);
                        if (valid)
                        {
                            valid = CheckNumericalRange(num2, 180);
                        }
                    }
                }
                Console.WriteLine(valid ? "Valid" : "Invalid");
            }
        }

        private static bool HasTrailingPeriod(string str)
        {
            return str.TrimEnd().Last() == '.';
        }

        private static bool CheckNumericalRange(double num, int max)
        {
            num = Math.Abs(num);
            return !(num > max);
        }

        static bool HasLeadingZeroes(string str)
        {
            int index;
            if (str.StartsWith("+") || str.StartsWith("-"))
            {
                index = 1;
            }
            else
            {
                index = 0;
            }
            return str[index] == '0';
        }
    }
}
