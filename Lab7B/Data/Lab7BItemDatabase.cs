using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Lab7B
{

    class Lab7BItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<Lab7BItemDatabase> Instance = new AsyncLazy<Lab7BItemDatabase>(async () =>
        {
            var instance = new Lab7BItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Lab7BItem>();
            return instance;
        });

        public Lab7BItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<Lab7BItem>> GetItemsAsync()
        {
            return Database.Table<Lab7BItem>().ToListAsync();
        }

        public Task<List<Lab7BItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Lab7BItem>("SELECT * FROM [Lab7BItemItem]");
        }

        public Task<Lab7BItem> GetItemAsync(int id)
        {
            return Database.Table<Lab7BItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Lab7BItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Lab7BItem item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
