using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Tejedor.Infrastructure.Entity
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public required string UserName { get; set; }
        public required string UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public string? Phone { get; set; }
        public string? ProfileImageRoute { get; set; }
        public int? ACoins { get; set; }
        public string? Address { get; set; }
        public string? BillingAddress { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
