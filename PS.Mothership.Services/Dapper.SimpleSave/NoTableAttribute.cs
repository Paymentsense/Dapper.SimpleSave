using System;

namespace Dapper.SimpleSave
{
    /// <summary>
    /// Mark enums that don't have a corresponding table in the database with this attribute,
    /// otherwise we'll assume they have a table and treat them as such. In practice what this
    /// generally means is that if an enum has a corresponding table its numeric value will be
    /// used as a foreign key reference to that table whereas, if it doesn't, the string value
    /// will be inserted (hasn't been necessary to implement this yet so I'm starting to wonder
    /// if this should just be deleted).
    /// </summary>
    public class NoTableAttribute : Attribute
    {
    }
}
