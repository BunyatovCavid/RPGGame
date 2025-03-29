using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Domain.Entities
{
    internal class User
    {
        public string Name { get; set; }
        public int Race { get; set; }
        public int Class { get; set; }
        public string Level { get; set; }

        public Race RaceID { get; set; }
        public Class ClassID { get; set; }
    }
}
