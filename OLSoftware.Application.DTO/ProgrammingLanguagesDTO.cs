using System;
using System.Collections.Generic;
using System.Text;

namespace OLSoftware.Application.DTO
{
    public class ProgrammingLanguagesDTO
    {
        public int Id { get; set; }
        public string ProgrammingLanguage { get; set; }
        public string Level { get; set; }
        public DateTime Date { get; set; }

        public List<ProgrammingLanguagesbyProjectDTO> ProgrammingLanguagesbyProjects { get; set; }
    }

}
