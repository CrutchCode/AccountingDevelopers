using DevelopersAccountingDatabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingDevelopersCore.DTO.Models
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreate { get; set; }
    }
}
