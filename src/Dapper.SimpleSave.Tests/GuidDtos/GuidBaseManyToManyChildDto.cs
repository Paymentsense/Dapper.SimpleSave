using System;

namespace Dapper.SimpleSave.Tests.GuidDtos
{
    public abstract class GuidBaseManyToManyChildDto : GuidBaseChildDto
    {
        protected GuidBaseManyToManyChildDto()
        {
            //  We don't support INSERTs on many to many child tables so we set a child key here,
            //  otherwise it won't work.
            ChildKey = Guid.NewGuid();
        }
    }
}
