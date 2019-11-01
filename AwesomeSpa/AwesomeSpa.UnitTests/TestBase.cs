using AwesomeSpa.Data;
using System;
using Xunit;

namespace AwesomeSpa.UnitTests
{
    public class TestBase : IDisposable
    {
        public TestBase() // Setup
        {
            Context = DbContextFactory.Create();
        }

        public ApplicationDbContext Context { get; }

        public void Dispose() // Clean-up
        {
            DbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("ReadTests")]
    public class QueryCollection : ICollectionFixture<TestBase> { }
}
