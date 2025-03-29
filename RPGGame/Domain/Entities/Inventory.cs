using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Domain.Entities
{
    internal class Inventory
    {
        public int ID { get; set; }
        public string CardName { get; set; }
        public int Status { get; set; }
        public Card Card { get; set; }
    }
}
