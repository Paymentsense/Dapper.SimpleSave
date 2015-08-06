# Dapper.SimpleSave - simply save objects to a database

Dapper.SimpleSave makes it easy to save complex object hierarchies to a relational database.

[![Build status](https://ci.appveyor.com/api/projects/status/a4wyo6k561cn16ut?svg=true)](https://ci.appveyor.com/project/PaymentSense/dapper-simplesave)

##How can Dapper.SimpleSave help me?

[Dapper](https://github.com/StackExchange/dapper-dot-net) makes it really easy to load rows from a database into POCOs.

However, except for the most basic CRUD operations involving a single object, it doesn't help much with saving when you're dealing with complex hierarchies of objects.

Let's take the concept of a user within an organisation:

* A User:
    * has one Office Phone Number,
    * has one Position
    * is a member of one or more Departments,
    * and one or more Teams,
    * and has zero or more Additional Roles,
    * as well as a bunch of basic properties like FirstName, LastName, Username, Email, etc.


Furthermore:

* a User's roles are defined by their Position and Departments, as well as any Additional Roles they might be assigned,
* Office Phone Numbers can only be assigned to a single User,
* many Users might hold the same Position,
* whilst Departments, Teams, and Roles all have many Users.


So we can see that the relationship between Users and Office Phone Numbers is 1:1, whereas that between Users and Departments, Teams, and Roles are all M:N (i.e., many to many).

In a relational database system M:N relationships are modelled using link tables. So, for example, to link the User table to Departments, we might have a Lnk_UserDepartment table whose rows contain pairs of foreign key references to rows in User and Department.
This can be seen in Figure 1, below.


**Figure 1. Visualisation of partial user schema.**

In code, however, we don't really want to be dealing with the hassle of link tables. Something more OO would be better:

```C#
    public class UserDto
    {
        ....
        public string FirstName { get; set; }
        public string LastName { get; set; }
        ...
        public OfficeNumberDto OfficeNumber { get; set; }
        ...
        public PositionDto Position { get; set; }
        public IList<DepartmentDto> Department { get; set; }
        public IList<RoleDto> AdditionalRoles { get; set; }
        public IList<TeamDto> Team { get; set; }
    }
```

Note the absence of anything resembling the modelling of link tables.

When we edit a user we might change a load of their basic properties (LastName, Email, etc.), assign them to a new Position, move them to one or more new Departments, and change their Team membership (imagine they got married, came back from honeymoon, and immediately got a big promotion).

The point being that we want to save all these changes in one go without having to write loads of code to do it - calculating which objects need adding/updating/deleting, in what order, and what SQL we need to execute to do this - for each different object type we want to save.

This is where Dapper.SimpleSave comes in. It exists to:

* Simplify saving complex objects to the database,
* Quickly,
* Reliably,
* With minimal configuration,

And to allow us to make sensible design decisions both in our code and in our database schemas.

##How do I use Dapper.SimpleSave?

We wanted to make using Dapper.SimpleSave similar to using Dapper so, just like loading data with Dapper, you save objects by calling extension methods on IDbConnection.

There are four things you need to do:

1. Reference the Dapper.SimpleSave project, which you can find in the services solution (or corresponding Nuget package if/when we implement package publishing).
2. Import the Dapper.SimpleSave namespace anywhere you want to use Dapper.SimpleSave.
3. Decorate any DTOs or other objects you want to save to the database with appropriate SimpleSave attributes.
4. Call extension methods on IDbConnection to save objects. We provide Create<T>, Update<T>, and Delete<T>.

We'll look at the last two points in detail below.

##Attribute decoration

At the moment you need to decorate any objects you want to save to your database with attributes. In the future we may support wire-up, which means the types being saved don't need to know anything about Dapper.SimpleSave.

###Basic attributes:

* **`[Table(schemaQualifiedTableName)]`** - every type you want to save should be decorated with this attribute. We've only tested it on classes, but it ought to work with interfaces (it may not honour the contract at the moment), and structs too. You must qualify the table name with its schema, e.g., "[user].[USER_MST]". We recommend the use of square braces around identifiers to avoid running into potential issues with T-SQL reserved words, of which there are a surprisingly large number.
* **`[ReferenceData]`** - add this attribute to any type representing a table that contains reference data that is not intended to be updated. Dapper.SimpleSave will not try to save entities marked as such to the database, unless you use the constructor overload that takes a bool indicating whether or not the table has updateable foreign keys. If so, i.e., you passed in true, it will allow the update of columns containing foreign key values only.
* **`[PrimaryKey]`** - mark the property used as the primary key, which must be an int?, long?, or GUID? with this attribute.
* **`[Column(name)]`** - not needed in most cases but, if your database column name differs from the property name in code, mark it with this attribute and pass in the name of the column in the database.
* **`[SimpleSaveIgnore]`** - mark any columns you don't want saved to the database with this. For example, you might want to ignore any computed columns.
* **`[ReadOnly]`** - this attribute has been deprecated and replaced by `[SimpleSaveIgnore]`. If you continue to use the `[ReadOnly]` attribute you'll get a compile time error that asks you to use `[SimpleSaveIgnore]` instead.
* **`[SoftDeleteColumn(trueIndicatesDeleted)]`** - for situations where you need to support soft deletion of database records, mark the column that indicates whether or not a record is live or deleted with this attribute. Only columns of type `BIT` (i.e., mapping to `bool` in C#) are supported. You can optionally pass a parameter indicating whether `true` (or 1) indicates the record has been deleted, or `false` (i.e., 0, the default).

###Relationship cardinality attributes

* **`[ManyToMany(schemaQualifiedLinkTableName)]`** - mark enumerable properties with a many to many relationship with the underlying entity with this. Dapper.SimpleSave will not try to update the underlying entity at all, but rather will add or remove records in the specified link table. In a many to many relationship Dapper.SimpleSave will assume that child records should not be modified since other records in the parent table may depend on them. If you need to update items in the enumerable you should define a different DTO type for this purpose.
* **`[ManyToOne]`** - mark any properties representing many to one relationships with this attribute. Dapper.SimpleSave will assume the foreign key is in the column corresponding to the marked property. It's fine to use the [Column] attribute to specify a different name for the underlying column if it doesn't match the property name. Again, since other records can depend upon the child object, Dapper.SimpleSave will not try to modify child rows. If you need to modify the child rows define another DTO type for this purpose.
* **`[OneToMany]`** - mark any properties representing one to many relationships with this attribute. Dapper.SimpleSave will look for the foreign key in the child object.
* **`[OneToOne]`** - one to one relationships can be defined with the foreign key either on the parent or the child. Therefore, if the property is also marked with a `[ForeignKey]` (see below), Dapper.SimpleSave will assume there is an underlying column containing the foreign key value (again, renaming with `[Column]` is fine) in the parent entity. Otherwise it will assume the foreign key is in the child entity and you should supply the name of the FK column to the constructor for `[OneToOne]`, and mark the appropriate property on the child type with a `[ForeignKey]` attribute.
* **`[ForeignKey(Type referencedDto)]`** - in practice, rarely needed. Marks a property as a foreign key relationship with the specified DTO. Generally only needed for one to one relationships.

###Example: decorating UserDto

Taking our UserDto above as an example, the final decorated version looks like this:

```c#
    [Table("[user].USER_MST")]
    public class UserDto
    {
        [PrimaryKey]
        public int? UserKey { get; set; }
        public Guid UserGUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        [Column("UserStatusKey")]
        [ManyToOne]
        public UserStatusEnum Status { get; set; }
        public string CountryCode { get; set; }
        public string PersonalMobileNumber { get; set; }
        public string BusinessMobileNumber { get; set; }
        [Column("OfficeNumberKey")]
        [OneToOne]
        [ForeignKeyReference(typeof(OfficeNumberDto))]
        public OfficeNumberDto OfficeNumber { get; set; }
        public string VirtualLineNumber { get; set; }
        public string EmailAddress { get; set; }
        public int PasswordFailureCount { get; set; }
        [ManyToOne]
        [Column("PositionKey")]
        public PositionDto Position { get; set; }
        [ManyToMany("[user].USER_DEPARTMENT_LNK")]
        public IList<DepartmentDto> Department { get; set; }
        [ManyToMany("[user].USER_ADDITIONAL_ROLES_LNK")]
        public IList<RoleDto> AdditionalRoles { get; set; }
        [ManyToMany("[user].USER_TEAM_LNK")]
        public IList<TeamDto> Team { get; set; }
    }
```

##IDBConnection extension methods

###Extension methods for saving single objects

Use these `IDbConnection` extension methods to save a single object:

```C# 
public static void Create<T>(this IDbConnection connection, T obj, IDbTransaction transaction = null);
public static void Update<T>(this IDbConnection connection, T oldObject, T newObject, IDbTransaction transaction = null);
public static void Delete<T>(this IDbConnection connection, T obj, IDbTransaction transaction = null);
public static void SoftDelete<T>(this IDbConnection connection, T obj, IDbTransaction transaction = null);
```

To save an object, all you have to do is call the appropriate method.

When using the Update<T> method, you must supply both the old version of the object and the new version (see below for an explanation of why). If you only supply the old version you will end up deleting the object. If you supply only the new version, you'll create a new object in the database. (Today's challenge: without looking at the code, see if you can figure out how Create<T> and Delete<T> are implemented.)

If you do not pass in a transaction, Dapper.SimpleSave will create a transaction to encapsulate all the operations required to create, update, or delete the object you supply to the method.

In the case where Dapper.SimpleSave creates the transaction for you, all row changes that need to be made in the database will either succeed in totality, or all of them will fail. If a transaction fails for any reason an exception will be thrown. Often this will be a SqlException, but there are other things that can go wrong - for example, Dapper.SimpleSave does perform some basic validation checks on your entities - so don't assume you'll only see SqlExceptions out of these methods.

If you supply the transaction yourself, you'll still get the exception, but it becomes your responsibility to decide what to do about it - i.e., whether to rollback the transaction or not.

####A brief word on `SoftDelete<T>(...)`

Use `SoftDelete<T>(...)` when, rather than actually deleting records, you only want to mark them as deleted by setting a `BIT`/`bool` value on a column. You need to mark the property corresponding to this column with the `[SoftDeleteColumn]` attribute.

When you soft delete only the root record will be marked as soft deleted. Child records in other tables will be untouched. This is because, say you want to undo the soft delete, it becomes possible to restore the entire hierarchy or records. If we recursively soft deleted we'd lose information about any child records that may or may not have been separately soft deleted.

###Extension methods for saving collections of objects

Use these `IDbConnection` extension methods to save collections of objects:

```C#
public static void CreateAll<T>(this IDbConnection connection, IEnumerable<T> newObjects, IDbTransaction transaction = null);
public static void UpdateAll<T>(this IDbConnection connection, IEnumerable<Tuple<T, T>> oldAndNewObjects, IDbTransaction transaction = null);
public static void UpdateAll<T>(this IDbConnection connection, IEnumerable<T> newObjects, Func<T, T> mapNewObjectToOldObject, IDbTransaction transaction = null);
public static void UpdateAllMappingFromOldObjects<T>(this IDbConnection connection, IEnumerable<T> oldObjects, Func<T, T> mapOldObjectToNewObject, IDbTransaction transaction = null);
public static void DeleteAll<T>(this IDbConnection connection, IEnumerable<T> oldObjects, IDbTransaction transaction = null);
public static void SoftDeleteAll<T>(this IDbConnection connection, IEnumerable<T> objects, IDbTransaction transaction = null);
```

The same principles, particularly with respect to transactions, apply here as to the single object methods.

If you don't supply a transaction, instead leaving Dapper.SimpleSave to create it for you, either all the objects in the collection will be saved, or none of them will (if an error occurs). If a transaction is rolled back the exception that caused the rollback is rethrown so you'll know about it.

If you supply the transaction Dapper.SimpleSave will allow exceptions to bubble up to you but won't rollback when they occur - that responsibility becomes yours.

Similarly `SoftDeleteAll<T>(...)` will mark all root records in the collection as soft deleted. Remember to add the `[SoftDeleteColumn]` attribute to the relevant property on your `T`s.

###General points on working with the extension methods

It's perfectly OK to do partial creates/updates if you have a DTO that represents part of your object hierarchy. For example, we might define a BasicUserDto that contains only name, email, username, and office phone number details for faster retrieval of only these values via Dapper, and faster saving via Dapper.SimpleSave. Obviously you're on dangerous ground if you try to use one of these 'partial entities' to create new rows because you might be missing properties corresponding to NOT NULL columns with no defaults defined, in which case you'll get an error back from the database.

Note that, as a general rule, if you need the full DTO hierarchy for some part of handling a request, you should use it throughout. The cost of an additional round trip to the database just to get a more slimline version of the data when you need full fat elsewhere will vastly outweigh any saving made by not building the full hierarchy. This implies a design decision: if some methods work with a partial DTO, and some with full fat, then you may wish to implement the partial DTO as a base class of the full to take advantage of polymorphism. Of course you may prefer a clean separation with no inheritance, at the cost of some duplication.

##How does Dapper.SimpleSave work?

For pattern junkies, Dapper.SimpleSave encapsulates an implementation of a well known enterprise architeture pattern known as Unit of Work. It also assumes that the objects it saves are a bit like Row Data Gateways (though if you're just working with DTOs, they're not really).

The process by which Dapper.SimpleSave saves data to the database is as follows:

1. Perform a deep comparison between the current object and the previous version of that object, and build a list of differences.
2. Use the list of differences to build a list of operations that describe the changes that need to be made to the corresponding database rows to make them match the new version of the object.
3. Use the list of operations to build a list of commands that will provide the template for the SQL that will be generated - in particular coalesce updates into a single command for each row.
4. Use the list of commands to build the minimum number of parameterised SQL batches that will update the database with the required changes.
5. Execute the SQL batches sequentially as a single database transaction to update the database, resolving any previously unknown primary key values before each batch is executed.

Since SQL Server does not support deferred referential integrity checks, implicit in the above is that operations are performed in the correct order to ensure that referential integrity is maintained throughout the duration of the transaction. We do not yet have an explicit topological sort step, but rather imply this with the order in which the list of operations is built. Therefore, there are possibly situations where script execution will fail that we haven't yet encountered.

Should such a situation arise there are a number of options:

1. Raise a bug against Dapper.SimpleSave. We'll evaluate it as a community and decide on the best course of action (we might choose to fix, or not fix because we choose not to support certain scenarios - for example if such a scenario is very rare, yet disproportionately complex to support),
2. You can fork Dapper.SimpleSave, fix the bug, and submit a PR (we'd like this a lot),
3. You could tactically remove or alter foreign key relationships in the underlying database - in particular we recommend you avoid circular relationships (these are explicitly NOT supported already),
4. Make isolated use of a more full-featured ORM, such as EF.
5. Write Raw Dapper or ADO.NET custom code to update the database,
6. For particularly complex bounded contexts, a CQRS approach may be justified but this really should be an option of last resort.

##Known/Intended Limitations

* You can't map a single object to multiple rows across several tables. Some ORMs support this but, like Dapper itself, we wanted Dapper.SimpleSave to be fast and simple to use, and we're not trying to be EF or NHibernate. If you want to do this kind of thing you'll therefore need to use object composition with 1:1 relationships. E.g, a UserDto has a reference to an OfficeNumberDto, and an OfficeNumberDto is assigned to only one user. Alternatively, you can create a VIEW and create a type that maps to it, performing updates that way.
* Only nullable integer, long, and GUID primary keys are supported at present. We never intend to support any J Random Datatypes as PKs. Nor do we intend to support compound keys (primary and foreign keys across multiple columns). We intend to keep it simple.
* Types **must** have a primary key.
* Only public read/write properties are saved.
* Circular reference chains are not supported and never will be.

##FAQ

###Do my objects need to implement a property for every column in the corresponding database table?

No, not at all. Dapper.SimpleSave doesn't pay any attention to the actual database schema, deriving all the information it needs from your .NET types and the attribute decorations you've added to them.

##Can I customise the SQL that Dapper.SimpleSave generates?

No, this is not supported. Hopefully it'll never be supported. If you find yourself in a situation where this is absolutely necessary you may wish to consider alternative strategies (e.g., write raw Dapper or ADO.NET code).

##Why do I need to provide the old object when I want to save changes to an existing object (i.e., do an UPDATE)? Isn't this inefficient?

One of the assumptions that we built Dapper.SimpleSave on is that roundtrips to the database are relatively expensive compared with computation time within a process boundary. This takes into account fallacies 2 (latency is zero) and 7 (transport cost is zero) of the Fallacies of distributed computing. // TODO: LINKY

We therefore want to minimise the number of such roundtrips. Or, in other words, if we view our service layer and the database as separate nodes in a distributed system, we want to minimise the chattiness of the protocol they use to communicate by keeping things as course grained as possible. Why UPDATE or DELETE rows in different tables one at a time when you could do ten at once?

Unfortunately this logic doesn't hold for INSERTs due to the need to retrieve primary key values for newly inserted rows and populate the objects to which they map so that
these values can then be reused in subsequent INSERTs or UPDATEs within the same transaction, our objects will be in a correct state should we wish to continue using them after our database transaction has completed.

Sometimes we can still bundle INSERTs in with other DDL statements but they will always be the last or last but one statement in any batch of SQL we send to the server. For numeric PKs the very last statement in a batch is a command that retrieves the PK value of the inserted row.

Getting back to the original question therefore, we need the old version of the object so that we can compare it with the new version to find out what has changed. As already described, this then allows us to build the SQL batches we need to save those changes to the database.

##Why do I need to provide an object, rather than just a primary key value, to the Delete<T> method?

Remember that Dapper.SimpleSave is concerned with saving hierarchies of objects to a database. Therefore, to correctly execute a DELETE it needs the complete object hierarchy, with you passing in the reference to the top level object, e.g., a User. A DELETE will general involve multiple DELETEs and UPDATEs across multiple tables. Dapper.SimpleSave can't calculate what these should be without the whole object.

Moreover, Dapper.SimpleSave only deals with writing objects to the database. It has no idea how to read them - that's what Dapper and, in particular, its multi-mapping functionality are for. If you give it only a primary key value, it has no idea how to rebuild the complete object hierarchy from it, so can't execute a correct transaction to delete that object and its children.

(Assuming you've implemented a repository pattern you're obviously perfectly free to implement Delete() methods on them that take only a primary key value, as long as you pass the object itself - either from a cache, or freshly loaded from the database - into Dapper.SimpleSave.)

##Where do I get the old object from?

It depends:

* It might be acceptable to retrieve it directly from the database, assuming this is inexpensive (this should be true if your database is well optimised, and you can pull it back with a single query),
* Alternatively, if roundtripping is an issue you might have implemented some form of middleware caching, in which case you should pull the old object from there, and replace it with the new after a successful save.


TODO: DOCUMENT SOFT DELETE SUPPORT
TODO: EXAMPLES FOR EACH RELATIONSHIP TYPE
