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
            var generatedKey = new string(
                Enumerable.Repeat(chars, 5)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
            return string.Concat(DateTime.Now.ToString("ddMM"), generatedKey);
        }
    }
}