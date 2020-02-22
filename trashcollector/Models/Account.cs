using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace trashcollector.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public double Balance { get; set; }
        [Display(Name = "Pick Up Day")]
        public DayOfWeek PickupDay { get; set; }
        [Display(Name = "One-Time Pick Up")]
        [DataType(DataType.Date)]
        public DateTime? OneTimePickup { get; set; }
        [Display(Name = "Is Account Suspended?")]
        public bool IsSuspended { get; set; }
        [Display(Name = "Start of Suspension")]
        [DataType(DataType.Date)]
        public DateTime? StartSuspension { get; set; }
        [Display(Name = "End of Suspension")]
        [DataType(DataType.Date)]
        public DateTime? EndSuspension { get; set; }
        [Display(Name = "Last Pick Up Date")]
        [DataType(DataType.Date)]
        public DateTime LastPickupDate { get; set; }
        //[NotMapped]
        //public SelectList WorkDays
        //{
        //    get
        //    {
        //        return new SelectList(new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday });
        //    }
        //}

    }
}
