using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PasswordGenerator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        public IActionResult NewPassword(int passwordLength, string includeSymbols, string includeNumbers, string includeLowercase, string includeUppercase, string specialWord)
        {

            List<char> symbol = new List<char> { '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')','_',
                '-', '=', '+', '{', '}', '[', ']', ':', ';', ',', '.', '<', '>', '?', '/' };

            List<char> number = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

            List<char> lowerAlpha = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
                'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            List<char> upperAlpha = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            List<List<char>> allCharacter = new List<List<char>> {  };

            if (includeSymbols == "on") allCharacter.Add(symbol);
            if (includeNumbers == "on") allCharacter.Add(number);
            if (includeUppercase == "on") allCharacter.Add(upperAlpha);
            if (includeLowercase == "on") allCharacter.Add(lowerAlpha);

            Random random = new Random();

            String newPassword = "";

            if(specialWord != null)
            {
                passwordLength = passwordLength - specialWord.Length;
            }

            if(allCharacter.Count > 0)
            {
                for (int i = 1; i <= passwordLength; i++)
                {
                    int randIndex1 = random.Next(allCharacter.Count);

                    int randIndex2 = random.Next(allCharacter[randIndex1].Count);

                    newPassword += allCharacter[randIndex1][randIndex2];
                }
            }

            newPassword = newPassword + specialWord;

            ViewBag.NewPassword = newPassword;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
