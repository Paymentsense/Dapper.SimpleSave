using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.SimpleSave.Tests.Dto;
using NUnit.Framework;

namespace Dapper.SimpleSave.Tests
{

    [TestFixture]
    public class OneToOneRelationshipFkOnParentScriptGenerationTests
    {
        public void insert_with_fk_on_parent_no_reference_data_inserts_rows_in_child_and_parent()
        {
            var newDto = new ParentDto
            {
                OneToOneChildDtoNoFk = new OneToOneChildDtoNoFk()
            };

            insert_maybe_inserts_in_child_and_always_in_parent(newDto, typeof(OneToOneChildDtoNoFk), true);
        }
    }
}
