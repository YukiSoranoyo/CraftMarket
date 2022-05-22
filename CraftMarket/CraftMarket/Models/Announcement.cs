using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace CraftMarket.Models
{
    public class Announcement
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Price { get; set; }
        public string ImageName { get; set; }
    }
}
