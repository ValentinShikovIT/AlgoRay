using System;

namespace AlgoRay.UnitTests.Helpers
{
    internal static class Extensions
    {
        internal static string[] SplitWihtoutEmptyEntries(this string str, params string[] separator)
            => str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
    }
}
