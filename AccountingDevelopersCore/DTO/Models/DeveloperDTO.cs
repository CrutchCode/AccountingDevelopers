using DevelopersAccountingDatabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingDevelopersCore.DTO.Models
{
    public class DeveloperDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
    }
}
