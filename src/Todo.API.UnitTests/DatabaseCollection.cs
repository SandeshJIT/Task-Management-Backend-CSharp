using Todo.API.Model;

namespace Todo.API.UnitTests
{

    [CollectionDefinition("DatabaseCollection")]
    public class DatabaseCollection : ICollectionFixture<DbFixture>, ICollectionFixture<TaskEntity>
    {
        
    }
}
