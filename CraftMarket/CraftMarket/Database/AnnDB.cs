using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using CraftMarket.Models;

namespace CraftMarket.Database
{
    public class AnnDB
    {
        readonly SQLiteAsyncConnection db1;

        public AnnDB(string ConnectionString1)
        {
            db1 = new SQLiteAsyncConnection(ConnectionString1);
            db1.CreateTableAsync<Announcement>().Wait();
        }

        public Task<List<Announcement>> GetAnnsAsync()
        {
            return db1.Table<Announcement>().ToListAsync();
        }

        public Task<Announcement> GetAnnAsync(int id)
        {
            return db1.Table<Announcement>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveAnnAsync(Announcement ann)
        {
            if (ann.ID != 0)
            {
                return db1.UpdateAsync(ann);
            }
            else
            {
                return db1.InsertAsync(ann);
            }
        }

        public Task<int> DeleteAnnAsync(Announcement ann)
        {
            return db1.DeleteAsync(ann);
        }
    }
}
