using System;
using System.Collections.Generic;
using System.Text;

namespace OLSoftware.Domain.Entity
{
    public class ProgrammingLanguages
    {
        public int Id { get; set; }
        public string ProgrammingLanguage { get; set; }
        public string Level { get; set; }
        public DateTime Date { get; set; }        

    }
}
