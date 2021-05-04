using System;
using System.Collections.Generic;
using System.Text;

namespace OLSoftware.Application.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
    }
}
