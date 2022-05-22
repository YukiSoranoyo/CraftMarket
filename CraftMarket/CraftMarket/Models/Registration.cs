using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace CraftMarket.Models
{
    public class Registration
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
