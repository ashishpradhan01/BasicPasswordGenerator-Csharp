using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordGenerator.Models
{
    public class PasswordModel
    {
        public int passwordLength { get; set; }
        public bool includeSymbols { get; set; }
        public bool includeNumbers { get; set; }
        public bool includeLowercase { get; set; }
        public bool includeUppercase { get; set; }
        public string specialWord { get; set; }
    }
}
