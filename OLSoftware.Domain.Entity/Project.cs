using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OLSoftware.Domain.Entity
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string ProjectName { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int NumberHours { get; set; }
        /// <summary>
        /// N = En Negociación, P = En Proceso, T = Terminado, A = Anulado
        /// </summary>
        [Required]
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        public DateTime Date { get; set; }        

        [NotMapped]
        public List<InfoProject> InfoProjects { get; set; }

    }
}
