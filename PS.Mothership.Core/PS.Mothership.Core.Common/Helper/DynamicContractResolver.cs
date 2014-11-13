using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace PS.Mothership.Core.Common.Helper
{
    public class DynamicContractResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            return objectType.GetProperties()
                .Where(p => p.GetIndexParameters().Length == 0)
                .Cast<MemberInfo>()
                .ToList();
        }
    }
}
