using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Domain.Entities
{
    internal class CardType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Card Card { get; set; }
    }
}
