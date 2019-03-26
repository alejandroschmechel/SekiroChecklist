using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SekiroChecklist.Models;

namespace SekiroChecklist.Services
{
    public class MockDataStore
    {
        static List<Item> Items { get; set; }

        public MockDataStore()
        {
            Items = new List<Item>();
            List<Item> mockItems = App.Database.GetItemsAsync().Result;
            foreach (var item in mockItems)
            {
                Items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public static async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = Items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            Items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }
    }
}