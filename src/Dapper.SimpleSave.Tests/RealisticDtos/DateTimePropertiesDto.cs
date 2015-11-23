using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.RealisticDtos
{
    [Table("[test].[DATETIMEPROPERTIES]")]
    public class DateTimePropertiesDto
    {
        [PrimaryKey]
        public int? DateTimePropertiesKey { get; set; }

        public DateTime? DateTimeProperty { get; set; }

        public DateTimeOffset? DateTimeOffsetProperty { get; set; }
    }
}
