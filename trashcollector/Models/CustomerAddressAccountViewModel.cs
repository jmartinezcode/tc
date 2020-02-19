using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trashcollector.Models
{
    public class CustomerAddressAccountViewModel
    {
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public Account Account { get; set; }
    }
}
