using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Domain.Entities
{
    internal class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int RaceID { get; set; }
        public int ClassID { get; set; }
        public string Level { get; set; }

        public Race Race { get; set; }
        public Class Class { get; set; }
    }
}
