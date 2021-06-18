using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamAssignment.Models
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID{ get; set; }
        public string Name { get; set; }
        public string TeamName{ get; set; }
        public int LuckyNumber{ get; set; }
    }
}