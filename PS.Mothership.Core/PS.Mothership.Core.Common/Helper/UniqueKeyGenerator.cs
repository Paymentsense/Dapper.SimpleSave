using System;
using System.Linq;

namespace PS.Mothership.Core.Common.Helper
{
    public class UniqueKeyGenerator
    {
        public static string Generate()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var generatedKey = new string(
                Enumerable.Repeat(chars, 5)
                    .Select(s => s[RandomProvider.GetThreadRandom().Next(s.Length)])
                    .ToArray());
            return string.Concat(DateTime.Now.ToString("ddMM"), generatedKey);
        }
    }
}