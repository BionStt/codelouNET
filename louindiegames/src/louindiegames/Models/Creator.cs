using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace louindiegames.Models
{
    public class Creator
    {
        [ScaffoldColumn(false)]
        public int CreatorID { get; set; }

        [Required]
        [Display(Name = "Creator's Name")]
        public string CreatorName { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
