using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingDevelopers.Models
{
    public class FullAccountingModel
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
