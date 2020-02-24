using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trashcollector.Models
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public Address Address { get; set; }
        public Account Account { get; set; }
        public Customer Customer { get; set; }
        public List<Customer> Customers { get; set; }
        public DayOfWeek? Day { get; set; }
    }
}
