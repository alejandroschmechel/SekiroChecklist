using System;
using System.Collections.Generic;
using SQLite;

namespace SekiroChecklist.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        [Ignore]
        public List<Step> Steps { get; set; }
    }
}