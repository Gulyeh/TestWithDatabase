namespace Task5_0.Drivers
{
    public class EntityFrameworkConfigure : DbContext
    {
        public EntityFrameworkConfigure()
        {
            Log = Set<Log>();
            Test = Set<Test>();
        }

        public DbSet<Log> Log { get; init; }
        public DbSet<Test> Test { get; init; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionModel = ConfigReader.GetValue<ConnectionModel>("connectionData");
            optionsBuilder.UseMySQL($"server={connectionModel.Server};database={connectionModel.Database};user={connectionModel.User};password={connectionModel.Password}");
        }
    }
}