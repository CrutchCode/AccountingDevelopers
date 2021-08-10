using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingDevelopersCore.DTO.Models
{
    public class FullDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreate { get; set; }
        public int? DeveloperId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
    }
}
