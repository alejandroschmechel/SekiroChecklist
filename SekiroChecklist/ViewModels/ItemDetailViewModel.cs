using System;

using SekiroChecklist.Models;

namespace SekiroChecklist.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            item.Steps = App.Database.GetStepsFromItem(item).Result;
            Item = item;
        }
    }
}
