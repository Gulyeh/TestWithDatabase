namespace Task5_0.Utils
{
    public static class DatabaseUtils
    {
        public static async Task AddToDatabase<T>(T data) where T : BasicEntity
        {
            var dbContext = SqlDriver.GetConnection();
            if (dbContext is null) return;

            await dbContext.Set<T>().AddAsync(data);
            await dbContext.SaveChangesAsync();
        }

        public static async Task AddRangeToDatabase<T>(IEnumerable<T> data) where T : BasicEntity
        {
            var dbContext = SqlDriver.GetConnection();
            if (dbContext is null) return;

            await dbContext.Set<T>().AddRangeAsync(data);
            await dbContext.SaveChangesAsync();
        }

        public static async Task RemoveRangeFromDatabase<T>(IEnumerable<T> data) where T : BasicEntity
        {
            var dbContext = SqlDriver.GetConnection();
            if (dbContext is null) return;

            dbContext.Set<T>().RemoveRange(data);
            await dbContext.SaveChangesAsync();
        }

        public static async Task<IEnumerable<T>> GetRandomRecords<T>(int amountToGet) where T : BasicEntity
        {
            var dbContext = SqlDriver.GetConnection();
            if (dbContext is null) return new List<T>();

            Random rand = new Random();
            var maxToSkip = dbContext.Set<T>().Count() - amountToGet;
            int toSkip = rand.Next(0, maxToSkip);

            return await dbContext.Set<T>().OrderBy(r => r.Id).Skip(toSkip).Take(amountToGet).ToListAsync();
        }

        public static async Task<IEnumerable<T>> GetTwoRepeatingDigitsInIdRecords<T>(int maxRecords) where T : BasicEntity
        {
            var dbContext = SqlDriver.GetConnection();
            if (dbContext is null) return new List<T>();

            string[] repetitiveDigits = new string[] { "'%0%0%'", "'%1%1%'", "'%2%2%'", "'%3%3%'", "'%4%4%'", "'%5%5%'", "'%6%6%'", "'%7%7%'", "'%8%8%'", "'%9%9%'" };
            Random rand = new Random();
            var toTake = rand.Next(0, maxRecords);

            var sqlQuery = $"SELECT * FROM {typeof(T).Name} WHERE Id LIKE {string.Join(" OR Id LIKE ", repetitiveDigits)}";
            var listOfRows = await dbContext.Set<T>()
                .FromSqlRaw(sqlQuery)
                .ToListAsync();

            var maxToSkip = listOfRows.Count() - toTake;
            int toSkip = rand.Next(0, maxToSkip);

            return listOfRows.Skip(toSkip).Take(toTake).ToList();
        }

        public static async Task<int> GetAmountOfRows<T>() where T : BasicEntity
        {
            var dbContext = SqlDriver.GetConnection();
            if (dbContext is null) return 0;

            return await dbContext.Set<T>().CountAsync();
        }
    }
}