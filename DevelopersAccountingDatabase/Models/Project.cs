using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DevelopersAccountingDatabase.Models
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DateOfCreate { get; set; }

        public ICollection<Developer> Developers { get; set; }
        public Project()
        {
            Developers = new List<Developer>();
        }
    }
}
