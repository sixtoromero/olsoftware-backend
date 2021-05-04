using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OLSoftware.Domain.Entity
{
    public class LanguagesByProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ProgrammingLanguagesId { get; set; }
        [Required]
        public int ProjectId { get; set; }

    }
}
