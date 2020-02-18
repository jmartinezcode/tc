﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace trashcollector.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public double Balance { get; set; }
        [Display(Name = "Pick-Up Day")]
        public DayOfWeek PickupDay { get; set; }
        [Display(Name = "One-Time Pick Up")]
        public DateTime OneTimePickup { get; set; }
        [Display(Name = "Is Account Suspended?")]
        public bool IsSuspended { get; set; }
        [Display(Name = "Start of Suspension")]
        public DateTime StartSuspension { get; set; }
        [Display(Name = "End of Suspension")]
        public DateTime EndSuspension { get; set; }

    }
}