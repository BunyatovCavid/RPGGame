using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Interfaces
{
    internal interface ISelectingService
    {
        Task<int?> Choose(params string[] options);
    }
}
