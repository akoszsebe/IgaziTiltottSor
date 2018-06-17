using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models
{
    public class User
    {
        public string useremail { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public string cardnumber { get; set; }

        public string cardexpiration { get; set; }

        public string cvv { get; set; }

    }
}
