using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SekiroChecklist.Models;
using SQLite;

namespace SekiroChecklist.Repositories
{
    public class ItemsRepository
    {
        readonly SQLiteAsyncConnection database;

        public ItemsRepository(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            var result = database.ExecuteScalarAsync<int>("SELECT count(*) FROM sqlite_master WHERE type='table' AND name='Item';", new string[] { }).Result;
            if (result == 0)
            {
                database.CreateTableAsync<Item>().Wait();
                List<Item> mockItems = new List<Item>
                {
                    new Item { Id = 1, Text = "Ashina Reservoir", Description="Ashina Reservoir is a Location in Sekiro: Shadows Die Twice. This is the very start of the game after the prologue, and acts as a tutorial for the basic mechanics of the game.", Status = false },
                    new Item { Id = 2, Text = "Dilapidated Temple", Description="This is an item description.", Status = false },
                    new Item { Id = 3, Text = "Ashina Outskirts", Description="This is an item description.", Status = false },
                    new Item { Id = 4, Text = "Hirata Estate", Description="This is an item description.", Status = false },
                    new Item { Id = 5, Text = "Ashina Outskirts pt. 2", Description="This is an item description.", Status = false },
                    new Item { Id = 6, Text = "Hirata State pt. 2", Description="This is an item description.", Status = false },
                    new Item { Id = 7, Text = "Ashina Castle", Description="This is an item description.", Status = false },
                    new Item { Id = 8, Text = "Ashina Reservoir (Revisited)", Description="This is an item description.", Status = false },
                    new Item { Id = 9, Text = "Ashina Castle pt. 2", Description="This is an item description.", Status = false },
                    new Item { Id = 10, Text = "Abandoned Dungeon", Description="This is an item description.", Status = false },
                    new Item { Id = 11, Text = "Senpou Temple, Mt. Kongo", Description="This is an item description.", Status = false },
                    new Item { Id = 12, Text = "Ashina Castle pt. 3", Description="This is an item description.", Status = false },
                    new Item { Id = 13, Text = "Sunken Valley", Description="This is an item description.", Status = false },
                    new Item { Id = 14, Text = "Sunken Valley Passage", Description="This is an item description.", Status = false },
                    new Item { Id = 15, Text = "Ashina Depths", Description="This is an item description.", Status = false },
                    new Item { Id = 16, Text = "Mibu Village", Description="This is an item description.", Status = false },
                    new Item { Id = 17, Text = "Ashina Castle Final Part", Description="This is an item description.", Status = false },
                    new Item { Id = 18, Text = "Fountainhead Palace", Description="This is an item description.", Status = false }
                };

                foreach (Item item in mockItems)
                {
                    database.InsertAsync(item).Wait();
                }

                List<Step> steps = new List<Step>() {
                    new Step() { 
                        Title = "Get to the Moon-view Tower", 
                        HowTo = "This is the game's prologue and it acts as a tutorial for players to learn the basic game controls. Stealth your way to Moon-view tower, and obtain key items and heal yourself before setting off and facing your first battles and encounter your first Mini-Boss", 
                        Status = false,
                        ItemId = 1,
                    },
                    new Step() { Title = "Acquire Kusabimaru and Healing Gourd", HowTo = "", Status = false, ItemId = 1 },
                    new Step() { Title = "Face Genichiro Ashina", HowTo = "", Status = false, ItemId = 1 }
                };
                database.CreateTableAsync<Step>().Wait();

                foreach (Step step in steps)
                {
                    database.InsertAsync(step).Wait();
                }
            }
        }

        public Task<List<Item>> GetItemsAsync()
        {
            return database.Table<Item>().ToListAsync();
        }

        public Task<List<Item>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Item>("SELECT * FROM [Item]");
        }

        public Task<List<Step>> GetStepsFromItem(Item it)
        {
            return database.QueryAsync<Step>("SELECT * FROM [Step] where ItemId = " + it.Id);
        }

        public Task<Item> GetItemAsync(int id)
        {
            return database.Table<Item>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public List<Item> SaveItemAsync(Item item)
        {
            int status = item.Status ? 1 : 0;
            return database.QueryAsync<Item>("UPDATE [Item] SET Status = " + status + " WHERE Id = " + item.Id).Result;

        }

        public List<Step> SaveStep(Step step)
        {
            int status = step.Status ? 1 : 0;
            return database.QueryAsync<Step>("UPDATE [Step] SET Status = " + status + " WHERE Title = '" + step.Title + "' AND ItemId = " + step.ItemId).Result;
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            return database.DeleteAsync(item);
        }
    }
}
