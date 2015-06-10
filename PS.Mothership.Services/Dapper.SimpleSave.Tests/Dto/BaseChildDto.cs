using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave.Tests.Dto {
    public abstract class BaseChildDto {
        protected BaseChildDto()
        {
            Name = "Kiddie";
        }

        [PrimaryKey]
        public int ChildKey { get; set; }

        public string Name { get; set; }
    }
}
