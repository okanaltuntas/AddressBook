using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.API.Model
{
    public class NumbersOfAtLocation : BaseEntity
    {
        public string LocationName { get; set; }
        public int PhoneNumberCount { get; set; }
        public int ContactCount { get; set; }
    }
}
