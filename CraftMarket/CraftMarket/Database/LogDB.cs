using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using CraftMarket.Models;

namespace CraftMarket.Database
{
    public class LogDB
    {
        readonly SQLiteAsyncConnection db2;

        public LogDB(string ConnectionString1)
        {
            db2 = new SQLiteAsyncConnection(ConnectionString1);
            db2.CreateTableAsync<Registration>().Wait();
        }

        public Task<List<Registration>> GetAnnsAsync()
        {
            return db2.Table<Registration>().ToListAsync();
        }

        public Task<Registration> GetAnnAsync(int id)
        {
            return db2.Table<Registration>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveAnnAsync(Registration log)
        {
            if (log.ID != 0)
            {
                return db2.UpdateAsync(log);
            }
            else
            {
                return db2.InsertAsync(log);
            }
        }

        public Task<int> DeleteAnnAsync(Registration log)
        {
            return db2.DeleteAsync(log);
        }
    }
}
