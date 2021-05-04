using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OLSoftware.Domain.Entity
{
    public class Customer
    {        
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Names { get; set; }
        [Required]
        [MaxLength(120)]
        public string Surnames { get; set; }
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
        [Required]
        [MaxLength(150)]
        public string Address { get; set; }
        [MaxLength(25)]
        public string Phone { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public List<Project> Projects { get; set; }

    }
}
