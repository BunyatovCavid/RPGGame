using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Domain.Entities
{
    internal class Card
    {
        [Key]
        public string Name { get; set; }
        public int CardType { get; set; }
        public string Description { get; set; }

        public CardType CardTypeID { get; set; }

    }
}
