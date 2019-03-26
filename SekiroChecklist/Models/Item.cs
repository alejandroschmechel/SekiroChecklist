using System;
using System.Collections.Generic;

namespace SekiroChecklist.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public List<Step> Steps { get; set; }
    }
}