using System;
using System.Linq;

namespace PS.Mothership.Core.Common.WcfErrorHandling
{
    public class UniqueKeyGenerator
    {
        public static string Generate()
        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(
                Enumerable.Repeat(chars, 5)
                    .Select(s => s[random.Next(s.Length)])
                    .Concat("_")
                    .Concat(DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"))
                    .ToArray());
        }
    }
}