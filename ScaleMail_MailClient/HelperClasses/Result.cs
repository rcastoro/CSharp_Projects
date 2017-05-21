using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClasses
{
    public class Result
    {
        public bool Success { get; set; }
        public bool Fail { get; set; }
        public bool AlreadyExists { get; set; }
        public bool New { get; set; }
    }
}
