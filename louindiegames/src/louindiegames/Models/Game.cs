using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace louindiegames.Models
{
    public class Game
    {
        [ScaffoldColumn(false)]
        public int GameID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Screenshot { get; set; }

        // How to get/set an image?

        [ScaffoldColumn(false)]
        public int CreatorID { get; set; }

        //Navigation Property
        public virtual Creator Creator { get; set; }
    }
}
