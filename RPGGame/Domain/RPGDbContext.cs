using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RPGGame.Domain
{
    internal class RPGDbContext:DbContext
    {
        public RPGDbContext()
        {
            
        }

        public RPGDbContext(DbContextOptions<RPGDbContext> options):base(options) 
        {
            
        }

    }
}
