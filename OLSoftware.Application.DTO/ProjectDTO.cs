using System;
using System.Collections.Generic;
using System.Text;

namespace OLSoftware.Application.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }        
        public string ProjectName { get; set; }        
        public int CustomerId { get; set; }        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public int NumberHours { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public List<InfoProjectDTO> InfoProjects { get; set; }
    }
}
