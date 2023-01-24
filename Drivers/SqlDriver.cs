namespace Task5_0.Drivers
{
    public static class SqlDriver
    {
        public static EntityFrameworkConfigure? sqlConnection;

        public static EntityFrameworkConfigure? GetConnection()
        {
            if (sqlConnection is null)
                sqlConnection = new EntityFrameworkConfigure();
            return sqlConnection;
        }

        public static void Dispose()
        {
            sqlConnection?.Dispose();
            sqlConnection = null;
        }
    }
}