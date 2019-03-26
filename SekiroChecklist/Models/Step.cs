using System;
namespace SekiroChecklist.Models
{
    public class Step
    {
        public string Title { get; set; }
        public string HowTo { get; set; }
        public bool Status { get; set; }
        public int ItemId { get; set; }
    }
}
