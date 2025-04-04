using Microsoft.Extensions.Logging;
using RPGGame.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame.Services
{
    internal class SelectingService : ISelectingService
    {
        private readonly ILogger<SelectingService> _logger;

        public SelectingService(ILogger<SelectingService> logger)
        {
            _logger = logger;
        }

        public Task<int?> Choose(params string[] options)
        {
            try
            {
                int index = 0;
                string prefix = "►";
                ConsoleKeyInfo keyinfo;
                do
                {
                    Console.Clear();
                    for (int i = 0; i < options.Length; i++)
                    {
                        if (index == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine(prefix + $"{i + 1}. "
                            + options[i]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine($"{i + 1}. " + options[i]);
                        }
                    }
                    keyinfo = Console.ReadKey(true);
                    if (keyinfo.Key == ConsoleKey.UpArrow)
                    {
                        if (index == 0) index = options.Length - 1;
                        else index--;
                    }
                    else if (keyinfo.Key == ConsoleKey.DownArrow)
                    {
                        if (index == options.Length - 1) index = 0;
                        else index++;
                    }
                    Console.ResetColor();
                }
                while (keyinfo.Key != ConsoleKey.Enter);
                Console.Clear();
                return Task.FromResult<int?>(index);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Seçim əməliyyatı zamanı xəta baş verdi.");
                return null;
            }
        }
    }
}
