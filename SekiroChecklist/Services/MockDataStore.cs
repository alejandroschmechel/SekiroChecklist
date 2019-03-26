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
            var mockItems = new List<Item>
            {
                new Item {
                    Id = 1,
                    Text = "Ashina Reservoir",
                    Description="Ashina Reservoir is a Location in Sekiro: Shadows Die Twice. This is the very start of the game after the prologue, and acts as a tutorial for the basic mechanics of the game.",
                    Steps = new List<Step>()
                    {
                        new Step() { 
                            Title = "Get to the Moon-view Tower", 
                            HowTo = "This is the game's prologue and it acts as a tutorial for players to learn the basic game controls. Stealth your way to Moon-view tower, and obtain key items and heal yourself before setting off and facing your first battles and encounter your first Mini-Boss", 
                            Status = false 
                        },
                        new Step() { Title = "Acquire Kusabimaru and Healing Gourd", HowTo = "", Status = false },
                        new Step() { Title = "Face Genichiro Ashina", HowTo = "", Status = false },
                    }
                },
                new Item { Id = 2, Text = "Dilapidated Temple", Description="This is an item description.", Steps = new List<Step>() },
                new Item { Id = 3, Text = "Ashina Outskirts", Description="This is an item description.", Steps = new List<Step>() },
                new Item { Id = 4, Text = "Hirata Estate", Description="This is an item description.", Steps = new List<Step>() },
                new Item { Id = 5, Text = "Ashina Outskirts pt. 2", Description="This is an item description.", Steps = new List<Step>() },
                new Item { Id = 6, Text = "Hirata State pt. 2", Description="This is an item description.", Steps = new List<Step>() },
                new Item { Id = 7, Text = "Ashina Castle", Description="This is an item description.", Steps = new List<Step>() },
                new Item { Id = 8, Text = "Ashina Reservoir (Revisited)", Description="This is an item description.", Steps = new List<Step>()},
                new Item { Id = 9, Text = "Ashina Castle pt. 2", Description="This is an item description.", Steps = new List<Step>() },
                new Item { Id = 10, Text = "Abandoned Dungeon", Description="This is an item description.", Steps = new List<Step>() },
                new Item { Id = 11, Text = "Senpou Temple, Mt. Kongo", Description="This is an item description.", Steps = new List<Step>() },
                new Item { Id = 12, Text = "Ashina Castle pt. 3", Description="This is an item description.", Steps = new List<Step>() },
                new Item { Id = 13, Text = "Sunken Valley", Description="This is an item description.", Steps = new List<Step>() },
                new Item { Id = 14, Text = "Sunken Valley Passage", Description="This is an item description.", Steps = new List<Step>() },
                new Item { Id = 15, Text = "Ashina Depths", Description="This is an item description.", Steps = new List<Step>() },
                new Item { Id = 16, Text = "Mibu Village", Description="This is an item description.", Steps = new List<Step>() },
                new Item { Id = 17, Text = "Ashina Castle Final Part", Description="This is an item description.", Steps = new List<Step>() },
                new Item { Id = 18, Text = "Fountainhead Palace", Description="This is an item description.", Steps = new List<Step>() },
            };

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