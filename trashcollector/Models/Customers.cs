using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace trashcollector.Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Lat Name")]
        public string LastName { get; set; }
        [ForeignKey("Address")]
        [Display(Name = "Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        [ForeignKey("Account")]
        [Display(Name = "Account Info")]
        public int AccountId { get; set; }
        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }


    }
}
