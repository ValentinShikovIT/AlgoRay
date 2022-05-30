using AlgoRay.UnitTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.UnitTests.Setups.Dummies
{
    internal static class CombinatoricsDummies
    {
        internal static class Permutations
        {
            public static (string[] Input, List<string[]> ExpectedOutput) Test_WithoutRepetition { get; } =
                (new string[] { "A", "B", "C" },
                new List<string[]>
                {
                    new string[] {"A", "B", "C"},
                    new string[] {"A", "C", "B"},
                    new string[] {"B", "A", "C"},
                    new string[] {"B", "C", "A"},
                    new string[] {"C", "A", "B"},
                    new string[] {"C", "B", "A"},
                });

            public static (string[] Input, List<string[]> ExpectedOutput) Test_WithRepetition { get; } =
                (new string[] { "A", "B", "B" },
                new List<string[]>
            {
                new string[] {"A", "B", "B"},
                new string[] {"B", "A", "B"},
                new string[] {"B", "B", "A"},
            });
        }

        internal static class Variations
        {
            public static (string[] Input, int LengthOfVariationWithoutRepetitions, List<string[]> Expected) Test_WithoutRepetition { get; } =
                (new string[] { "A", "B", "C" },
                2,
                new List<string[]>
                {
                    new string[] {"A", "B"},
                    new string[] {"A", "C"},
                    new string[] {"B", "A"},
                    new string[] {"B", "C"},
                    new string[] {"C", "A"},
                    new string[] {"C", "B"},
                });

            public static (string[] Input, int LengthOfVariationWithRepetitions, List<string[]> Expected) Test_WithRepetition { get; } =
                (new string[] { "A", "B", "C" },
                2,
                new List<string[]>
                {
                    new string[] {"A", "A"},
                    new string[] {"A", "B"},
                    new string[] {"A", "C"},
                    new string[] {"B", "A"},
                    new string[] {"B", "B"},
                    new string[] {"B", "C"},
                    new string[] {"C", "A"},
                    new string[] {"C", "B"},
                    new string[] {"C", "C"},
                });
        }

        internal static class Combinations
        {
            public static (string[] Input, int LengthOfCombinationWithoutRepetitions, List<string[]> Expected) Test_WithoutRepetition { get; } =
                (new string[] { "A", "B", "C" },
                2,
                new List<string[]>
                {
                    new string[] {"A", "B"},
                    new string[] {"A", "C"},
                    new string[] {"B", "C"},
                });

            public static (string[] Input, int LengthOfCombinationWithRepetitions, List<string[]> Expected) Test_WithRepetition { get; } =
                (new string[] { "A", "B", "C" },
                2,
                new List<string[]>
                {
                    new string[] {"A", "A"},
                    new string[] {"A", "B"},
                    new string[] {"A", "C"},
                    new string[] {"B", "B"},
                    new string[] {"B", "C"},
                    new string[] {"C", "C"},
                });
        }

        internal static class NChooseKCountBinom
        {
            public static (int N, int K, int Expected) Test_1 { get; } =
                (3, 2, 3);

            public static (int N, int K, int Expected) Test_2 { get; } =
                (5, 3, 10);
        }

        internal static class ReverseArrayByRecursion
        {
            public static (string[] Input, string[] Expected) Test_1 { get; } =
                (new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" }, 
                new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" }.Reverse().ToArray());

            public static (string[] Input, string[] Expected) Test_2 { get; } =
                (new string[] { "asd", "rtex", "sad" },
                new string[] { "asd", "rtex", "sad" }.Reverse().ToArray());
        }

        internal static class NestedLoopsToRecursion
        {
            public static (int Input, IList<int[]> Expected) Test_1 { get; } =
                (2,
                new List<int[]>()
                {
                    new[] { 1, 1 },
                    new[] { 1, 2 },
                    new[] { 2, 1 },
                    new[] { 2, 2 },
                });
        }

        internal static class ConnectedAreasInMatrix
        {
            public static (char[,] InputMatrix, IList<string> Expected) Test_1 { get; } =
                (new char[,]
                {
                    { '-', '-', '-', '*', '-', '-', '-', '*', '-' },
                    { '-', '-', '-', '*', '-', '-', '-', '*', '-' },
                    { '-', '-', '-', '*', '-', '-', '-', '*', '-' },
                    { '-', '-', '-', '-', '*', '-', '*', '-', '-' }
                },
                new List<string>
                {
                    "Total areas found: 3",
                    "Area #1 at (0, 0), size: 13",
                    "Area #2 at (0, 4), size: 10",
                    "Area #3 at (0, 8), size: 5"
                });
        }

        internal static class Cinema
        {
            internal static (IList<string> Names, IDictionary<string, int> PlaceChanges, IList<string[]> Expected) Test_1 { get; } =
                ("Peter, Amy, George, Rick".Split(", ").ToList(),
                new Dictionary<string, int>()
                {
                    {"Amy", 1},
                    {"Rick", 4 }
                },
                @"Amy Peter George Rick
                Amy George Peter Rick"
                .Split(Environment.NewLine)
                .Select(names => names.TrimStart().SplitWihtoutEmptyEntries())
                .ToList());

            internal static (IList<string> Names, IDictionary<string, int> PlaceChanges, IList<string[]> Expected) Test_2 { get; } =
                ("Garry, Liam, Teddy, Anna, Buddy, Simon".Split(", ").ToList(),
                new Dictionary<string, int>()
                {
                    {"Buddy", 3 },
                    {"Liam", 5 },
                    {"Simon", 1 }
                },
                 @"Simon Garry Buddy Teddy Liam Anna
                Simon Garry Buddy Anna Liam Teddy
                Simon Teddy Buddy Garry Liam Anna
                Simon Teddy Buddy Anna Liam Garry
                Simon Anna Buddy Garry Liam Teddy
                Simon Anna Buddy Teddy Liam Garry"
                .Split(Environment.NewLine)
                .Select(names => names.TrimStart().SplitWihtoutEmptyEntries())
                .ToList());
        }

        internal static class SchoolTeams
        {
            internal static (IList<string> GirlNames, IList<string> BoyNames, IList<string[]> Expected) Test_1 { get; } =
                ("Linda, Amy, Katty".Split(", ").ToList(),
                "John, Bill".Split(", ").ToList(),
                "Linda, Amy, Katty, John, Bill"
                .Split(Environment.NewLine)
                .Select(names => names.Split(", "))
                .ToList());

            internal static (IList<string> GirlNames, IList<string> BoyNames, IList<string[]> Expected) Test_2 { get; } =
                ("Lisa, Yoana, Marta, Rachel".Split(", ").ToList(),
                "George, Garry, Bob".Split(", ").ToList(),
                @"Lisa, Yoana, Marta, George, Garry
                Lisa, Yoana, Marta, George, Bob
                Lisa, Yoana, Marta, Garry, Bob
                Lisa, Yoana, Rachel, George, Garry
                Lisa, Yoana, Rachel, George, Bob
                Lisa, Yoana, Rachel, Garry, Bob
                Lisa, Marta, Rachel, George, Garry
                Lisa, Marta, Rachel, George, Bob
                Lisa, Marta, Rachel, Garry, Bob
                Yoana, Marta, Rachel, George, Garry
                Yoana, Marta, Rachel, George, Bob
                Yoana, Marta, Rachel, Garry, Bob"
                .Split(Environment.NewLine)
                .Select(names => names.TrimStart().SplitWihtoutEmptyEntries(", "))
                .ToList());
        }

        internal static class WordCruncher
        {
            internal static (string[] WordParts, string Word, IList<string[]> Expected) Test_1 { get; } = 
                ("text, me, so, do, m, ran".Split(", ").ToArray(), 
                "somerandomtext", 
                "so me ran do m text".Split(Environment.NewLine)
                .Select(names => names.Split())
                .ToList());

            internal static (string[] WordParts, string Word, IList<string[]> Expected) Test_2 { get; } = 
                ("Word, cruncher, cr, h, unch, c, r, un, ch, er".Split(", ").ToArray(),
                "Wordcruncher",
                @"Word c r un ch er
                Word c r unch er
                Word cr un c h er
                Word cr un ch er
                Word cr unch er
                Word cruncher".Split(Environment.NewLine)
                .Select(names => names.TrimStart().SplitWihtoutEmptyEntries())
                .ToList());

            internal static (string[] WordParts, string Word, IList<string[]> Expected) Test_3 { get; } =
                ("tu, stu, p, i, d, pi, pid, s, pi".Split(", ").ToArray(),
                "stupid",
                @"s tu p i d
                s tu pi d
                s tu pid
                stu p i d
                stu pi d
                stu pid".Split(Environment.NewLine)
                .Select(names => names.TrimStart().SplitWihtoutEmptyEntries())
                .ToList());
        }
    }
}

