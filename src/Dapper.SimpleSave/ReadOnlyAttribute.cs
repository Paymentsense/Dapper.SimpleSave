using System;

namespace Dapper.SimpleSave
{
    [Obsolete("Use of this attribute is deprecated because its name is confusing/misleading when used on a property that has both a getter and setter, such as a convenience property. Please use SimpleSaveIgnoreAttributeInstead", true)]
    public class ReadOnlyAttribute : Attribute
    {
    }
}
