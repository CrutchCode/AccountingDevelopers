using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DevelopersAccountingDatabase.Models
{
    public class Developer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public ICollection<Project> Projects { get; set; }
        public Developer()
        {
            Projects = new List<Project>();
        }
    }
}
