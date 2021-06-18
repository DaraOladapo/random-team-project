using System;

namespace FrontEnd.Models
{
    public class Team
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string TeamName { get; set; }
        public int LuckyNumber { get; set; }
    }
}