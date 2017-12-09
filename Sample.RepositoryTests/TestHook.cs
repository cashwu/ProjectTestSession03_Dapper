using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.RepositoryTests.Misc;

namespace Sample.RepositoryTests
{
    [TestClass]
    public class TestHook
    {
        internal static string SampleDbConnection => 
            string.Format(TestDbConnection.LocalDb.LocalDbConnectionString, DatabaseName.SampleDB);

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            // Create SampleDB
            var sampleDbDatabase = new TestDbUtilities(DatabaseName.SampleDB);
            if (sampleDbDatabase.IsLocalDbExists())
            {
                sampleDbDatabase.DeleteLocalDb();
            }
            sampleDbDatabase.CreateDatabase();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // Delete SampleDB
            var defaultDatabase = new TestDbUtilities(DatabaseName.Default);
            defaultDatabase.DeleteLocalDb(SampleDbConnection);
        }
    }
}